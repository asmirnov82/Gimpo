using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml.Linq;
using CommunityToolkit.Diagnostics;

namespace Gimpo.Data.Primitives
{
    public sealed class NativeMemoryNullableVector<T> : IEnumerable<T?>, ICloneable, IDisposable
        where T : unmanaged
    {
        private readonly NativeMemoryBuffer _valueBuffer;
        private readonly Bitmap _validityBitmap;
        private long _length;

        public long Length => _length;
        public long Capacity { get; private set; }

        public long NullCount => _validityBitmap.NullCount;

        private NativeMemoryNullableVector(NativeMemoryBuffer valueBuffer, Bitmap validityBitmap, long length)
        {
            Debug.Assert(length >= 0);

            _length = length;
            _valueBuffer = valueBuffer;
            _validityBitmap = validityBitmap;

            Capacity = length;
        }

        #region Internal Methods (Allow to access value buffer and bitmap directly to increase performance)
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal unsafe Vector<T> LoadVector(long index)
        {
            Debug.Assert(Length >= Vector<T>.Count);
            Debug.Assert(index <= Length - Vector<T>.Count);

            return _valueBuffer.LoadVector<T>(index);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal unsafe void WriteVector(long index, Vector<T> vector)
        {
            Debug.Assert(Length >= Vector<T>.Count);
            Debug.Assert(index <= Length - Vector<T>.Count);

            _valueBuffer.WriteVector(index, vector);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal Bitmap GetValidityBitmap() => _validityBitmap;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal ref T RawValue(long index)
        {
            Debug.Assert((ulong)index < (ulong)_length);

            return ref _valueBuffer.GetValueByRef<T>(index);
        }
        #endregion

        #region Contructors
        internal NativeMemoryNullableVector(long length, int alignment, bool skipZeroClear)
        {
            Guard.IsGreaterThanOrEqualTo(length, 0, nameof(length));

            _length = length;

            _valueBuffer = (alignment == 0) ?
                new NativeMemoryBuffer(length * Unsafe.SizeOf<T>(), skipZeroClear) : new NativeMemoryBufferAligned(length * Unsafe.SizeOf<T>(), alignment, skipZeroClear);

            _validityBitmap = new Bitmap(length);

            Capacity = length;
        }

        public NativeMemoryNullableVector(long length = 0, bool skipZeroClear = false) : this(length, 0, skipZeroClear)
        { }

        internal NativeMemoryNullableVector(IEnumerable<T?> values, int alignment)
        {
            Guard.IsNotNull(values);

            if (values is IReadOnlyCollection<T?> collection)
            {
                _length = collection.Count;

                _valueBuffer = (alignment == 0) ?
                    new NativeMemoryBuffer(_length * Unsafe.SizeOf<T>(), true) : new NativeMemoryBufferAligned(_length * Unsafe.SizeOf<T>(), alignment, true);

                _validityBitmap = new Bitmap(_length);

                Capacity = _length;

                int i = 0;
                foreach (var value in collection)
                {
                    this[i++] = value;
                }
            }
            else
            {
                _length = 0;

                _valueBuffer = alignment == 0 ?
                    new NativeMemoryBuffer(0) : new NativeMemoryBufferAligned(0, alignment);

                _validityBitmap = new Bitmap(0);

                Capacity = 0;

                foreach (var value in values)
                    Add(value);
            }
        }

        public NativeMemoryNullableVector(IEnumerable<T?> values) : this(values, 0)
        { }

        internal NativeMemoryNullableVector(IEnumerable<T> values, int alignment)
        {
            Guard.IsNotNull(values);

            if (values is IReadOnlyCollection<T> collection)
            {
                _length = collection.Count;

                _valueBuffer = (alignment == 0) ?
                    new NativeMemoryBuffer(_length * Unsafe.SizeOf<T>(), true) : new NativeMemoryBufferAligned(_length * Unsafe.SizeOf<T>(), alignment, true);

                _validityBitmap = new Bitmap(_length, true);

                Capacity = _length;

                int i = 0;
                foreach (var value in collection)
                {
                    _valueBuffer.GetValueByRef<T>(i++) = value;
                }
            }
            else
            {
                _length = 0;

                _valueBuffer = (alignment == 0) ?
                    new NativeMemoryBuffer(0) : new NativeMemoryBufferAligned(0, alignment, true);

                _validityBitmap = new Bitmap(0);

                Capacity = 0;

                foreach (var value in values)
                    Add(value);
            }
        }

        public NativeMemoryNullableVector(IEnumerable<T> values) : this(values, 0)
        { }
        #endregion

        #region Indexing
        public T? this[long index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if ((ulong)index >= (ulong)_length)
                    ThrowHelper.ThrowArgumentOutOfRangeException();

                return _validityBitmap.GetBit(index) ? (T?) _valueBuffer.GetValueByRef<T>(index) : null;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if ((uint)index >= (uint)_length)
                    ThrowHelper.ThrowArgumentOutOfRangeException(nameof(index));

                if (value.HasValue)
                {
                    _valueBuffer.GetValueByRef<T>(index) = value.Value;
                    _validityBitmap.SetBit(index);
                }
                else
                {
                    _validityBitmap.ClearBit(index);
                }
            }
        }

        public bool HasValue(long index)
        {
            if ((ulong)index >= (ulong)_length)
                ThrowHelper.ThrowArgumentOutOfRangeException();

            return _validityBitmap.GetBit(index);
        }
        #endregion

        #region Adding new elements
        public void Add(T? value)
        {
            var i = _length;
            Resize(_length + 1);
            this[i] = value;
        }

        public void AddMany(T? value, long count)
        {          
            var i = _length;
            _valueBuffer.EnsureCapacity<T>(Length + count);
            _length += count;

            if (value.HasValue)
            {
                while (i < _length)
                    _valueBuffer.GetValueByRef<T>(i++) = value.Value;

                _validityBitmap.AppendBits(true, count);
            }
        }

        public void AddRange(IEnumerable<T?> values)
        {
            if (values is IReadOnlyCollection<T?> collection)
            {
                var i = _length;
                Resize(_length + collection.Count);

                foreach (var value in collection)
                    this[i++] = value;
            }
            else
            {
                foreach (var value in values)
                    Add(value);
            }    
        }

        public void AddRange(IEnumerable<T> values)
        {
            if (values is IReadOnlyCollection<T> collection)
            {
                var i = _length;
                int count = collection.Count;
                _valueBuffer.EnsureCapacity<T>(_length + count);
                _length += count;
                
                foreach (var value in collection)
                {
                    _valueBuffer.GetValueByRef<T>(i++) = value;
                }

                _validityBitmap.AppendBits(true, count);

                Capacity = _length;
            }
            else
            {
                long count = 0;
                foreach (var value in values)
                {
                    var i = _length;
                    _length++;
                    _valueBuffer.EnsureCapacity<T>(_length);
                    _valueBuffer.GetValueByRef<T>(i) = value;
                    count++;
                }

                _validityBitmap.AppendBits(true, count);

                Capacity = _length;
            }
        }
        #endregion

        #region Resizing
        public void Resize(long length)
        {
            Guard.IsGreaterThanOrEqualTo(length, 0, nameof(length));

            _validityBitmap.Resize(length);
            _valueBuffer.EnsureCapacity<T>(length);
            _length = length;

            Capacity = length;
        }

        public void EnsureCapacity(long capacity)
        {
            _validityBitmap.EnsureCapacity(capacity);
            _valueBuffer.EnsureCapacity<T>(capacity);

            Capacity = capacity;
        }
        #endregion

        #region Enumeration
        public IEnumerator<T?> GetEnumerator()
        {
            for (long i = 0; i < Length; i++)
                yield return this[i];
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        #endregion

        #region Clone
        public NativeMemoryNullableVector<T> Clone()
        {
            return new NativeMemoryNullableVector<T>(_valueBuffer.Clone(), _validityBitmap.Clone(), Length);
        }

        public NativeMemoryNullableVector<T> Clone(IEnumerable<long> indicesMap)
        {
            Guard.IsNotNull(indicesMap);

            var newVector = new NativeMemoryNullableVector<T>();

            if (indicesMap is NativeMemoryVector<long> indicesVector)
            {
                newVector = new NativeMemoryNullableVector<T>(indicesVector.Length);

                for (long i = 0; i < indicesVector.Length; i++)
                {
                    newVector[i] = this[indicesVector[i]];
                }

                return newVector;
            }

            foreach (long index in indicesMap)
            {
                if (index > Length)
                    throw new ArgumentOutOfRangeException(nameof(indicesMap));

                newVector.Add(this[index]);
            }

            return newVector;
        }

        public NativeMemoryNullableVector<T> Clone(IEnumerable<long?> indicesMap)
        {
            Guard.IsNotNull(indicesMap);

            NativeMemoryNullableVector<T> newVector;

            if (indicesMap is NativeMemoryNullableVector<long> indicesVector)
            {
                newVector = new NativeMemoryNullableVector<T>(indicesVector.Length);

                for (long i = 0; i < indicesVector.Length; i++)
                {
                    newVector[i] = indicesVector[i].HasValue ? this[indicesVector[i].Value] : null;
                }

                return newVector;
            }

            newVector = new NativeMemoryNullableVector<T>();

            foreach (long? index in indicesMap)
            {
                if (index > Length)
                    throw new ArgumentOutOfRangeException(nameof(indicesMap));

                newVector.Add(index.HasValue ? this[index.Value] : null);
            }

            return newVector;
        }

        object ICloneable.Clone() => Clone();
        #endregion

        #region Disposing
        public void Dispose()
        {
            _validityBitmap.Dispose();
            _valueBuffer.Dispose();
        }
        #endregion
    }
}

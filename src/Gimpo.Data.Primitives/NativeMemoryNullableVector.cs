using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
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

        #region Contructors
        public NativeMemoryNullableVector(long length = 0, bool skipZeroClear = false)
        {
            Guard.IsGreaterThanOrEqualTo(length, 0, nameof(length));

            _length = length;
            _valueBuffer = new NativeMemoryBuffer(length * Unsafe.SizeOf<T>(), skipZeroClear);
            _validityBitmap = new Bitmap(length);

            Capacity = length;
        }

        public NativeMemoryNullableVector(IEnumerable<T?> values) 
        {
            Guard.IsNotNull(values);

            if (values is IReadOnlyCollection<T?> collection)
            {
                _length = collection.Count;
                _valueBuffer = new NativeMemoryBuffer(_length * Unsafe.SizeOf<T>(), true);
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
                _valueBuffer = new NativeMemoryBuffer(0);
                _validityBitmap = new Bitmap(0);

                Capacity = 0;
                                
                foreach (var value in values)
                    Add(value);
            }
        }

        public NativeMemoryNullableVector(IEnumerable<T> values)
        {
            Guard.IsNotNull(values);

            if (values is IReadOnlyCollection<T> collection)
            {
                _length = collection.Count;
                _valueBuffer = new NativeMemoryBuffer(_length * Unsafe.SizeOf<T>(), true);
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
                _valueBuffer = new NativeMemoryBuffer(0 * Unsafe.SizeOf<T>());
                _validityBitmap = new Bitmap(0);

                Capacity = 0;

                foreach (var value in values)
                    Add(value);
            }
        }
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

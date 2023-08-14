using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using CommunityToolkit.Diagnostics;

namespace Gimpo.Data.Primitives
{
    public sealed class NativeMemoryVector<T> : IEnumerable<T>, ICloneable, IDisposable
        where T : unmanaged
    {
        private readonly NativeMemoryBuffer _valueBuffer;

        private long _length;

        public long Length => _length;
        public long Capacity { get; private set; }

        private NativeMemoryVector(NativeMemoryBuffer valueBuffer, long length)
        {
            Debug.Assert(length >= 0);

            _length = length;
            Capacity = length;

            _valueBuffer = valueBuffer;
        }

        #region Constructors
        public NativeMemoryVector(long length = 0, int alignment = 0, bool skipZeroClear = false)
        {
            Guard.IsGreaterThanOrEqualTo(length, 0, nameof(length));
            Guard.IsGreaterThanOrEqualTo(alignment, 0, nameof(alignment));

            _length = length;
            Capacity = _length;
                        
            _valueBuffer = (alignment == 0) ?
                new NativeMemoryBuffer(_length * Unsafe.SizeOf<T>(), skipZeroClear) : new NativeMemoryBufferAligned(_length * Unsafe.SizeOf<T>(), alignment, skipZeroClear);
        }

        public NativeMemoryVector(IEnumerable<T> values, int alignment = 0) 
        {
            Guard.IsNotNull(values, nameof(values));
            Guard.IsGreaterThanOrEqualTo(alignment, 0, nameof(alignment));

            if (values is IReadOnlyCollection<T?> collection)
            {
                _length = collection.Count;
                Capacity = _length;

                _valueBuffer = alignment == 0 ?
                    new NativeMemoryBuffer(_length * Unsafe.SizeOf<T>()) : new NativeMemoryBufferAligned(_length * Unsafe.SizeOf<T>(), alignment);

                int i = 0;
                foreach (var value in values)
                    _valueBuffer.GetValueByRef<T>(i++) = value;
            }
            else
            {
                _length = 0;
                Capacity = 0;

                _valueBuffer = alignment == 0 ?
                    new NativeMemoryBuffer(0) : new NativeMemoryBufferAligned(0, alignment);

                foreach (var value in values)
                    Add(value);
            }
        }
        #endregion

        #region Indexing
        public ref T this[long index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                Guard.IsLessThan((ulong)index, (ulong)Length);
                return ref _valueBuffer.GetValueByRef<T>(index);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe Vector<T> GetVector(long index)
        {
            Guard.IsGreaterThanOrEqualTo(Length, Vector<T>.Count);
            Guard.IsLessThanOrEqualTo(index, Length - Vector<T>.Count);

            return _valueBuffer.GetVector<T>(index);
        }
        #endregion

        #region Adding elements
        public void Add(T value)
        {
            if (Length == Capacity)
            {
                EnsureCapacity(Length + 1);
            }
            this[_length++] = value;
        }

        public void AddMany(T value, long count)
        {
            EnsureCapacity(Length + count);

            var i = Length;
            _length += count;

            while (i < _length)
                this[i++] = value;
        }

        public void AddRange(IEnumerable<T> values)
        {
            if (values is IReadOnlyCollection<T> collection)
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
        #endregion

        #region Resizing
        public void Resize(long length)
        {
            Debug.Assert(length >= 0);

            _valueBuffer.EnsureCapacity<T>(length);

            Capacity = length;
            _length = length;
        }

        public void EnsureCapacity(long capacity)
        {
            if (capacity <= Capacity)
                return;

            _valueBuffer.EnsureCapacity<T>(capacity);

            Capacity = capacity;
        }
        #endregion

        #region Enumeration
        public IEnumerator<T> GetEnumerator()
        {
            for (var i = 0; i < _length; i++)
                yield return this[i];
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        #endregion

        #region Clone
        public NativeMemoryVector<T> Clone()
        {            
            return new NativeMemoryVector<T>(_valueBuffer.Clone(), Length);
        }
                
        public NativeMemoryVector<T> Clone(IEnumerable<long> indicesMap)
        {
            Guard.IsNotNull(indicesMap);

            NativeMemoryVector<T> newVector;
            if (indicesMap is NativeMemoryVector<long> indicesVector)
            {
                newVector = new NativeMemoryVector<T>(indicesVector.Length);

                for (long i = 0; i < indicesVector.Length; i++)
                {
                    newVector[i] = this[indicesVector[i]];
                }

                return newVector;
            }

            newVector = new NativeMemoryVector<T>();
            foreach (long index in indicesMap)
            {
                if (index > Length)
                    throw new ArgumentOutOfRangeException(nameof(indicesMap));

                newVector.Add(this[index]);
            }

            return newVector;
        }
               
        object ICloneable.Clone() => Clone();
        #endregion

        #region Disposing
        public void Dispose()
        {
            _valueBuffer.Dispose();
        }
        #endregion

        /*
        private long CalculateNewCapacity(long delta)
        {
            var newLenght = Length + delta;

            //Allocate additional capacity to reduce the amount of time, when memory reallocation is required
            if (newLenght <= Capacity)
                return Capacity;

            return Math.Max(newLenght, Length * 2);
        }
        */
    }
}

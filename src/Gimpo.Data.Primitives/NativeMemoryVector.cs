using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
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
        public NativeMemoryVector(long length = 0, bool skipZeroClear = false)
        {
            Guard.IsGreaterThanOrEqualTo(length, 0, nameof(length));

            _length = length;
            Capacity = _length;
                        
            _valueBuffer = new NativeMemoryBuffer(_length * Unsafe.SizeOf<T>());
        }

        public NativeMemoryVector(IEnumerable<T> values) 
        {
            Guard.IsNotNull(values, nameof(values));

            if (values is IReadOnlyCollection<T?> collection)
            {
                _length = collection.Count;
                Capacity = _length;

                _valueBuffer = new NativeMemoryBuffer(_length * Unsafe.SizeOf<T>());

                int i = 0;
                foreach (var value in values)
                    _valueBuffer.GetValueByRef<T>(i++) = value;
            }
            else
            {
                _length = 0;
                Capacity = 0;

                _valueBuffer = new NativeMemoryBuffer(0);

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
                if ((ulong)index >= (ulong)Length)
                    ThrowHelper.ThrowArgumentOutOfRangeException(nameof(index));

                return ref _valueBuffer.GetValueByRef<T>(index);
            }
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

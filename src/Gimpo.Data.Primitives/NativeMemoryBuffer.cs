using System;
using System.Diagnostics;
using System.Numerics;
using System.Runtime.CompilerServices;
using CommunityToolkit.Diagnostics;
using Gimpo.Data.Primitives.Helpers;

namespace Gimpo.Data.Primitives
{
    public unsafe class NativeMemoryBuffer : ICloneable, IDisposable
    {
        protected bool _isDisposed = false;
        protected readonly object _lock = new object();

        protected byte* _ptr;

        internal byte* Ptr { get => _ptr; }
        
        public long Size { get; protected set; }

        private NativeMemoryBuffer(NativeMemoryBuffer buffer)
        {
            Size = buffer.Size;

            if (Size == 0)
            {
                _ptr = (byte*)Unsafe.AsPointer(ref Unsafe.NullRef<byte>());
            }
            else
            {
                _ptr = NativeMemoryHelper.Allocate(Size, true);
                GC.AddMemoryPressure(Size);

                Buffer.MemoryCopy(buffer.Ptr, Ptr, Size, Size);
            }
        }
        
        public NativeMemoryBuffer(long size = 0, bool skipZeroClear = false)
        {
            Guard.IsGreaterThanOrEqualTo(size, 0);

            Size = size;

            if (size == 0)
            {
                _ptr = (byte*)Unsafe.AsPointer(ref Unsafe.NullRef<byte>());
                return;
            }

            _ptr = NativeMemoryHelper.Allocate(size, skipZeroClear);

            GC.AddMemoryPressure(size);
        }

        public virtual void Resize(long size, bool skipZeroClear = true)
        {
            Debug.Assert(size >= 0);

            lock (_lock)
            {
                if (Size == size || _isDisposed)
                    return;

                var newPtr = NativeMemoryHelper.Reallocate(Ptr, Size, size, skipZeroClear);

                var delta = size - Size;

                if (delta > 0)
                    GC.AddMemoryPressure(delta);
                else
                    GC.RemoveMemoryPressure(-delta);

                _ptr = newPtr;
                Size = size;
            }
        }

        public void EnsureCapacity<T>(long capacity)
        {
            var requiredByteCount = capacity * Unsafe.SizeOf<T>();

            if (requiredByteCount <= Size)
                return;

            Resize(requiredByteCount);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool HasCompatibleAlignment(int alignment)
        {
            return ((long)Ptr % alignment) == 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ref T GetValueByRef<T>(long index)
            where T : unmanaged
        {
            var memoryIndex = index * Unsafe.SizeOf<T>();
            return ref Unsafe.AsRef<T>(Ptr + memoryIndex);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe Vector<T> GetVector<T>(long index)
            where T : unmanaged
        {
            var memoryIndex = index * Unsafe.SizeOf<T>();
            return Unsafe.ReadUnaligned<Vector<T>>(Ptr + memoryIndex);
        }

        public virtual NativeMemoryBuffer Clone()
        {            
            return new NativeMemoryBuffer(this);
        }

        object ICloneable.Clone() => Clone();

        public void Dispose()
        {
            DisposeInternal();
            GC.SuppressFinalize(this);
        }

        ~NativeMemoryBuffer()
        {
            DisposeInternal();
        }

        protected virtual void DisposeInternal()
        {
            lock (_lock)
            {
                if (_isDisposed)
                    return;

                if (Unsafe.IsNullRef(ref Unsafe.AsRef<byte>(Ptr)))
                    return;

                NativeMemoryHelper.Free(Ptr);
                _ptr = null;

                GC.RemoveMemoryPressure(Size);

                _isDisposed = true;
            }
        }
    }
}

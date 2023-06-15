using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

using Gimpo.Data.Primitives.Helpers;

namespace Gimpo.Data.Primitives
{
    public sealed unsafe class NativeMemoryBuffer : ICloneable, IDisposable
    {
        private bool _isDisposed = false;
        private readonly object _lock = new object();

        internal byte* Ptr { get; private set; }

        public long Size { get; private set; }

        private NativeMemoryBuffer(NativeMemoryBuffer buffer)
        {
            Size = buffer.Size;

            if (Size == 0)
            {
                Ptr = (byte*)Unsafe.AsPointer(ref Unsafe.NullRef<byte>());
            }
            else
            {
                Ptr = NativeMemoryHelper.Allocate(Size, true);
                GC.AddMemoryPressure(Size);

                Buffer.MemoryCopy(buffer.Ptr, Ptr, Size, Size);
            }
        }

        public NativeMemoryBuffer(long size = 0, bool skipZeroClear = false)
        {
            Debug.Assert(size >= 0);

            Size = size;

            if (size == 0)
            {
                Ptr = (byte*)Unsafe.AsPointer(ref Unsafe.NullRef<byte>());
                return;
            }

            Ptr = NativeMemoryHelper.Allocate(size, skipZeroClear);

            GC.AddMemoryPressure(size);
        }

        public void Resize(long size, bool skipZeroClear = true)
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

                Ptr = newPtr;
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
        public ref T GetValueByRef<T>(long index)
        {
            var memoryIndex = index * Unsafe.SizeOf<T>();
            return ref Unsafe.AsRef<T>(Ptr + memoryIndex);
        }

        public NativeMemoryBuffer Clone()
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

        private void DisposeInternal()
        {
            lock (_lock)
            {
                if (_isDisposed)
                    return;

                if (Unsafe.IsNullRef(ref Unsafe.AsRef<byte>(Ptr)))
                    return;

                NativeMemoryHelper.Free(Ptr);
                Ptr = null;

                GC.RemoveMemoryPressure(Size);

                _isDisposed = true;
            }
        }
    }
}

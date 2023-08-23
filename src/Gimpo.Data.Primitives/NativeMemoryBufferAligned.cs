using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using Gimpo.Data.Primitives.Helpers;

namespace Gimpo.Data.Primitives
{
    internal sealed unsafe class NativeMemoryBufferAligned : NativeMemoryBuffer
    {
        private int _alignment;

#if NET6_0_OR_GREATER

        private NativeMemoryBufferAligned(NativeMemoryBufferAligned buffer)
        {
            Size = buffer.Size;
            _alignment = buffer._alignment;

            if (Size == 0)
            {
                _ptr = (byte*)Unsafe.AsPointer(ref Unsafe.NullRef<byte>());
            }
            else
            {
                _ptr = NativeMemoryHelper.AllocateAligned(buffer.Size, _alignment, true);
                GC.AddMemoryPressure(Size);

                Buffer.MemoryCopy(buffer.Ptr, Ptr, Size, Size);
            }
        }

        public NativeMemoryBufferAligned(long size = 0, int alignment = 64, bool skipZeroClear = false)
        {
            Debug.Assert(size >= 0);
            Debug.Assert(alignment > 0);

            Size = size;

            _alignment = alignment;

            if (size == 0)
            {
                _ptr = (byte*)Unsafe.AsPointer(ref Unsafe.NullRef<byte>());
                return;
            }

            _ptr = NativeMemoryHelper.AllocateAligned(size, _alignment, skipZeroClear);

            GC.AddMemoryPressure(size);
        }

        public override void Resize(long size, bool skipZeroClear = true)
        {
            Debug.Assert(size >= 0);

            lock (_lock)
            {
                if (Size == size || _isDisposed)
                    return;

                var newPtr = NativeMemoryHelper.ReallocateAligned(Ptr, Size, size, _alignment, skipZeroClear);

                var delta = size - Size;

                if (delta > 0)
                    GC.AddMemoryPressure(delta);
                else
                    GC.RemoveMemoryPressure(-delta);

                _ptr = newPtr;
                Size = size;
            }
        }

        public override NativeMemoryBuffer Clone()
        {
            return new NativeMemoryBufferAligned(this);
        }

        protected override void DisposeInternal()
        {
            lock (_lock)
            {
                if (_isDisposed)
                    return;

                if (Unsafe.IsNullRef(ref Unsafe.AsRef<byte>(_ptr)))
                    return;

                NativeMemoryHelper.FreeAligned(_ptr);
                _ptr = null;

                GC.RemoveMemoryPressure(Size);
                _isDisposed = true;
            }
        }
#else
//Legacy implementation for netstandard2.0
//Use offset to align data

        private byte* _wPtr;
        
        private NativeMemoryBufferAligned(NativeMemoryBufferAligned buffer)
        {
            Size = buffer.Size;
            _alignment = buffer._alignment;

            if (Size == 0)
            {
                _ptr = (byte*)Unsafe.AsPointer(ref Unsafe.NullRef<byte>());
            }
            else
            {
                _wPtr = NativeMemoryHelper.Allocate(Size + _alignment, true);
                var offset = (int)(_alignment - ((long)_wPtr & (_alignment - 1)));
                _ptr = _wPtr + offset;
                
                GC.AddMemoryPressure(Size + _alignment);

                Buffer.MemoryCopy(buffer.Ptr, Ptr, Size, Size);
            }
        }

        public NativeMemoryBufferAligned(long size = 0, int alignment = 64, bool skipZeroClear = false)
        {
            Debug.Assert(size >= 0);
            Debug.Assert(alignment > 0);

            _alignment = alignment;
            Size = size;

            if (size == 0)
            {
                _ptr = (byte*)Unsafe.AsPointer(ref Unsafe.NullRef<byte>());
                _wPtr = _ptr;
                
                return;
            }

            _wPtr = NativeMemoryHelper.Allocate(size + alignment, skipZeroClear);
            var offset = (int)(alignment - ((long)_wPtr & (alignment - 1)));
            _ptr = _wPtr + offset;

            GC.AddMemoryPressure(size + alignment);
        }

        public override void Resize(long size, bool skipZeroClear = true)
        {
            Debug.Assert(size > 0);
                        
            lock (_lock)
            {
                if (Size == size || _isDisposed)
                    return;
                                
                var newPtr = (byte*)Marshal.AllocHGlobal((IntPtr)(size + _alignment));
                var offset = (int)(_alignment - ((long)newPtr & (_alignment - 1)));

                var newAlignedPtr = newPtr + offset;

                //Copy content of aligned block
                Buffer.MemoryCopy(Ptr, newAlignedPtr, size, Math.Min(Size, size));

                Marshal.FreeHGlobal((IntPtr)_wPtr);
                
                if (!skipZeroClear)
                {
                    NativeMemoryHelper.ZeroMemory(newAlignedPtr, Size, size);
                }

                var delta = size - Size;
                                
                if (Size == 0)
                    delta += _alignment;
                
                if (delta > 0)
                    GC.AddMemoryPressure(delta);
                else
                    GC.RemoveMemoryPressure(-delta);

                _wPtr = newPtr;
                _ptr = newAlignedPtr;

                Size = size;
            }
        }

        public override NativeMemoryBuffer Clone()
        {
            return new NativeMemoryBufferAligned(this);
        }

        protected override void DisposeInternal()
        {
            lock (_lock)
            {
                if (_isDisposed)
                    return;

                if (Unsafe.IsNullRef(ref Unsafe.AsRef<byte>(_wPtr)))
                    return;

                NativeMemoryHelper.Free(_wPtr);
                _ptr = null;
                _wPtr = null;

                GC.RemoveMemoryPressure(Size + _alignment);

                _isDisposed = true;
            }
        }
#endif
    }
}

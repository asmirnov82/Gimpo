using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using CommunityToolkit.Diagnostics;

namespace Gimpo.Data.Primitives.Helpers
{
    internal unsafe static class NativeMemoryHelper
    {
        public static byte* Allocate(long requiredByteCount, bool skipZeroClear)
        {
            byte* ptr;

#if NET6_0_OR_GREATER
            if (skipZeroClear)
            {
                ptr = (byte*)NativeMemory.Alloc(checked((nuint)requiredByteCount), (nuint)Unsafe.SizeOf<byte>());
            }
            else
            {
                ptr = (byte*)NativeMemory.AllocZeroed(checked((nuint)requiredByteCount), (nuint)Unsafe.SizeOf<byte>());
            }
#else
            if (IntPtr.Size == 4 && requiredByteCount > int.MaxValue)
                ThrowHelper.ThrowArgumentOutOfRangeException(nameof(requiredByteCount), requiredByteCount, Resources.ArgumentOutOfRange_ExceededMemoryLimitOn32Bit);

            ptr = (byte*)Marshal.AllocHGlobal((IntPtr)requiredByteCount);

            if (!skipZeroClear)
            {
                ZeroMemory(ptr, 0, requiredByteCount);
            }
#endif

            return ptr;
        }

        public static byte* Reallocate(byte* ptr, long currentByteCount, long requiredByteCount, bool skipZeroClear)
        {
            byte* newPtr;

#if NET6_0_OR_GREATER
            newPtr = (byte*)NativeMemory.Realloc(ptr, checked((nuint)requiredByteCount));
#else
            newPtr = Allocate(requiredByteCount, false);
            Buffer.MemoryCopy(ptr, newPtr, requiredByteCount, Math.Min(currentByteCount, requiredByteCount));
            Free(ptr);
#endif

            if (!skipZeroClear)
            {
                ZeroMemory(newPtr, currentByteCount, requiredByteCount);
            }

            return newPtr;
        }

        public static void ZeroMemory(byte* ptr, long startByteIndex, long endByteIndex)
        {
            FillMemory(ptr, startByteIndex, endByteIndex, 0);
        }

        public static void FillMemory(byte* ptr, long startByteIndex, long endByteIndex, byte value)
        {
            long index = startByteIndex;
            while (index < endByteIndex)
            {
                Unsafe.InitBlock(ptr + index, value, (uint)Math.Min(endByteIndex - index, int.MaxValue));
                index += int.MaxValue;
            }
        }

        public static void Free(byte* ptr)
        {

#if NET6_0_OR_GREATER
            NativeMemory.Free(ptr);
#else

            Marshal.FreeHGlobal((IntPtr)ptr);
#endif
        }
    }
}

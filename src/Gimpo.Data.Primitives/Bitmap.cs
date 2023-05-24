using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using Gimpo.Data.Primitives.Helpers;

namespace Gimpo.Data.Primitives
{
    /// <summary>
    /// A 1 (set bit) for startOffset i indicates that the value is not null, while a 0 (bit not set) indicates that it is null.
    /// </summary>
    internal sealed unsafe class Bitmap : ICloneable, IDisposable 
    {
        private static ReadOnlySpan<byte> BitcountTable => new byte[] {
            0, 1, 1, 2, 1, 2, 2, 3, 1, 2, 2, 3, 2, 3, 3, 4, 1, 2, 2, 3, 2, 3, 3, 4, 2, 3, 3, 4, 3, 4, 4, 5,
            1, 2, 2, 3, 2, 3, 3, 4, 2, 3, 3, 4, 3, 4, 4, 5, 2, 3, 3, 4, 3, 4, 4, 5, 3, 4, 4, 5, 4, 5, 5, 6,
            1, 2, 2, 3, 2, 3, 3, 4, 2, 3, 3, 4, 3, 4, 4, 5, 2, 3, 3, 4, 3, 4, 4, 5, 3, 4, 4, 5, 4, 5, 5, 6,
            2, 3, 3, 4, 3, 4, 4, 5, 3, 4, 4, 5, 4, 5, 5, 6, 3, 4, 4, 5, 4, 5, 5, 6, 4, 5, 5, 6, 5, 6, 6, 7,
            1, 2, 2, 3, 2, 3, 3, 4, 2, 3, 3, 4, 3, 4, 4, 5, 2, 3, 3, 4, 3, 4, 4, 5, 3, 4, 4, 5, 4, 5, 5, 6,
            2, 3, 3, 4, 3, 4, 4, 5, 3, 4, 4, 5, 4, 5, 5, 6, 3, 4, 4, 5, 4, 5, 5, 6, 4, 5, 5, 6, 5, 6, 6, 7,
            2, 3, 3, 4, 3, 4, 4, 5, 3, 4, 4, 5, 4, 5, 5, 6, 3, 4, 4, 5, 4, 5, 5, 6, 4, 5, 5, 6, 5, 6, 6, 7,
            3, 4, 4, 5, 4, 5, 5, 6, 4, 5, 5, 6, 5, 6, 6, 7, 4, 5, 5, 6, 5, 6, 6, 7, 5, 6, 6, 7, 6, 7, 7, 8,
        };

        private readonly NativeMemoryBuffer _buffer;

        public long Length { get; private set; }
        public long NullCount { get; private set; }

        private Bitmap(Bitmap bitmap)
        {
            _buffer = bitmap._buffer.Clone();
            Length = bitmap.Length;
            NullCount = bitmap.NullCount;
        }

        public Bitmap(long length = 0, bool setAllBits = false)  
        {
            _buffer = new NativeMemoryBuffer(BitUtility.ByteCount(length), setAllBits);

            if (setAllBits)
            {
                SetBits(0, true, length);
                NullCount = 0;
            }
            else
                NullCount = length;

            Length = length;
        }

        public bool GetBit(long index)
        {
            var data = *(_buffer.Ptr + index / 8);
            return BitUtility.GetBit(data, (int)(index % 8));
        }

        public void ClearBit(long index)
        {
            byte* ptr = _buffer.Ptr + index / 8;

            int bitOffset = (int)(index % 8);
            var bitValue = BitUtility.GetBit(*ptr, bitOffset);

            if (bitValue)
            {
                *ptr = BitUtility.ClearBit(*ptr, bitOffset);
                NullCount++;
            }
        }

        public void SetBit(long index)
        {
            byte* ptr = _buffer.Ptr + index / 8;
            int bitOffset = (int)(index % 8);

            var bitValue = BitUtility.GetBit(*ptr, bitOffset);

            if (bitValue)
                return;

            *ptr = BitUtility.SetBit(*ptr, bitOffset);
            NullCount--;
        }

        public void SetBit(long index, bool value)
        {
            byte* ptr = _buffer.Ptr + index / 8;
            int bitOffset = (int)(index % 8);
            var bitValue = BitUtility.GetBit(*ptr, bitOffset);

            if (bitValue == value)
                return;
            
            *ptr = BitUtility.SetBit(*ptr, bitOffset, value);

            if (value)
                NullCount--;
            else
                NullCount++;
        }

        public void ToggleBit(long index)
        {
            byte* ptr = _buffer.Ptr + index / 8;
            int bitOffset = (int)(index % 8);

            var bitValue = BitUtility.GetBit(*ptr, bitOffset);

            *ptr = BitUtility.ToggleBit(*ptr, bitOffset);

            if (bitValue)
                NullCount++;
            else
                NullCount--;
        }

        public void AppendBit(bool value)
        {
            EnsureCapacity(Length + 1);
                        
            byte* ptr = _buffer.Ptr + Length / 8;
            int bitOffset = (int)(Length % 8);
            var bitValue = BitUtility.GetBit(*ptr, bitOffset);

            *ptr = BitUtility.SetBit(*ptr, bitOffset, value);

            if (!bitValue)
                NullCount++;
        }

        public void AppendBits(bool value, long count)
        {
            if (count <= 0)
                return;

            var newSize = BitUtility.ByteCount(Length + count);

            if (newSize > _buffer.Size)
            {
                //Skip zero clear as we set the bits to provided value later in the code
                _buffer.Resize(newSize, true);

                //Only zero the last byte
                _buffer.GetValueByRef<byte>(newSize - 1) = 0x00;
            }

            SetBits(Length, value, count);

            if (!value)
            {
                NullCount += count;
            }

            Length += count;
        }

        public void Dispose()
        {
            _buffer.Dispose();
        }
                
        public void Resize(long length)
        {            
            var newSize = BitUtility.ByteCount(length);

            var delta = length - Length;

            if (delta > 0)
                NullCount += delta;
            else
            {
                delta = -delta;

                //Calculate set bits in the shortest part
                if (delta < length)
                    NullCount -= delta - CountBits(Length - delta, Length - 1);
                else
                    NullCount = length - CountBits(0, length - 1);
            }

            Length = length;

            if (newSize <= _buffer.Size)
                return;

            _buffer.Resize(newSize, false);
        }

        public void EnsureCapacity(long length)
        {
            var newSize = BitUtility.ByteCount(length);

            if (newSize <= _buffer.Size)
                return;

            _buffer.Resize(newSize, false);
        }

        public Bitmap Clone()
        {
            return new Bitmap(this);
        }

        object ICloneable.Clone() => Clone();

        private long CountBits(long startOffset, long endOffset)
        {
            if (startOffset > endOffset)
                return 0;

            long startByteIndex = startOffset / 8;
            int startBitOffset = (int) (startOffset % 8);
            long endByteIndex = endOffset / 8;
            int endBitOffset = (int)(endOffset % 8);

            int countBits = 0;
            if (startByteIndex == endByteIndex)
            {
                // Range starts and ends within the same byte.
                var data = *(_buffer.Ptr + startByteIndex);
                for (int i = startBitOffset; i <= endBitOffset; i++)
                    countBits += BitUtility.GetBit(data, i) ? 1 : 0;

                return countBits;
            }

            // If the starting index and ending index are not byte-aligned,
            // we'll need to count bits the slow way.  If they are
            // byte-aligned, and for all other bytes in the 'middle', we
            // can use a faster byte-aligned count.
            long fullByteStartIndex = startBitOffset == 0 ? startByteIndex : startByteIndex + 1;
            long fullByteEndIndex = endBitOffset == 7 ? endByteIndex : endByteIndex - 1;

            if (startBitOffset != 0)
            {
                var data = *(_buffer.Ptr + startByteIndex);
                for (int i = startBitOffset; i <= 7; i++)
                    countBits += BitUtility.GetBit(data, i) ? 1 : 0;
            }

            if (fullByteEndIndex >= fullByteStartIndex)
            {                
                byte* ptr = _buffer.Ptr + fullByteStartIndex;
                for (long i = 0; i < fullByteEndIndex - fullByteStartIndex + 1; i++)
                    countBits += BitcountTable[*(ptr + i)];
            }

            if (endBitOffset != 7)
            {
                var data = *(_buffer.Ptr + endByteIndex);
                for (int i = 0; i <= endBitOffset; i++)
                    countBits += BitUtility.GetBit(data, i) ? 1 : 0;
            }

            return countBits;
        }
                
        private void SetBits(long offset, bool value, long count)
        {
            if (offset < 0)
                return;

            long startByteIndex = offset / 8;
            int startBitOffset = (int)(offset % 8);
            long endByteIndex = (offset + count - 1) / 8;
            int endBitOffset = (int)((offset + count - 1) % 8);
                        
            if (startBitOffset < 0)
                return;

            if (startByteIndex == endByteIndex)
            {
                // Range starts and ends within the same byte.
                var bitPtr = _buffer.Ptr + startByteIndex;
                for (int i = startBitOffset; i <= endBitOffset; i++)
                    *bitPtr = BitUtility.SetBit(*bitPtr, i, value);

                return;
            }

            // If the starting index and ending index are not byte-aligned,
            // we'll need to set bits the slow way.  If they are
            // byte-aligned, and for all other bytes in the 'middle', we
            // can use a faster byte-aligned memory Fill.
            long fullByteStartIndex = startBitOffset == 0 ? startByteIndex : startByteIndex + 1;
            long fullByteEndIndex = endBitOffset == 7 ? endByteIndex : endByteIndex - 1;

            if (startBitOffset != 0)
            {
                var bitPtr = _buffer.Ptr + startByteIndex;
                for (int i = startBitOffset; i <= 7; i++)
                    *bitPtr = BitUtility.SetBit(*bitPtr, i, value);
            }

            if (fullByteEndIndex >= fullByteStartIndex)
            {
                NativeMemoryHelper.FillMemory(_buffer.Ptr, fullByteStartIndex, fullByteEndIndex + 1, (byte)(value ? 0xff : 0x00));
            }

            if (endBitOffset != 7)
            {
                var bitPtr = _buffer.Ptr + endByteIndex;
                for (int i = 0; i <= endBitOffset; i++)
                    *bitPtr = BitUtility.SetBit(*bitPtr, i, value);
            }
        }
    }
}

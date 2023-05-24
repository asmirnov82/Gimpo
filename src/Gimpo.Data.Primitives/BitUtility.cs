// Licensed to the Apache Software Foundation (ASF) under one or more
// contributor license agreements. See the NOTICE file distributed with
// this work for additional information regarding copyright ownership.
// The ASF licenses this file to You under the Apache License, Version 2.0
// (the "License"); you may not use this file except in compliance with
// the License.  You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;

namespace Gimpo.Data.Primitives
{
    /// <summary>
    /// BitUtility class represents a set of static methods for working with individual bits in contiguous block in memory.
    /// </summary>
    public static class BitUtility
    {        
        private static ReadOnlySpan<byte> BitMask => new byte[] {
            1, 2, 4, 8, 16, 32, 64, 128
        };

        /// <summary>
        /// Gets the value of particular bit inside the span.
        /// </summary>
        /// <param name="data">Memory span.</param>
        /// <param name="index">Index of the bit.</param>
        /// <returns>True if bit is set to 1</returns>
        public static bool GetBit(ReadOnlySpan<byte> data, int index) =>
            GetBit(data[index / 8], index % 8);

        /// <summary>
        /// Gets the value of particular bit inside the span.
        /// </summary>
        /// <param name="data">Memory span.</param>
        /// <param name="index">Index of the bit.</param>
        /// <returns>True if bit is set to 1</returns>
        public static bool GetBit(ReadOnlySpan<byte> data, long index) =>
            GetBit(data[checked((int)(index / 8))], (int) index % 8);

        /// <summary>
        /// Gets the value of particular bit inside the byte.
        /// </summary>
        /// <param name="data">Byte.</param>
        /// <param name="bitOffset">Offset of the bit inside the byte.</param>
        /// <returns>True if bit is set to 1</returns>
        public static bool GetBit(byte data, int bitOffset) => (data & BitMask[bitOffset]) != 0;

        /// <summary>
        /// Clears particular bit (sets bit to 0).
        /// </summary>
        /// <param name="data">Memory span.</param>
        /// <param name="index">Index of the bit.</param>
        public static void ClearBit(Span<byte> data, int index) =>
            data[index / 8] &= (byte)~BitMask[index % 8];

        /// <summary>
        /// Clears particular bit (sets bit to 0).
        /// </summary>
        /// <param name="data">Memory span.</param>
        /// <param name="index">Index of the bit.</param>
        public static void ClearBit(Span<byte> data, long index) =>
            data[checked((int)(index / 8))] &= (byte)~BitMask[(int)index % 8];

        /// <summary>
        /// Clears particular bit (sets bit to 0) in byte.
        /// </summary>
        /// <param name="data">Byte.</param>
        /// <param name="bitOffset">Offset of the bit inside the byte.</param>
        /// <returns>Byte with changed bit.</returns>
        public static byte ClearBit(byte data, int bitOffset) =>
            (byte) (data & ~BitMask[bitOffset]);
                
        /// <summary>
        /// Sets bit to 1.
        /// </summary>
        /// <param name="data">Memory span.</param>
        /// <param name="index">Index of the bit.</param>
        public static void SetBit(Span<byte> data, int index) =>
            data[index / 8] |= BitMask[index % 8];
        
        /// <summary>
        /// Sets bit to 1.
        /// </summary>
        /// <param name="data">Memory span.</param>
        /// <param name="index">Index of the bit.</param>
        public static void SetBit(Span<byte> data, long index) =>
            data[checked((int)(index / 8))] |= BitMask[(int) index % 8];


        /// <summary>
        /// Sets bit to 1.
        /// </summary>
        /// <param name="data">Byte.</param>
        /// <param name="bitOffset">Offset of the bit inside the byte.</param>
        /// <returns>Byte with changed bit.</returns>
        public static byte SetBit(byte data, int bitOffset) =>
            (byte) (data | BitMask[bitOffset]);
        
                
        /// <summary>
        /// Sets bit to provided value.
        /// </summary>
        /// <param name="data">Memory span.</param>
        /// <param name="index">Index of the bit.</param>
        /// <param name="value">Bit value.</param>
        public static void SetBit(Span<byte> data, int index, bool value)
        {
            int idx = index / 8;
            int mod = index % 8;
            data[idx] = value
                ? (byte)(data[idx] | BitMask[mod])
                : (byte)(data[idx] & ~BitMask[mod]);
        }

        /// <summary>
        /// Sets bit to provided value.
        /// </summary>
        /// <param name="data">Memory span.</param>
        /// <param name="index">Index of the bit.</param>
        /// <param name="value">Bit value.</param>
        public static void SetBit(Span<byte> data, long index, bool value)
        {
            int idx = checked ((int)(index / 8));
            int mod = (int) index % 8;
            data[idx] = value
                ? (byte)(data[idx] | BitMask[mod])
                : (byte)(data[idx] & ~BitMask[mod]);
        }

        /// <summary>
        /// Sets bit to provided value.
        /// </summary>
        /// <param name="data">Byte.</param>
        /// <param name="bitOffset">Offset of the bit inside the byte.</param>
        /// <param name="value">Bit value.</param>
        /// <returns>Byte with changed bit.</returns>
        public static byte SetBit(byte data, int bitOffset, bool value)
        {            
            return value
                ? (byte)(data | BitMask[bitOffset])
                : (byte)(data & ~BitMask[bitOffset]);
        }
                
        /// <summary>
        /// Changes bit value to opposite.
        /// </summary>
        /// <param name="data">Memory span.</param>
        /// <param name="index">Bit index.</param>
        public static void ToggleBit(Span<byte> data, int index)
        {
            data[index / 8] ^= BitMask[index % 8];
        }

        /// <summary>
        /// Changes bit value to opposite.
        /// </summary>
        /// <param name="data">Memory span.</param>
        /// <param name="index">Bit index.</param>
        public static void ToggleBit(Span<byte> data, long index)
        {
            data[checked((int)(index / 8))] ^= BitMask[(int)index % 8];
        }

        /// <summary>
        /// Changes bit value to opposite.
        /// </summary>
        /// <param name="data">Byte.</param>
        /// <param name="bitOffset">Offset of the bit inside the byte.</param>
        /// <returns>Byte with changed bit.</returns>
        public static byte ToggleBit(byte data, int bitOffset)
        {
            return (byte) (data ^ BitMask[bitOffset]);
        }

        /// <summary>
        /// Calculates the amount of bytes required to store n bits.
        /// </summary>
        /// <param name="n">The amount of bits.</param>
        /// <returns>The amount of bytes.</returns>
        public static int ByteCount(int n)
        {
            Debug.Assert(n >= 0);
            return n / 8 + (n % 8 != 0 ? 1 : 0); // ceil(n / 8)
        }

        /// <summary>
        /// Calculates the amount of bytes required to store n bits.
        /// </summary>
        /// <param name="n">The amount of bits.</param>
        /// <returns>The amount of bytes.</returns>
        public static long ByteCount(long n)
        {
            Debug.Assert(n >= 0);
            return n / 8 + (n % 8 != 0 ? 1 : 0); // ceil(n / 8)
        }
        /// <summary>
        /// Rounds a number to the nearest multiple of 64.
        /// </summary>
        /// <param name="number">Number to round.</param>
        /// <returns>Number rounded to the nearest multiple of 64.</returns>
        public static long RoundUpToMultipleOf64(long number) =>
            RoundUpToMultiplePowerOfTwo(number, 64);

        /// <summary>
        /// Rounds a number to the nearest multiple of 8.
        /// </summary>
        /// <param name="number">Number to round.</param>
        /// <returns>Number rounded to the nearest multiple of 8.</returns>
        public static long RoundUpToMultipleOf8(long number) =>
            RoundUpToMultiplePowerOfTwo(number, 8);

        /// <summary>
        /// Rounds an number up to the nearest multiple of factor, where
        /// factor must be a power of two.
        ///
        /// This function does not throw when the factor is not a power of two.
        /// </summary>
        /// <param name="number">Number to round up.</param>
        /// <param name="factor">Power of two factor to round up to.</param>
        /// <returns>Integer rounded up to the nearest power of two.</returns>
        public static long RoundUpToMultiplePowerOfTwo(long number, int factor)
        {
            // Assert that factor is a power of two.
            Debug.Assert(factor > 0 && (factor & (factor - 1)) == 0);
            return (number + (factor - 1)) & ~(factor - 1);
        }
    }
}

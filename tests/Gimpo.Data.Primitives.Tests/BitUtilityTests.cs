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

using FluentAssertions;
using System;
using Xunit;

namespace Gimpo.Data.Primitives.Tests
{
    public class BitUtilityTest
    {

        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(8, 1)]
        [InlineData(9, 2)]
        [InlineData(32, 4)]
        public void ByteCountTestHasExpectedResult(int numberOfBits, int expected)
        {
            //Act
            var byteCount = BitUtility.ByteCount(numberOfBits);

            //Assert
            byteCount.Should().Be(expected);
        }

        [Theory]
        [InlineData(new byte[] { 0b01001001 }, 0, true)]
        [InlineData(new byte[] { 0b01001001 }, 1, false)]
        [InlineData(new byte[] { 0b01001001 }, 2, false)]
        [InlineData(new byte[] { 0b01001001 }, 3, true)]
        [InlineData(new byte[] { 0b01001001 }, 4, false)]
        [InlineData(new byte[] { 0b01001001 }, 5, false)]
        [InlineData(new byte[] { 0b01001001 }, 6, true)]
        [InlineData(new byte[] { 0b01001001 }, 7, false)]
        [InlineData(new byte[] { 0b01001001, 0b01010010 }, 8, false)]
        [InlineData(new byte[] { 0b01001001, 0b01010010 }, 14, true)]
        public void GetBitеTestGetsCorrectBitForIndex(byte[] data, int index, bool expectedValue)
        {
            //Act
            var value = BitUtility.GetBit(data, index);

            //Assert
            value.Should().Be(expectedValue);
        }
                
        [Theory]
        [InlineData(null, 0)]
        [InlineData(new byte[] { 0b00000000 }, -1)]
        public void GetBitеTestThrowsWhenBitIndexOutOfRange(byte[] data, int index)
        {
            Assert.Throws<IndexOutOfRangeException>(() =>
                BitUtility.GetBit(data, index));
        }
                
        [Theory]
        [InlineData(new byte[] { 0b00000000 }, 0, new byte[] { 0b00000001 })]
        [InlineData(new byte[] { 0b00000000 }, 2, new byte[] { 0b00000100 })]
        [InlineData(new byte[] { 0b00000000 }, 7, new byte[] { 0b10000000 })]
        [InlineData(new byte[] { 0b00000000, 0b00000000 }, 8, new byte[] { 0b00000000, 0b00000001 })]
        [InlineData(new byte[] { 0b00000000, 0b00000000 }, 15, new byte[] { 0b00000000, 0b10000000 })]
        public void SetBitTestAtIndex(byte[] data, int index, byte[] expectedValue)
        {
            //Act
            BitUtility.SetBit(data, index);

            //Assert
            data.Should().BeEquivalentTo(expectedValue);
        }

        [Theory]
        [InlineData(new byte[] { 0b00000000 }, 0, true, new byte[] { 0b00000001 })]
        [InlineData(new byte[] { 0b00000001 }, 0, true, new byte[] { 0b00000001 })]
        [InlineData(new byte[] { 0b11111111 }, 0, false, new byte[] { 0b11111110 })]
        [InlineData(new byte[] { 0b11111110 }, 0, false, new byte[] { 0b11111110 })]
        [InlineData(new byte[] { 0b00000000 }, 2, true, new byte[] { 0b00000100 })]
        [InlineData(new byte[] { 0b00000000 }, 7, true, new byte[] { 0b10000000 })]
        [InlineData(new byte[] { 0b00000000, 0b00000000 }, 8, true, new byte[] { 0b00000000, 0b00000001 })]
        [InlineData(new byte[] { 0b00000000, 0b00000000 }, 15, true, new byte[] { 0b00000000, 0b10000000 })]
        public void SetBitTestWithValuesAtIndex(byte[] data, int index, bool value, byte[] expectedValue)
        {
            //Act
            BitUtility.SetBit(data, index, value);

            //Assert
            data.Should().BeEquivalentTo(expectedValue);
        }
                
        [Theory]
        [InlineData(new byte[] { 0b00000001 }, 0, new byte[] { 0b00000000 })]
        [InlineData(new byte[] { 0b00000000 }, 0, new byte[] { 0b00000000 })]
        [InlineData(new byte[] { 0b00000010 }, 1, new byte[] { 0b00000000 })]
        [InlineData(new byte[] { 0b00000000 }, 1, new byte[] { 0b00000000 })]
        [InlineData(new byte[] { 0b10000001 }, 7, new byte[] { 0b00000001 })]
        [InlineData(new byte[] { 0b00000001 }, 7, new byte[] { 0b00000001 })]
        [InlineData(new byte[] { 0b11111111, 0b11111111 }, 15, new byte[] { 0b11111111, 0b01111111 })]
        [InlineData(new byte[] { 0b11111111, 0b01111111 }, 15, new byte[] { 0b11111111, 0b01111111 })]
        public void ClearBitTestAtIndex(byte[] data, int index, byte[] expectedValue)
        {
            //Act
            BitUtility.ClearBit(data, index);

            //Assert
            data.Should().BeEquivalentTo(expectedValue);
        }
                
        [Theory]
        [InlineData(new byte[] { 0b00000001 }, 0, new byte[] { 0b00000000 })]
        [InlineData(new byte[] { 0b00000000 }, 0, new byte[] { 0b00000001 })]
        [InlineData(new byte[] { 0b00000010 }, 1, new byte[] { 0b00000000 })]
        [InlineData(new byte[] { 0b00000000 }, 1, new byte[] { 0b00000010 })]
        [InlineData(new byte[] { 0b10000001 }, 7, new byte[] { 0b00000001 })]
        [InlineData(new byte[] { 0b00000001 }, 7, new byte[] { 0b10000001 })]
        [InlineData(new byte[] { 0b11111111, 0b11111111 }, 15, new byte[] { 0b11111111, 0b01111111 })]
        [InlineData(new byte[] { 0b11111111, 0b01111111 }, 15, new byte[] { 0b11111111, 0b11111111 })]
        public void ToggleBitTestAtIndex(byte[] data, int index, byte[] expectedValue)
        {
            //Act
            BitUtility.ToggleBit(data, index);

            //Assert
            data.Should().BeEquivalentTo(expectedValue);
        }
                
        [Theory]
        [InlineData(-1, 0)]
        [InlineData(0, 0)]
        [InlineData(1, 64)]
        [InlineData(63, 64)]
        [InlineData(64, 64)]
        [InlineData(65, 128)]
        [InlineData(129, 192)]
        public void RoundUpToMultipleOf64TestReturnsNextMultiple(int number, int expectedValue)
        {
            //Act
            var value = BitUtility.RoundUpToMultipleOf64(number);

            //Assert
            value.Should().Be(expectedValue);
        }
    }
}

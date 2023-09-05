using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Gimpo.Data.Primitives.Tests
{
    public class BitMapTests
    {
        [Fact]
        public void BitmapConstractionFromByteArrayTest()
        {
            //Act
            var bitmap = new Bitmap(new byte[] { 0b01001001 }, 8);

            //Assert
            bitmap.Length.Should().Be(8);
            bitmap.NullCount.Should().Be(5);

            bitmap.GetBit(0).Should().BeTrue();
            bitmap.GetBit(1).Should().BeFalse();
            bitmap.GetBit(2).Should().BeFalse();
            bitmap.GetBit(3).Should().BeTrue();
            bitmap.GetBit(4).Should().BeFalse();
            bitmap.GetBit(5).Should().BeFalse();
            bitmap.GetBit(6).Should().BeTrue();
            bitmap.GetBit(7).Should().BeFalse();
        }
            
        [Theory]
        [InlineData(new byte[] { 0b00001100 }, new byte[] { 0b00001010 }, 8, new byte[] { 0b00001000 }, 7)]
        [InlineData(new byte[] { 0b00001100 }, new byte[] { 0b00001010 }, 7, new byte[] { 0b00001000 }, 6)]
        [InlineData(new byte[] { 0b00011100, 0b00001100 }, new byte[] { 0b00011100, 0b00001010 }, 16, new byte[] { 0b00011100, 0b00001000 }, 12)]
        public void ElementWiseAndTest(byte[] leftData, byte[] rightData, int length,  byte[] expectedData, int expectedNullCount)
        {
            //Arrange
            var left = new Bitmap(leftData, length);
            var right = new Bitmap(rightData, length);

            var result = new Bitmap(length);

            //Act
            Bitmap.ElementWiseAnd(left, right, result);

            result.Length.Should().Be(length);

            for (int i = 0; i < BitUtility.ByteCount(length); i++) 
                result.GetByte(i).Should().Be(expectedData[i]);

            result.NullCount.Should().Be(expectedNullCount);
        }
    }
}

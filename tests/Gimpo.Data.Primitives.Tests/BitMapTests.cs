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
        public void ElementWiseAndBitmapTest()
        {
            var left = new Bitmap(8);
            left.SetByte(0, 12);

            var right = new Bitmap(8);
            right.SetByte(0, 10);

            var result = new Bitmap(8);

            Bitmap.ElementWiseAndBitmap(left, right, result);

            result.GetByte(0).Should().Be(8);
        }
    }
}

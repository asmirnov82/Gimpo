using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Gimpo.Data.Analysis
{
    public class NumericColumnsArithmeticTests
    {
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void AdditionTest_Double(bool forceSimd)
        {
            DataFrame.ForceSimdCalculationsDisabled = forceSimd;

            var left = new DoubleDataFrameColumn("Left", new[] { 1.5, 2.5, 3, 44, 126.25, 99.9 });
            var right = new DoubleDataFrameColumn("Right", new[] { 0.5, 1.5, 3, -43.5, 1.75, 0.1 });

            var sum = left + right;

            sum.Should().BeEquivalentTo(new double?[] { 2, 4, 6, 0.5, 128, 100 });
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void AdditionTest_LessThanFloatVectorSize_DoubleFloat(bool forceSimdDisabled)
        {
            DataFrame.ForceSimdCalculationsDisabled = forceSimdDisabled;

            var left = new DoubleDataFrameColumn("Left",  new double?[] { 1.5, 2.5, 3, 44, 126.25, null }) ;
            var right = new FloatDataFrameColumn("Right", new[]         { 0.5f, 1.5f, 3, -43.5f, 1.75f, 22});

            var sum = left + right;

            sum.Should().BeEquivalentTo(new double?[] { 2, 4, 6, 0.5, 128, null });
        }

        [Fact]
        public void AdditionTest_HigherThanFloatVectorSize_DoubleFloat()
        {
            DataFrame.ForceSimdCalculationsDisabled = false;

            var left = new DoubleDataFrameColumn("Left",  new double?[] { 1.5, 2.5,  3,    44, 126.25, null, null, 126.25, 126.25 });
            var right = new FloatDataFrameColumn("Right", new float?[] { 0.5f, 1.5f, 3, -43.5f, 1.75f,   22, null, null, 1.75f });

            var sum = left + right;

            sum.Should().BeEquivalentTo(new double?[] { 2, 4, 6, 0.5, 128, null, null, null, 128 });
        }
    }
}

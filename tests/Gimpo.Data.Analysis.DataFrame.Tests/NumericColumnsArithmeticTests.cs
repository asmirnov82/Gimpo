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

        #region Addition

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void AdditionTest_Double(bool forceSimdDisabled)
        {
            //Arrange
            DataFrame.ForceSimdCalculationsDisabled = forceSimdDisabled;

            var left = new DoubleDataFrameColumn("Left", new[] { 1.5, 2.5, 3, 44, 126.25, 99.9 });
            var right = new DoubleDataFrameColumn("Right", new[] { 0.5, 1.5, 3, -43.5, 1.75, 0.1 });

            //Act
            var sum1 = left + right;
            var sum2 = right + left;

            //Assert
            sum1.DataType.RawType.Should().Be(typeof(double));
            sum1.Should().BeEquivalentTo(new double?[] { 2, 4, 6, 0.5, 128, 100 });

            sum2.DataType.RawType.Should().Be(typeof(double));
            sum2.Should().BeEquivalentTo(new double?[] { 2, 4, 6, 0.5, 128, 100 });
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void AdditionTest_LessThanFloatVectorSize_DoubleFloat(bool forceSimdDisabled)
        {
            //Arrange
            DataFrame.ForceSimdCalculationsDisabled = forceSimdDisabled;

            var left = new DoubleDataFrameColumn("Left",  new double?[] { 1.5, 2.5, 3, 44, 126.25, null }) ;
            var right = new FloatDataFrameColumn("Right", new[]         { 0.5f, 1.5f, 3, -43.5f, 1.75f, 22});

            //Act
            var sum1 = left + right;
            var sum2 = right + left;

            //Assert
            sum1.DataType.RawType.Should().Be(typeof(double));
            sum1.Should().BeEquivalentTo(new double?[] { 2, 4, 6, 0.5, 128, null });

            sum2.DataType.RawType.Should().Be(typeof(double));
            sum2.Should().BeEquivalentTo(new double?[] { 2, 4, 6, 0.5, 128, null });
        }

        [Fact]
        public void AdditionTest_HigherThanFloatVectorSize_DoubleFloat()
        {
            //Arrange
            DataFrame.ForceSimdCalculationsDisabled = false;

            var left = new DoubleDataFrameColumn("Left",  new double?[] { 1.5, 2.5,  3,    44, 126.25, null, null, 126.25, 126.25 });
            var right = new FloatDataFrameColumn("Right", new float?[] { 0.5f, 1.5f, 3, -43.5f, 1.75f,   22, null, null, 1.75f });

            //Act
            var sum1 = left + right;
            var sum2 = right + left;

            //Assert
            sum1.DataType.RawType.Should().Be(typeof(double));
            sum1.Should().BeEquivalentTo(new double?[] { 2, 4, 6, 0.5, 128, null, null, null, 128 });

            sum2.DataType.RawType.Should().Be(typeof(double));
            sum2.Should().BeEquivalentTo(new double?[] { 2, 4, 6, 0.5, 128, null, null, null, 128 });
        }
                

        [Fact]
        public void AdditionTest_HigherThanIntVectorSize_LongShort()
        {
            //Arrange
            DataFrame.ForceSimdCalculationsDisabled = false;
            const int length = 1024;

            var left = new Int64DataFrameColumn("Left", length, true);
            var right = new Int16DataFrameColumn("Right", length, true);

            for (int i = 0; i < length; i++)
            {
                left[i] = long.MaxValue - i;
                right[i] = (short) i;
            }

            //Act
            var sum1 = left + right;
            var sum2 = right + left;

            //Assert
            sum1.DataType.RawType.Should().Be(typeof(long));
            sum2.DataType.RawType.Should().Be(typeof(long));

            for (int i = 0; i < length; i++)
            {
                sum1[i].Should().Be(long.MaxValue);
                sum2[i].Should().Be(long.MaxValue);
            }
        }

        #endregion

        #region Subsraction
        [Theory]
        [InlineData(true)]
       // [InlineData(false)]
        public void SubsractionTest_Double(bool forceSimdDisabled)
        {
            //Arrange
            DataFrame.ForceSimdCalculationsDisabled = forceSimdDisabled;

            var left = new DoubleDataFrameColumn("Left", new[] { 1.5, 2.5, 3, 44, 126.25, 100.1 });
            var right = new DoubleDataFrameColumn("Right", new[] { 0.5, 1.5, 3, -43.5, 1.25, 0.1 });

            //Act
            var diff1 = left - right;
            var diff2 = right - left;

            //Assert
            diff1.DataType.RawType.Should().Be(typeof(double));
            diff1.Should().BeEquivalentTo(new double?[] { 1.0, 1.0, 0, 87.5, 125, 100 });

            diff2.DataType.RawType.Should().Be(typeof(double));
            diff2.Should().BeEquivalentTo(new double?[] { -1.0, -1.0, 0, -87.5, -125, -100 });
        }
        #endregion
    }
}

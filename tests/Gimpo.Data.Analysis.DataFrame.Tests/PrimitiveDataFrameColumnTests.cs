using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Gimpo.Data.Analysis
{
    public class PrimitiveDataFrameColumnTests
    {
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(128)]
        public void TestSettersOnPrimitiveColumn(long length)
        {
            //Arrange
            using (Int64DataFrameColumn column = new Int64DataFrameColumn("Test column", length))
            {
                //Act
                for (long i = 0; i < length; i++)
                {
                    column[i] = i;
                }

                //Assert
                column.Name.Should().Be("Test column");
                column.DataType.RawType.Should().Be(typeof(long));
                column.Length.Should().Be(length);
                column.IsDetached.Should().BeTrue();
                                
                for (long i = 0; i < length; i++)
                {
                    column[i].Should().Be(i);
                }
            }
        }

        [Fact]
        public void TestSettersOnBaseColumn()
        {
            //Arrange
            const int rowCount = 10;
            using (DataFrame df = new DataFrame())
            {

                df.AddColumn<int>("Test column", rowCount);
                var column = df["Test column"];

                //Act
                for (int i = 0; i < rowCount; i++)
                {
                    column[i] = i;
                }

                //Assert
                df.Columns.Should().NotBeNull();
                df.Columns.Should().ContainSingle();

                df.Rows.Should().NotBeNullOrEmpty();
                df.Columns[0].Name.Should().Be("Test column");
                df.Columns[0].DataType.RawType.Should().Be(typeof(int));

                df.Rows.Count.Should().Be(rowCount);
                
                for (int i = 0; i < rowCount; i++)
                {
                    column[i].Should().Be(i);
                }
            }
        }
    }
}

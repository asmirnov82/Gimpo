using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            using (Int64DataFrameColumn column = new ("Test column", length))
            {
                //Act
                for (long i = 0; i < length; i++)
                {
                    column[i] = i;
                }

                //Assert
                Assert.Equal("Test column", column.Name);
                Assert.Equal(typeof(long), column.DataType.RawType);
                Assert.Equal(length, column.Length);
                Assert.True(column.IsDetached);

                for (long i = 0; i < length; i++)
                {
                    Assert.Equal(i, column[i]);
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
                Assert.NotNull(df.Columns);
                Assert.NotNull(df.Rows);

                Assert.Single(df.Columns);
                Assert.Equal("Test column", df.Columns[0].Name);
                //Assert.Equal(typeof(int), df.Columns[0].DataType);

                Assert.Equal(rowCount, df.Rows.Count);

                for (int i = 0; i < rowCount; i++)
                {
                    Assert.Equal(i, column[i]);
                }
            }
        }
    }
}

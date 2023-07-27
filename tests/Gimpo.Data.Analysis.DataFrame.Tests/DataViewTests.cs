using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gimpo.Data.Analysis
{
    public class DataViewTests
    {
        #region Converstion ToDataFrame
        [Fact]
        public void TestDataViewToDataFrameConversion()
        {
            using (DataFrame df = new DataFrame())
            {
                //Arrange
                df.AddColumn("Long Column", new long?[] { -2, -1, 0, null, 2 });
                df.AddColumn("Double Column", new double?[] { -2.2, -1.1, 0, null, 3.3 });

                //Act
                using (var newDf = df.Rows.ToDataFrame())
                {
                    //Assert
                    Assert.NotEqual(df, newDf);

                    Assert.Equal(df.RowCount, newDf.RowCount);
                    Assert.Equal(df.ColumnCount, newDf.ColumnCount);

                    Assert.True(newDf.Columns.Contains("Long Column"));
                    Assert.True(newDf.Columns.Contains("Double Column"));

                    for (long i = 0; i < 5; i++)
                    {
                        Assert.Equal(df[i, 0], newDf[i, 0]);
                        Assert.Equal(df[i, 1], newDf[i, 1]);
                    }

                }
            }
        }
        #endregion

        #region Filtering
        [Fact]
        public void TestDataViewFilteringAndConvertingToDataFrame()
        {
            using (DataFrame df = new DataFrame())
            {
                //Arrange
                df.AddColumn("Index", new int[] { 0, 1, 2, 3, 4, 5, 6, 7 });
                df.AddColumn("Value", new double[] { 0.0, 1.1, 2.2, 3.3, 4.4, -5.5, 6.6, 7.7 });

                //Act
                using (var filteredDf = df.Rows.Filter("Index", (int? index) => index % 3 == 0).ToDataFrame())
                {
                    //Assert
                    Assert.Equal(3, filteredDf.RowCount);

                    Assert.Equal(0, filteredDf[0, 0]);
                    Assert.Equal(0.0, filteredDf[0, 1]);

                    Assert.Equal(3, filteredDf[1, 0]);
                    Assert.Equal(3.3, filteredDf[1, 1]);

                    Assert.Equal(6, filteredDf[2, 0]);
                    Assert.Equal(6.6, filteredDf[2, 1]);
                }
            }
        }

        [Fact]
        public void TestDataViewFilteringChainAndConvertingToDataFrame()
        {
            using (DataFrame df = new DataFrame())
            {
                //Arrange
                df.AddColumn("Index", new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
                df.AddColumn("Value", new double?[] { 0, -1.1, -2.2, 3.3, null, -5.5, 6.6, 7.7, 8.8, -9.9, -10.1 });

                //Act
                using (var filteredDf = df.Rows.Filter("Index", (int? index) => index % 2 == 0).Filter("Value", (double? value) => value.HasValue && value >= 0).ToDataFrame())
                {
                    //Assert
                    Assert.Equal(3, filteredDf.RowCount);

                    Assert.Equal(0, filteredDf[0, 0]);
                    Assert.Equal(0.0, filteredDf[0, 1]);

                    Assert.Equal(6, filteredDf[1, 0]);
                    Assert.Equal(6.6, filteredDf[1, 1]);

                    Assert.Equal(8, filteredDf[2, 0]);
                    Assert.Equal(8.8, filteredDf[2, 1]);
                }
            }
        }
        #endregion
    }
}

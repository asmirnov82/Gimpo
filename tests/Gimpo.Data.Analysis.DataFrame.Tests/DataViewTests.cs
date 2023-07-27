using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

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
                    newDf.Should().NotBeSameAs(df);

                    newDf.RowCount.Should().Be(df.RowCount);
                    newDf.ColumnCount.Should().Be(df.ColumnCount);

                    newDf.Columns.Should().Contain(column => column.Name == "Long Column");
                    newDf.Columns.Should().Contain(column => column.Name == "Double Column");

                    newDf.Columns["Long Column"].Should().NotBeSameAs(df.Columns["Long Column"]);
                    newDf.Columns["Long Column"].Should().BeEquivalentTo(df.Columns["Long Column"]);

                    newDf.Columns["Double Column"].Should().NotBeSameAs(df.Columns["Double Column"]);
                    newDf.Columns["Double Column"].Should().BeEquivalentTo(df.Columns["Double Column"]);
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
                    filteredDf.RowCount.Should().Be(3);
                    filteredDf["Index"].Should().BeEquivalentTo(new int[] { 0, 3, 6 });
                    filteredDf["Value"].Should().BeEquivalentTo(new double[] { 0.0, 3.3, 6.6 });
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
                    filteredDf.RowCount.Should().Be(3);
                    filteredDf["Index"].Should().BeEquivalentTo(new int[] { 0, 6, 8 });
                    filteredDf["Value"].Should().BeEquivalentTo(new double[] { 0.0, 6.6, 8.8 });
                }
            }
        }
        #endregion
    }
}

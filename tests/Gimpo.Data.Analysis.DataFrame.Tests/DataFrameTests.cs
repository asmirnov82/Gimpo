using System;
using System.Data.Common;
using System.Linq;
using System.Resources;
using FluentAssertions;
using Xunit;

namespace Gimpo.Data.Analysis
{
    public class DataFrameTests
    {
        #region Construction/Initialization
        [Fact]
        public void TestEmptyDataFrameDefaultConstructor()
        {
            //Act
            using (DataFrame df = new DataFrame())
            {
                //Assert
                df.Columns.Should().NotBeNull();
                df.Rows.Should().NotBeNull();

                df.Columns.Should().BeEmpty();
                df.Rows.Should().BeEmpty();
            }
        }
        #endregion

        #region Column Management
        [Fact]
        public void TestAddAndRemoveColumnToTheEmptyDataFrame()
        {
            //Arrange
            DataFrame dataFrame = new DataFrame();
            DataFrameColumn intColumn = new Int32DataFrameColumn("NewIntColumn", Enumerable.Range(0, 10));

            //Act
            dataFrame.AddColumn(intColumn);

            //Assert
            dataFrame.Columns.Should().ContainSingle();
            dataFrame.Columns.Count.Should().Be(1);

            dataFrame.Rows.Count.Should().Be(10);
            intColumn.IsDetached.Should().BeFalse();

            //Act
            dataFrame.RemoveColumn(intColumn.Name);

            //Assert
            dataFrame.Columns.Should().BeEmpty();
            dataFrame.Rows.Count.Should().Be(0);
            dataFrame.Rows.Should().BeEmpty();
            intColumn.IsDetached.Should().BeTrue();
        }

        [Fact]
        public void TestColumnsClear()
        {
            //Arrange
            using (DataFrame df = new DataFrame())
            {
                DataFrameColumn column = new Int32DataFrameColumn("NewIntColumn", Enumerable.Range(0, 10));
                df.Columns.Add(column);

                //Act
                df.Columns.Clear();

                //Assert
                df.Columns.Should().BeEmpty();
                df.Columns.Count.Should().Be(0);

                df.Rows.Should().BeEmpty();
                df.Rows.Count.Should().Be(0);
            }
        }

        [Fact]
        public void TestAddColumnWithDuplicateName()
        {
            //Arrange
            const long rowCount = 10;

            using (DataFrame df = new DataFrame())
            {
                df.AddColumn<int>("Test column", rowCount);

                //Act
                Action act = () => df.AddColumn<int>("Test column", rowCount);

                //Assert
                act.Should().Throw<ArgumentException>();
            }
        }

        [Fact]
        public void TestAddColumnToDifferentDataFrames()
        {
            //Arrange
            const long rowCount = 10;

            using (DataFrame df1 = new DataFrame())
            using (DataFrame df2 = new DataFrame())
            {
                var column = new Int32DataFrameColumn("Test column", rowCount);

                df1.AddColumn(column);

                Assert.False(column.IsDetached);

                //Act
                Assert.Throws<ArgumentException>(() => df1.AddColumn(column));
                Assert.Throws<ArgumentException>(() => df1.Columns.Add(column));
                Assert.Throws<ArgumentException>(() => df2.AddColumn(column));
                Assert.Throws<ArgumentException>(() => df2.Columns.Add(column));
            }
        }
        #endregion

        #region Schema
        [Fact]
        public void TestDataFrameSchema()
        {
            using (DataFrame df = new DataFrame())
            {
                //Arrange
                df.AddColumn<long>("Long Column");
                df.AddColumn<double>("Double Column");

                //Act
                var schema = df.Schema;

                //Assert
                schema.Count.Should().Be(2);

                var longColumnDescription = schema["Long Column"];
                longColumnDescription.Name.Should().Be("Long Column");
                longColumnDescription.DataType.RawType.Should().Be(typeof(long));

                var doubleColumnDescription = schema["Double Column"];
                doubleColumnDescription.Name.Should().Be("Double Column");
                doubleColumnDescription.DataType.RawType.Should().Be(typeof(double));
            }
        }
        #endregion

        #region Getters/Setters
        [Fact]
        public void TestGettersAfterAddingColumn()
        {
            //Arrange
            using (DataFrame df = new DataFrame())
            {
                //Act
                df.AddColumn("Int column", values: new[] { 0, 1, 2 });
                df.AddColumn("Double column", values: new[] { 0.5, 1.5, 2.5 });

                //Assert 2D Getters
                df[0, 0].Should().Be(0);
                df[1, 0].Should().Be(1);
                df[2, 0].Should().Be(2);

                df[0, 1].Should().Be(0.5);
                df[1, 1].Should().Be(1.5);
                df[2, 1].Should().Be(2.5);

                //Assert column/values Getters
                df["Int column"][0].Should().Be(0);
                df["Int column"][1].Should().Be(1);
                df["Int column"][2].Should().Be(2);

                df["Double column"][0].Should().Be(0.5);
                df["Double column"][1].Should().Be(1.5);
                df["Double column"][2].Should().Be(2.5);
            }
        }

        /*
        [Fact]
        public void TestSettersOnStringColumn()
        {
            //Arrange
            const int rowCount = 10;
            using (DataFrame df = new DataFrame(rowCount))
            {
                StringDataFrameColumn column = df.AddStringColumn("Test column");

                //Act
                for (int i = 0; i < rowCount; i++)
                {
                    column[i] = "String number " + i;
                }

                //Assert
                Assert.NotNull(df.Columns);
                Assert.NotNull(df.Rows);

                Assert.Single(df.Columns);
                Assert.Equal("Test column", df.Columns[0].Name);
                Assert.Equal(typeof(string), df.Columns[0].DataType);

                Assert.Equal(rowCount, df.Rows.Count);

                for (int i = 0; i < rowCount; i++)
                {
                    Assert.Equal("String number " + i, column[i]);
                }
            }
        }
        */

        #endregion

        #region Rows Manipulation
        [Fact]
        public void TestRowGetters()
        {
            //Arrange
            using (DataFrame df = new DataFrame())
            {

                df.AddColumn("Int column", values: new[] { -1 });
                df.AddColumn("Double column", values: new[] { -0.5 });
                df.AddColumn("Long column", values: new[] { long.MinValue });

                //Act
                DataFrameRow row = df.Rows.Single();

                //Assert
                row[0].Should().Be(-1);
                row[1].Should().Be(-0.5);
                row[2].Should().Be(long.MinValue);
            }
        }

        [Fact]
        public void TestAppendRow_SizeIsEqualToNumberOfColumns()
        {
            //Arrange
            using (DataFrame df = new DataFrame())
            {

                df.AddColumn("Int column", values: new[] { 0, 1, 2 });
                df.AddColumn("Double column", values: new[] { 0.5, 1.5, 2.5 });
                df.AddColumn("Long column", values: new long[] { 10, 20, 33 });

                //Act
                df.Append(new object[] { 3, 3.5, long.MaxValue });

                //Assert
                df.Rows.Count.Should().Be(4);

                var row = df.Rows[3];

                //Assert
                row[0].Should().Be(3);
                row[1].Should().Be(3.5);
                row[2].Should().Be(long.MaxValue);
            }
        }
        #endregion

        #region Row Cursor
        [Fact]
        public void TestRowCursorGetters()
        {
            //Arrange
            using (DataFrame df = new DataFrame())
            {
                var intValues = new int?[] { -1, 0, null, 2 };
                var doubleValues = new[] { -0.5, 0.5, 1.5, 2.5 };
                var longValues = new[] { long.MinValue, 0, 1, long.MaxValue };

                df.AddColumn("Int column", values: intValues);
                df.AddColumn("Double column", values: doubleValues);
                df.AddColumn("Long column", values: longValues);

                //Act
                var cursor = df.Rows.GetRowCursor();

                var intGetter = cursor.GetGetter<int?>("Int column");
                var doubleGetter = cursor.GetGetter<double?>("Double column");
                var longGetter = cursor.GetGetter<long?>("Long column");

                //Assert
                for (int i = 0; i < 4; i++)
                {
                    Assert.True(cursor.MoveNext());

                    intGetter.Invoke(out int? intValue);
                    doubleGetter.Invoke(out double? doubleValue);
                    longGetter.Invoke(out long? longValue);

                    intValues[i].Should().Be(intValue);
                    doubleValues[i].Should().Be(doubleValue);
                    longValues[i].Should().Be(longValue);
                }

                cursor.MoveNext().Should().BeFalse();
            }
        }
        #endregion

        #region Clone
        [Fact]
        public void TestEmptyDataFrameClone()
        {
            using (DataFrame df = new DataFrame())
            {
                var clonedDf = df.Clone();

                clonedDf.Should().NotBeNull();

                clonedDf.Should().NotBeSameAs(df);
                clonedDf.Columns.Should().NotBeSameAs(df.Columns);
                clonedDf.Rows.Should().NotBeSameAs(df.Rows);

                clonedDf.Columns.Should().NotBeNull();
                clonedDf.Rows.Should().NotBeNull();

                clonedDf.Columns.Should().BeEmpty();
                clonedDf.Rows.Should().BeEmpty();

                clonedDf.Dispose();
            }
        }

        [Fact]
        public void TestDataFrameCloneWithData()
        {
            using (DataFrame df = new DataFrame())
            {
                df.AddColumn("Column 1", new int[] { 1, 2, 3, 4 });
                df.AddColumn("Column 2", new long?[] { null, 3, 2, 1 });

                var clonedDf = df.Clone();

                clonedDf.Should().NotBeNull();
                clonedDf.Should().NotBeSameAs(df);

                clonedDf.Columns.Should().NotBeSameAs(df.Columns);
                clonedDf.Rows.Should().NotBeSameAs(df.Rows);

                clonedDf.Columns.Should().NotBeNull();
                clonedDf.Rows.Should().NotBeNull();

                clonedDf.Columns.Count.Should().Be(2);
                clonedDf.RowCount.Should().Be(4);

                clonedDf.Columns[0].Name.Should().Be("Column 1");
                clonedDf.Columns[1].Name.Should().Be("Column 2");

                clonedDf.Columns[0].DataType.RawType.Should().Be(typeof(int));
                clonedDf.Columns[1].DataType.RawType.Should().Be(typeof(long));

                clonedDf.Columns[0].IsDetached.Should().BeFalse();
                clonedDf.Columns[1].IsDetached.Should().BeFalse();

                clonedDf.Columns[0].Should().BeEquivalentTo(new int[] { 1, 2, 3, 4 });
                clonedDf.Columns[1].Should().BeEquivalentTo(new long?[] { null, 3, 2, 1 });

                clonedDf.Dispose();
            }
        }

        [Fact]
        public void TestDataFrameCloneWithDataAndReodering()
        {
            using (DataFrame df = new DataFrame())
            {
                df.AddColumn("Index", new long[] { 0, 1, 2, 3, 4 });
                df.AddColumn("Value", new int?[] { null, 3, 2, 1, null });

                var clonedDf = df.Clone(new long[] { 0, 0, 4, 3, 2, 1 });

                clonedDf.Should().NotBeNull();
                clonedDf.Should().NotBeSameAs(df);

                clonedDf.Columns.Should().NotBeSameAs(df.Columns);
                clonedDf.Rows.Should().NotBeSameAs(df.Rows);

                clonedDf.Columns.Should().NotBeNull();
                clonedDf.Rows.Should().NotBeNull();

                clonedDf.Columns.Count.Should().Be(2);
                clonedDf.RowCount.Should().Be(6);

                clonedDf.Columns[0].Name.Should().Be("Index");
                clonedDf.Columns[1].Name.Should().Be("Value");

                clonedDf.Columns[0].DataType.RawType.Should().Be(typeof(long));
                clonedDf.Columns[1].DataType.RawType.Should().Be(typeof(int));

                clonedDf.Columns[0].IsDetached.Should().BeFalse();
                clonedDf.Columns[1].IsDetached.Should().BeFalse();
                                
                clonedDf.Columns[1].Should().BeEquivalentTo(new int?[] { null, null, null, 1, 2, 3 });

                clonedDf.Dispose();
            }
        }
        #endregion
    }
}

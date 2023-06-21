using System.Runtime.InteropServices;

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
                Assert.NotNull(df.Columns);
                Assert.NotNull(df.Rows);

                Assert.Empty(df.Columns);
                Assert.Empty(df.Rows);
            }
        }
        #endregion

        #region Column Management
        [Fact]
        public void TestAddAndRemoveColumnToTheEmptyDataFrame()
        {
            DataFrame dataFrame = new DataFrame();
            DataFrameColumn intColumn = new Int32DataFrameColumn("NewIntColumn", Enumerable.Range(0, 10));

            dataFrame.AddColumn(intColumn);
            Assert.Single(dataFrame.Columns);
            Assert.Equal(10, dataFrame.Rows.Count);
            Assert.False(intColumn.IsDetached);

            dataFrame.RemoveColumn(intColumn.Name);
            Assert.Empty(dataFrame.Columns);
            Assert.Equal(0, dataFrame.Rows.Count);
            Assert.True(intColumn.IsDetached);
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
                Assert.Empty(df.Columns);

                Assert.Equal(0, df.Rows.Count);
                Assert.Equal(0, df.Columns.LongCount());
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
                Assert.Throws<ArgumentException>(() => df.AddColumn<int>("Test column", rowCount));
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
                Assert.Equal(2, schema.Count);

                var longColumnDescription = schema["Long Column"];
                Assert.Equal("Long Column", longColumnDescription.Name);
                Assert.Equal(typeof(long), longColumnDescription.DataType.RawType);

                var doubleColumnDescription = schema["Double Column"];
                Assert.Equal("Double Column", doubleColumnDescription.Name);
                Assert.Equal(typeof(double), doubleColumnDescription.DataType.RawType);
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
                Assert.Equal(0, df[0, 0]);
                Assert.Equal(1, df[1, 0]);
                Assert.Equal(2, df[2, 0]);

                Assert.Equal(0.5, df[0, 1]);
                Assert.Equal(1.5, df[1, 1]);
                Assert.Equal(2.5, df[2, 1]);
                               
                //Assert column/values Getters
                Assert.Equal(0, df["Int column"][0]);
                Assert.Equal(1, df["Int column"][1]);
                Assert.Equal(2, df["Int column"][2]);

                Assert.Equal(0.5, df["Double column"][0]);
                Assert.Equal(1.5, df["Double column"][1]);
                Assert.Equal(2.5, df["Double column"][2]);
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
                Assert.Equal(-1, row[0]);
                Assert.Equal(-0.5, row[1]);
                Assert.Equal(long.MinValue, row[2]);
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
                df.Append(new object[] { 3, 3.5, long.MaxValue}) ;

                //Assert
                Assert.Equal(4, df.Rows.Count);

                var row = df.Rows[3];

                //Assert
                Assert.Equal(3, row[0]);
                Assert.Equal(3.5, row[1]);
                Assert.Equal(long.MaxValue, row[2]);
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

                    Assert.Equal(intValues[i], intValue);
                    Assert.Equal(doubleValues[i], doubleValue);
                    Assert.Equal(longValues[i], longValue);
                }

                Assert.False(cursor.MoveNext());
            }
        }
        #endregion

        #region DataFrameView
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
    }
}

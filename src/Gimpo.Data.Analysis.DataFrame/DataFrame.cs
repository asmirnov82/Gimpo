using System;
using System.Collections.Generic;
using CommunityToolkit.Diagnostics;

namespace Gimpo.Data.Analysis
{ 
    public class DataFrame : IDataFrame, IDisposable
    {
        private readonly ColumnCollection _columns;
        private readonly RowCollection _rows;

        public long RowCount => _columns.RowCount;
        public int ColumnCount { get; private set; }

        public IColumnCollection Columns => _columns;
        public IRowCollection Rows => _rows;

        #region Constructors
        public DataFrame()
        {
            _columns = new ColumnCollection(this);
            _rows = new RowCollection(this);
        }

        public DataFrame(IEnumerable<DataFrameColumn> columns)
        {
            _columns = new ColumnCollection(columns);
            _rows = new RowCollection(this);
        }

        public DataFrame(params DataFrameColumn[] columns)
        {
            _columns = new ColumnCollection(columns);
            _rows = new RowCollection(this);
        }
        #endregion

        #region Indexing
        public DataFrameColumn this[string columnName]
        {
            get { return _columns[columnName]; }
        }

        public object this[long rowIndex, int columnIndex]
        {
            get => _columns[columnIndex][rowIndex];
            set => _columns[columnIndex][rowIndex] = value;
        }
        #endregion

        #region Columns Manipulation
        public DataFrameColumn AddColumn(DataFrameColumn column) => _columns.Add(column);

        public DataFrameColumn AddColumn<T>(string columnName, IEnumerable<T?> values) where T : unmanaged
        {
            var column = new PrimitiveDataFrameColumn<T>(columnName, values);
            return _columns.Add(column);
        }

        public DataFrameColumn AddColumn<T>(string columnName, IEnumerable<T> values) where T : unmanaged
        {
            var column = new PrimitiveDataFrameColumn<T>(columnName, values);
            return _columns.Add(column);
        }

        public DataFrameColumn AddColumn<T>(string columnName, long length) where T : unmanaged
        {
            var column = new PrimitiveDataFrameColumn<T>(columnName, length);
            return _columns.Add(column);
        }

        public void RemoveColumn(string columnName)
        {
            _columns.Remove(columnName);
        }

        #endregion

        #region Rows Manipulation
        public void Append(IReadOnlyCollection<object> row)
        {
            _columns.AppendRow(row);
        }
        #endregion

        #region Disposing
        public void Dispose()
        {
            foreach (var column in _columns)
            {
                column.Dispose();
            }
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Gimpo.Data.Analysis
{
    public interface IDataFrame : ICloneable
    {
        DataFrameViewSchema Schema { get; }
        object this[long rowIndex, int columnIndex] { get; set; }
        DataFrameColumn this[string columnName] { get; }
        IColumnCollection Columns {  get; }
        IRowCollection Rows { get; }
        long RowCount { get; }
        int ColumnCount { get; }

        DataFrameColumn AddColumn(DataFrameColumn column);
        DataFrameColumn AddColumn<T>(string columnName, IEnumerable<T?> values) where T : unmanaged;
        DataFrameColumn AddColumn<T>(string columnName, IEnumerable<T> values);
        DataFrameColumn AddColumn<T>(string columnName, long length);

        DataFrameColumn DetachColumn(string columnName);
        void RemoveColumn(string columnName);

        void Append(IReadOnlyCollection<object> row);
        void Append(IEnumerable<KeyValuePair<string, object>> row);

        /*
        IDataFrame Info();
        IDataFrame Description();


        IDataFrame Head(int numberOfRows);
        IDataFrame Filter(IEnumerable<long> rowIndices);

        IDataFrame Tail(int numberOfRows);
        IDataFrame Clone();
        IDataFrame OrderBy(string columnName);
        IDataFrame OrderByDescending(string columnName);
        IDataFrame Sample(int numberOfRows);
        IDataFrame DropNulls(object options);
        IDataFrame Append(IEnumerable<object> rows, bool inPlace = false);
        IDataFrame Append(IEnumerable<KeyValuePair<string, object>> row, bool inPlace = false);

        //From column collection
        void Insert(int columnIndex, IEnumerable<object> column, string columnName);
        void Remove(string columnName);
        object GroupBy(string columnName);
        */
    }
}

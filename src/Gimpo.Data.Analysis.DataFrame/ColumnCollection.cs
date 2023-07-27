using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommunityToolkit.Diagnostics;

namespace Gimpo.Data.Analysis
{
    internal class ColumnCollection : IColumnCollection
    {
        private readonly DataFrame _owner;
        private readonly List<DataFrameColumn> _columns;
        private readonly Dictionary<string, int> _columnNameToIndexDictionary = new Dictionary<string, int>(StringComparer.Ordinal);

        internal long RowCount { get; private set; }

        public int Count => _columns.Count;

        #region Constructors
        internal ColumnCollection(DataFrame owner)
        {
            _owner = owner;
            _columns = new List<DataFrameColumn>();
        }

        internal ColumnCollection(DataFrame owner, IEnumerable<DataFrameColumn> columns) : this(owner)
        {           
            foreach (var column in columns)
            {
                AddColumnInternal(column);
            }
        }
        #endregion

        #region Indexing
        public DataFrameColumn this[int index] => _columns[index];
        
        public DataFrameColumn this[string columnName]
        {
            get
            {
                int columnIndex = IndexOf(columnName);
                if (columnIndex == -1)
                {
                    throw new ArgumentException(String.Format(Resources.InvalidColumnName, columnName), nameof(columnName));
                }
                return _columns[columnIndex];
            }
        }
        #endregion

        #region Column Management
        public int IndexOf(string columnName)
        {
            Guard.IsNotNullOrEmpty(columnName, nameof(columnName));

            if (columnName != null && _columnNameToIndexDictionary.TryGetValue(columnName, out int columnIndex))
            {
                return columnIndex;
            }
            return -1;
        }

        public bool Contains(string columnName)
        {
            Guard.IsNotNullOrEmpty(columnName, nameof(columnName));

            return _columnNameToIndexDictionary.ContainsKey(columnName);
        }

        public DataFrameColumn Add(DataFrameColumn column)
        {
            AddColumnInternal(column);
            return column;
        }

        public void Remove(string columnName)
        {
            var column = Detach(columnName);
            column.Dispose();
        }

        public DataFrameColumn Detach(string columnName)
        {
            int columnIndex = IndexOf(columnName);
            if (columnIndex == -1)
            {
                throw new ArgumentException(String.Format(Resources.InvalidColumnName, columnName), nameof(columnName));
            }

            _columnNameToIndexDictionary.Remove(columnName);
            for (int i = columnIndex + 1; i < Count; i++)
            {
                _columnNameToIndexDictionary[_columns[i].Name]--;
            }

            var column = _columns[columnIndex];
            _columns.RemoveAt(columnIndex);

            //Reset RowCount if the last column was removed and dataframe is empty
            if (Count == 0)
                RowCount = 0;

            column.SetOwner(null);
            return column;
        }

        public void Clear()
        {
            foreach (var column in _columns)
                column.Dispose();

            _columns.Clear();
            _columnNameToIndexDictionary.Clear();

            //reset RowCount as DataFrame is now empty
            RowCount = 0;
        }
        #endregion

        #region Enumeration
        public IEnumerator<DataFrameColumn> GetEnumerator() => _columns.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        IEnumerator<DataFrameColumn> IEnumerable<DataFrameColumn>.GetEnumerator() => GetEnumerator();
        #endregion

        internal void AppendRow(IReadOnlyCollection<object> row)
        {
            Guard.IsNotNull(row, nameof(row));

            if (row.Count != Count)
                ThrowHelper.ThrowArgumentException(Resources.WrongNumberOfColumns, nameof(row));
                                    
            int i = 0;
            try
            {
                foreach (var value in row)
                {
                    this[i].Append(value);
                    i++;
                }
            }
            catch
            {
                //Undo changes to preserve state
                //for (var j = 0; j < i; j++)
                //    this[i].Reduce();

                throw;
            }

            RowCount++;
        }

        internal void AppendRow(IEnumerable<KeyValuePair<string, object>> row)
        {
            Guard.IsNotNull(row, nameof(row));

            int i = 0;
            try
            {
                foreach (var value in row)
                {
                    this[value.Key].Append(value.Value);
                    i++;
                }

                if (i != Count)
                    ThrowHelper.ThrowArgumentException(Resources.WrongNumberOfColumns, nameof(row));
            }
            catch
            {
                //Undo changes to preserve state
                //for (var j = 0; j < i; j++)
                //    this[i].Reduce();

                throw;
            }

            RowCount++;
        }
    
        private void AddColumnInternal(DataFrameColumn column)
        {
            var columnName = column.Name;

            if (!column.IsDetached)
                ThrowHelper.ThrowArgumentException(String.Format(Resources.ColumnIsNotDetached, columnName), nameof(column));
            
            if (_columnNameToIndexDictionary.ContainsKey(columnName))
                ThrowHelper.ThrowArgumentException(String.Format(Resources.DuplicateColumnName, columnName), nameof(column));

            if (Count == 0)
            {
                //Adding first column
                RowCount = column.Length;
            }
            else if (column.Length != RowCount)
                ThrowHelper.ThrowArgumentException(String.Format(Resources.MismatchedColumnLengths, columnName), nameof(column));

            _columnNameToIndexDictionary.Add(columnName, _columns.Count);
            _columns.Add(column);
            column.SetOwner(_owner);
        }
    }
}

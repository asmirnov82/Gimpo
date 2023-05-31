﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gimpo.Data.Analysis
{
    public class DataFrame : IDataFrame, IDisposable
    {
        #region Static
        private static readonly Dictionary<Type, IDataFrameColumnFactory> _factories = new Dictionary<Type, IDataFrameColumnFactory>();

        public static IDataFrameColumnFactory GetColumnFactory(Type type)
        {
            lock (_factories)
            {
                //TODO exception message
                return _factories[type];
            }
        }

        public static void RegisterColumnFactory(Type type, IDataFrameColumnFactory factory)
        {
            lock (_factories)
            {
                _factories.Add(type, factory);
            }
        }

        static DataFrame()
        {
            DataFrameColumn.RegisterAutoGeneratedPrimitiveDataFrameColumns();
        }
        #endregion

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
            var column = GetColumnFactory(typeof(T))?.CreateColumn(columnName, values);
            return _columns.Add(column);
        }

        public DataFrameColumn AddColumn<T>(string columnName, IEnumerable<T> values)
        {
            var column = GetColumnFactory(typeof(T))?.CreateColumn(columnName, values);
            return _columns.Add(column);
        }

        public DataFrameColumn AddColumn<T>(string columnName, long length)
        {
            var column = GetColumnFactory(typeof(T))?.CreateColumn(columnName, length);
            return _columns.Add(column);
        }

        public DataFrameColumn DetachColumn(string columnName)
        {
            return _columns.Detach(columnName);
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

        public void Append(IEnumerable<KeyValuePair<string, object>> row)
        {
            _columns.AppendRow(row);
        }
        #endregion

        #region Clone
        public DataFrame Clone()
        {
            return new DataFrame(Columns.Select(c => c.Clone()));
        }
        #endregion

        #region ToString
        /// <summary>
        /// A preview of the contents of this <see cref="DataFrame"/> as a string.
        /// </summary>
        /// <returns>A preview of the contents of this <see cref="DataFrame"/>.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            int longestColumnName = 0;
            for (int i = 0; i < Columns.Count; i++)
            {
                longestColumnName = Math.Max(longestColumnName, Columns[i].Name.Length);
            }

            int padding = Math.Max(10, longestColumnName + 1);
            for (int i = 0; i < Columns.Count; i++)
            {
                // Left align by 10 or more (in case of longer column names)
                sb.Append(string.Format(Columns[i].Name.PadRight(padding)));
            }
            sb.AppendLine();
            long numberOfRows = Math.Min(Rows.Count, 25);
            for (int i = 0; i < numberOfRows; i++)
            {
                foreach (object obj in Rows[i])
                {
                    sb.Append((obj ?? "null").ToString().PadRight(padding));
                }
                sb.AppendLine();
            }
            return sb.ToString();
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

        object ICloneable.Clone() => this.Clone();
    }
}
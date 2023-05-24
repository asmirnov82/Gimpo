using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Gimpo.Data.Analysis
{
    /// <summary>
    /// A DataFrameRow is a collection of values that represent a row in a <see cref="DataFrame"/>.
    /// </summary>
    public readonly struct DataFrameRow : IReadOnlyList<object>
    {
        private readonly DataFrame _dataFrame;
        private readonly long _rowIndex;

        internal DataFrameRow(DataFrame df, long rowIndex)
        {
            Debug.Assert(rowIndex < df.RowCount);

            _dataFrame = df;
            _rowIndex = rowIndex;
        }

        public int Count => _dataFrame.Columns.Count;

        /// <summary>
        /// An indexer to return the value at <paramref name="index"./>.
        /// </summary>
        /// <param name="index">The index of the value to return.</param>
        /// <returns>The value at this <paramref name="index"/>.</returns>
        public object this[int index]
        {
            get => _dataFrame.Columns[index][_rowIndex];
            set => _dataFrame.Columns[index][_rowIndex] = value;
        }

        /// <summary>
        /// Returns an enumerator of the values in this row.
        /// </summary>
        public IEnumerator<object> GetEnumerator()
        {
            foreach (var column in _dataFrame.Columns)
            {
                yield return column[_rowIndex];
            }
        }
                
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}

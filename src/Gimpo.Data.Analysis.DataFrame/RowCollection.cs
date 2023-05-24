using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using CommunityToolkit.Diagnostics;

namespace Gimpo.Data.Analysis
{
    internal class RowCollection : IRowCollection
    {
        private readonly DataFrame _dataFrame;

        public long Count => _dataFrame.RowCount;

        internal RowCollection(DataFrame dataFrame)
        {
            Guard.IsNotNull(dataFrame, nameof(dataFrame));

            _dataFrame = dataFrame;
        }

        public DataFrameRow this[long rowIndex] => new DataFrameRow(_dataFrame, rowIndex);

        DataFrameRow IRowCollection.this[long rowIndex] => this[rowIndex];

        public IEnumerator<DataFrameRow> GetEnumerator()
        {
            for (long i = 0; i < Count; i++)
            {
                yield return new DataFrameRow(_dataFrame, i);
            }
        }
                
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}

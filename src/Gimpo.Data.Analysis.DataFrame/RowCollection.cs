using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using CommunityToolkit.Diagnostics;

namespace Gimpo.Data.Analysis
{
    /// <summary>
    /// Virtual collection of rows.
    /// </summary>
    internal class RowCollection : IRowCollection
    {
        private readonly DataFrame _dataFrame;
       
        public long Count => _dataFrame.RowCount;
        
        internal RowCollection(DataFrame dataFrame)
        {
            _dataFrame = dataFrame;
        }

        public DataViewSchema Schema
        {
            get
            {
                return _dataFrame.Schema;
            }
        }

        public DataFrameRow this[long rowIndex] => new DataFrameRow(_dataFrame, rowIndex);

        public IRowCursor GetRowCursor() => new DataFrameRowCursor(_dataFrame);

        IEnumerator<DataFrameRow> IEnumerable<DataFrameRow>.GetEnumerator()
        {
            for (long i = 0; i < Count; i++)
            {
                yield return new DataFrameRow(_dataFrame, i);
            }
        }
                
        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable<DataFrameRow>)this).GetEnumerator();

        long? IDataView.GetRowCount() => _dataFrame.RowCount;
    }
}

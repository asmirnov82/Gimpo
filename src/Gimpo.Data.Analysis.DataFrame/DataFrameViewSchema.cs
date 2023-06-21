using System;
using System.Collections.Generic;
using System.Text;

namespace Gimpo.Data.Analysis
{
    public readonly struct DataFrameViewSchema
    {
        private readonly IColumnCollection _columns;

        public int Count => _columns.Count;

        public ColumnDescription this[string columnName] => _columns[columnName].GetColumnDescription();
                
        internal DataFrameViewSchema(IColumnCollection columns)
        {
            _columns = columns;
        }

        public ColumnDescription this[int index]
        {
            get { return _columns[index].GetColumnDescription(); }
        }
    }
}

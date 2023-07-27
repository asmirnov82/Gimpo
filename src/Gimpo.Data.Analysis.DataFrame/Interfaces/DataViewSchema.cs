using System;
using System.Collections.Generic;

namespace Gimpo.Data.Analysis
{
    public readonly struct DataViewSchema
    {
        private readonly IColumnReadOnlyCollection _columns;

        public int Count => _columns.Count;

        public ColumnDescription this[string columnName] => _columns[columnName].GetColumnDescription();

        internal DataViewSchema(IColumnReadOnlyCollection columns)
        {
            _columns = columns;
        }

        public ColumnDescription this[int index]
        {
            get { return _columns[index].GetColumnDescription(); }
        }
    }
}

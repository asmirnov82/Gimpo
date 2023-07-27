using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gimpo.Data.Analysis
{
    internal class FilteringDataView<TSource> : IDataView
    {
        private readonly IDataView _src;
        private readonly string _columnName;
        private readonly Func<TSource, bool> _filter;

        public DataViewSchema Schema => _src.Schema;

        public long? GetRowCount()
        {
            return null;
        }

        public IRowCursor GetRowCursor() => new FilteringRowCursor<TSource>(_src.GetRowCursor(), _columnName, _filter);

        public FilteringDataView(IDataView src, string columnName, Func<TSource, bool> filter)
        {          
            _src = src;
            _columnName = columnName;
            _filter = filter;
        }
    }
}

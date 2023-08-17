using System;
using System.Collections.Generic;
using System.Text;

namespace Gimpo.Data.Analysis
{
    public interface IDataFrameColumnFactory
    {
        DataFrameColumn CreateColumn(string columnName, long length = 0, bool skipZeroClear = false);
        DataFrameColumn CreateColumn<T>(string columnName, IEnumerable<T> values);
        DataFrameColumn CreateColumn<T>(string columnName, IEnumerable<T?> values) where T : unmanaged;
    }
}

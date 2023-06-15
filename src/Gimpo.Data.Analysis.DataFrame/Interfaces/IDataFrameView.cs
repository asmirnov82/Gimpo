using System;
using System.Collections.Generic;
using System.Text;

namespace Gimpo.Data.Analysis
{
    public delegate void ValueGetter<T>(out T value);
    
    public interface IDataFrameView : IEnumerable<DataFrameRow>
    {
        long? GetRowCount();
        RowCursor GetRowCursor();
    }
}

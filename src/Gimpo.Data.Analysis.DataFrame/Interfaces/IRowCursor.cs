using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Gimpo.Data.Analysis
{
    public interface IRowCursor
    {
        DataFrameRow Row { get; }
        long Position { get; }
        ValueGetter<T> GetGetter<T>(string columnName);
        bool MoveNext();
    }
}

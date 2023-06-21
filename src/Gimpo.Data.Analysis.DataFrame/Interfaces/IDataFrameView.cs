using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Gimpo.Data.Analysis
{
    public delegate void ValueGetter<T>(out T value);
    
    public interface IDataFrameView 
    {
        DataFrameViewSchema Schema { get; }
        long? GetRowCount();
        RowCursor GetRowCursor();
    }        
}

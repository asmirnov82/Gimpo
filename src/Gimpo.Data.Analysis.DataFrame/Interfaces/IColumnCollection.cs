using System;
using System.Collections.Generic;
using System.Text;

namespace Gimpo.Data.Analysis
{
    public interface IColumnCollection : IColumnReadOnlyCollection 
    {        
        DataFrameColumn Add(DataFrameColumn column);
        DataFrameColumn Detach(string columnName);
        void Remove(string columnName);
        void Clear();
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Gimpo.Data.Analysis
{
    public interface IColumnCollection : IReadOnlyList<DataFrameColumn>
    {
        DataFrameColumn this[string columnName] { get; }
        int IndexOf(string columnName);
        bool Contains(string columnName);
        
        DataFrameColumn Add(DataFrameColumn column);
        void Remove(string columnName);
        void Clear();
    }
}

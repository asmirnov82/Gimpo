using System;
using System.Collections.Generic;
using System.Text;

namespace Gimpo.Data.Analysis
{
    public interface IColumnReadOnlyCollection : IReadOnlyList<DataFrameColumn>
    {
        DataFrameColumn this[string columnName] { get; }
        int IndexOf(string columnName);
        bool Contains(string columnName);
    }
}

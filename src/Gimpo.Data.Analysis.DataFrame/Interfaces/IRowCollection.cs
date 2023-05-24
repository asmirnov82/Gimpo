using System;
using System.Collections.Generic;
using System.Text;

namespace Gimpo.Data.Analysis
{
    public interface IRowCollection : IEnumerable<DataFrameRow>
    {
        DataFrameRow this[long rowIndex] { get; }
        long Count { get; }
    }
}

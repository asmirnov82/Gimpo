using System;
using System.Collections.Generic;
using System.Text;
using Gimpo.Data.Analysis.Computations;

namespace Gimpo.Data.Analysis
{
    public interface INumericColumn : IArithmeticOperationColumn
    {
        DataFrameColumn Add<T>(INumericArithmeticComputations computation) where T : unmanaged;
    }
}

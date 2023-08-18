using System;
using System.Collections.Generic;
using System.Text;

namespace Gimpo.Data.Analysis
{
    public interface INumericColumn : IArithmeticOperationColumn, INumericArithmeticComputationVisitor
    {
        DataFrameColumn AcceptAddVisitor(INumericArithmeticComputationVisitor visitor, bool inPlace = false);
    }
}

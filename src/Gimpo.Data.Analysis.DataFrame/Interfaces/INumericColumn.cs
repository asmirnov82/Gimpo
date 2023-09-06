using System;
using System.Collections.Generic;
using System.Text;

namespace Gimpo.Data.Analysis
{
    public interface INumericColumn : IArithmeticOperationColumn, INumericArithmeticComputationVisitor
    {
        DataFrameColumn AcceptAddVisitor(INumericArithmeticComputationVisitor visitor, bool inPlace = false);
        DataFrameColumn AcceptReverseAddVisitor(INumericArithmeticComputationVisitor visitor);

        DataFrameColumn AcceptSubstractVisitor(INumericArithmeticComputationVisitor visitor, bool inPlace = false);
        DataFrameColumn AcceptReverseSubstractVisitor(INumericArithmeticComputationVisitor visitor);
    }
}

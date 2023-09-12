using System;
using System.Collections.Generic;
using System.Text;

namespace Gimpo.Data.Analysis
{
    public interface INumericColumn : IArithmeticOperationColumn, INumericArithmeticVisitor
    {
        DataFrameColumn AcceptNumericArithmeticVisitor(INumericArithmeticVisitor visitor, ArithmeticOperation operation, bool inPlace = false);
        DataFrameColumn AcceptReverseNumericArithmeticVisitor(INumericArithmeticVisitor visitor, ArithmeticOperation operation);
    }
}

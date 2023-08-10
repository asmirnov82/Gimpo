using System;
using System.Collections.Generic;
using System.Text;

namespace Gimpo.Data.Analysis
{
    public interface IArithmeticOperationColumn
    {
        Type GetResultTypeFor(Type argumentType);
        DataFrameColumn Add(DataFrameColumn column);
        DataFrameColumn Substract(DataFrameColumn column);
        DataFrameColumn Multiply(DataFrameColumn column);
        DataFrameColumn Divide(DataFrameColumn column);
        DataFrameColumn Modulo(DataFrameColumn column);
    }
}

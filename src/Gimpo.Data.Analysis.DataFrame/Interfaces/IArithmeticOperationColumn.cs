using System;
using System.Collections.Generic;
using System.Text;

namespace Gimpo.Data.Analysis
{
    public interface IArithmeticOperationColumn
    {
        bool IsArgumentTypeSupported(Type argumentType);

        DataFrameColumn Add(DataFrameColumn column, bool inPlace = false);
        DataFrameColumn ReverseAdd(DataFrameColumn column);

        DataFrameColumn Substract(DataFrameColumn column, bool inPlace = false);
        DataFrameColumn ReverseSubstract(DataFrameColumn column);

        DataFrameColumn Multiply(DataFrameColumn column, bool inPlace = false);
        DataFrameColumn ReverseMultiply(DataFrameColumn column);

        DataFrameColumn Divide(DataFrameColumn column, bool inPlace = false);
        DataFrameColumn ReverseDivide(DataFrameColumn column);

        DataFrameColumn Modulo(DataFrameColumn column, bool inPlace = false);
        DataFrameColumn ReverseModulo(DataFrameColumn column);
    }
}

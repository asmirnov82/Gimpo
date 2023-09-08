
// Generated from IArithmeticOperationColumn.tt. Do not modify directly

using System;
using System.Collections.Generic;

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

    }
}

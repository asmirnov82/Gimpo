using System;
using System.Collections.Generic;
using System.Text;
using Gimpo.Data.Analysis.Interfaces;

namespace Gimpo.Data.Analysis
{
    public abstract partial class DataFrameColumn
    {
        #region Column Arithmetic Operators
        public static DataFrameColumn operator +(DataFrameColumn left, DataFrameColumn right)
        {
            if (left is IArithmeticOperationColumn arithmeticColumn)
                return arithmeticColumn.Add(right);

            throw new NotSupportedException();
        }

        public static DataFrameColumn operator -(DataFrameColumn left, DataFrameColumn right)
        {
            if (left is IArithmeticOperationColumn arithmeticColumn)
                return arithmeticColumn.Substract(right);

            throw new NotSupportedException();
        }

        public static DataFrameColumn operator *(DataFrameColumn left, DataFrameColumn right)
        {
            if (left is IArithmeticOperationColumn arithmeticColumn)
                return arithmeticColumn.Multiply(right);

            throw new NotSupportedException();
        }

        public static DataFrameColumn operator /(DataFrameColumn left, DataFrameColumn right)
        {
            if (left is IArithmeticOperationColumn arithmeticColumn)
                return arithmeticColumn.Divide(right);

            throw new NotSupportedException();
        }

        public static DataFrameColumn operator %(DataFrameColumn left, DataFrameColumn right)
        {
            if (left is IArithmeticOperationColumn arithmeticColumn)
                return arithmeticColumn.Multiply(right);

            throw new NotSupportedException();
        }
        #endregion

        #region Scalar operators
        //TODO
        #endregion
    }
}

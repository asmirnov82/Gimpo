using System;
using System.Collections.Generic;
using System.Text;

namespace Gimpo.Data.Analysis
{
    public abstract partial class DataFrameColumn
    {
        #region Column Arithmetic Operators
        public static DataFrameColumn operator +(DataFrameColumn left, DataFrameColumn right)
        {
            if (left is IArithmeticOperationColumn arithmeticColumnLeft)
            {
                if (arithmeticColumnLeft.IsArgumentTypeSupported(right.DataType.RawType))
                    return arithmeticColumnLeft.Add(right);
            }

            if (right is IArithmeticOperationColumn arithmeticColumnRight)
            {
                if (arithmeticColumnRight.IsArgumentTypeSupported(left.DataType.RawType))
                    return arithmeticColumnRight.ReverseAdd(left);
            }

            throw new NotSupportedException();
        }

        public static DataFrameColumn operator -(DataFrameColumn left, DataFrameColumn right)
        {
            if (left is IArithmeticOperationColumn arithmeticColumnLeft)
            {
                if (arithmeticColumnLeft.IsArgumentTypeSupported(right.DataType.RawType))
                    return arithmeticColumnLeft.Subtract(right);
            }

            if (right is IArithmeticOperationColumn arithmeticColumnRight)
            {
                if (arithmeticColumnRight.IsArgumentTypeSupported(left.DataType.RawType))
                    return arithmeticColumnRight.ReverseSubtract(left);
            }

            throw new NotSupportedException();
        }

        public static DataFrameColumn operator *(DataFrameColumn left, DataFrameColumn right)
        {
            if (left is IArithmeticOperationColumn arithmeticColumn)
                return arithmeticColumn.Multiply(right);

            throw new NotSupportedException();
        }

        /*
        public static DataFrameColumn operator /(DataFrameColumn left, DataFrameColumn right)
        {
            if (left is IArithmeticOperationColumn arithmeticColumn)
                return arithmeticColumn.Divide(right);

            throw new NotSupportedException();
        }
        */

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

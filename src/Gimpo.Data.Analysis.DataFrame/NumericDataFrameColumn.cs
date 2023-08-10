using System;
using System.Collections.Generic;
using System.Text;
using Gimpo.Data.Analysis;

namespace Gimpo.Data.Analysis
{
    public abstract class NumericDataFrameColumn<T> : PrimitiveDataFrameColumn<T>, IArithmeticOperationColumn
        where T : unmanaged
    {
        public abstract Type GetResultTypeFor(Type argumentType);

        protected NumericDataFrameColumn(PrimitiveDataFrameColumn<T> column) : base(column)
        {
        }

        public DataFrameColumn Add(DataFrameColumn column)
        {
            var resultType = GetResultTypeFor(column.DataType.RawType);

            if (resultType == null)
            {
                if (column is IArithmeticOperationColumn arithmeticColumn)
                    resultType = arithmeticColumn.GetResultTypeFor(this.DataType.RawType);
            }

            if (resultType == null)
                throw new NotSupportedException(); //TODO exception message

            //Get Arithmetics
            var arithmetics = DataFrame.GetArithmetics(resultType);
            
            arithmetics.Add(I)
            return null;
        }

        public DataFrameColumn Divide(DataFrameColumn column) => throw new NotImplementedException();
        
        public DataFrameColumn Modulo(DataFrameColumn column) => throw new NotImplementedException();
        public DataFrameColumn Multiply(DataFrameColumn column) => throw new NotImplementedException();
        public DataFrameColumn Substract(DataFrameColumn column) => throw new NotImplementedException();
    }
}

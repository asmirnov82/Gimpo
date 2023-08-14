using System;
using System.Collections.Generic;
using System.Text;
using Gimpo.Data.Analysis;

namespace Gimpo.Data.Analysis
{
    public abstract class NumericDataFrameColumn<T> : PrimitiveDataFrameColumn<T>, IArithmeticOperationColumn
        where T : unmanaged
    {
        public abstract bool IsArgumentTypeSupported(Type argumentType);

        public DataFrameColumn Add(DataFrameColumn column, bool inPlace = false) => throw new NotImplementedException();
        public DataFrameColumn ReverseAdd(DataFrameColumn column) => throw new NotImplementedException();

        public DataFrameColumn Substract(DataFrameColumn column, bool inPlace = false) => throw new NotImplementedException();
        public DataFrameColumn ReverseSubstract(DataFrameColumn column) => throw new NotImplementedException();

        public DataFrameColumn Multiply(DataFrameColumn column, bool inPlace = false) => throw new NotImplementedException();
        public DataFrameColumn ReverseMultiply(DataFrameColumn column) => throw new NotImplementedException();

        public DataFrameColumn Divide(DataFrameColumn column, bool inPlace = false) => throw new NotImplementedException();
        public DataFrameColumn ReverseDivide(DataFrameColumn column) => throw new NotImplementedException();

        public DataFrameColumn Modulo(DataFrameColumn column, bool inPlace = false) => throw new NotImplementedException();
        public DataFrameColumn ReverseModulo(DataFrameColumn column) => throw new NotImplementedException();

        protected NumericDataFrameColumn(PrimitiveDataFrameColumn<T> column) : base(column)
        {
        }
    }
}

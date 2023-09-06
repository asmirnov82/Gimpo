using System;
using System.Collections.Generic;
using Gimpo.Data.Primitives;

namespace Gimpo.Data.Analysis
{
    public abstract partial class NumericDataFrameColumn<T> : PrimitiveDataFrameColumn<T>, IArithmeticOperationColumn, INumericColumn
        where T : unmanaged
    {        
        public abstract bool IsArgumentTypeSupported(Type argumentType);

        protected abstract NumericArithmeticComputation<T> ArithmeticComputation { get; }

        #region Constructors
        protected NumericDataFrameColumn(PrimitiveDataFrameColumn<T> column, IEnumerable<long> indicesMap) : base(column, indicesMap)
        { }

        protected NumericDataFrameColumn(string name, long length, bool skipZeroClear) : base(name, length, skipZeroClear)
        { }

        protected NumericDataFrameColumn(NumericDataFrameColumn<T> column) : base(column)
        { }

        protected NumericDataFrameColumn(string name, IEnumerable<T> values) : base(name, values)
        { }

        protected NumericDataFrameColumn(string name, IEnumerable<T?> values) : base(name, values)
        { }
        #endregion

        protected abstract NumericDataFrameColumn<T> CreateNewColumn(string name, long length = 0, bool skipZeroClear = false);

        //protected abstract DataFrameColumn Add(NativeMemoryNullableVector<T> values, bool inPlace = false);
        //protected abstract DataFrameColumn ReserveAdd(NativeMemoryNullableVector<T> values);

        #region IArithmeticOperationColumn implementation
        public DataFrameColumn Add(DataFrameColumn column, bool inPlace = false)
        {            
            /*
            if (column is NumericDataFrameColumn<T> sameTypeColumn)
            {
                return Add(sameTypeColumn._values, inPlace);
            }
            */
                        
            if (column is INumericColumn numeric)
            {
                return numeric.AcceptAddVisitor(this, inPlace);
            }

            throw new NotSupportedException();
        }
               
        public DataFrameColumn ReverseAdd(DataFrameColumn column)
        {
            /*
            if (column is NumericDataFrameColumn<T> sameTypeColumn)
            {
                return ReserveAdd(sameTypeColumn._values);
            }
            */

            if (column is INumericColumn numeric)
            {
                return numeric.AcceptReserveAddVisitor(this);
            }

            throw new NotSupportedException();
        }

        public DataFrameColumn Substract(DataFrameColumn column, bool inPlace = false) => throw new NotImplementedException();
        public DataFrameColumn ReverseSubstract(DataFrameColumn column) => throw new NotImplementedException();

        public DataFrameColumn Multiply(DataFrameColumn column, bool inPlace = false) => throw new NotImplementedException();
        public DataFrameColumn ReverseMultiply(DataFrameColumn column) => throw new NotImplementedException();

        public DataFrameColumn Divide(DataFrameColumn column, bool inPlace = false) => throw new NotImplementedException();
        public DataFrameColumn ReverseDivide(DataFrameColumn column) => throw new NotImplementedException();

        public DataFrameColumn Modulo(DataFrameColumn column, bool inPlace = false) => throw new NotImplementedException();
        public DataFrameColumn ReverseModulo(DataFrameColumn column) => throw new NotImplementedException();
        #endregion

        public abstract DataFrameColumn AcceptAddVisitor(INumericArithmeticComputationVisitor visitor, bool inPlace = false);
        public abstract DataFrameColumn AcceptReserveAddVisitor(INumericArithmeticComputationVisitor visitor);
    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;
using Gimpo.Data.Analysis.Computations;
using Gimpo.Data.Primitives;

namespace Gimpo.Data.Analysis
{
    public abstract class NumericDataFrameColumn<T> : PrimitiveDataFrameColumn<T>, IArithmeticOperationColumn, INumericColumn
        where T : unmanaged
    {
        public abstract bool IsArgumentTypeSupported(Type argumentType);

        #region Constructors
        protected INumericArithmeticComputations Computations { get; }

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

        #region IArithmeticOperationColumn implementation
        public DataFrameColumn Add(DataFrameColumn column, bool inPlace = false)
        {
            if (column is NumericDataFrameColumn<T> sameTypeColumn)
            {
                var result = inPlace ? this : this.CreateNewColumn("", this.Length, true);
                Add(sameTypeColumn._values, result._values);

                return result;
            }
            

            if (column is INumericColumn numeric)
            {
                return numeric.Add<T>(Computations);
            }

            throw new NotSupportedException();
        }
               
        public DataFrameColumn ReverseAdd(DataFrameColumn column) => throw new NotImplementedException();

        public DataFrameColumn Substract(DataFrameColumn column, bool inPlace = false) => throw new NotImplementedException();
        public DataFrameColumn ReverseSubstract(DataFrameColumn column) => throw new NotImplementedException();

        public DataFrameColumn Multiply(DataFrameColumn column, bool inPlace = false) => throw new NotImplementedException();
        public DataFrameColumn ReverseMultiply(DataFrameColumn column) => throw new NotImplementedException();

        public DataFrameColumn Divide(DataFrameColumn column, bool inPlace = false) => throw new NotImplementedException();
        public DataFrameColumn ReverseDivide(DataFrameColumn column) => throw new NotImplementedException();

        public DataFrameColumn Modulo(DataFrameColumn column, bool inPlace = false) => throw new NotImplementedException();
        public DataFrameColumn ReverseModulo(DataFrameColumn column) => throw new NotImplementedException();
        #endregion

        public abstract DataFrameColumn Add<U>(INumericArithmeticComputations computation) where U : unmanaged;

        protected virtual void Add(NativeMemoryNullableVector<T> values, NativeMemoryNullableVector<T> result)
        {
            //TODO
        }
    }
}

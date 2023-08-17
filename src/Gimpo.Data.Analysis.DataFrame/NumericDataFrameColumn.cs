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

        protected abstract INumericArithmeticComputation<T> ArithmeticComputation { get; }

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

        #region IArithmeticOperationColumn implementation
        public DataFrameColumn Add(DataFrameColumn column, bool inPlace = false)
        {            
            /*
            if (column is NumericDataFrameColumn<T> sameTypeColumn)
            {
                Add(sameTypeColumn._values, result._values);

                return result;
            }
            */
            
            if (column is INumericColumn numeric)
            {
                return numeric.AcceptAddVisitor(this, inPlace);
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

        #region INumericColumn
        public abstract DataFrameColumn AcceptAddVisitor(INumericArithmeticComputationVisitor visitor, bool inPlace = false);

        public DataFrameColumn Add(NativeMemoryNullableVector<long> values, bool inPlace = false)
        {
            var result = inPlace ? this : CreateNewColumn("", Length, true);
            ArithmeticComputation.Add(_values, values, result._values);

            return result;
        }

        public DataFrameColumn Add(NativeMemoryNullableVector<int> values, bool inPlace = false) => throw new NotImplementedException();
        public DataFrameColumn Add(NativeMemoryNullableVector<short> values, bool inPlace = false) => throw new NotImplementedException();
        public DataFrameColumn Add(NativeMemoryNullableVector<sbyte> values, bool inPlace = false) => throw new NotImplementedException();
        public DataFrameColumn Add(NativeMemoryNullableVector<ulong> values, bool inPlace = false) => throw new NotImplementedException();
        public DataFrameColumn Add(NativeMemoryNullableVector<uint> values, bool inPlace = false) => throw new NotImplementedException();
        public DataFrameColumn Add(NativeMemoryNullableVector<ushort> values, bool inPlace = false) => throw new NotImplementedException();
        public DataFrameColumn Add(NativeMemoryNullableVector<byte> values, bool inPlace = false) => throw new NotImplementedException();
        public DataFrameColumn Add(NativeMemoryNullableVector<double> values, bool inPlace = false) => throw new NotImplementedException();
        public DataFrameColumn Add(NativeMemoryNullableVector<float> values, bool inPlace = false) => throw new NotImplementedException();
        #endregion

        /*
        protected virtual void Add(NativeMemoryNullableVector<T> values, NativeMemoryNullableVector<T> result)
        {
            //naive implementation
            if (this._values.Length != values.Length || this._values.Length != result.Length)
                throw new Exception(); //TODO correct exception type and message

            for (long i = 0; i < _values.Length; i++)
            {
                var left = _values[i];
                var right = values[i];

                if (left.HasValue && right.HasValue)
                {
                    //result[i] = left + right;
                }
            }

            //TODO SIMD implementation
        }
        */
    }
}

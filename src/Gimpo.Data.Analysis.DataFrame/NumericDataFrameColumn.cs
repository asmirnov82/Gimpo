using System;
using System.Collections.Generic;

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
                                       
        public abstract DataFrameColumn AcceptNumericArithmeticVisitor (INumericArithmeticVisitor visitor, ArithmeticOperation operation, bool inPlace = false);
        public abstract DataFrameColumn AcceptReverseNumericArithmeticVisitor(INumericArithmeticVisitor visitor, ArithmeticOperation operation);
        
    }
}



// Generated from NumericDataFrameColumn.Arithmetic.tt. Do not modify directly
using System;
using System.Collections.Generic;
using Gimpo.Data.Primitives;

namespace Gimpo.Data.Analysis
{
    public abstract partial class NumericDataFrameColumn<T>
    {

         protected abstract DataFrameColumn Compute(NativeMemoryNullableVector<T> values, ArithmeticOperation operation, bool inPlace = false);
         
        #region IArithmeticOperationColumn implementation
        public DataFrameColumn Add(DataFrameColumn column, bool inPlace = false)
        {            
            if (column is NumericDataFrameColumn<T> sameTypeColumn)
            {
                return Compute(sameTypeColumn._values, ArithmeticOperation.Add, inPlace);
            }
                                    
            if (column is INumericColumn numeric)
            {
                return numeric.AcceptNumericArithmeticVisitor(this, ArithmeticOperation.Add, inPlace);
            }

            throw new NotSupportedException();
        }

        public DataFrameColumn ReverseAdd(DataFrameColumn column)
        {            
            if (column is INumericColumn numeric)
            {
                return numeric.AcceptReverseNumericArithmeticVisitor(this, ArithmeticOperation.Add);
            }

            throw new NotSupportedException();
        }

        public DataFrameColumn Substract(DataFrameColumn column, bool inPlace = false)
        {            
            if (column is NumericDataFrameColumn<T> sameTypeColumn)
            {
                return Compute(sameTypeColumn._values, ArithmeticOperation.Substract, inPlace);
            }
                                    
            if (column is INumericColumn numeric)
            {
                return numeric.AcceptNumericArithmeticVisitor(this, ArithmeticOperation.Substract, inPlace);
            }

            throw new NotSupportedException();
        }

        public DataFrameColumn ReverseSubstract(DataFrameColumn column)
        {            
            if (column is INumericColumn numeric)
            {
                return numeric.AcceptReverseNumericArithmeticVisitor(this, ArithmeticOperation.Substract);
            }

            throw new NotSupportedException();
        }

        public DataFrameColumn Multiply(DataFrameColumn column, bool inPlace = false)
        {            
            if (column is NumericDataFrameColumn<T> sameTypeColumn)
            {
                return Compute(sameTypeColumn._values, ArithmeticOperation.Multiply, inPlace);
            }
                                    
            if (column is INumericColumn numeric)
            {
                return numeric.AcceptNumericArithmeticVisitor(this, ArithmeticOperation.Multiply, inPlace);
            }

            throw new NotSupportedException();
        }

        public DataFrameColumn ReverseMultiply(DataFrameColumn column)
        {            
            if (column is INumericColumn numeric)
            {
                return numeric.AcceptReverseNumericArithmeticVisitor(this, ArithmeticOperation.Multiply);
            }

            throw new NotSupportedException();
        }

        public DataFrameColumn Divide(DataFrameColumn column, bool inPlace = false)
        {            
            if (column is NumericDataFrameColumn<T> sameTypeColumn)
            {
                return Compute(sameTypeColumn._values, ArithmeticOperation.Divide, inPlace);
            }
                                    
            if (column is INumericColumn numeric)
            {
                return numeric.AcceptNumericArithmeticVisitor(this, ArithmeticOperation.Divide, inPlace);
            }

            throw new NotSupportedException();
        }

        public DataFrameColumn ReverseDivide(DataFrameColumn column)
        {            
            if (column is INumericColumn numeric)
            {
                return numeric.AcceptReverseNumericArithmeticVisitor(this, ArithmeticOperation.Divide);
            }

            throw new NotSupportedException();
        }

    #endregion

        DataFrameColumn INumericArithmeticVisitor.Visit(NativeMemoryNullableVector<double> values, ArithmeticOperation operation, bool inPlace)
        {
            NumericDataFrameColumn<T> result;
            switch (operation)
            {
                case ArithmeticOperation.Add:
                    result = inPlace ? this : CreateNewColumn("Add", Length, true);
                    ArithmeticComputation.Add(_values, values, result._values);
                    return result;
                 case ArithmeticOperation.Substract:
                    result = inPlace ? this : CreateNewColumn("Substract", Length, true);
                    ArithmeticComputation.Substract(_values, values, result._values);
                    return result;
                 case ArithmeticOperation.Multiply:
                    result = inPlace ? this : CreateNewColumn("Multiply", Length, true);
                    ArithmeticComputation.Multiply(_values, values, result._values);
                    return result;
                 case ArithmeticOperation.Divide:
                    result = inPlace ? this : CreateNewColumn("Divide", Length, true);
                    ArithmeticComputation.Divide(_values, values, result._values);
                    return result;
 
                default: throw new NotSupportedException();
            }
        }

        DataFrameColumn INumericArithmeticVisitor.ReverseVisit(NativeMemoryNullableVector<double> values, ArithmeticOperation operation)
        {
            NumericDataFrameColumn<T> result;
            switch (operation)
            {
            case ArithmeticOperation.Add:
                    result = CreateNewColumn("Add", Length, true);
                    ArithmeticComputation.ReverseAdd(values, _values, result._values);
                    return result;
             case ArithmeticOperation.Substract:
                    result = CreateNewColumn("Substract", Length, true);
                    ArithmeticComputation.ReverseSubstract(values, _values, result._values);
                    return result;
             case ArithmeticOperation.Multiply:
                    result = CreateNewColumn("Multiply", Length, true);
                    ArithmeticComputation.ReverseMultiply(values, _values, result._values);
                    return result;
             case ArithmeticOperation.Divide:
                    result = CreateNewColumn("Divide", Length, true);
                    ArithmeticComputation.ReverseDivide(values, _values, result._values);
                    return result;
 
                default: throw new NotSupportedException();
            }
        }

        DataFrameColumn INumericArithmeticVisitor.Visit(NativeMemoryNullableVector<float> values, ArithmeticOperation operation, bool inPlace)
        {
            NumericDataFrameColumn<T> result;
            switch (operation)
            {
                case ArithmeticOperation.Add:
                    result = inPlace ? this : CreateNewColumn("Add", Length, true);
                    ArithmeticComputation.Add(_values, values, result._values);
                    return result;
                 case ArithmeticOperation.Substract:
                    result = inPlace ? this : CreateNewColumn("Substract", Length, true);
                    ArithmeticComputation.Substract(_values, values, result._values);
                    return result;
                 case ArithmeticOperation.Multiply:
                    result = inPlace ? this : CreateNewColumn("Multiply", Length, true);
                    ArithmeticComputation.Multiply(_values, values, result._values);
                    return result;
                 case ArithmeticOperation.Divide:
                    result = inPlace ? this : CreateNewColumn("Divide", Length, true);
                    ArithmeticComputation.Divide(_values, values, result._values);
                    return result;
 
                default: throw new NotSupportedException();
            }
        }

        DataFrameColumn INumericArithmeticVisitor.ReverseVisit(NativeMemoryNullableVector<float> values, ArithmeticOperation operation)
        {
            NumericDataFrameColumn<T> result;
            switch (operation)
            {
            case ArithmeticOperation.Add:
                    result = CreateNewColumn("Add", Length, true);
                    ArithmeticComputation.ReverseAdd(values, _values, result._values);
                    return result;
             case ArithmeticOperation.Substract:
                    result = CreateNewColumn("Substract", Length, true);
                    ArithmeticComputation.ReverseSubstract(values, _values, result._values);
                    return result;
             case ArithmeticOperation.Multiply:
                    result = CreateNewColumn("Multiply", Length, true);
                    ArithmeticComputation.ReverseMultiply(values, _values, result._values);
                    return result;
             case ArithmeticOperation.Divide:
                    result = CreateNewColumn("Divide", Length, true);
                    ArithmeticComputation.ReverseDivide(values, _values, result._values);
                    return result;
 
                default: throw new NotSupportedException();
            }
        }

        DataFrameColumn INumericArithmeticVisitor.Visit(NativeMemoryNullableVector<sbyte> values, ArithmeticOperation operation, bool inPlace)
        {
            NumericDataFrameColumn<T> result;
            switch (operation)
            {
                case ArithmeticOperation.Add:
                    result = inPlace ? this : CreateNewColumn("Add", Length, true);
                    ArithmeticComputation.Add(_values, values, result._values);
                    return result;
                 case ArithmeticOperation.Substract:
                    result = inPlace ? this : CreateNewColumn("Substract", Length, true);
                    ArithmeticComputation.Substract(_values, values, result._values);
                    return result;
                 case ArithmeticOperation.Multiply:
                    result = inPlace ? this : CreateNewColumn("Multiply", Length, true);
                    ArithmeticComputation.Multiply(_values, values, result._values);
                    return result;
                 case ArithmeticOperation.Divide:
                    result = inPlace ? this : CreateNewColumn("Divide", Length, true);
                    ArithmeticComputation.Divide(_values, values, result._values);
                    return result;
 
                default: throw new NotSupportedException();
            }
        }

        DataFrameColumn INumericArithmeticVisitor.ReverseVisit(NativeMemoryNullableVector<sbyte> values, ArithmeticOperation operation)
        {
            NumericDataFrameColumn<T> result;
            switch (operation)
            {
            case ArithmeticOperation.Add:
                    result = CreateNewColumn("Add", Length, true);
                    ArithmeticComputation.ReverseAdd(values, _values, result._values);
                    return result;
             case ArithmeticOperation.Substract:
                    result = CreateNewColumn("Substract", Length, true);
                    ArithmeticComputation.ReverseSubstract(values, _values, result._values);
                    return result;
             case ArithmeticOperation.Multiply:
                    result = CreateNewColumn("Multiply", Length, true);
                    ArithmeticComputation.ReverseMultiply(values, _values, result._values);
                    return result;
             case ArithmeticOperation.Divide:
                    result = CreateNewColumn("Divide", Length, true);
                    ArithmeticComputation.ReverseDivide(values, _values, result._values);
                    return result;
 
                default: throw new NotSupportedException();
            }
        }

        DataFrameColumn INumericArithmeticVisitor.Visit(NativeMemoryNullableVector<byte> values, ArithmeticOperation operation, bool inPlace)
        {
            NumericDataFrameColumn<T> result;
            switch (operation)
            {
                case ArithmeticOperation.Add:
                    result = inPlace ? this : CreateNewColumn("Add", Length, true);
                    ArithmeticComputation.Add(_values, values, result._values);
                    return result;
                 case ArithmeticOperation.Substract:
                    result = inPlace ? this : CreateNewColumn("Substract", Length, true);
                    ArithmeticComputation.Substract(_values, values, result._values);
                    return result;
                 case ArithmeticOperation.Multiply:
                    result = inPlace ? this : CreateNewColumn("Multiply", Length, true);
                    ArithmeticComputation.Multiply(_values, values, result._values);
                    return result;
                 case ArithmeticOperation.Divide:
                    result = inPlace ? this : CreateNewColumn("Divide", Length, true);
                    ArithmeticComputation.Divide(_values, values, result._values);
                    return result;
 
                default: throw new NotSupportedException();
            }
        }

        DataFrameColumn INumericArithmeticVisitor.ReverseVisit(NativeMemoryNullableVector<byte> values, ArithmeticOperation operation)
        {
            NumericDataFrameColumn<T> result;
            switch (operation)
            {
            case ArithmeticOperation.Add:
                    result = CreateNewColumn("Add", Length, true);
                    ArithmeticComputation.ReverseAdd(values, _values, result._values);
                    return result;
             case ArithmeticOperation.Substract:
                    result = CreateNewColumn("Substract", Length, true);
                    ArithmeticComputation.ReverseSubstract(values, _values, result._values);
                    return result;
             case ArithmeticOperation.Multiply:
                    result = CreateNewColumn("Multiply", Length, true);
                    ArithmeticComputation.ReverseMultiply(values, _values, result._values);
                    return result;
             case ArithmeticOperation.Divide:
                    result = CreateNewColumn("Divide", Length, true);
                    ArithmeticComputation.ReverseDivide(values, _values, result._values);
                    return result;
 
                default: throw new NotSupportedException();
            }
        }

        DataFrameColumn INumericArithmeticVisitor.Visit(NativeMemoryNullableVector<short> values, ArithmeticOperation operation, bool inPlace)
        {
            NumericDataFrameColumn<T> result;
            switch (operation)
            {
                case ArithmeticOperation.Add:
                    result = inPlace ? this : CreateNewColumn("Add", Length, true);
                    ArithmeticComputation.Add(_values, values, result._values);
                    return result;
                 case ArithmeticOperation.Substract:
                    result = inPlace ? this : CreateNewColumn("Substract", Length, true);
                    ArithmeticComputation.Substract(_values, values, result._values);
                    return result;
                 case ArithmeticOperation.Multiply:
                    result = inPlace ? this : CreateNewColumn("Multiply", Length, true);
                    ArithmeticComputation.Multiply(_values, values, result._values);
                    return result;
                 case ArithmeticOperation.Divide:
                    result = inPlace ? this : CreateNewColumn("Divide", Length, true);
                    ArithmeticComputation.Divide(_values, values, result._values);
                    return result;
 
                default: throw new NotSupportedException();
            }
        }

        DataFrameColumn INumericArithmeticVisitor.ReverseVisit(NativeMemoryNullableVector<short> values, ArithmeticOperation operation)
        {
            NumericDataFrameColumn<T> result;
            switch (operation)
            {
            case ArithmeticOperation.Add:
                    result = CreateNewColumn("Add", Length, true);
                    ArithmeticComputation.ReverseAdd(values, _values, result._values);
                    return result;
             case ArithmeticOperation.Substract:
                    result = CreateNewColumn("Substract", Length, true);
                    ArithmeticComputation.ReverseSubstract(values, _values, result._values);
                    return result;
             case ArithmeticOperation.Multiply:
                    result = CreateNewColumn("Multiply", Length, true);
                    ArithmeticComputation.ReverseMultiply(values, _values, result._values);
                    return result;
             case ArithmeticOperation.Divide:
                    result = CreateNewColumn("Divide", Length, true);
                    ArithmeticComputation.ReverseDivide(values, _values, result._values);
                    return result;
 
                default: throw new NotSupportedException();
            }
        }

        DataFrameColumn INumericArithmeticVisitor.Visit(NativeMemoryNullableVector<ushort> values, ArithmeticOperation operation, bool inPlace)
        {
            NumericDataFrameColumn<T> result;
            switch (operation)
            {
                case ArithmeticOperation.Add:
                    result = inPlace ? this : CreateNewColumn("Add", Length, true);
                    ArithmeticComputation.Add(_values, values, result._values);
                    return result;
                 case ArithmeticOperation.Substract:
                    result = inPlace ? this : CreateNewColumn("Substract", Length, true);
                    ArithmeticComputation.Substract(_values, values, result._values);
                    return result;
                 case ArithmeticOperation.Multiply:
                    result = inPlace ? this : CreateNewColumn("Multiply", Length, true);
                    ArithmeticComputation.Multiply(_values, values, result._values);
                    return result;
                 case ArithmeticOperation.Divide:
                    result = inPlace ? this : CreateNewColumn("Divide", Length, true);
                    ArithmeticComputation.Divide(_values, values, result._values);
                    return result;
 
                default: throw new NotSupportedException();
            }
        }

        DataFrameColumn INumericArithmeticVisitor.ReverseVisit(NativeMemoryNullableVector<ushort> values, ArithmeticOperation operation)
        {
            NumericDataFrameColumn<T> result;
            switch (operation)
            {
            case ArithmeticOperation.Add:
                    result = CreateNewColumn("Add", Length, true);
                    ArithmeticComputation.ReverseAdd(values, _values, result._values);
                    return result;
             case ArithmeticOperation.Substract:
                    result = CreateNewColumn("Substract", Length, true);
                    ArithmeticComputation.ReverseSubstract(values, _values, result._values);
                    return result;
             case ArithmeticOperation.Multiply:
                    result = CreateNewColumn("Multiply", Length, true);
                    ArithmeticComputation.ReverseMultiply(values, _values, result._values);
                    return result;
             case ArithmeticOperation.Divide:
                    result = CreateNewColumn("Divide", Length, true);
                    ArithmeticComputation.ReverseDivide(values, _values, result._values);
                    return result;
 
                default: throw new NotSupportedException();
            }
        }

        DataFrameColumn INumericArithmeticVisitor.Visit(NativeMemoryNullableVector<int> values, ArithmeticOperation operation, bool inPlace)
        {
            NumericDataFrameColumn<T> result;
            switch (operation)
            {
                case ArithmeticOperation.Add:
                    result = inPlace ? this : CreateNewColumn("Add", Length, true);
                    ArithmeticComputation.Add(_values, values, result._values);
                    return result;
                 case ArithmeticOperation.Substract:
                    result = inPlace ? this : CreateNewColumn("Substract", Length, true);
                    ArithmeticComputation.Substract(_values, values, result._values);
                    return result;
                 case ArithmeticOperation.Multiply:
                    result = inPlace ? this : CreateNewColumn("Multiply", Length, true);
                    ArithmeticComputation.Multiply(_values, values, result._values);
                    return result;
                 case ArithmeticOperation.Divide:
                    result = inPlace ? this : CreateNewColumn("Divide", Length, true);
                    ArithmeticComputation.Divide(_values, values, result._values);
                    return result;
 
                default: throw new NotSupportedException();
            }
        }

        DataFrameColumn INumericArithmeticVisitor.ReverseVisit(NativeMemoryNullableVector<int> values, ArithmeticOperation operation)
        {
            NumericDataFrameColumn<T> result;
            switch (operation)
            {
            case ArithmeticOperation.Add:
                    result = CreateNewColumn("Add", Length, true);
                    ArithmeticComputation.ReverseAdd(values, _values, result._values);
                    return result;
             case ArithmeticOperation.Substract:
                    result = CreateNewColumn("Substract", Length, true);
                    ArithmeticComputation.ReverseSubstract(values, _values, result._values);
                    return result;
             case ArithmeticOperation.Multiply:
                    result = CreateNewColumn("Multiply", Length, true);
                    ArithmeticComputation.ReverseMultiply(values, _values, result._values);
                    return result;
             case ArithmeticOperation.Divide:
                    result = CreateNewColumn("Divide", Length, true);
                    ArithmeticComputation.ReverseDivide(values, _values, result._values);
                    return result;
 
                default: throw new NotSupportedException();
            }
        }

        DataFrameColumn INumericArithmeticVisitor.Visit(NativeMemoryNullableVector<uint> values, ArithmeticOperation operation, bool inPlace)
        {
            NumericDataFrameColumn<T> result;
            switch (operation)
            {
                case ArithmeticOperation.Add:
                    result = inPlace ? this : CreateNewColumn("Add", Length, true);
                    ArithmeticComputation.Add(_values, values, result._values);
                    return result;
                 case ArithmeticOperation.Substract:
                    result = inPlace ? this : CreateNewColumn("Substract", Length, true);
                    ArithmeticComputation.Substract(_values, values, result._values);
                    return result;
                 case ArithmeticOperation.Multiply:
                    result = inPlace ? this : CreateNewColumn("Multiply", Length, true);
                    ArithmeticComputation.Multiply(_values, values, result._values);
                    return result;
                 case ArithmeticOperation.Divide:
                    result = inPlace ? this : CreateNewColumn("Divide", Length, true);
                    ArithmeticComputation.Divide(_values, values, result._values);
                    return result;
 
                default: throw new NotSupportedException();
            }
        }

        DataFrameColumn INumericArithmeticVisitor.ReverseVisit(NativeMemoryNullableVector<uint> values, ArithmeticOperation operation)
        {
            NumericDataFrameColumn<T> result;
            switch (operation)
            {
            case ArithmeticOperation.Add:
                    result = CreateNewColumn("Add", Length, true);
                    ArithmeticComputation.ReverseAdd(values, _values, result._values);
                    return result;
             case ArithmeticOperation.Substract:
                    result = CreateNewColumn("Substract", Length, true);
                    ArithmeticComputation.ReverseSubstract(values, _values, result._values);
                    return result;
             case ArithmeticOperation.Multiply:
                    result = CreateNewColumn("Multiply", Length, true);
                    ArithmeticComputation.ReverseMultiply(values, _values, result._values);
                    return result;
             case ArithmeticOperation.Divide:
                    result = CreateNewColumn("Divide", Length, true);
                    ArithmeticComputation.ReverseDivide(values, _values, result._values);
                    return result;
 
                default: throw new NotSupportedException();
            }
        }

        DataFrameColumn INumericArithmeticVisitor.Visit(NativeMemoryNullableVector<long> values, ArithmeticOperation operation, bool inPlace)
        {
            NumericDataFrameColumn<T> result;
            switch (operation)
            {
                case ArithmeticOperation.Add:
                    result = inPlace ? this : CreateNewColumn("Add", Length, true);
                    ArithmeticComputation.Add(_values, values, result._values);
                    return result;
                 case ArithmeticOperation.Substract:
                    result = inPlace ? this : CreateNewColumn("Substract", Length, true);
                    ArithmeticComputation.Substract(_values, values, result._values);
                    return result;
                 case ArithmeticOperation.Multiply:
                    result = inPlace ? this : CreateNewColumn("Multiply", Length, true);
                    ArithmeticComputation.Multiply(_values, values, result._values);
                    return result;
                 case ArithmeticOperation.Divide:
                    result = inPlace ? this : CreateNewColumn("Divide", Length, true);
                    ArithmeticComputation.Divide(_values, values, result._values);
                    return result;
 
                default: throw new NotSupportedException();
            }
        }

        DataFrameColumn INumericArithmeticVisitor.ReverseVisit(NativeMemoryNullableVector<long> values, ArithmeticOperation operation)
        {
            NumericDataFrameColumn<T> result;
            switch (operation)
            {
            case ArithmeticOperation.Add:
                    result = CreateNewColumn("Add", Length, true);
                    ArithmeticComputation.ReverseAdd(values, _values, result._values);
                    return result;
             case ArithmeticOperation.Substract:
                    result = CreateNewColumn("Substract", Length, true);
                    ArithmeticComputation.ReverseSubstract(values, _values, result._values);
                    return result;
             case ArithmeticOperation.Multiply:
                    result = CreateNewColumn("Multiply", Length, true);
                    ArithmeticComputation.ReverseMultiply(values, _values, result._values);
                    return result;
             case ArithmeticOperation.Divide:
                    result = CreateNewColumn("Divide", Length, true);
                    ArithmeticComputation.ReverseDivide(values, _values, result._values);
                    return result;
 
                default: throw new NotSupportedException();
            }
        }

        DataFrameColumn INumericArithmeticVisitor.Visit(NativeMemoryNullableVector<ulong> values, ArithmeticOperation operation, bool inPlace)
        {
            NumericDataFrameColumn<T> result;
            switch (operation)
            {
                case ArithmeticOperation.Add:
                    result = inPlace ? this : CreateNewColumn("Add", Length, true);
                    ArithmeticComputation.Add(_values, values, result._values);
                    return result;
                 case ArithmeticOperation.Substract:
                    result = inPlace ? this : CreateNewColumn("Substract", Length, true);
                    ArithmeticComputation.Substract(_values, values, result._values);
                    return result;
                 case ArithmeticOperation.Multiply:
                    result = inPlace ? this : CreateNewColumn("Multiply", Length, true);
                    ArithmeticComputation.Multiply(_values, values, result._values);
                    return result;
                 case ArithmeticOperation.Divide:
                    result = inPlace ? this : CreateNewColumn("Divide", Length, true);
                    ArithmeticComputation.Divide(_values, values, result._values);
                    return result;
 
                default: throw new NotSupportedException();
            }
        }

        DataFrameColumn INumericArithmeticVisitor.ReverseVisit(NativeMemoryNullableVector<ulong> values, ArithmeticOperation operation)
        {
            NumericDataFrameColumn<T> result;
            switch (operation)
            {
            case ArithmeticOperation.Add:
                    result = CreateNewColumn("Add", Length, true);
                    ArithmeticComputation.ReverseAdd(values, _values, result._values);
                    return result;
             case ArithmeticOperation.Substract:
                    result = CreateNewColumn("Substract", Length, true);
                    ArithmeticComputation.ReverseSubstract(values, _values, result._values);
                    return result;
             case ArithmeticOperation.Multiply:
                    result = CreateNewColumn("Multiply", Length, true);
                    ArithmeticComputation.ReverseMultiply(values, _values, result._values);
                    return result;
             case ArithmeticOperation.Divide:
                    result = CreateNewColumn("Divide", Length, true);
                    ArithmeticComputation.ReverseDivide(values, _values, result._values);
                    return result;
 
                default: throw new NotSupportedException();
            }
        }


    }
}

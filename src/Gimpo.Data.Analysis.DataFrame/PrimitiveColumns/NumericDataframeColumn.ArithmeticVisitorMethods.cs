
// Generated from NumericDataFrameColumn.ArithmeticVisitorMethods.tt. Do not modify directly

using System;
using System.Collections.Generic;
using Gimpo.Data.Primitives;

namespace Gimpo.Data.Analysis
{
    public abstract partial class NumericDataFrameColumn<T>
    {
        DataFrameColumn INumericArithmeticComputationVisitor.Add(NativeMemoryNullableVector<double> values, bool inPlace)
        {
            var result = inPlace ? this : CreateNewColumn("Add", Length, true);
            ArithmeticComputation.Add(_values, values, result._values);

            return result;
        }

        DataFrameColumn INumericArithmeticComputationVisitor.ReverseAdd(NativeMemoryNullableVector<double> values)
        {
            var result = CreateNewColumn("Add", Length, true);
            ArithmeticComputation.ReverseAdd(values, _values, result._values);

            return result;
        }

        DataFrameColumn INumericArithmeticComputationVisitor.Add(NativeMemoryNullableVector<float> values, bool inPlace)
        {
            var result = inPlace ? this : CreateNewColumn("Add", Length, true);
            ArithmeticComputation.Add(_values, values, result._values);

            return result;
        }

        DataFrameColumn INumericArithmeticComputationVisitor.ReverseAdd(NativeMemoryNullableVector<float> values)
        {
            var result = CreateNewColumn("Add", Length, true);
            ArithmeticComputation.ReverseAdd(values, _values, result._values);

            return result;
        }

        DataFrameColumn INumericArithmeticComputationVisitor.Add(NativeMemoryNullableVector<sbyte> values, bool inPlace)
        {
            var result = inPlace ? this : CreateNewColumn("Add", Length, true);
            ArithmeticComputation.Add(_values, values, result._values);

            return result;
        }

        DataFrameColumn INumericArithmeticComputationVisitor.ReverseAdd(NativeMemoryNullableVector<sbyte> values)
        {
            var result = CreateNewColumn("Add", Length, true);
            ArithmeticComputation.ReverseAdd(values, _values, result._values);

            return result;
        }

        DataFrameColumn INumericArithmeticComputationVisitor.Add(NativeMemoryNullableVector<byte> values, bool inPlace)
        {
            var result = inPlace ? this : CreateNewColumn("Add", Length, true);
            ArithmeticComputation.Add(_values, values, result._values);

            return result;
        }

        DataFrameColumn INumericArithmeticComputationVisitor.ReverseAdd(NativeMemoryNullableVector<byte> values)
        {
            var result = CreateNewColumn("Add", Length, true);
            ArithmeticComputation.ReverseAdd(values, _values, result._values);

            return result;
        }

        DataFrameColumn INumericArithmeticComputationVisitor.Add(NativeMemoryNullableVector<short> values, bool inPlace)
        {
            var result = inPlace ? this : CreateNewColumn("Add", Length, true);
            ArithmeticComputation.Add(_values, values, result._values);

            return result;
        }

        DataFrameColumn INumericArithmeticComputationVisitor.ReverseAdd(NativeMemoryNullableVector<short> values)
        {
            var result = CreateNewColumn("Add", Length, true);
            ArithmeticComputation.ReverseAdd(values, _values, result._values);

            return result;
        }

        DataFrameColumn INumericArithmeticComputationVisitor.Add(NativeMemoryNullableVector<ushort> values, bool inPlace)
        {
            var result = inPlace ? this : CreateNewColumn("Add", Length, true);
            ArithmeticComputation.Add(_values, values, result._values);

            return result;
        }

        DataFrameColumn INumericArithmeticComputationVisitor.ReverseAdd(NativeMemoryNullableVector<ushort> values)
        {
            var result = CreateNewColumn("Add", Length, true);
            ArithmeticComputation.ReverseAdd(values, _values, result._values);

            return result;
        }

        DataFrameColumn INumericArithmeticComputationVisitor.Add(NativeMemoryNullableVector<int> values, bool inPlace)
        {
            var result = inPlace ? this : CreateNewColumn("Add", Length, true);
            ArithmeticComputation.Add(_values, values, result._values);

            return result;
        }

        DataFrameColumn INumericArithmeticComputationVisitor.ReverseAdd(NativeMemoryNullableVector<int> values)
        {
            var result = CreateNewColumn("Add", Length, true);
            ArithmeticComputation.ReverseAdd(values, _values, result._values);

            return result;
        }

        DataFrameColumn INumericArithmeticComputationVisitor.Add(NativeMemoryNullableVector<uint> values, bool inPlace)
        {
            var result = inPlace ? this : CreateNewColumn("Add", Length, true);
            ArithmeticComputation.Add(_values, values, result._values);

            return result;
        }

        DataFrameColumn INumericArithmeticComputationVisitor.ReverseAdd(NativeMemoryNullableVector<uint> values)
        {
            var result = CreateNewColumn("Add", Length, true);
            ArithmeticComputation.ReverseAdd(values, _values, result._values);

            return result;
        }

        DataFrameColumn INumericArithmeticComputationVisitor.Add(NativeMemoryNullableVector<long> values, bool inPlace)
        {
            var result = inPlace ? this : CreateNewColumn("Add", Length, true);
            ArithmeticComputation.Add(_values, values, result._values);

            return result;
        }

        DataFrameColumn INumericArithmeticComputationVisitor.ReverseAdd(NativeMemoryNullableVector<long> values)
        {
            var result = CreateNewColumn("Add", Length, true);
            ArithmeticComputation.ReverseAdd(values, _values, result._values);

            return result;
        }

        DataFrameColumn INumericArithmeticComputationVisitor.Add(NativeMemoryNullableVector<ulong> values, bool inPlace)
        {
            var result = inPlace ? this : CreateNewColumn("Add", Length, true);
            ArithmeticComputation.Add(_values, values, result._values);

            return result;
        }

        DataFrameColumn INumericArithmeticComputationVisitor.ReverseAdd(NativeMemoryNullableVector<ulong> values)
        {
            var result = CreateNewColumn("Add", Length, true);
            ArithmeticComputation.ReverseAdd(values, _values, result._values);

            return result;
        }

    }
}

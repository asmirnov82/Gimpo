

// Generated from INumericArithmeticVisitor.tt. Do not modify directly

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Gimpo.Data.Primitives;

namespace Gimpo.Data.Analysis
{
    public interface INumericArithmeticVisitor
    {
        DataFrameColumn Visit(NativeMemoryNullableVector<double> values, ArithmeticOperation operation, bool inPlace = false);
        DataFrameColumn Visit(NativeMemoryNullableVector<float> values, ArithmeticOperation operation, bool inPlace = false);
        DataFrameColumn Visit(NativeMemoryNullableVector<sbyte> values, ArithmeticOperation operation, bool inPlace = false);
        DataFrameColumn Visit(NativeMemoryNullableVector<byte> values, ArithmeticOperation operation, bool inPlace = false);
        DataFrameColumn Visit(NativeMemoryNullableVector<short> values, ArithmeticOperation operation, bool inPlace = false);
        DataFrameColumn Visit(NativeMemoryNullableVector<ushort> values, ArithmeticOperation operation, bool inPlace = false);
        DataFrameColumn Visit(NativeMemoryNullableVector<int> values, ArithmeticOperation operation, bool inPlace = false);
        DataFrameColumn Visit(NativeMemoryNullableVector<uint> values, ArithmeticOperation operation, bool inPlace = false);
        DataFrameColumn Visit(NativeMemoryNullableVector<long> values, ArithmeticOperation operation, bool inPlace = false);
        DataFrameColumn Visit(NativeMemoryNullableVector<ulong> values, ArithmeticOperation operation, bool inPlace = false);

        DataFrameColumn ReverseVisit(NativeMemoryNullableVector<double> values, ArithmeticOperation operation);
        DataFrameColumn ReverseVisit(NativeMemoryNullableVector<float> values, ArithmeticOperation operation);
        DataFrameColumn ReverseVisit(NativeMemoryNullableVector<sbyte> values, ArithmeticOperation operation);
        DataFrameColumn ReverseVisit(NativeMemoryNullableVector<byte> values, ArithmeticOperation operation);
        DataFrameColumn ReverseVisit(NativeMemoryNullableVector<short> values, ArithmeticOperation operation);
        DataFrameColumn ReverseVisit(NativeMemoryNullableVector<ushort> values, ArithmeticOperation operation);
        DataFrameColumn ReverseVisit(NativeMemoryNullableVector<int> values, ArithmeticOperation operation);
        DataFrameColumn ReverseVisit(NativeMemoryNullableVector<uint> values, ArithmeticOperation operation);
        DataFrameColumn ReverseVisit(NativeMemoryNullableVector<long> values, ArithmeticOperation operation);
        DataFrameColumn ReverseVisit(NativeMemoryNullableVector<ulong> values, ArithmeticOperation operation);
    }
}

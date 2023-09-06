using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Gimpo.Data.Primitives;

namespace Gimpo.Data.Analysis
{
    public interface INumericArithmeticComputationVisitor
    {
        DataFrameColumn Add (NativeMemoryNullableVector<long> values, bool inPlace = false);
        DataFrameColumn Add (NativeMemoryNullableVector<int> values, bool inPlace = false);
        DataFrameColumn Add (NativeMemoryNullableVector<short> values, bool inPlace = false);
        DataFrameColumn Add (NativeMemoryNullableVector<sbyte> values, bool inPlace = false);

        DataFrameColumn Add (NativeMemoryNullableVector<ulong> values, bool inPlace = false);
        DataFrameColumn Add (NativeMemoryNullableVector<uint> values, bool inPlace = false);
        DataFrameColumn Add (NativeMemoryNullableVector<ushort> values, bool inPlace = false);
        DataFrameColumn Add (NativeMemoryNullableVector<byte> values, bool inPlace = false);

        DataFrameColumn Add (NativeMemoryNullableVector<double> values, bool inPlace = false);
        DataFrameColumn Add (NativeMemoryNullableVector<float> values, bool inPlace = false);

        DataFrameColumn ReserveAdd(NativeMemoryNullableVector<long> values);
        DataFrameColumn ReserveAdd(NativeMemoryNullableVector<int> values);
        DataFrameColumn ReserveAdd(NativeMemoryNullableVector<short> values);
        DataFrameColumn ReserveAdd(NativeMemoryNullableVector<sbyte> values);

        DataFrameColumn ReserveAdd(NativeMemoryNullableVector<ulong> values);
        DataFrameColumn ReserveAdd(NativeMemoryNullableVector<uint> values);
        DataFrameColumn ReserveAdd(NativeMemoryNullableVector<ushort> values);
        DataFrameColumn ReserveAdd(NativeMemoryNullableVector<byte> values);

        DataFrameColumn ReserveAdd(NativeMemoryNullableVector<double> values);
        DataFrameColumn ReserveAdd(NativeMemoryNullableVector<float> values);
    }
}

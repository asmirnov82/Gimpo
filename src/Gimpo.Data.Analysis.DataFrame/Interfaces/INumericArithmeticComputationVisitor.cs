﻿using System;
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

        DataFrameColumn ReverseAdd(NativeMemoryNullableVector<long> values);
        DataFrameColumn ReverseAdd(NativeMemoryNullableVector<int> values);
        DataFrameColumn ReverseAdd(NativeMemoryNullableVector<short> values);
        DataFrameColumn ReverseAdd(NativeMemoryNullableVector<sbyte> values);

        DataFrameColumn ReverseAdd(NativeMemoryNullableVector<ulong> values);
        DataFrameColumn ReverseAdd(NativeMemoryNullableVector<uint> values);
        DataFrameColumn ReverseAdd(NativeMemoryNullableVector<ushort> values);
        DataFrameColumn ReverseAdd(NativeMemoryNullableVector<byte> values);

        DataFrameColumn ReverseAdd(NativeMemoryNullableVector<double> values);
        DataFrameColumn ReverseAdd(NativeMemoryNullableVector<float> values);
    }
}

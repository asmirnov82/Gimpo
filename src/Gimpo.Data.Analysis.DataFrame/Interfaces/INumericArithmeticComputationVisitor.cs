using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Gimpo.Data.Primitives;

namespace Gimpo.Data.Analysis
{
    public interface INumericArithmeticComputationVisitor
    {
        #region Addition
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
        #endregion

        #region Substraction
        DataFrameColumn Substract(NativeMemoryNullableVector<long> values, bool inPlace = false);
        DataFrameColumn Substract(NativeMemoryNullableVector<int> values, bool inPlace = false);
        DataFrameColumn Substract(NativeMemoryNullableVector<short> values, bool inPlace = false);
        DataFrameColumn Substract(NativeMemoryNullableVector<sbyte> values, bool inPlace = false);

        DataFrameColumn Substract(NativeMemoryNullableVector<ulong> values, bool inPlace = false);
        DataFrameColumn Substract(NativeMemoryNullableVector<uint> values, bool inPlace = false);
        DataFrameColumn Substract(NativeMemoryNullableVector<ushort> values, bool inPlace = false);
        DataFrameColumn Substract(NativeMemoryNullableVector<byte> values, bool inPlace = false);

        DataFrameColumn Substract(NativeMemoryNullableVector<double> values, bool inPlace = false);
        DataFrameColumn Substract(NativeMemoryNullableVector<float> values, bool inPlace = false);

        DataFrameColumn ReverseSubstract(NativeMemoryNullableVector<long> values);
        DataFrameColumn ReverseSubstract(NativeMemoryNullableVector<int> values);
        DataFrameColumn ReverseSubstract(NativeMemoryNullableVector<short> values);
        DataFrameColumn ReverseSubstract(NativeMemoryNullableVector<sbyte> values);

        DataFrameColumn ReverseSubstract(NativeMemoryNullableVector<ulong> values);
        DataFrameColumn ReverseSubstract(NativeMemoryNullableVector<uint> values);
        DataFrameColumn ReverseSubstract(NativeMemoryNullableVector<ushort> values);
        DataFrameColumn ReverseSubstract(NativeMemoryNullableVector<byte> values);

        DataFrameColumn ReverseSubstract(NativeMemoryNullableVector<double> values);
        DataFrameColumn ReverseSubstract(NativeMemoryNullableVector<float> values);
        #endregion
    }
}


// Generated from NNumericDataFrameColumn.ArithmeticVisitorMethods.tt. Do not modify directly

using System;
using System.Collections.Generic;
using Gimpo.Data.Primitives;

namespace Gimpo.Data.Analysis
{
    public abstract partial class NumericDataFrameColumn<T>
    {
        public DataFrameColumn Add(NativeMemoryNullableVector<double> values, bool inPlace = false)
        {
            var result = inPlace ? this : CreateNewColumn("Add", Length, true);
            ArithmeticComputation.Add(_values, values, result._values);

            return result;
        }
        public DataFrameColumn Add(NativeMemoryNullableVector<float> values, bool inPlace = false)
        {
            var result = inPlace ? this : CreateNewColumn("Add", Length, true);
            ArithmeticComputation.Add(_values, values, result._values);

            return result;
        }
        public DataFrameColumn Add(NativeMemoryNullableVector<sbyte> values, bool inPlace = false)
        {
            var result = inPlace ? this : CreateNewColumn("Add", Length, true);
            ArithmeticComputation.Add(_values, values, result._values);

            return result;
        }
        public DataFrameColumn Add(NativeMemoryNullableVector<byte> values, bool inPlace = false)
        {
            var result = inPlace ? this : CreateNewColumn("Add", Length, true);
            ArithmeticComputation.Add(_values, values, result._values);

            return result;
        }
        public DataFrameColumn Add(NativeMemoryNullableVector<short> values, bool inPlace = false)
        {
            var result = inPlace ? this : CreateNewColumn("Add", Length, true);
            ArithmeticComputation.Add(_values, values, result._values);

            return result;
        }
        public DataFrameColumn Add(NativeMemoryNullableVector<ushort> values, bool inPlace = false)
        {
            var result = inPlace ? this : CreateNewColumn("Add", Length, true);
            ArithmeticComputation.Add(_values, values, result._values);

            return result;
        }
        public DataFrameColumn Add(NativeMemoryNullableVector<int> values, bool inPlace = false)
        {
            var result = inPlace ? this : CreateNewColumn("Add", Length, true);
            ArithmeticComputation.Add(_values, values, result._values);

            return result;
        }
        public DataFrameColumn Add(NativeMemoryNullableVector<uint> values, bool inPlace = false)
        {
            var result = inPlace ? this : CreateNewColumn("Add", Length, true);
            ArithmeticComputation.Add(_values, values, result._values);

            return result;
        }
        public DataFrameColumn Add(NativeMemoryNullableVector<long> values, bool inPlace = false)
        {
            var result = inPlace ? this : CreateNewColumn("Add", Length, true);
            ArithmeticComputation.Add(_values, values, result._values);

            return result;
        }
        public DataFrameColumn Add(NativeMemoryNullableVector<ulong> values, bool inPlace = false)
        {
            var result = inPlace ? this : CreateNewColumn("Add", Length, true);
            ArithmeticComputation.Add(_values, values, result._values);

            return result;
        }
    }
}

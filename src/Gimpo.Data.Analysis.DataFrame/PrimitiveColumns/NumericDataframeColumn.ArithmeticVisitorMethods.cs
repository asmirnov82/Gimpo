
// Generated from NumericDataFrameColumn.ArithmeticVisitorMethods.tt. Do not modify directly

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

        public DataFrameColumn ReserveAdd(NativeMemoryNullableVector<double> values)
        {
            var result = CreateNewColumn("Add", Length, true);
            ArithmeticComputation.ReserveAdd(values, _values, result._values);

            return result;
        }
        public DataFrameColumn Add(NativeMemoryNullableVector<float> values, bool inPlace = false)
        {
            var result = inPlace ? this : CreateNewColumn("Add", Length, true);
            ArithmeticComputation.Add(_values, values, result._values);

            return result;
        }

        public DataFrameColumn ReserveAdd(NativeMemoryNullableVector<float> values)
        {
            var result = CreateNewColumn("Add", Length, true);
            ArithmeticComputation.ReserveAdd(values, _values, result._values);

            return result;
        }
        public DataFrameColumn Add(NativeMemoryNullableVector<sbyte> values, bool inPlace = false)
        {
            var result = inPlace ? this : CreateNewColumn("Add", Length, true);
            ArithmeticComputation.Add(_values, values, result._values);

            return result;
        }

        public DataFrameColumn ReserveAdd(NativeMemoryNullableVector<sbyte> values)
        {
            var result = CreateNewColumn("Add", Length, true);
            ArithmeticComputation.ReserveAdd(values, _values, result._values);

            return result;
        }
        public DataFrameColumn Add(NativeMemoryNullableVector<byte> values, bool inPlace = false)
        {
            var result = inPlace ? this : CreateNewColumn("Add", Length, true);
            ArithmeticComputation.Add(_values, values, result._values);

            return result;
        }

        public DataFrameColumn ReserveAdd(NativeMemoryNullableVector<byte> values)
        {
            var result = CreateNewColumn("Add", Length, true);
            ArithmeticComputation.ReserveAdd(values, _values, result._values);

            return result;
        }
        public DataFrameColumn Add(NativeMemoryNullableVector<short> values, bool inPlace = false)
        {
            var result = inPlace ? this : CreateNewColumn("Add", Length, true);
            ArithmeticComputation.Add(_values, values, result._values);

            return result;
        }

        public DataFrameColumn ReserveAdd(NativeMemoryNullableVector<short> values)
        {
            var result = CreateNewColumn("Add", Length, true);
            ArithmeticComputation.ReserveAdd(values, _values, result._values);

            return result;
        }
        public DataFrameColumn Add(NativeMemoryNullableVector<ushort> values, bool inPlace = false)
        {
            var result = inPlace ? this : CreateNewColumn("Add", Length, true);
            ArithmeticComputation.Add(_values, values, result._values);

            return result;
        }

        public DataFrameColumn ReserveAdd(NativeMemoryNullableVector<ushort> values)
        {
            var result = CreateNewColumn("Add", Length, true);
            ArithmeticComputation.ReserveAdd(values, _values, result._values);

            return result;
        }
        public DataFrameColumn Add(NativeMemoryNullableVector<int> values, bool inPlace = false)
        {
            var result = inPlace ? this : CreateNewColumn("Add", Length, true);
            ArithmeticComputation.Add(_values, values, result._values);

            return result;
        }

        public DataFrameColumn ReserveAdd(NativeMemoryNullableVector<int> values)
        {
            var result = CreateNewColumn("Add", Length, true);
            ArithmeticComputation.ReserveAdd(values, _values, result._values);

            return result;
        }
        public DataFrameColumn Add(NativeMemoryNullableVector<uint> values, bool inPlace = false)
        {
            var result = inPlace ? this : CreateNewColumn("Add", Length, true);
            ArithmeticComputation.Add(_values, values, result._values);

            return result;
        }

        public DataFrameColumn ReserveAdd(NativeMemoryNullableVector<uint> values)
        {
            var result = CreateNewColumn("Add", Length, true);
            ArithmeticComputation.ReserveAdd(values, _values, result._values);

            return result;
        }
        public DataFrameColumn Add(NativeMemoryNullableVector<long> values, bool inPlace = false)
        {
            var result = inPlace ? this : CreateNewColumn("Add", Length, true);
            ArithmeticComputation.Add(_values, values, result._values);

            return result;
        }

        public DataFrameColumn ReserveAdd(NativeMemoryNullableVector<long> values)
        {
            var result = CreateNewColumn("Add", Length, true);
            ArithmeticComputation.ReserveAdd(values, _values, result._values);

            return result;
        }
        public DataFrameColumn Add(NativeMemoryNullableVector<ulong> values, bool inPlace = false)
        {
            var result = inPlace ? this : CreateNewColumn("Add", Length, true);
            ArithmeticComputation.Add(_values, values, result._values);

            return result;
        }

        public DataFrameColumn ReserveAdd(NativeMemoryNullableVector<ulong> values)
        {
            var result = CreateNewColumn("Add", Length, true);
            ArithmeticComputation.ReserveAdd(values, _values, result._values);

            return result;
        }
    }
}

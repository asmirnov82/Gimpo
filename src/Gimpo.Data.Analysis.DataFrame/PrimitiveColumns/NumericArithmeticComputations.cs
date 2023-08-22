
// Generated from NumericArithmeticComputations.tt. Do not modify directly

using System;
using System.Collections.Generic;
using Gimpo.Data.Primitives;

namespace Gimpo.Data.Analysis
{
    #region Add    

    public class DoubleNumericArithmeticComputation : NumericArithmeticComputation<double>
    {
        public override void Add(NativeMemoryNullableVector<double> left, NativeMemoryNullableVector<double> right, NativeMemoryNullableVector<double> result)
        {
            for (long i = 0; i < left.Length; i++)
            {
                result[i] = left.HasValue(i) && right.HasValue(i) ? (double?)(left[i].Value + right[i].Value) : (double?) null;
            }
        }

        public override void Add(NativeMemoryNullableVector<double> left, NativeMemoryNullableVector<float> right, NativeMemoryNullableVector<double> result)
        {
            for (long i = 0; i < left.Length; i++)
            {
                result[i] = left.HasValue(i) && right.HasValue(i) ? (double?)(left[i].Value + right[i].Value) : (double?) null;
            }
        }

    }

    public class FloatNumericArithmeticComputation : NumericArithmeticComputation<float>
    {
        public override void Add(NativeMemoryNullableVector<float> left, NativeMemoryNullableVector<float> right, NativeMemoryNullableVector<float> result)
        {
            for (long i = 0; i < left.Length; i++)
            {
                result[i] = left.HasValue(i) && right.HasValue(i) ? (float?)(left[i].Value + right[i].Value) : (float?) null;
            }
        }

    }

    public class Int8NumericArithmeticComputation : NumericArithmeticComputation<sbyte>
    {
        public override void Add(NativeMemoryNullableVector<sbyte> left, NativeMemoryNullableVector<sbyte> right, NativeMemoryNullableVector<sbyte> result)
        {
            for (long i = 0; i < left.Length; i++)
            {
                result[i] = left.HasValue(i) && right.HasValue(i) ? (sbyte?)(left[i].Value + right[i].Value) : (sbyte?) null;
            }
        }

    }

    public class UInt8NumericArithmeticComputation : NumericArithmeticComputation<byte>
    {
    }

    public class Int16NumericArithmeticComputation : NumericArithmeticComputation<short>
    {
        public override void Add(NativeMemoryNullableVector<short> left, NativeMemoryNullableVector<short> right, NativeMemoryNullableVector<short> result)
        {
            for (long i = 0; i < left.Length; i++)
            {
                result[i] = left.HasValue(i) && right.HasValue(i) ? (short?)(left[i].Value + right[i].Value) : (short?) null;
            }
        }

        public override void Add(NativeMemoryNullableVector<short> left, NativeMemoryNullableVector<sbyte> right, NativeMemoryNullableVector<short> result)
        {
            for (long i = 0; i < left.Length; i++)
            {
                result[i] = left.HasValue(i) && right.HasValue(i) ? (short?)(left[i].Value + right[i].Value) : (short?) null;
            }
        }

    }

    public class UInt16NumericArithmeticComputation : NumericArithmeticComputation<ushort>
    {
    }

    public class Int32NumericArithmeticComputation : NumericArithmeticComputation<int>
    {
        public override void Add(NativeMemoryNullableVector<int> left, NativeMemoryNullableVector<int> right, NativeMemoryNullableVector<int> result)
        {
            for (long i = 0; i < left.Length; i++)
            {
                result[i] = left.HasValue(i) && right.HasValue(i) ? (int?)(left[i].Value + right[i].Value) : (int?) null;
            }
        }

        public override void Add(NativeMemoryNullableVector<int> left, NativeMemoryNullableVector<short> right, NativeMemoryNullableVector<int> result)
        {
            for (long i = 0; i < left.Length; i++)
            {
                result[i] = left.HasValue(i) && right.HasValue(i) ? (int?)(left[i].Value + right[i].Value) : (int?) null;
            }
        }

        public override void Add(NativeMemoryNullableVector<int> left, NativeMemoryNullableVector<sbyte> right, NativeMemoryNullableVector<int> result)
        {
            for (long i = 0; i < left.Length; i++)
            {
                result[i] = left.HasValue(i) && right.HasValue(i) ? (int?)(left[i].Value + right[i].Value) : (int?) null;
            }
        }

    }

    public class UInt32NumericArithmeticComputation : NumericArithmeticComputation<uint>
    {
    }

    public class Int64NumericArithmeticComputation : NumericArithmeticComputation<long>
    {
        public override void Add(NativeMemoryNullableVector<long> left, NativeMemoryNullableVector<long> right, NativeMemoryNullableVector<long> result)
        {
            for (long i = 0; i < left.Length; i++)
            {
                result[i] = left.HasValue(i) && right.HasValue(i) ? (long?)(left[i].Value + right[i].Value) : (long?) null;
            }
        }

        public override void Add(NativeMemoryNullableVector<long> left, NativeMemoryNullableVector<int> right, NativeMemoryNullableVector<long> result)
        {
            for (long i = 0; i < left.Length; i++)
            {
                result[i] = left.HasValue(i) && right.HasValue(i) ? (long?)(left[i].Value + right[i].Value) : (long?) null;
            }
        }

        public override void Add(NativeMemoryNullableVector<long> left, NativeMemoryNullableVector<short> right, NativeMemoryNullableVector<long> result)
        {
            for (long i = 0; i < left.Length; i++)
            {
                result[i] = left.HasValue(i) && right.HasValue(i) ? (long?)(left[i].Value + right[i].Value) : (long?) null;
            }
        }

        public override void Add(NativeMemoryNullableVector<long> left, NativeMemoryNullableVector<sbyte> right, NativeMemoryNullableVector<long> result)
        {
            for (long i = 0; i < left.Length; i++)
            {
                result[i] = left.HasValue(i) && right.HasValue(i) ? (long?)(left[i].Value + right[i].Value) : (long?) null;
            }
        }

    }

    public class UInt64NumericArithmeticComputation : NumericArithmeticComputation<ulong>
    {
    }
    #endregion
}

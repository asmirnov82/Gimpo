
// Generated from SimdNumericArithmeticComputations.tt. Do not modify directly

using System;
using System.Numerics;
using System.Collections.Generic;
using Gimpo.Data.Primitives;

namespace Gimpo.Data.Analysis
{
    #region Add    

    public class DoubleSimdNumericArithmeticComputation : NumericArithmeticComputation<double>
    {
        public override void Add(NativeMemoryNullableVector<double> left, NativeMemoryNullableVector<double> right, NativeMemoryNullableVector<double> result)
        {
            int vectorSize = Vector<double>.Count;

            long i;

            for (i = 0; i < left.Length - vectorSize; i += vectorSize)
            {
                //result[i] = left.HasValue(i) && right.HasValue(i) ? (double?)(left[i].Value + right[i].Value) : (double?) null;
            }
        }

        public override void Add(NativeMemoryNullableVector<double> left, NativeMemoryNullableVector<float> right, NativeMemoryNullableVector<double> result)
        {
            int vectorSize = Vector<double>.Count;

            long i;

            for (i = 0; i < left.Length - vectorSize; i += vectorSize)
            {
                //result[i] = left.HasValue(i) && right.HasValue(i) ? (double?)(left[i].Value + right[i].Value) : (double?) null;
            }
        }

    }

    public class FloatSimdNumericArithmeticComputation : NumericArithmeticComputation<float>
    {
        public override void Add(NativeMemoryNullableVector<float> left, NativeMemoryNullableVector<float> right, NativeMemoryNullableVector<float> result)
        {
            int vectorSize = Vector<float>.Count;

            long i;

            for (i = 0; i < left.Length - vectorSize; i += vectorSize)
            {
                //result[i] = left.HasValue(i) && right.HasValue(i) ? (float?)(left[i].Value + right[i].Value) : (float?) null;
            }
        }

    }

    public class Int8SimdNumericArithmeticComputation : NumericArithmeticComputation<sbyte>
    {
        public override void Add(NativeMemoryNullableVector<sbyte> left, NativeMemoryNullableVector<sbyte> right, NativeMemoryNullableVector<sbyte> result)
        {
            int vectorSize = Vector<sbyte>.Count;

            long i;

            for (i = 0; i < left.Length - vectorSize; i += vectorSize)
            {
                //result[i] = left.HasValue(i) && right.HasValue(i) ? (sbyte?)(left[i].Value + right[i].Value) : (sbyte?) null;
            }
        }

    }

    public class UInt8SimdNumericArithmeticComputation : NumericArithmeticComputation<byte>
    {
    }

    public class Int16SimdNumericArithmeticComputation : NumericArithmeticComputation<short>
    {
        public override void Add(NativeMemoryNullableVector<short> left, NativeMemoryNullableVector<short> right, NativeMemoryNullableVector<short> result)
        {
            int vectorSize = Vector<short>.Count;

            long i;

            for (i = 0; i < left.Length - vectorSize; i += vectorSize)
            {
                //result[i] = left.HasValue(i) && right.HasValue(i) ? (short?)(left[i].Value + right[i].Value) : (short?) null;
            }
        }

        public override void Add(NativeMemoryNullableVector<short> left, NativeMemoryNullableVector<sbyte> right, NativeMemoryNullableVector<short> result)
        {
            int vectorSize = Vector<short>.Count;

            long i;

            for (i = 0; i < left.Length - vectorSize; i += vectorSize)
            {
                //result[i] = left.HasValue(i) && right.HasValue(i) ? (short?)(left[i].Value + right[i].Value) : (short?) null;
            }
        }

    }

    public class UInt16SimdNumericArithmeticComputation : NumericArithmeticComputation<ushort>
    {
    }

    public class Int32SimdNumericArithmeticComputation : NumericArithmeticComputation<int>
    {
        public override void Add(NativeMemoryNullableVector<int> left, NativeMemoryNullableVector<int> right, NativeMemoryNullableVector<int> result)
        {
            int vectorSize = Vector<int>.Count;

            long i;

            for (i = 0; i < left.Length - vectorSize; i += vectorSize)
            {
                //result[i] = left.HasValue(i) && right.HasValue(i) ? (int?)(left[i].Value + right[i].Value) : (int?) null;
            }
        }

        public override void Add(NativeMemoryNullableVector<int> left, NativeMemoryNullableVector<short> right, NativeMemoryNullableVector<int> result)
        {
            int vectorSize = Vector<int>.Count;

            long i;

            for (i = 0; i < left.Length - vectorSize; i += vectorSize)
            {
                //result[i] = left.HasValue(i) && right.HasValue(i) ? (int?)(left[i].Value + right[i].Value) : (int?) null;
            }
        }

        public override void Add(NativeMemoryNullableVector<int> left, NativeMemoryNullableVector<sbyte> right, NativeMemoryNullableVector<int> result)
        {
            int vectorSize = Vector<int>.Count;

            long i;

            for (i = 0; i < left.Length - vectorSize; i += vectorSize)
            {
                //result[i] = left.HasValue(i) && right.HasValue(i) ? (int?)(left[i].Value + right[i].Value) : (int?) null;
            }
        }

    }

    public class UInt32SimdNumericArithmeticComputation : NumericArithmeticComputation<uint>
    {
    }

    public class Int64SimdNumericArithmeticComputation : NumericArithmeticComputation<long>
    {
        public override void Add(NativeMemoryNullableVector<long> left, NativeMemoryNullableVector<long> right, NativeMemoryNullableVector<long> result)
        {
            int vectorSize = Vector<long>.Count;

            long i;

            for (i = 0; i < left.Length - vectorSize; i += vectorSize)
            {
                //result[i] = left.HasValue(i) && right.HasValue(i) ? (long?)(left[i].Value + right[i].Value) : (long?) null;
            }
        }

        public override void Add(NativeMemoryNullableVector<long> left, NativeMemoryNullableVector<int> right, NativeMemoryNullableVector<long> result)
        {
            int vectorSize = Vector<long>.Count;

            long i;

            for (i = 0; i < left.Length - vectorSize; i += vectorSize)
            {
                //result[i] = left.HasValue(i) && right.HasValue(i) ? (long?)(left[i].Value + right[i].Value) : (long?) null;
            }
        }

        public override void Add(NativeMemoryNullableVector<long> left, NativeMemoryNullableVector<short> right, NativeMemoryNullableVector<long> result)
        {
            int vectorSize = Vector<long>.Count;

            long i;

            for (i = 0; i < left.Length - vectorSize; i += vectorSize)
            {
                //result[i] = left.HasValue(i) && right.HasValue(i) ? (long?)(left[i].Value + right[i].Value) : (long?) null;
            }
        }

        public override void Add(NativeMemoryNullableVector<long> left, NativeMemoryNullableVector<sbyte> right, NativeMemoryNullableVector<long> result)
        {
            int vectorSize = Vector<long>.Count;

            long i;

            for (i = 0; i < left.Length - vectorSize; i += vectorSize)
            {
                //result[i] = left.HasValue(i) && right.HasValue(i) ? (long?)(left[i].Value + right[i].Value) : (long?) null;
            }
        }

    }

    public class UInt64SimdNumericArithmeticComputation : NumericArithmeticComputation<ulong>
    {
    }
    #endregion
}

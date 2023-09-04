
// Generated from SimdNumericArithmeticComputations.tt. Do not modify directly

using System;
using System.Numerics;
using Gimpo.Data.Primitives;

namespace Gimpo.Data.Analysis
{
    #region Add    

    public class DoubleSimdNumericArithmeticComputation : NumericArithmeticComputation<double>
    {
        public override void Add(NativeMemoryNullableVector<double> left, NativeMemoryNullableVector<double> right, NativeMemoryNullableVector<double> result)
        {
            var i = SimdComputationsHelper.Compute((v1, v2) => v1 + v2, left, right, result);

            //Calculate validity (nulls)
            Bitmap.ElementWiseAndBitmap(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
                            
            for (; i < left.Length; i++)
                result[i] = (double?)(left[i] + right[i]);
        }

        public override void Add(NativeMemoryNullableVector<double> left, NativeMemoryNullableVector<float> right, NativeMemoryNullableVector<double> result)
        {
            var i = SimdComputationsHelper.Compute((v1, v2) => v1 + v2, left, right, result);

            //Calculate validity (nulls)
            Bitmap.ElementWiseAndBitmap(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
                            
            for (; i < left.Length; i++)
                result[i] = (double?)(left[i] + right[i]);
        }

    }

    public class FloatSimdNumericArithmeticComputation : NumericArithmeticComputation<float>
    {
        public override void Add(NativeMemoryNullableVector<float> left, NativeMemoryNullableVector<float> right, NativeMemoryNullableVector<float> result)
        {
            var i = SimdComputationsHelper.Compute((v1, v2) => v1 + v2, left, right, result);

            //Calculate validity (nulls)
            Bitmap.ElementWiseAndBitmap(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
                            
            for (; i < left.Length; i++)
                result[i] = (float?)(left[i] + right[i]);
        }

    }

    public class Int8SimdNumericArithmeticComputation : NumericArithmeticComputation<sbyte>
    {
        public override void Add(NativeMemoryNullableVector<sbyte> left, NativeMemoryNullableVector<sbyte> right, NativeMemoryNullableVector<sbyte> result)
        {
            var i = SimdComputationsHelper.Compute((v1, v2) => v1 + v2, left, right, result);

            //Calculate validity (nulls)
            Bitmap.ElementWiseAndBitmap(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
                            
            for (; i < left.Length; i++)
                result[i] = (sbyte?)(left[i] + right[i]);
        }

    }

    public class UInt8SimdNumericArithmeticComputation : NumericArithmeticComputation<byte>
    {
    }

    public class Int16SimdNumericArithmeticComputation : NumericArithmeticComputation<short>
    {
        public override void Add(NativeMemoryNullableVector<short> left, NativeMemoryNullableVector<short> right, NativeMemoryNullableVector<short> result)
        {
            var i = SimdComputationsHelper.Compute((v1, v2) => v1 + v2, left, right, result);

            //Calculate validity (nulls)
            Bitmap.ElementWiseAndBitmap(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
                            
            for (; i < left.Length; i++)
                result[i] = (short?)(left[i] + right[i]);
        }

        public override void Add(NativeMemoryNullableVector<short> left, NativeMemoryNullableVector<sbyte> right, NativeMemoryNullableVector<short> result)
        {
            var i = SimdComputationsHelper.Compute((v1, v2) => v1 + v2, left, right, result);

            //Calculate validity (nulls)
            Bitmap.ElementWiseAndBitmap(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
                            
            for (; i < left.Length; i++)
                result[i] = (short?)(left[i] + right[i]);
        }

    }

    public class UInt16SimdNumericArithmeticComputation : NumericArithmeticComputation<ushort>
    {
    }

    public class Int32SimdNumericArithmeticComputation : NumericArithmeticComputation<int>
    {
        public override void Add(NativeMemoryNullableVector<int> left, NativeMemoryNullableVector<int> right, NativeMemoryNullableVector<int> result)
        {
            var i = SimdComputationsHelper.Compute((v1, v2) => v1 + v2, left, right, result);

            //Calculate validity (nulls)
            Bitmap.ElementWiseAndBitmap(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
                            
            for (; i < left.Length; i++)
                result[i] = (int?)(left[i] + right[i]);
        }

        public override void Add(NativeMemoryNullableVector<int> left, NativeMemoryNullableVector<short> right, NativeMemoryNullableVector<int> result)
        {
            var i = SimdComputationsHelper.Compute((v1, v2) => v1 + v2, left, right, result);

            //Calculate validity (nulls)
            Bitmap.ElementWiseAndBitmap(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
                            
            for (; i < left.Length; i++)
                result[i] = (int?)(left[i] + right[i]);
        }

        public override void Add(NativeMemoryNullableVector<int> left, NativeMemoryNullableVector<sbyte> right, NativeMemoryNullableVector<int> result)
        {
            var i = SimdComputationsHelper.Compute((v1, v2) => v1 + v2, left, right, result);

            //Calculate validity (nulls)
            Bitmap.ElementWiseAndBitmap(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
                            
            for (; i < left.Length; i++)
                result[i] = (int?)(left[i] + right[i]);
        }

    }

    public class UInt32SimdNumericArithmeticComputation : NumericArithmeticComputation<uint>
    {
    }

    public class Int64SimdNumericArithmeticComputation : NumericArithmeticComputation<long>
    {
        public override void Add(NativeMemoryNullableVector<long> left, NativeMemoryNullableVector<long> right, NativeMemoryNullableVector<long> result)
        {
            var i = SimdComputationsHelper.Compute((v1, v2) => v1 + v2, left, right, result);

            //Calculate validity (nulls)
            Bitmap.ElementWiseAndBitmap(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
                            
            for (; i < left.Length; i++)
                result[i] = (long?)(left[i] + right[i]);
        }

        public override void Add(NativeMemoryNullableVector<long> left, NativeMemoryNullableVector<int> right, NativeMemoryNullableVector<long> result)
        {
            var i = SimdComputationsHelper.Compute((v1, v2) => v1 + v2, left, right, result);

            //Calculate validity (nulls)
            Bitmap.ElementWiseAndBitmap(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
                            
            for (; i < left.Length; i++)
                result[i] = (long?)(left[i] + right[i]);
        }

        public override void Add(NativeMemoryNullableVector<long> left, NativeMemoryNullableVector<short> right, NativeMemoryNullableVector<long> result)
        {
            var i = SimdComputationsHelper.Compute((v1, v2) => v1 + v2, left, right, result);

            //Calculate validity (nulls)
            Bitmap.ElementWiseAndBitmap(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
                            
            for (; i < left.Length; i++)
                result[i] = (long?)(left[i] + right[i]);
        }

        public override void Add(NativeMemoryNullableVector<long> left, NativeMemoryNullableVector<sbyte> right, NativeMemoryNullableVector<long> result)
        {
            var i = SimdComputationsHelper.Compute((v1, v2) => v1 + v2, left, right, result);

            //Calculate validity (nulls)
            Bitmap.ElementWiseAndBitmap(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
                            
            for (; i < left.Length; i++)
                result[i] = (long?)(left[i] + right[i]);
        }

    }

    public class UInt64SimdNumericArithmeticComputation : NumericArithmeticComputation<ulong>
    {
    }
    #endregion
}

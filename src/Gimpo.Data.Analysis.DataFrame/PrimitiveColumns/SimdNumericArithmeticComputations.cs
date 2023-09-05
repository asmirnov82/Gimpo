
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
            //Calculate raw values
            var i = SimdComputationsHelper.Compute((v1, v2) => v1 + v2, left, right, result);
                                                    
            for (; i < left.Length; i++)
                result.RawValue(i) = (double)(left.RawValue(i) + right.RawValue(i));

            //Calculate validity (nulls)
            Bitmap.ElementWiseAnd(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }

        public override void Add(NativeMemoryNullableVector<double> left, NativeMemoryNullableVector<float> right, NativeMemoryNullableVector<double> result)
        {
            //Calculate raw values
            var i = SimdComputationsHelper.Compute((v1, v2) => v1 + v2, left, right, result);
                                                    
            for (; i < left.Length; i++)
                result.RawValue(i) = (double)(left.RawValue(i) + right.RawValue(i));

            //Calculate validity (nulls)
            Bitmap.ElementWiseAnd(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }

    }

    public class FloatSimdNumericArithmeticComputation : NumericArithmeticComputation<float>
    {
        public override void Add(NativeMemoryNullableVector<float> left, NativeMemoryNullableVector<float> right, NativeMemoryNullableVector<float> result)
        {
            //Calculate raw values
            var i = SimdComputationsHelper.Compute((v1, v2) => v1 + v2, left, right, result);
                                                    
            for (; i < left.Length; i++)
                result.RawValue(i) = (float)(left.RawValue(i) + right.RawValue(i));

            //Calculate validity (nulls)
            Bitmap.ElementWiseAnd(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }

    }

    public class Int8SimdNumericArithmeticComputation : NumericArithmeticComputation<sbyte>
    {
        public override void Add(NativeMemoryNullableVector<sbyte> left, NativeMemoryNullableVector<sbyte> right, NativeMemoryNullableVector<sbyte> result)
        {
            //Calculate raw values
            var i = SimdComputationsHelper.Compute((v1, v2) => v1 + v2, left, right, result);
                                                    
            for (; i < left.Length; i++)
                result.RawValue(i) = (sbyte)(left.RawValue(i) + right.RawValue(i));

            //Calculate validity (nulls)
            Bitmap.ElementWiseAnd(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }

    }

    public class UInt8SimdNumericArithmeticComputation : NumericArithmeticComputation<byte>
    {
    }

    public class Int16SimdNumericArithmeticComputation : NumericArithmeticComputation<short>
    {
        public override void Add(NativeMemoryNullableVector<short> left, NativeMemoryNullableVector<short> right, NativeMemoryNullableVector<short> result)
        {
            //Calculate raw values
            var i = SimdComputationsHelper.Compute((v1, v2) => v1 + v2, left, right, result);
                                                    
            for (; i < left.Length; i++)
                result.RawValue(i) = (short)(left.RawValue(i) + right.RawValue(i));

            //Calculate validity (nulls)
            Bitmap.ElementWiseAnd(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }

        public override void Add(NativeMemoryNullableVector<short> left, NativeMemoryNullableVector<sbyte> right, NativeMemoryNullableVector<short> result)
        {
            //Calculate raw values
            var i = SimdComputationsHelper.Compute((v1, v2) => v1 + v2, left, right, result);
                                                    
            for (; i < left.Length; i++)
                result.RawValue(i) = (short)(left.RawValue(i) + right.RawValue(i));

            //Calculate validity (nulls)
            Bitmap.ElementWiseAnd(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }

    }

    public class UInt16SimdNumericArithmeticComputation : NumericArithmeticComputation<ushort>
    {
    }

    public class Int32SimdNumericArithmeticComputation : NumericArithmeticComputation<int>
    {
        public override void Add(NativeMemoryNullableVector<int> left, NativeMemoryNullableVector<int> right, NativeMemoryNullableVector<int> result)
        {
            //Calculate raw values
            var i = SimdComputationsHelper.Compute((v1, v2) => v1 + v2, left, right, result);
                                                    
            for (; i < left.Length; i++)
                result.RawValue(i) = (int)(left.RawValue(i) + right.RawValue(i));

            //Calculate validity (nulls)
            Bitmap.ElementWiseAnd(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }

        public override void Add(NativeMemoryNullableVector<int> left, NativeMemoryNullableVector<short> right, NativeMemoryNullableVector<int> result)
        {
            //Calculate raw values
            var i = SimdComputationsHelper.Compute((v1, v2) => v1 + v2, left, right, result);
                                                    
            for (; i < left.Length; i++)
                result.RawValue(i) = (int)(left.RawValue(i) + right.RawValue(i));

            //Calculate validity (nulls)
            Bitmap.ElementWiseAnd(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }

        public override void Add(NativeMemoryNullableVector<int> left, NativeMemoryNullableVector<sbyte> right, NativeMemoryNullableVector<int> result)
        {
            //Calculate raw values
            var i = SimdComputationsHelper.Compute((v1, v2) => v1 + v2, left, right, result);
                                                    
            for (; i < left.Length; i++)
                result.RawValue(i) = (int)(left.RawValue(i) + right.RawValue(i));

            //Calculate validity (nulls)
            Bitmap.ElementWiseAnd(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }

    }

    public class UInt32SimdNumericArithmeticComputation : NumericArithmeticComputation<uint>
    {
    }

    public class Int64SimdNumericArithmeticComputation : NumericArithmeticComputation<long>
    {
        public override void Add(NativeMemoryNullableVector<long> left, NativeMemoryNullableVector<long> right, NativeMemoryNullableVector<long> result)
        {
            //Calculate raw values
            var i = SimdComputationsHelper.Compute((v1, v2) => v1 + v2, left, right, result);
                                                    
            for (; i < left.Length; i++)
                result.RawValue(i) = (long)(left.RawValue(i) + right.RawValue(i));

            //Calculate validity (nulls)
            Bitmap.ElementWiseAnd(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }

        public override void Add(NativeMemoryNullableVector<long> left, NativeMemoryNullableVector<int> right, NativeMemoryNullableVector<long> result)
        {
            //Calculate raw values
            var i = SimdComputationsHelper.Compute((v1, v2) => v1 + v2, left, right, result);
                                                    
            for (; i < left.Length; i++)
                result.RawValue(i) = (long)(left.RawValue(i) + right.RawValue(i));

            //Calculate validity (nulls)
            Bitmap.ElementWiseAnd(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }

        public override void Add(NativeMemoryNullableVector<long> left, NativeMemoryNullableVector<short> right, NativeMemoryNullableVector<long> result)
        {
            //Calculate raw values
            var i = SimdComputationsHelper.Compute((v1, v2) => v1 + v2, left, right, result);
                                                    
            for (; i < left.Length; i++)
                result.RawValue(i) = (long)(left.RawValue(i) + right.RawValue(i));

            //Calculate validity (nulls)
            Bitmap.ElementWiseAnd(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }

        public override void Add(NativeMemoryNullableVector<long> left, NativeMemoryNullableVector<sbyte> right, NativeMemoryNullableVector<long> result)
        {
            //Calculate raw values
            var i = SimdComputationsHelper.Compute((v1, v2) => v1 + v2, left, right, result);
                                                    
            for (; i < left.Length; i++)
                result.RawValue(i) = (long)(left.RawValue(i) + right.RawValue(i));

            //Calculate validity (nulls)
            Bitmap.ElementWiseAnd(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }

    }

    public class UInt64SimdNumericArithmeticComputation : NumericArithmeticComputation<ulong>
    {
    }
    #endregion
}

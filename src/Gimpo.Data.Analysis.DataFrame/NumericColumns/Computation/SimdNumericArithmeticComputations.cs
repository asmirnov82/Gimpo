

// Generated from SimdNumericArithmeticComputations.tt. Do not modify directly

using System;
using System.Numerics;
using Gimpo.Data.Primitives;

namespace Gimpo.Data.Analysis
{

    public class DoubleSimdNumericArithmeticComputation : NumericArithmeticComputation<double>
    {

        #region Add
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


        #endregion

        #region Subtract
        public override void Subtract(NativeMemoryNullableVector<double> left, NativeMemoryNullableVector<double> right, NativeMemoryNullableVector<double> result)
        {
            //Calculate raw values
            var i = SimdComputationsHelper.Compute((v1, v2) => v1 - v2, left, right, result);
                                                    
            for (; i < left.Length; i++)
                result.RawValue(i) = (double)(left.RawValue(i) - right.RawValue(i));

            //Calculate validity (nulls)
            Bitmap.ElementWiseAnd(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }

        public override void ReverseSubtract(NativeMemoryNullableVector<double> left, NativeMemoryNullableVector<double> right, NativeMemoryNullableVector<double> result)
        {
            //Calculate raw values
            var i = SimdComputationsHelper.Compute((v1, v2) => v2 - v1, right, left, result);
                                                    
            for (; i < left.Length; i++)
                result.RawValue(i) = (double)(left.RawValue(i) - right.RawValue(i));

            //Calculate validity (nulls)
            Bitmap.ElementWiseAnd(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }

        public override void Subtract(NativeMemoryNullableVector<double> left, NativeMemoryNullableVector<float> right, NativeMemoryNullableVector<double> result)
        {
            //Calculate raw values
            var i = SimdComputationsHelper.Compute((v1, v2) => v1 - v2, left, right, result);
                                                    
            for (; i < left.Length; i++)
                result.RawValue(i) = (double)(left.RawValue(i) - right.RawValue(i));

            //Calculate validity (nulls)
            Bitmap.ElementWiseAnd(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }

        public override void ReverseSubtract(NativeMemoryNullableVector<float> left, NativeMemoryNullableVector<double> right, NativeMemoryNullableVector<double> result)
        {
            //Calculate raw values
            var i = SimdComputationsHelper.Compute((v1, v2) => v2 - v1, right, left, result);
                                                    
            for (; i < left.Length; i++)
                result.RawValue(i) = (double)(left.RawValue(i) - right.RawValue(i));

            //Calculate validity (nulls)
            Bitmap.ElementWiseAnd(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }

        #endregion

        #region Multiply
        public override void Multiply(NativeMemoryNullableVector<double> left, NativeMemoryNullableVector<double> right, NativeMemoryNullableVector<double> result)
        {
            //Calculate raw values
            var i = SimdComputationsHelper.Compute((v1, v2) => v1 * v2, left, right, result);
                                                    
            for (; i < left.Length; i++)
                result.RawValue(i) = (double)(left.RawValue(i) * right.RawValue(i));

            //Calculate validity (nulls)
            Bitmap.ElementWiseAnd(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }


        public override void Multiply(NativeMemoryNullableVector<double> left, NativeMemoryNullableVector<float> right, NativeMemoryNullableVector<double> result)
        {
            //Calculate raw values
            var i = SimdComputationsHelper.Compute((v1, v2) => v1 * v2, left, right, result);
                                                    
            for (; i < left.Length; i++)
                result.RawValue(i) = (double)(left.RawValue(i) * right.RawValue(i));

            //Calculate validity (nulls)
            Bitmap.ElementWiseAnd(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }


        #endregion

    }

    public class FloatSimdNumericArithmeticComputation : NumericArithmeticComputation<float>
    {

        #region Add
        public override void Add(NativeMemoryNullableVector<float> left, NativeMemoryNullableVector<float> right, NativeMemoryNullableVector<float> result)
        {
            //Calculate raw values
            var i = SimdComputationsHelper.Compute((v1, v2) => v1 + v2, left, right, result);
                                                    
            for (; i < left.Length; i++)
                result.RawValue(i) = (float)(left.RawValue(i) + right.RawValue(i));

            //Calculate validity (nulls)
            Bitmap.ElementWiseAnd(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }


        #endregion

        #region Subtract
        public override void Subtract(NativeMemoryNullableVector<float> left, NativeMemoryNullableVector<float> right, NativeMemoryNullableVector<float> result)
        {
            //Calculate raw values
            var i = SimdComputationsHelper.Compute((v1, v2) => v1 - v2, left, right, result);
                                                    
            for (; i < left.Length; i++)
                result.RawValue(i) = (float)(left.RawValue(i) - right.RawValue(i));

            //Calculate validity (nulls)
            Bitmap.ElementWiseAnd(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }

        public override void ReverseSubtract(NativeMemoryNullableVector<float> left, NativeMemoryNullableVector<float> right, NativeMemoryNullableVector<float> result)
        {
            //Calculate raw values
            var i = SimdComputationsHelper.Compute((v1, v2) => v2 - v1, right, left, result);
                                                    
            for (; i < left.Length; i++)
                result.RawValue(i) = (float)(left.RawValue(i) - right.RawValue(i));

            //Calculate validity (nulls)
            Bitmap.ElementWiseAnd(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }

        #endregion

        #region Multiply
        public override void Multiply(NativeMemoryNullableVector<float> left, NativeMemoryNullableVector<float> right, NativeMemoryNullableVector<float> result)
        {
            //Calculate raw values
            var i = SimdComputationsHelper.Compute((v1, v2) => v1 * v2, left, right, result);
                                                    
            for (; i < left.Length; i++)
                result.RawValue(i) = (float)(left.RawValue(i) * right.RawValue(i));

            //Calculate validity (nulls)
            Bitmap.ElementWiseAnd(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }


        #endregion

    }

    public class Int8SimdNumericArithmeticComputation : NumericArithmeticComputation<sbyte>
    {

        #region Add
        public override void Add(NativeMemoryNullableVector<sbyte> left, NativeMemoryNullableVector<sbyte> right, NativeMemoryNullableVector<sbyte> result)
        {
            //Calculate raw values
            var i = SimdComputationsHelper.Compute((v1, v2) => v1 + v2, left, right, result);
                                                    
            for (; i < left.Length; i++)
                result.RawValue(i) = (sbyte)(left.RawValue(i) + right.RawValue(i));

            //Calculate validity (nulls)
            Bitmap.ElementWiseAnd(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }


        #endregion

        #region Subtract
        public override void Subtract(NativeMemoryNullableVector<sbyte> left, NativeMemoryNullableVector<sbyte> right, NativeMemoryNullableVector<sbyte> result)
        {
            //Calculate raw values
            var i = SimdComputationsHelper.Compute((v1, v2) => v1 - v2, left, right, result);
                                                    
            for (; i < left.Length; i++)
                result.RawValue(i) = (sbyte)(left.RawValue(i) - right.RawValue(i));

            //Calculate validity (nulls)
            Bitmap.ElementWiseAnd(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }

        public override void ReverseSubtract(NativeMemoryNullableVector<sbyte> left, NativeMemoryNullableVector<sbyte> right, NativeMemoryNullableVector<sbyte> result)
        {
            //Calculate raw values
            var i = SimdComputationsHelper.Compute((v1, v2) => v2 - v1, right, left, result);
                                                    
            for (; i < left.Length; i++)
                result.RawValue(i) = (sbyte)(left.RawValue(i) - right.RawValue(i));

            //Calculate validity (nulls)
            Bitmap.ElementWiseAnd(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }

        #endregion

        #region Multiply
        public override void Multiply(NativeMemoryNullableVector<sbyte> left, NativeMemoryNullableVector<sbyte> right, NativeMemoryNullableVector<sbyte> result)
        {
            //Calculate raw values
            var i = SimdComputationsHelper.Compute((v1, v2) => v1 * v2, left, right, result);
                                                    
            for (; i < left.Length; i++)
                result.RawValue(i) = (sbyte)(left.RawValue(i) * right.RawValue(i));

            //Calculate validity (nulls)
            Bitmap.ElementWiseAnd(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }


        #endregion

    }

    public class UInt8SimdNumericArithmeticComputation : NumericArithmeticComputation<byte>
    {

        #region Add
        #endregion

        #region Subtract
        #endregion

        #region Multiply
        #endregion

    }

    public class Int16SimdNumericArithmeticComputation : NumericArithmeticComputation<short>
    {

        #region Add
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


        #endregion

        #region Subtract
        public override void Subtract(NativeMemoryNullableVector<short> left, NativeMemoryNullableVector<short> right, NativeMemoryNullableVector<short> result)
        {
            //Calculate raw values
            var i = SimdComputationsHelper.Compute((v1, v2) => v1 - v2, left, right, result);
                                                    
            for (; i < left.Length; i++)
                result.RawValue(i) = (short)(left.RawValue(i) - right.RawValue(i));

            //Calculate validity (nulls)
            Bitmap.ElementWiseAnd(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }

        public override void ReverseSubtract(NativeMemoryNullableVector<short> left, NativeMemoryNullableVector<short> right, NativeMemoryNullableVector<short> result)
        {
            //Calculate raw values
            var i = SimdComputationsHelper.Compute((v1, v2) => v2 - v1, right, left, result);
                                                    
            for (; i < left.Length; i++)
                result.RawValue(i) = (short)(left.RawValue(i) - right.RawValue(i));

            //Calculate validity (nulls)
            Bitmap.ElementWiseAnd(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }

        public override void Subtract(NativeMemoryNullableVector<short> left, NativeMemoryNullableVector<sbyte> right, NativeMemoryNullableVector<short> result)
        {
            //Calculate raw values
            var i = SimdComputationsHelper.Compute((v1, v2) => v1 - v2, left, right, result);
                                                    
            for (; i < left.Length; i++)
                result.RawValue(i) = (short)(left.RawValue(i) - right.RawValue(i));

            //Calculate validity (nulls)
            Bitmap.ElementWiseAnd(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }

        public override void ReverseSubtract(NativeMemoryNullableVector<sbyte> left, NativeMemoryNullableVector<short> right, NativeMemoryNullableVector<short> result)
        {
            //Calculate raw values
            var i = SimdComputationsHelper.Compute((v1, v2) => v2 - v1, right, left, result);
                                                    
            for (; i < left.Length; i++)
                result.RawValue(i) = (short)(left.RawValue(i) - right.RawValue(i));

            //Calculate validity (nulls)
            Bitmap.ElementWiseAnd(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }

        #endregion

        #region Multiply
        public override void Multiply(NativeMemoryNullableVector<short> left, NativeMemoryNullableVector<short> right, NativeMemoryNullableVector<short> result)
        {
            //Calculate raw values
            var i = SimdComputationsHelper.Compute((v1, v2) => v1 * v2, left, right, result);
                                                    
            for (; i < left.Length; i++)
                result.RawValue(i) = (short)(left.RawValue(i) * right.RawValue(i));

            //Calculate validity (nulls)
            Bitmap.ElementWiseAnd(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }


        public override void Multiply(NativeMemoryNullableVector<short> left, NativeMemoryNullableVector<sbyte> right, NativeMemoryNullableVector<short> result)
        {
            //Calculate raw values
            var i = SimdComputationsHelper.Compute((v1, v2) => v1 * v2, left, right, result);
                                                    
            for (; i < left.Length; i++)
                result.RawValue(i) = (short)(left.RawValue(i) * right.RawValue(i));

            //Calculate validity (nulls)
            Bitmap.ElementWiseAnd(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }


        #endregion

    }

    public class UInt16SimdNumericArithmeticComputation : NumericArithmeticComputation<ushort>
    {

        #region Add
        #endregion

        #region Subtract
        #endregion

        #region Multiply
        #endregion

    }

    public class Int32SimdNumericArithmeticComputation : NumericArithmeticComputation<int>
    {

        #region Add
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


        #endregion

        #region Subtract
        public override void Subtract(NativeMemoryNullableVector<int> left, NativeMemoryNullableVector<int> right, NativeMemoryNullableVector<int> result)
        {
            //Calculate raw values
            var i = SimdComputationsHelper.Compute((v1, v2) => v1 - v2, left, right, result);
                                                    
            for (; i < left.Length; i++)
                result.RawValue(i) = (int)(left.RawValue(i) - right.RawValue(i));

            //Calculate validity (nulls)
            Bitmap.ElementWiseAnd(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }

        public override void ReverseSubtract(NativeMemoryNullableVector<int> left, NativeMemoryNullableVector<int> right, NativeMemoryNullableVector<int> result)
        {
            //Calculate raw values
            var i = SimdComputationsHelper.Compute((v1, v2) => v2 - v1, right, left, result);
                                                    
            for (; i < left.Length; i++)
                result.RawValue(i) = (int)(left.RawValue(i) - right.RawValue(i));

            //Calculate validity (nulls)
            Bitmap.ElementWiseAnd(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }

        public override void Subtract(NativeMemoryNullableVector<int> left, NativeMemoryNullableVector<short> right, NativeMemoryNullableVector<int> result)
        {
            //Calculate raw values
            var i = SimdComputationsHelper.Compute((v1, v2) => v1 - v2, left, right, result);
                                                    
            for (; i < left.Length; i++)
                result.RawValue(i) = (int)(left.RawValue(i) - right.RawValue(i));

            //Calculate validity (nulls)
            Bitmap.ElementWiseAnd(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }

        public override void ReverseSubtract(NativeMemoryNullableVector<short> left, NativeMemoryNullableVector<int> right, NativeMemoryNullableVector<int> result)
        {
            //Calculate raw values
            var i = SimdComputationsHelper.Compute((v1, v2) => v2 - v1, right, left, result);
                                                    
            for (; i < left.Length; i++)
                result.RawValue(i) = (int)(left.RawValue(i) - right.RawValue(i));

            //Calculate validity (nulls)
            Bitmap.ElementWiseAnd(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }

        public override void Subtract(NativeMemoryNullableVector<int> left, NativeMemoryNullableVector<sbyte> right, NativeMemoryNullableVector<int> result)
        {
            //Calculate raw values
            var i = SimdComputationsHelper.Compute((v1, v2) => v1 - v2, left, right, result);
                                                    
            for (; i < left.Length; i++)
                result.RawValue(i) = (int)(left.RawValue(i) - right.RawValue(i));

            //Calculate validity (nulls)
            Bitmap.ElementWiseAnd(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }

        public override void ReverseSubtract(NativeMemoryNullableVector<sbyte> left, NativeMemoryNullableVector<int> right, NativeMemoryNullableVector<int> result)
        {
            //Calculate raw values
            var i = SimdComputationsHelper.Compute((v1, v2) => v2 - v1, right, left, result);
                                                    
            for (; i < left.Length; i++)
                result.RawValue(i) = (int)(left.RawValue(i) - right.RawValue(i));

            //Calculate validity (nulls)
            Bitmap.ElementWiseAnd(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }

        #endregion

        #region Multiply
        public override void Multiply(NativeMemoryNullableVector<int> left, NativeMemoryNullableVector<int> right, NativeMemoryNullableVector<int> result)
        {
            //Calculate raw values
            var i = SimdComputationsHelper.Compute((v1, v2) => v1 * v2, left, right, result);
                                                    
            for (; i < left.Length; i++)
                result.RawValue(i) = (int)(left.RawValue(i) * right.RawValue(i));

            //Calculate validity (nulls)
            Bitmap.ElementWiseAnd(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }


        public override void Multiply(NativeMemoryNullableVector<int> left, NativeMemoryNullableVector<short> right, NativeMemoryNullableVector<int> result)
        {
            //Calculate raw values
            var i = SimdComputationsHelper.Compute((v1, v2) => v1 * v2, left, right, result);
                                                    
            for (; i < left.Length; i++)
                result.RawValue(i) = (int)(left.RawValue(i) * right.RawValue(i));

            //Calculate validity (nulls)
            Bitmap.ElementWiseAnd(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }


        public override void Multiply(NativeMemoryNullableVector<int> left, NativeMemoryNullableVector<sbyte> right, NativeMemoryNullableVector<int> result)
        {
            //Calculate raw values
            var i = SimdComputationsHelper.Compute((v1, v2) => v1 * v2, left, right, result);
                                                    
            for (; i < left.Length; i++)
                result.RawValue(i) = (int)(left.RawValue(i) * right.RawValue(i));

            //Calculate validity (nulls)
            Bitmap.ElementWiseAnd(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }


        #endregion

    }

    public class UInt32SimdNumericArithmeticComputation : NumericArithmeticComputation<uint>
    {

        #region Add
        #endregion

        #region Subtract
        #endregion

        #region Multiply
        #endregion

    }

    public class Int64SimdNumericArithmeticComputation : NumericArithmeticComputation<long>
    {

        #region Add
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


        #endregion

        #region Subtract
        public override void Subtract(NativeMemoryNullableVector<long> left, NativeMemoryNullableVector<long> right, NativeMemoryNullableVector<long> result)
        {
            //Calculate raw values
            var i = SimdComputationsHelper.Compute((v1, v2) => v1 - v2, left, right, result);
                                                    
            for (; i < left.Length; i++)
                result.RawValue(i) = (long)(left.RawValue(i) - right.RawValue(i));

            //Calculate validity (nulls)
            Bitmap.ElementWiseAnd(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }

        public override void ReverseSubtract(NativeMemoryNullableVector<long> left, NativeMemoryNullableVector<long> right, NativeMemoryNullableVector<long> result)
        {
            //Calculate raw values
            var i = SimdComputationsHelper.Compute((v1, v2) => v2 - v1, right, left, result);
                                                    
            for (; i < left.Length; i++)
                result.RawValue(i) = (long)(left.RawValue(i) - right.RawValue(i));

            //Calculate validity (nulls)
            Bitmap.ElementWiseAnd(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }

        public override void Subtract(NativeMemoryNullableVector<long> left, NativeMemoryNullableVector<int> right, NativeMemoryNullableVector<long> result)
        {
            //Calculate raw values
            var i = SimdComputationsHelper.Compute((v1, v2) => v1 - v2, left, right, result);
                                                    
            for (; i < left.Length; i++)
                result.RawValue(i) = (long)(left.RawValue(i) - right.RawValue(i));

            //Calculate validity (nulls)
            Bitmap.ElementWiseAnd(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }

        public override void ReverseSubtract(NativeMemoryNullableVector<int> left, NativeMemoryNullableVector<long> right, NativeMemoryNullableVector<long> result)
        {
            //Calculate raw values
            var i = SimdComputationsHelper.Compute((v1, v2) => v2 - v1, right, left, result);
                                                    
            for (; i < left.Length; i++)
                result.RawValue(i) = (long)(left.RawValue(i) - right.RawValue(i));

            //Calculate validity (nulls)
            Bitmap.ElementWiseAnd(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }

        public override void Subtract(NativeMemoryNullableVector<long> left, NativeMemoryNullableVector<short> right, NativeMemoryNullableVector<long> result)
        {
            //Calculate raw values
            var i = SimdComputationsHelper.Compute((v1, v2) => v1 - v2, left, right, result);
                                                    
            for (; i < left.Length; i++)
                result.RawValue(i) = (long)(left.RawValue(i) - right.RawValue(i));

            //Calculate validity (nulls)
            Bitmap.ElementWiseAnd(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }

        public override void ReverseSubtract(NativeMemoryNullableVector<short> left, NativeMemoryNullableVector<long> right, NativeMemoryNullableVector<long> result)
        {
            //Calculate raw values
            var i = SimdComputationsHelper.Compute((v1, v2) => v2 - v1, right, left, result);
                                                    
            for (; i < left.Length; i++)
                result.RawValue(i) = (long)(left.RawValue(i) - right.RawValue(i));

            //Calculate validity (nulls)
            Bitmap.ElementWiseAnd(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }

        public override void Subtract(NativeMemoryNullableVector<long> left, NativeMemoryNullableVector<sbyte> right, NativeMemoryNullableVector<long> result)
        {
            //Calculate raw values
            var i = SimdComputationsHelper.Compute((v1, v2) => v1 - v2, left, right, result);
                                                    
            for (; i < left.Length; i++)
                result.RawValue(i) = (long)(left.RawValue(i) - right.RawValue(i));

            //Calculate validity (nulls)
            Bitmap.ElementWiseAnd(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }

        public override void ReverseSubtract(NativeMemoryNullableVector<sbyte> left, NativeMemoryNullableVector<long> right, NativeMemoryNullableVector<long> result)
        {
            //Calculate raw values
            var i = SimdComputationsHelper.Compute((v1, v2) => v2 - v1, right, left, result);
                                                    
            for (; i < left.Length; i++)
                result.RawValue(i) = (long)(left.RawValue(i) - right.RawValue(i));

            //Calculate validity (nulls)
            Bitmap.ElementWiseAnd(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }

        #endregion

        #region Multiply
        public override void Multiply(NativeMemoryNullableVector<long> left, NativeMemoryNullableVector<long> right, NativeMemoryNullableVector<long> result)
        {
            //Calculate raw values
            var i = SimdComputationsHelper.Compute((v1, v2) => v1 * v2, left, right, result);
                                                    
            for (; i < left.Length; i++)
                result.RawValue(i) = (long)(left.RawValue(i) * right.RawValue(i));

            //Calculate validity (nulls)
            Bitmap.ElementWiseAnd(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }


        public override void Multiply(NativeMemoryNullableVector<long> left, NativeMemoryNullableVector<int> right, NativeMemoryNullableVector<long> result)
        {
            //Calculate raw values
            var i = SimdComputationsHelper.Compute((v1, v2) => v1 * v2, left, right, result);
                                                    
            for (; i < left.Length; i++)
                result.RawValue(i) = (long)(left.RawValue(i) * right.RawValue(i));

            //Calculate validity (nulls)
            Bitmap.ElementWiseAnd(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }


        public override void Multiply(NativeMemoryNullableVector<long> left, NativeMemoryNullableVector<short> right, NativeMemoryNullableVector<long> result)
        {
            //Calculate raw values
            var i = SimdComputationsHelper.Compute((v1, v2) => v1 * v2, left, right, result);
                                                    
            for (; i < left.Length; i++)
                result.RawValue(i) = (long)(left.RawValue(i) * right.RawValue(i));

            //Calculate validity (nulls)
            Bitmap.ElementWiseAnd(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }


        public override void Multiply(NativeMemoryNullableVector<long> left, NativeMemoryNullableVector<sbyte> right, NativeMemoryNullableVector<long> result)
        {
            //Calculate raw values
            var i = SimdComputationsHelper.Compute((v1, v2) => v1 * v2, left, right, result);
                                                    
            for (; i < left.Length; i++)
                result.RawValue(i) = (long)(left.RawValue(i) * right.RawValue(i));

            //Calculate validity (nulls)
            Bitmap.ElementWiseAnd(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }


        #endregion

    }

    public class UInt64SimdNumericArithmeticComputation : NumericArithmeticComputation<ulong>
    {

        #region Add
        #endregion

        #region Subtract
        #endregion

        #region Multiply
        #endregion

    }
}

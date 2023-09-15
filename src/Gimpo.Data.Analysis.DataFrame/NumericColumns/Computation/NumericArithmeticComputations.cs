

// Generated from NumericArithmeticComputations.tt. Do not modify directly

using System;
using System.Collections.Generic;
using Gimpo.Data.Primitives;

namespace Gimpo.Data.Analysis
{
    public class DoubleNumericArithmeticComputation : NumericArithmeticComputation<double>
    {

        #region Add
        public override void Add(NativeMemoryNullableVector<double> left, NativeMemoryNullableVector<double> right, NativeMemoryNullableVector<double> result)
        {
            for (long i = 0; i < left.Length; i++)
            {                
                result.RawValue(i) = (double)(left.RawValue(i) + right.RawValue(i));
            }

            //Calculate validity (nulls)
            Bitmap.ElementWiseAnd(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }

        public override void Add(NativeMemoryNullableVector<double> left, NativeMemoryNullableVector<float> right, NativeMemoryNullableVector<double> result)
        {
            for (long i = 0; i < left.Length; i++)
            {                
                result.RawValue(i) = (double)(left.RawValue(i) + right.RawValue(i));
            }

            //Calculate validity (nulls)
            Bitmap.ElementWiseAnd(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }

        #endregion

        #region Subtract
        public override void Subtract(NativeMemoryNullableVector<double> left, NativeMemoryNullableVector<double> right, NativeMemoryNullableVector<double> result)
        {
            for (long i = 0; i < left.Length; i++)
            {                
                result.RawValue(i) = (double)(left.RawValue(i) - right.RawValue(i));
            }

            //Calculate validity (nulls)
            Bitmap.ElementWiseAnd(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }

        public override void ReverseSubtract(NativeMemoryNullableVector<double> left, NativeMemoryNullableVector<double> right, NativeMemoryNullableVector<double> result)
        {
            for (long i = 0; i < left.Length; i++)
            {                
                result.RawValue(i) = (double)(left.RawValue(i) - right.RawValue(i));
            }

            //Calculate validity (nulls)
            Bitmap.ElementWiseAnd(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }

        public override void Subtract(NativeMemoryNullableVector<double> left, NativeMemoryNullableVector<float> right, NativeMemoryNullableVector<double> result)
        {
            for (long i = 0; i < left.Length; i++)
            {                
                result.RawValue(i) = (double)(left.RawValue(i) - right.RawValue(i));
            }

            //Calculate validity (nulls)
            Bitmap.ElementWiseAnd(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }

        public override void ReverseSubtract(NativeMemoryNullableVector<float> left, NativeMemoryNullableVector<double> right, NativeMemoryNullableVector<double> result)
        {
            for (long i = 0; i < left.Length; i++)
            {                
                result.RawValue(i) = (double)(left.RawValue(i) - right.RawValue(i));
            }

            //Calculate validity (nulls)
            Bitmap.ElementWiseAnd(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }

        #endregion

        #region Multiply
        public override void Multiply(NativeMemoryNullableVector<double> left, NativeMemoryNullableVector<double> right, NativeMemoryNullableVector<double> result)
        {
            for (long i = 0; i < left.Length; i++)
            {                
                result.RawValue(i) = (double)(left.RawValue(i) * right.RawValue(i));
            }

            //Calculate validity (nulls)
            Bitmap.ElementWiseAnd(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }

        public override void Multiply(NativeMemoryNullableVector<double> left, NativeMemoryNullableVector<float> right, NativeMemoryNullableVector<double> result)
        {
            for (long i = 0; i < left.Length; i++)
            {                
                result.RawValue(i) = (double)(left.RawValue(i) * right.RawValue(i));
            }

            //Calculate validity (nulls)
            Bitmap.ElementWiseAnd(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }

        #endregion

        #region Divide
        public override void Divide(NativeMemoryNullableVector<double> left, NativeMemoryNullableVector<double> right, NativeMemoryNullableVector<double> result)
        {
            for (long i = 0; i < left.Length; i++)
            {
                result[i] = left.HasValue(i) && right.HasValue(i) ? (double?)(left[i].Value / right[i].Value) : (double?) null;
            }
        }

        public override void Divide(NativeMemoryNullableVector<double> left, NativeMemoryNullableVector<float> right, NativeMemoryNullableVector<double> result)
        {
            for (long i = 0; i < left.Length; i++)
            {
                result[i] = left.HasValue(i) && right.HasValue(i) ? (double?)(left[i].Value / right[i].Value) : (double?) null;
            }
        }

        #endregion

    }
    public class FloatNumericArithmeticComputation : NumericArithmeticComputation<float>
    {

        #region Add
        public override void Add(NativeMemoryNullableVector<float> left, NativeMemoryNullableVector<float> right, NativeMemoryNullableVector<float> result)
        {
            for (long i = 0; i < left.Length; i++)
            {                
                result.RawValue(i) = (float)(left.RawValue(i) + right.RawValue(i));
            }

            //Calculate validity (nulls)
            Bitmap.ElementWiseAnd(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }

        #endregion

        #region Subtract
        public override void Subtract(NativeMemoryNullableVector<float> left, NativeMemoryNullableVector<float> right, NativeMemoryNullableVector<float> result)
        {
            for (long i = 0; i < left.Length; i++)
            {                
                result.RawValue(i) = (float)(left.RawValue(i) - right.RawValue(i));
            }

            //Calculate validity (nulls)
            Bitmap.ElementWiseAnd(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }

        public override void ReverseSubtract(NativeMemoryNullableVector<float> left, NativeMemoryNullableVector<float> right, NativeMemoryNullableVector<float> result)
        {
            for (long i = 0; i < left.Length; i++)
            {                
                result.RawValue(i) = (float)(left.RawValue(i) - right.RawValue(i));
            }

            //Calculate validity (nulls)
            Bitmap.ElementWiseAnd(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }

        #endregion

        #region Multiply
        public override void Multiply(NativeMemoryNullableVector<float> left, NativeMemoryNullableVector<float> right, NativeMemoryNullableVector<float> result)
        {
            for (long i = 0; i < left.Length; i++)
            {                
                result.RawValue(i) = (float)(left.RawValue(i) * right.RawValue(i));
            }

            //Calculate validity (nulls)
            Bitmap.ElementWiseAnd(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }

        #endregion

        #region Divide
        public override void Divide(NativeMemoryNullableVector<float> left, NativeMemoryNullableVector<float> right, NativeMemoryNullableVector<float> result)
        {
            for (long i = 0; i < left.Length; i++)
            {
                result[i] = left.HasValue(i) && right.HasValue(i) ? (float?)(left[i].Value / right[i].Value) : (float?) null;
            }
        }

        #endregion

    }
    public class Int8NumericArithmeticComputation : NumericArithmeticComputation<sbyte>
    {

        #region Add
        public override void Add(NativeMemoryNullableVector<sbyte> left, NativeMemoryNullableVector<sbyte> right, NativeMemoryNullableVector<sbyte> result)
        {
            for (long i = 0; i < left.Length; i++)
            {                
                result.RawValue(i) = (sbyte)(left.RawValue(i) + right.RawValue(i));
            }

            //Calculate validity (nulls)
            Bitmap.ElementWiseAnd(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }

        #endregion

        #region Subtract
        public override void Subtract(NativeMemoryNullableVector<sbyte> left, NativeMemoryNullableVector<sbyte> right, NativeMemoryNullableVector<sbyte> result)
        {
            for (long i = 0; i < left.Length; i++)
            {                
                result.RawValue(i) = (sbyte)(left.RawValue(i) - right.RawValue(i));
            }

            //Calculate validity (nulls)
            Bitmap.ElementWiseAnd(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }

        public override void ReverseSubtract(NativeMemoryNullableVector<sbyte> left, NativeMemoryNullableVector<sbyte> right, NativeMemoryNullableVector<sbyte> result)
        {
            for (long i = 0; i < left.Length; i++)
            {                
                result.RawValue(i) = (sbyte)(left.RawValue(i) - right.RawValue(i));
            }

            //Calculate validity (nulls)
            Bitmap.ElementWiseAnd(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }

        #endregion

        #region Multiply
        public override void Multiply(NativeMemoryNullableVector<sbyte> left, NativeMemoryNullableVector<sbyte> right, NativeMemoryNullableVector<sbyte> result)
        {
            for (long i = 0; i < left.Length; i++)
            {                
                result.RawValue(i) = (sbyte)(left.RawValue(i) * right.RawValue(i));
            }

            //Calculate validity (nulls)
            Bitmap.ElementWiseAnd(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }

        #endregion

        #region Divide
        public override void Divide(NativeMemoryNullableVector<sbyte> left, NativeMemoryNullableVector<sbyte> right, NativeMemoryNullableVector<sbyte> result)
        {
            for (long i = 0; i < left.Length; i++)
            {
                result[i] = left.HasValue(i) && right.HasValue(i) ? (sbyte?)(left[i].Value / right[i].Value) : (sbyte?) null;
            }
        }

        #endregion

    }
    public class UInt8NumericArithmeticComputation : NumericArithmeticComputation<byte>
    {

        #region Add
        #endregion

        #region Subtract
        #endregion

        #region Multiply
        #endregion

        #region Divide
        #endregion

    }
    public class Int16NumericArithmeticComputation : NumericArithmeticComputation<short>
    {

        #region Add
        public override void Add(NativeMemoryNullableVector<short> left, NativeMemoryNullableVector<short> right, NativeMemoryNullableVector<short> result)
        {
            for (long i = 0; i < left.Length; i++)
            {                
                result.RawValue(i) = (short)(left.RawValue(i) + right.RawValue(i));
            }

            //Calculate validity (nulls)
            Bitmap.ElementWiseAnd(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }

        public override void Add(NativeMemoryNullableVector<short> left, NativeMemoryNullableVector<sbyte> right, NativeMemoryNullableVector<short> result)
        {
            for (long i = 0; i < left.Length; i++)
            {                
                result.RawValue(i) = (short)(left.RawValue(i) + right.RawValue(i));
            }

            //Calculate validity (nulls)
            Bitmap.ElementWiseAnd(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }

        #endregion

        #region Subtract
        public override void Subtract(NativeMemoryNullableVector<short> left, NativeMemoryNullableVector<short> right, NativeMemoryNullableVector<short> result)
        {
            for (long i = 0; i < left.Length; i++)
            {                
                result.RawValue(i) = (short)(left.RawValue(i) - right.RawValue(i));
            }

            //Calculate validity (nulls)
            Bitmap.ElementWiseAnd(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }

        public override void ReverseSubtract(NativeMemoryNullableVector<short> left, NativeMemoryNullableVector<short> right, NativeMemoryNullableVector<short> result)
        {
            for (long i = 0; i < left.Length; i++)
            {                
                result.RawValue(i) = (short)(left.RawValue(i) - right.RawValue(i));
            }

            //Calculate validity (nulls)
            Bitmap.ElementWiseAnd(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }

        public override void Subtract(NativeMemoryNullableVector<short> left, NativeMemoryNullableVector<sbyte> right, NativeMemoryNullableVector<short> result)
        {
            for (long i = 0; i < left.Length; i++)
            {                
                result.RawValue(i) = (short)(left.RawValue(i) - right.RawValue(i));
            }

            //Calculate validity (nulls)
            Bitmap.ElementWiseAnd(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }

        public override void ReverseSubtract(NativeMemoryNullableVector<sbyte> left, NativeMemoryNullableVector<short> right, NativeMemoryNullableVector<short> result)
        {
            for (long i = 0; i < left.Length; i++)
            {                
                result.RawValue(i) = (short)(left.RawValue(i) - right.RawValue(i));
            }

            //Calculate validity (nulls)
            Bitmap.ElementWiseAnd(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }

        #endregion

        #region Multiply
        public override void Multiply(NativeMemoryNullableVector<short> left, NativeMemoryNullableVector<short> right, NativeMemoryNullableVector<short> result)
        {
            for (long i = 0; i < left.Length; i++)
            {                
                result.RawValue(i) = (short)(left.RawValue(i) * right.RawValue(i));
            }

            //Calculate validity (nulls)
            Bitmap.ElementWiseAnd(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }

        public override void Multiply(NativeMemoryNullableVector<short> left, NativeMemoryNullableVector<sbyte> right, NativeMemoryNullableVector<short> result)
        {
            for (long i = 0; i < left.Length; i++)
            {                
                result.RawValue(i) = (short)(left.RawValue(i) * right.RawValue(i));
            }

            //Calculate validity (nulls)
            Bitmap.ElementWiseAnd(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }

        #endregion

        #region Divide
        public override void Divide(NativeMemoryNullableVector<short> left, NativeMemoryNullableVector<short> right, NativeMemoryNullableVector<short> result)
        {
            for (long i = 0; i < left.Length; i++)
            {
                result[i] = left.HasValue(i) && right.HasValue(i) ? (short?)(left[i].Value / right[i].Value) : (short?) null;
            }
        }

        public override void Divide(NativeMemoryNullableVector<short> left, NativeMemoryNullableVector<sbyte> right, NativeMemoryNullableVector<short> result)
        {
            for (long i = 0; i < left.Length; i++)
            {
                result[i] = left.HasValue(i) && right.HasValue(i) ? (short?)(left[i].Value / right[i].Value) : (short?) null;
            }
        }

        #endregion

    }
    public class UInt16NumericArithmeticComputation : NumericArithmeticComputation<ushort>
    {

        #region Add
        #endregion

        #region Subtract
        #endregion

        #region Multiply
        #endregion

        #region Divide
        #endregion

    }
    public class Int32NumericArithmeticComputation : NumericArithmeticComputation<int>
    {

        #region Add
        public override void Add(NativeMemoryNullableVector<int> left, NativeMemoryNullableVector<int> right, NativeMemoryNullableVector<int> result)
        {
            for (long i = 0; i < left.Length; i++)
            {                
                result.RawValue(i) = (int)(left.RawValue(i) + right.RawValue(i));
            }

            //Calculate validity (nulls)
            Bitmap.ElementWiseAnd(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }

        public override void Add(NativeMemoryNullableVector<int> left, NativeMemoryNullableVector<short> right, NativeMemoryNullableVector<int> result)
        {
            for (long i = 0; i < left.Length; i++)
            {                
                result.RawValue(i) = (int)(left.RawValue(i) + right.RawValue(i));
            }

            //Calculate validity (nulls)
            Bitmap.ElementWiseAnd(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }

        public override void Add(NativeMemoryNullableVector<int> left, NativeMemoryNullableVector<sbyte> right, NativeMemoryNullableVector<int> result)
        {
            for (long i = 0; i < left.Length; i++)
            {                
                result.RawValue(i) = (int)(left.RawValue(i) + right.RawValue(i));
            }

            //Calculate validity (nulls)
            Bitmap.ElementWiseAnd(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }

        #endregion

        #region Subtract
        public override void Subtract(NativeMemoryNullableVector<int> left, NativeMemoryNullableVector<int> right, NativeMemoryNullableVector<int> result)
        {
            for (long i = 0; i < left.Length; i++)
            {                
                result.RawValue(i) = (int)(left.RawValue(i) - right.RawValue(i));
            }

            //Calculate validity (nulls)
            Bitmap.ElementWiseAnd(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }

        public override void ReverseSubtract(NativeMemoryNullableVector<int> left, NativeMemoryNullableVector<int> right, NativeMemoryNullableVector<int> result)
        {
            for (long i = 0; i < left.Length; i++)
            {                
                result.RawValue(i) = (int)(left.RawValue(i) - right.RawValue(i));
            }

            //Calculate validity (nulls)
            Bitmap.ElementWiseAnd(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }

        public override void Subtract(NativeMemoryNullableVector<int> left, NativeMemoryNullableVector<short> right, NativeMemoryNullableVector<int> result)
        {
            for (long i = 0; i < left.Length; i++)
            {                
                result.RawValue(i) = (int)(left.RawValue(i) - right.RawValue(i));
            }

            //Calculate validity (nulls)
            Bitmap.ElementWiseAnd(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }

        public override void ReverseSubtract(NativeMemoryNullableVector<short> left, NativeMemoryNullableVector<int> right, NativeMemoryNullableVector<int> result)
        {
            for (long i = 0; i < left.Length; i++)
            {                
                result.RawValue(i) = (int)(left.RawValue(i) - right.RawValue(i));
            }

            //Calculate validity (nulls)
            Bitmap.ElementWiseAnd(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }

        public override void Subtract(NativeMemoryNullableVector<int> left, NativeMemoryNullableVector<sbyte> right, NativeMemoryNullableVector<int> result)
        {
            for (long i = 0; i < left.Length; i++)
            {                
                result.RawValue(i) = (int)(left.RawValue(i) - right.RawValue(i));
            }

            //Calculate validity (nulls)
            Bitmap.ElementWiseAnd(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }

        public override void ReverseSubtract(NativeMemoryNullableVector<sbyte> left, NativeMemoryNullableVector<int> right, NativeMemoryNullableVector<int> result)
        {
            for (long i = 0; i < left.Length; i++)
            {                
                result.RawValue(i) = (int)(left.RawValue(i) - right.RawValue(i));
            }

            //Calculate validity (nulls)
            Bitmap.ElementWiseAnd(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }

        #endregion

        #region Multiply
        public override void Multiply(NativeMemoryNullableVector<int> left, NativeMemoryNullableVector<int> right, NativeMemoryNullableVector<int> result)
        {
            for (long i = 0; i < left.Length; i++)
            {                
                result.RawValue(i) = (int)(left.RawValue(i) * right.RawValue(i));
            }

            //Calculate validity (nulls)
            Bitmap.ElementWiseAnd(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }

        public override void Multiply(NativeMemoryNullableVector<int> left, NativeMemoryNullableVector<short> right, NativeMemoryNullableVector<int> result)
        {
            for (long i = 0; i < left.Length; i++)
            {                
                result.RawValue(i) = (int)(left.RawValue(i) * right.RawValue(i));
            }

            //Calculate validity (nulls)
            Bitmap.ElementWiseAnd(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }

        public override void Multiply(NativeMemoryNullableVector<int> left, NativeMemoryNullableVector<sbyte> right, NativeMemoryNullableVector<int> result)
        {
            for (long i = 0; i < left.Length; i++)
            {                
                result.RawValue(i) = (int)(left.RawValue(i) * right.RawValue(i));
            }

            //Calculate validity (nulls)
            Bitmap.ElementWiseAnd(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }

        #endregion

        #region Divide
        public override void Divide(NativeMemoryNullableVector<int> left, NativeMemoryNullableVector<int> right, NativeMemoryNullableVector<int> result)
        {
            for (long i = 0; i < left.Length; i++)
            {
                result[i] = left.HasValue(i) && right.HasValue(i) ? (int?)(left[i].Value / right[i].Value) : (int?) null;
            }
        }

        public override void Divide(NativeMemoryNullableVector<int> left, NativeMemoryNullableVector<short> right, NativeMemoryNullableVector<int> result)
        {
            for (long i = 0; i < left.Length; i++)
            {
                result[i] = left.HasValue(i) && right.HasValue(i) ? (int?)(left[i].Value / right[i].Value) : (int?) null;
            }
        }

        public override void Divide(NativeMemoryNullableVector<int> left, NativeMemoryNullableVector<sbyte> right, NativeMemoryNullableVector<int> result)
        {
            for (long i = 0; i < left.Length; i++)
            {
                result[i] = left.HasValue(i) && right.HasValue(i) ? (int?)(left[i].Value / right[i].Value) : (int?) null;
            }
        }

        #endregion

    }
    public class UInt32NumericArithmeticComputation : NumericArithmeticComputation<uint>
    {

        #region Add
        #endregion

        #region Subtract
        #endregion

        #region Multiply
        #endregion

        #region Divide
        #endregion

    }
    public class Int64NumericArithmeticComputation : NumericArithmeticComputation<long>
    {

        #region Add
        public override void Add(NativeMemoryNullableVector<long> left, NativeMemoryNullableVector<long> right, NativeMemoryNullableVector<long> result)
        {
            for (long i = 0; i < left.Length; i++)
            {                
                result.RawValue(i) = (long)(left.RawValue(i) + right.RawValue(i));
            }

            //Calculate validity (nulls)
            Bitmap.ElementWiseAnd(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }

        public override void Add(NativeMemoryNullableVector<long> left, NativeMemoryNullableVector<int> right, NativeMemoryNullableVector<long> result)
        {
            for (long i = 0; i < left.Length; i++)
            {                
                result.RawValue(i) = (long)(left.RawValue(i) + right.RawValue(i));
            }

            //Calculate validity (nulls)
            Bitmap.ElementWiseAnd(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }

        public override void Add(NativeMemoryNullableVector<long> left, NativeMemoryNullableVector<short> right, NativeMemoryNullableVector<long> result)
        {
            for (long i = 0; i < left.Length; i++)
            {                
                result.RawValue(i) = (long)(left.RawValue(i) + right.RawValue(i));
            }

            //Calculate validity (nulls)
            Bitmap.ElementWiseAnd(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }

        public override void Add(NativeMemoryNullableVector<long> left, NativeMemoryNullableVector<sbyte> right, NativeMemoryNullableVector<long> result)
        {
            for (long i = 0; i < left.Length; i++)
            {                
                result.RawValue(i) = (long)(left.RawValue(i) + right.RawValue(i));
            }

            //Calculate validity (nulls)
            Bitmap.ElementWiseAnd(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }

        #endregion

        #region Subtract
        public override void Subtract(NativeMemoryNullableVector<long> left, NativeMemoryNullableVector<long> right, NativeMemoryNullableVector<long> result)
        {
            for (long i = 0; i < left.Length; i++)
            {                
                result.RawValue(i) = (long)(left.RawValue(i) - right.RawValue(i));
            }

            //Calculate validity (nulls)
            Bitmap.ElementWiseAnd(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }

        public override void ReverseSubtract(NativeMemoryNullableVector<long> left, NativeMemoryNullableVector<long> right, NativeMemoryNullableVector<long> result)
        {
            for (long i = 0; i < left.Length; i++)
            {                
                result.RawValue(i) = (long)(left.RawValue(i) - right.RawValue(i));
            }

            //Calculate validity (nulls)
            Bitmap.ElementWiseAnd(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }

        public override void Subtract(NativeMemoryNullableVector<long> left, NativeMemoryNullableVector<int> right, NativeMemoryNullableVector<long> result)
        {
            for (long i = 0; i < left.Length; i++)
            {                
                result.RawValue(i) = (long)(left.RawValue(i) - right.RawValue(i));
            }

            //Calculate validity (nulls)
            Bitmap.ElementWiseAnd(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }

        public override void ReverseSubtract(NativeMemoryNullableVector<int> left, NativeMemoryNullableVector<long> right, NativeMemoryNullableVector<long> result)
        {
            for (long i = 0; i < left.Length; i++)
            {                
                result.RawValue(i) = (long)(left.RawValue(i) - right.RawValue(i));
            }

            //Calculate validity (nulls)
            Bitmap.ElementWiseAnd(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }

        public override void Subtract(NativeMemoryNullableVector<long> left, NativeMemoryNullableVector<short> right, NativeMemoryNullableVector<long> result)
        {
            for (long i = 0; i < left.Length; i++)
            {                
                result.RawValue(i) = (long)(left.RawValue(i) - right.RawValue(i));
            }

            //Calculate validity (nulls)
            Bitmap.ElementWiseAnd(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }

        public override void ReverseSubtract(NativeMemoryNullableVector<short> left, NativeMemoryNullableVector<long> right, NativeMemoryNullableVector<long> result)
        {
            for (long i = 0; i < left.Length; i++)
            {                
                result.RawValue(i) = (long)(left.RawValue(i) - right.RawValue(i));
            }

            //Calculate validity (nulls)
            Bitmap.ElementWiseAnd(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }

        public override void Subtract(NativeMemoryNullableVector<long> left, NativeMemoryNullableVector<sbyte> right, NativeMemoryNullableVector<long> result)
        {
            for (long i = 0; i < left.Length; i++)
            {                
                result.RawValue(i) = (long)(left.RawValue(i) - right.RawValue(i));
            }

            //Calculate validity (nulls)
            Bitmap.ElementWiseAnd(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }

        public override void ReverseSubtract(NativeMemoryNullableVector<sbyte> left, NativeMemoryNullableVector<long> right, NativeMemoryNullableVector<long> result)
        {
            for (long i = 0; i < left.Length; i++)
            {                
                result.RawValue(i) = (long)(left.RawValue(i) - right.RawValue(i));
            }

            //Calculate validity (nulls)
            Bitmap.ElementWiseAnd(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }

        #endregion

        #region Multiply
        public override void Multiply(NativeMemoryNullableVector<long> left, NativeMemoryNullableVector<long> right, NativeMemoryNullableVector<long> result)
        {
            for (long i = 0; i < left.Length; i++)
            {                
                result.RawValue(i) = (long)(left.RawValue(i) * right.RawValue(i));
            }

            //Calculate validity (nulls)
            Bitmap.ElementWiseAnd(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }

        public override void Multiply(NativeMemoryNullableVector<long> left, NativeMemoryNullableVector<int> right, NativeMemoryNullableVector<long> result)
        {
            for (long i = 0; i < left.Length; i++)
            {                
                result.RawValue(i) = (long)(left.RawValue(i) * right.RawValue(i));
            }

            //Calculate validity (nulls)
            Bitmap.ElementWiseAnd(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }

        public override void Multiply(NativeMemoryNullableVector<long> left, NativeMemoryNullableVector<short> right, NativeMemoryNullableVector<long> result)
        {
            for (long i = 0; i < left.Length; i++)
            {                
                result.RawValue(i) = (long)(left.RawValue(i) * right.RawValue(i));
            }

            //Calculate validity (nulls)
            Bitmap.ElementWiseAnd(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }

        public override void Multiply(NativeMemoryNullableVector<long> left, NativeMemoryNullableVector<sbyte> right, NativeMemoryNullableVector<long> result)
        {
            for (long i = 0; i < left.Length; i++)
            {                
                result.RawValue(i) = (long)(left.RawValue(i) * right.RawValue(i));
            }

            //Calculate validity (nulls)
            Bitmap.ElementWiseAnd(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }

        #endregion

        #region Divide
        public override void Divide(NativeMemoryNullableVector<long> left, NativeMemoryNullableVector<long> right, NativeMemoryNullableVector<long> result)
        {
            for (long i = 0; i < left.Length; i++)
            {
                result[i] = left.HasValue(i) && right.HasValue(i) ? (long?)(left[i].Value / right[i].Value) : (long?) null;
            }
        }

        public override void Divide(NativeMemoryNullableVector<long> left, NativeMemoryNullableVector<int> right, NativeMemoryNullableVector<long> result)
        {
            for (long i = 0; i < left.Length; i++)
            {
                result[i] = left.HasValue(i) && right.HasValue(i) ? (long?)(left[i].Value / right[i].Value) : (long?) null;
            }
        }

        public override void Divide(NativeMemoryNullableVector<long> left, NativeMemoryNullableVector<short> right, NativeMemoryNullableVector<long> result)
        {
            for (long i = 0; i < left.Length; i++)
            {
                result[i] = left.HasValue(i) && right.HasValue(i) ? (long?)(left[i].Value / right[i].Value) : (long?) null;
            }
        }

        public override void Divide(NativeMemoryNullableVector<long> left, NativeMemoryNullableVector<sbyte> right, NativeMemoryNullableVector<long> result)
        {
            for (long i = 0; i < left.Length; i++)
            {
                result[i] = left.HasValue(i) && right.HasValue(i) ? (long?)(left[i].Value / right[i].Value) : (long?) null;
            }
        }

        #endregion

    }
    public class UInt64NumericArithmeticComputation : NumericArithmeticComputation<ulong>
    {

        #region Add
        #endregion

        #region Subtract
        #endregion

        #region Multiply
        #endregion

        #region Divide
        #endregion

    }
}


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
            //Calculate raw values
            int vectorSize = Vector<double>.Count;

            long i;
                        
            for (i = 0; i < left.Length - vectorSize; i += vectorSize)
            {
                var vector = left.LoadVector(i) + (Vector<double>)right.LoadVector(i);
                result.WriteVector(i, vector);
            }

            for (; i < left.Length; i++)
                result[i] = (double)(left[i].Value + right[i].Value);

            //Calculate validity (nulls)
            Bitmap.ElementWiseXorBitmap(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }

        public override void Add(NativeMemoryNullableVector<double> left, NativeMemoryNullableVector<float> right, NativeMemoryNullableVector<double> result)
        {
            //Calculate raw values
            int vectorSize = Vector<double>.Count;

            long i;
                        
            for (i = 0; i < left.Length - vectorSize; i += vectorSize)
            {
                var vector = left.LoadVector(i) + (Vector<double>)right.LoadVector(i);
                result.WriteVector(i, vector);
            }

            for (; i < left.Length; i++)
                result[i] = (double)(left[i].Value + right[i].Value);

            //Calculate validity (nulls)
            Bitmap.ElementWiseXorBitmap(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }

    }

    public class FloatSimdNumericArithmeticComputation : NumericArithmeticComputation<float>
    {
        public override void Add(NativeMemoryNullableVector<float> left, NativeMemoryNullableVector<float> right, NativeMemoryNullableVector<float> result)
        {
            //Calculate raw values
            int vectorSize = Vector<float>.Count;

            long i;
                        
            for (i = 0; i < left.Length - vectorSize; i += vectorSize)
            {
                var vector = left.LoadVector(i) + (Vector<float>)right.LoadVector(i);
                result.WriteVector(i, vector);
            }

            for (; i < left.Length; i++)
                result[i] = (float)(left[i].Value + right[i].Value);

            //Calculate validity (nulls)
            Bitmap.ElementWiseXorBitmap(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }

    }

    public class Int8SimdNumericArithmeticComputation : NumericArithmeticComputation<sbyte>
    {
        public override void Add(NativeMemoryNullableVector<sbyte> left, NativeMemoryNullableVector<sbyte> right, NativeMemoryNullableVector<sbyte> result)
        {
            //Calculate raw values
            int vectorSize = Vector<sbyte>.Count;

            long i;
                        
            for (i = 0; i < left.Length - vectorSize; i += vectorSize)
            {
                var vector = left.LoadVector(i) + (Vector<sbyte>)right.LoadVector(i);
                result.WriteVector(i, vector);
            }

            for (; i < left.Length; i++)
                result[i] = (sbyte)(left[i].Value + right[i].Value);

            //Calculate validity (nulls)
            Bitmap.ElementWiseXorBitmap(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
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
            int vectorSize = Vector<short>.Count;

            long i;
                        
            for (i = 0; i < left.Length - vectorSize; i += vectorSize)
            {
                var vector = left.LoadVector(i) + (Vector<short>)right.LoadVector(i);
                result.WriteVector(i, vector);
            }

            for (; i < left.Length; i++)
                result[i] = (short)(left[i].Value + right[i].Value);

            //Calculate validity (nulls)
            Bitmap.ElementWiseXorBitmap(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }

        public override void Add(NativeMemoryNullableVector<short> left, NativeMemoryNullableVector<sbyte> right, NativeMemoryNullableVector<short> result)
        {
            //Calculate raw values
            int vectorSize = Vector<short>.Count;

            long i;
                        
            for (i = 0; i < left.Length - vectorSize; i += vectorSize)
            {
                var vector = left.LoadVector(i) + (Vector<short>)right.LoadVector(i);
                result.WriteVector(i, vector);
            }

            for (; i < left.Length; i++)
                result[i] = (short)(left[i].Value + right[i].Value);

            //Calculate validity (nulls)
            Bitmap.ElementWiseXorBitmap(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
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
            int vectorSize = Vector<int>.Count;

            long i;
                        
            for (i = 0; i < left.Length - vectorSize; i += vectorSize)
            {
                var vector = left.LoadVector(i) + (Vector<int>)right.LoadVector(i);
                result.WriteVector(i, vector);
            }

            for (; i < left.Length; i++)
                result[i] = (int)(left[i].Value + right[i].Value);

            //Calculate validity (nulls)
            Bitmap.ElementWiseXorBitmap(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }

        public override void Add(NativeMemoryNullableVector<int> left, NativeMemoryNullableVector<short> right, NativeMemoryNullableVector<int> result)
        {
            //Calculate raw values
            int vectorSize = Vector<int>.Count;

            long i;
                        
            for (i = 0; i < left.Length - vectorSize; i += vectorSize)
            {
                var vector = left.LoadVector(i) + (Vector<int>)right.LoadVector(i);
                result.WriteVector(i, vector);
            }

            for (; i < left.Length; i++)
                result[i] = (int)(left[i].Value + right[i].Value);

            //Calculate validity (nulls)
            Bitmap.ElementWiseXorBitmap(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }

        public override void Add(NativeMemoryNullableVector<int> left, NativeMemoryNullableVector<sbyte> right, NativeMemoryNullableVector<int> result)
        {
            //Calculate raw values
            int vectorSize = Vector<int>.Count;

            long i;
                        
            for (i = 0; i < left.Length - vectorSize; i += vectorSize)
            {
                var vector = left.LoadVector(i) + (Vector<int>)right.LoadVector(i);
                result.WriteVector(i, vector);
            }

            for (; i < left.Length; i++)
                result[i] = (int)(left[i].Value + right[i].Value);

            //Calculate validity (nulls)
            Bitmap.ElementWiseXorBitmap(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
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
            int vectorSize = Vector<long>.Count;

            long i;
                        
            for (i = 0; i < left.Length - vectorSize; i += vectorSize)
            {
                var vector = left.LoadVector(i) + (Vector<long>)right.LoadVector(i);
                result.WriteVector(i, vector);
            }

            for (; i < left.Length; i++)
                result[i] = (long)(left[i].Value + right[i].Value);

            //Calculate validity (nulls)
            Bitmap.ElementWiseXorBitmap(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }

        public override void Add(NativeMemoryNullableVector<long> left, NativeMemoryNullableVector<int> right, NativeMemoryNullableVector<long> result)
        {
            //Calculate raw values
            int vectorSize = Vector<long>.Count;

            long i;
                        
            for (i = 0; i < left.Length - vectorSize; i += vectorSize)
            {
                var vector = left.LoadVector(i) + (Vector<long>)right.LoadVector(i);
                result.WriteVector(i, vector);
            }

            for (; i < left.Length; i++)
                result[i] = (long)(left[i].Value + right[i].Value);

            //Calculate validity (nulls)
            Bitmap.ElementWiseXorBitmap(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }

        public override void Add(NativeMemoryNullableVector<long> left, NativeMemoryNullableVector<short> right, NativeMemoryNullableVector<long> result)
        {
            //Calculate raw values
            int vectorSize = Vector<long>.Count;

            long i;
                        
            for (i = 0; i < left.Length - vectorSize; i += vectorSize)
            {
                var vector = left.LoadVector(i) + (Vector<long>)right.LoadVector(i);
                result.WriteVector(i, vector);
            }

            for (; i < left.Length; i++)
                result[i] = (long)(left[i].Value + right[i].Value);

            //Calculate validity (nulls)
            Bitmap.ElementWiseXorBitmap(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }

        public override void Add(NativeMemoryNullableVector<long> left, NativeMemoryNullableVector<sbyte> right, NativeMemoryNullableVector<long> result)
        {
            //Calculate raw values
            int vectorSize = Vector<long>.Count;

            long i;
                        
            for (i = 0; i < left.Length - vectorSize; i += vectorSize)
            {
                var vector = left.LoadVector(i) + (Vector<long>)right.LoadVector(i);
                result.WriteVector(i, vector);
            }

            for (; i < left.Length; i++)
                result[i] = (long)(left[i].Value + right[i].Value);

            //Calculate validity (nulls)
            Bitmap.ElementWiseXorBitmap(left.GetValidityBitmap(), right.GetValidityBitmap(), result.GetValidityBitmap());
        }

    }

    public class UInt64SimdNumericArithmeticComputation : NumericArithmeticComputation<ulong>
    {
    }
    #endregion
}

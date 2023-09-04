
// Generated from SimdComputationsHelper.tt. Do not modify directly

using System;
using System.Numerics;
using Gimpo.Data.Primitives;

namespace Gimpo.Data.Analysis
{
    public static class SimdComputationsHelper 
    {
        public static long Compute(Func<Vector<double>, Vector<double>, Vector<double>> func, NativeMemoryNullableVector<double> left, NativeMemoryNullableVector<double> right, NativeMemoryNullableVector<double> result)
        {
            //Calculate raw values
            long i;
           
            int vectorSize = Vector<double>.Count;
                                   
            for (i = 0; i < left.Length - vectorSize; i += vectorSize)
            {
                result.WriteVector(i, func.Invoke(left.LoadVector(i), right.LoadVector(i)));
            }

            return i;
        }

        public static long Compute(Func<Vector<double>, Vector<double>, Vector<double>> func, NativeMemoryNullableVector<double> left, NativeMemoryNullableVector<float> right, NativeMemoryNullableVector<double> result)
        {
            //Calculate raw values
            long i;
           
            int vectorSize = Vector<double>.Count;
            int supportedVectorSize = Vector<float>.Count;          
                       
            for (i = 0; i < left.Length - supportedVectorSize; )
            {
                Vector.Widen(right.LoadVector(i), out var rightVector1, out var rightVector2);
                                
                result.WriteVector(i, func.Invoke(left.LoadVector(i),rightVector1));
                i += vectorSize;

                result.WriteVector(i, func.Invoke(left.LoadVector(i),rightVector2));
                i += vectorSize;
            }

            return i;
        }

        public static long Compute(Func<Vector<float>, Vector<float>, Vector<float>> func, NativeMemoryNullableVector<float> left, NativeMemoryNullableVector<float> right, NativeMemoryNullableVector<float> result)
        {
            //Calculate raw values
            long i;
           
            int vectorSize = Vector<float>.Count;
                                   
            for (i = 0; i < left.Length - vectorSize; i += vectorSize)
            {
                result.WriteVector(i, func.Invoke(left.LoadVector(i), right.LoadVector(i)));
            }

            return i;
        }

        public static long Compute(Func<Vector<sbyte>, Vector<sbyte>, Vector<sbyte>> func, NativeMemoryNullableVector<sbyte> left, NativeMemoryNullableVector<sbyte> right, NativeMemoryNullableVector<sbyte> result)
        {
            //Calculate raw values
            long i;
           
            int vectorSize = Vector<sbyte>.Count;
                                   
            for (i = 0; i < left.Length - vectorSize; i += vectorSize)
            {
                result.WriteVector(i, func.Invoke(left.LoadVector(i), right.LoadVector(i)));
            }

            return i;
        }

        public static long Compute(Func<Vector<short>, Vector<short>, Vector<short>> func, NativeMemoryNullableVector<short> left, NativeMemoryNullableVector<short> right, NativeMemoryNullableVector<short> result)
        {
            //Calculate raw values
            long i;
           
            int vectorSize = Vector<short>.Count;
                                   
            for (i = 0; i < left.Length - vectorSize; i += vectorSize)
            {
                result.WriteVector(i, func.Invoke(left.LoadVector(i), right.LoadVector(i)));
            }

            return i;
        }

        public static long Compute(Func<Vector<short>, Vector<short>, Vector<short>> func, NativeMemoryNullableVector<short> left, NativeMemoryNullableVector<sbyte> right, NativeMemoryNullableVector<short> result)
        {
            //Calculate raw values
            long i;
           
            int vectorSize = Vector<short>.Count;
            int supportedVectorSize = Vector<sbyte>.Count;          
                       
            for (i = 0; i < left.Length - supportedVectorSize; )
            {
                Vector.Widen(right.LoadVector(i), out var rightVector1, out var rightVector2);
                                
                result.WriteVector(i, func.Invoke(left.LoadVector(i),rightVector1));
                i += vectorSize;

                result.WriteVector(i, func.Invoke(left.LoadVector(i),rightVector2));
                i += vectorSize;
            }

            return i;
        }

        public static long Compute(Func<Vector<int>, Vector<int>, Vector<int>> func, NativeMemoryNullableVector<int> left, NativeMemoryNullableVector<int> right, NativeMemoryNullableVector<int> result)
        {
            //Calculate raw values
            long i;
           
            int vectorSize = Vector<int>.Count;
                                   
            for (i = 0; i < left.Length - vectorSize; i += vectorSize)
            {
                result.WriteVector(i, func.Invoke(left.LoadVector(i), right.LoadVector(i)));
            }

            return i;
        }

        public static long Compute(Func<Vector<int>, Vector<int>, Vector<int>> func, NativeMemoryNullableVector<int> left, NativeMemoryNullableVector<short> right, NativeMemoryNullableVector<int> result)
        {
            //Calculate raw values
            long i;
           
            int vectorSize = Vector<int>.Count;
            int supportedVectorSize = Vector<short>.Count;          
                       
            for (i = 0; i < left.Length - supportedVectorSize; )
            {
                Vector.Widen(right.LoadVector(i), out var rightVector1, out var rightVector2);
                                
                result.WriteVector(i, func.Invoke(left.LoadVector(i),rightVector1));
                i += vectorSize;

                result.WriteVector(i, func.Invoke(left.LoadVector(i),rightVector2));
                i += vectorSize;
            }

            return i;
        }

        public static long Compute(Func<Vector<int>, Vector<int>, Vector<int>> func, NativeMemoryNullableVector<int> left, NativeMemoryNullableVector<sbyte> right, NativeMemoryNullableVector<int> result)
        {
            //Calculate raw values
            long i;
           
            int vectorSize = Vector<int>.Count;
            int supportedVectorSize = Vector<sbyte>.Count;          
                       
            for (i = 0; i < left.Length - supportedVectorSize; )
            {
                Vector.Widen(right.LoadVector(i), out var tmpVector1, out var tmpVector2);
                Vector.Widen(tmpVector1, out var rightVector1, out var rightVector2);
                Vector.Widen(tmpVector2, out var rightVector3, out var rightVector4);

                result.WriteVector(i, func.Invoke(left.LoadVector(i), rightVector1));
                i += vectorSize;

                result.WriteVector(i, func.Invoke(left.LoadVector(i), rightVector2));
                i += vectorSize;

                result.WriteVector(i, func.Invoke(left.LoadVector(i), rightVector3));
                i += vectorSize;

                result.WriteVector(i, func.Invoke(left.LoadVector(i), rightVector4));
                i += vectorSize;
            }

            return i;
        }

        public static long Compute(Func<Vector<long>, Vector<long>, Vector<long>> func, NativeMemoryNullableVector<long> left, NativeMemoryNullableVector<long> right, NativeMemoryNullableVector<long> result)
        {
            //Calculate raw values
            long i;
           
            int vectorSize = Vector<long>.Count;
                                   
            for (i = 0; i < left.Length - vectorSize; i += vectorSize)
            {
                result.WriteVector(i, func.Invoke(left.LoadVector(i), right.LoadVector(i)));
            }

            return i;
        }

        public static long Compute(Func<Vector<long>, Vector<long>, Vector<long>> func, NativeMemoryNullableVector<long> left, NativeMemoryNullableVector<int> right, NativeMemoryNullableVector<long> result)
        {
            //Calculate raw values
            long i;
           
            int vectorSize = Vector<long>.Count;
            int supportedVectorSize = Vector<int>.Count;          
                       
            for (i = 0; i < left.Length - supportedVectorSize; )
            {
                Vector.Widen(right.LoadVector(i), out var rightVector1, out var rightVector2);
                                
                result.WriteVector(i, func.Invoke(left.LoadVector(i),rightVector1));
                i += vectorSize;

                result.WriteVector(i, func.Invoke(left.LoadVector(i),rightVector2));
                i += vectorSize;
            }

            return i;
        }

        public static long Compute(Func<Vector<long>, Vector<long>, Vector<long>> func, NativeMemoryNullableVector<long> left, NativeMemoryNullableVector<short> right, NativeMemoryNullableVector<long> result)
        {
            //Calculate raw values
            long i;
           
            int vectorSize = Vector<long>.Count;
            int supportedVectorSize = Vector<short>.Count;          
                       
            for (i = 0; i < left.Length - supportedVectorSize; )
            {
                Vector.Widen(right.LoadVector(i), out var tmpVector1, out var tmpVector2);
                Vector.Widen(tmpVector1, out var rightVector1, out var rightVector2);
                Vector.Widen(tmpVector2, out var rightVector3, out var rightVector4);

                result.WriteVector(i, func.Invoke(left.LoadVector(i), rightVector1));
                i += vectorSize;

                result.WriteVector(i, func.Invoke(left.LoadVector(i), rightVector2));
                i += vectorSize;

                result.WriteVector(i, func.Invoke(left.LoadVector(i), rightVector3));
                i += vectorSize;

                result.WriteVector(i, func.Invoke(left.LoadVector(i), rightVector4));
                i += vectorSize;
            }

            return i;
        }

        public static long Compute(Func<Vector<long>, Vector<long>, Vector<long>> func, NativeMemoryNullableVector<long> left, NativeMemoryNullableVector<sbyte> right, NativeMemoryNullableVector<long> result)
        {
            //Calculate raw values
            long i;
           
            int vectorSize = Vector<long>.Count;
            int supportedVectorSize = Vector<sbyte>.Count;          
                       
            for (i = 0; i < left.Length - supportedVectorSize; )
            {
                Vector.Widen(right.LoadVector(i), out var tmpVector1, out var tmpVector2);

                Vector.Widen(tmpVector1, out var tmp2Vector1, out var tmp2Vector2);
                Vector.Widen(tmpVector2, out var tmp2Vector3, out var tmp2Vector4);

                Vector.Widen(tmp2Vector1, out var rightVector1, out var rightVector2);
                Vector.Widen(tmp2Vector2, out var rightVector3, out var rightVector4);
                Vector.Widen(tmp2Vector3, out var rightVector5, out var rightVector6);
                Vector.Widen(tmp2Vector4, out var rightVector7, out var rightVector8);

                result.WriteVector(i, func.Invoke(left.LoadVector(i), rightVector1));
                i += vectorSize;

                result.WriteVector(i, func.Invoke(left.LoadVector(i), rightVector2));
                i += vectorSize;

                result.WriteVector(i, func.Invoke(left.LoadVector(i), rightVector3));
                i += vectorSize;

                result.WriteVector(i, func.Invoke(left.LoadVector(i), rightVector4));
                i += vectorSize;

                result.WriteVector(i, func.Invoke(left.LoadVector(i), rightVector5));
                i += vectorSize;

                result.WriteVector(i, func.Invoke(left.LoadVector(i), rightVector6));
                i += vectorSize;

                result.WriteVector(i, func.Invoke(left.LoadVector(i), rightVector7));
                i += vectorSize;

                result.WriteVector(i, func.Invoke(left.LoadVector(i), rightVector8));
                i += vectorSize;
            }

            return i;
        }

    }
}


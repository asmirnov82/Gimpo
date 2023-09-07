

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

        #endregion

        #region Substract
        public override void Substract(NativeMemoryNullableVector<double> left, NativeMemoryNullableVector<double> right, NativeMemoryNullableVector<double> result)
        {
            for (long i = 0; i < left.Length; i++)
            {
                result[i] = left.HasValue(i) && right.HasValue(i) ? (double?)(left[i].Value - right[i].Value) : (double?) null;
            }
        }
        public override void ReverseSubstract(NativeMemoryNullableVector<double> left, NativeMemoryNullableVector<double> right, NativeMemoryNullableVector<double> result)
        {
            for (long i = 0; i < left.Length; i++)
            {
                result[i] = left.HasValue(i) && right.HasValue(i) ? (double?)(left[i].Value - right[i].Value) : (double?) null;
            }
        }

        public override void Substract(NativeMemoryNullableVector<double> left, NativeMemoryNullableVector<float> right, NativeMemoryNullableVector<double> result)
        {
            for (long i = 0; i < left.Length; i++)
            {
                result[i] = left.HasValue(i) && right.HasValue(i) ? (double?)(left[i].Value - right[i].Value) : (double?) null;
            }
        }
        public override void ReverseSubstract(NativeMemoryNullableVector<float> left, NativeMemoryNullableVector<double> right, NativeMemoryNullableVector<double> result)
        {
            for (long i = 0; i < left.Length; i++)
            {
                result[i] = left.HasValue(i) && right.HasValue(i) ? (double?)(left[i].Value - right[i].Value) : (double?) null;
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
                result[i] = left.HasValue(i) && right.HasValue(i) ? (float?)(left[i].Value + right[i].Value) : (float?) null;
            }
        }

        #endregion

        #region Substract
        public override void Substract(NativeMemoryNullableVector<float> left, NativeMemoryNullableVector<float> right, NativeMemoryNullableVector<float> result)
        {
            for (long i = 0; i < left.Length; i++)
            {
                result[i] = left.HasValue(i) && right.HasValue(i) ? (float?)(left[i].Value - right[i].Value) : (float?) null;
            }
        }
        public override void ReverseSubstract(NativeMemoryNullableVector<float> left, NativeMemoryNullableVector<float> right, NativeMemoryNullableVector<float> result)
        {
            for (long i = 0; i < left.Length; i++)
            {
                result[i] = left.HasValue(i) && right.HasValue(i) ? (float?)(left[i].Value - right[i].Value) : (float?) null;
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
                result[i] = left.HasValue(i) && right.HasValue(i) ? (sbyte?)(left[i].Value + right[i].Value) : (sbyte?) null;
            }
        }

        #endregion

        #region Substract
        public override void Substract(NativeMemoryNullableVector<sbyte> left, NativeMemoryNullableVector<sbyte> right, NativeMemoryNullableVector<sbyte> result)
        {
            for (long i = 0; i < left.Length; i++)
            {
                result[i] = left.HasValue(i) && right.HasValue(i) ? (sbyte?)(left[i].Value - right[i].Value) : (sbyte?) null;
            }
        }
        public override void ReverseSubstract(NativeMemoryNullableVector<sbyte> left, NativeMemoryNullableVector<sbyte> right, NativeMemoryNullableVector<sbyte> result)
        {
            for (long i = 0; i < left.Length; i++)
            {
                result[i] = left.HasValue(i) && right.HasValue(i) ? (sbyte?)(left[i].Value - right[i].Value) : (sbyte?) null;
            }
        }

        #endregion

    }

    public class UInt8NumericArithmeticComputation : NumericArithmeticComputation<byte>
    {

        #region Add
        #endregion

        #region Substract
        #endregion

    }

    public class Int16NumericArithmeticComputation : NumericArithmeticComputation<short>
    {

        #region Add
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

        #endregion

        #region Substract
        public override void Substract(NativeMemoryNullableVector<short> left, NativeMemoryNullableVector<short> right, NativeMemoryNullableVector<short> result)
        {
            for (long i = 0; i < left.Length; i++)
            {
                result[i] = left.HasValue(i) && right.HasValue(i) ? (short?)(left[i].Value - right[i].Value) : (short?) null;
            }
        }
        public override void ReverseSubstract(NativeMemoryNullableVector<short> left, NativeMemoryNullableVector<short> right, NativeMemoryNullableVector<short> result)
        {
            for (long i = 0; i < left.Length; i++)
            {
                result[i] = left.HasValue(i) && right.HasValue(i) ? (short?)(left[i].Value - right[i].Value) : (short?) null;
            }
        }

        public override void Substract(NativeMemoryNullableVector<short> left, NativeMemoryNullableVector<sbyte> right, NativeMemoryNullableVector<short> result)
        {
            for (long i = 0; i < left.Length; i++)
            {
                result[i] = left.HasValue(i) && right.HasValue(i) ? (short?)(left[i].Value - right[i].Value) : (short?) null;
            }
        }
        public override void ReverseSubstract(NativeMemoryNullableVector<sbyte> left, NativeMemoryNullableVector<short> right, NativeMemoryNullableVector<short> result)
        {
            for (long i = 0; i < left.Length; i++)
            {
                result[i] = left.HasValue(i) && right.HasValue(i) ? (short?)(left[i].Value - right[i].Value) : (short?) null;
            }
        }

        #endregion

    }

    public class UInt16NumericArithmeticComputation : NumericArithmeticComputation<ushort>
    {

        #region Add
        #endregion

        #region Substract
        #endregion

    }

    public class Int32NumericArithmeticComputation : NumericArithmeticComputation<int>
    {

        #region Add
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

        #endregion

        #region Substract
        public override void Substract(NativeMemoryNullableVector<int> left, NativeMemoryNullableVector<int> right, NativeMemoryNullableVector<int> result)
        {
            for (long i = 0; i < left.Length; i++)
            {
                result[i] = left.HasValue(i) && right.HasValue(i) ? (int?)(left[i].Value - right[i].Value) : (int?) null;
            }
        }
        public override void ReverseSubstract(NativeMemoryNullableVector<int> left, NativeMemoryNullableVector<int> right, NativeMemoryNullableVector<int> result)
        {
            for (long i = 0; i < left.Length; i++)
            {
                result[i] = left.HasValue(i) && right.HasValue(i) ? (int?)(left[i].Value - right[i].Value) : (int?) null;
            }
        }

        public override void Substract(NativeMemoryNullableVector<int> left, NativeMemoryNullableVector<short> right, NativeMemoryNullableVector<int> result)
        {
            for (long i = 0; i < left.Length; i++)
            {
                result[i] = left.HasValue(i) && right.HasValue(i) ? (int?)(left[i].Value - right[i].Value) : (int?) null;
            }
        }
        public override void ReverseSubstract(NativeMemoryNullableVector<short> left, NativeMemoryNullableVector<int> right, NativeMemoryNullableVector<int> result)
        {
            for (long i = 0; i < left.Length; i++)
            {
                result[i] = left.HasValue(i) && right.HasValue(i) ? (int?)(left[i].Value - right[i].Value) : (int?) null;
            }
        }

        public override void Substract(NativeMemoryNullableVector<int> left, NativeMemoryNullableVector<sbyte> right, NativeMemoryNullableVector<int> result)
        {
            for (long i = 0; i < left.Length; i++)
            {
                result[i] = left.HasValue(i) && right.HasValue(i) ? (int?)(left[i].Value - right[i].Value) : (int?) null;
            }
        }
        public override void ReverseSubstract(NativeMemoryNullableVector<sbyte> left, NativeMemoryNullableVector<int> right, NativeMemoryNullableVector<int> result)
        {
            for (long i = 0; i < left.Length; i++)
            {
                result[i] = left.HasValue(i) && right.HasValue(i) ? (int?)(left[i].Value - right[i].Value) : (int?) null;
            }
        }

        #endregion

    }

    public class UInt32NumericArithmeticComputation : NumericArithmeticComputation<uint>
    {

        #region Add
        #endregion

        #region Substract
        #endregion

    }

    public class Int64NumericArithmeticComputation : NumericArithmeticComputation<long>
    {

        #region Add
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

        #endregion

        #region Substract
        public override void Substract(NativeMemoryNullableVector<long> left, NativeMemoryNullableVector<long> right, NativeMemoryNullableVector<long> result)
        {
            for (long i = 0; i < left.Length; i++)
            {
                result[i] = left.HasValue(i) && right.HasValue(i) ? (long?)(left[i].Value - right[i].Value) : (long?) null;
            }
        }
        public override void ReverseSubstract(NativeMemoryNullableVector<long> left, NativeMemoryNullableVector<long> right, NativeMemoryNullableVector<long> result)
        {
            for (long i = 0; i < left.Length; i++)
            {
                result[i] = left.HasValue(i) && right.HasValue(i) ? (long?)(left[i].Value - right[i].Value) : (long?) null;
            }
        }

        public override void Substract(NativeMemoryNullableVector<long> left, NativeMemoryNullableVector<int> right, NativeMemoryNullableVector<long> result)
        {
            for (long i = 0; i < left.Length; i++)
            {
                result[i] = left.HasValue(i) && right.HasValue(i) ? (long?)(left[i].Value - right[i].Value) : (long?) null;
            }
        }
        public override void ReverseSubstract(NativeMemoryNullableVector<int> left, NativeMemoryNullableVector<long> right, NativeMemoryNullableVector<long> result)
        {
            for (long i = 0; i < left.Length; i++)
            {
                result[i] = left.HasValue(i) && right.HasValue(i) ? (long?)(left[i].Value - right[i].Value) : (long?) null;
            }
        }

        public override void Substract(NativeMemoryNullableVector<long> left, NativeMemoryNullableVector<short> right, NativeMemoryNullableVector<long> result)
        {
            for (long i = 0; i < left.Length; i++)
            {
                result[i] = left.HasValue(i) && right.HasValue(i) ? (long?)(left[i].Value - right[i].Value) : (long?) null;
            }
        }
        public override void ReverseSubstract(NativeMemoryNullableVector<short> left, NativeMemoryNullableVector<long> right, NativeMemoryNullableVector<long> result)
        {
            for (long i = 0; i < left.Length; i++)
            {
                result[i] = left.HasValue(i) && right.HasValue(i) ? (long?)(left[i].Value - right[i].Value) : (long?) null;
            }
        }

        public override void Substract(NativeMemoryNullableVector<long> left, NativeMemoryNullableVector<sbyte> right, NativeMemoryNullableVector<long> result)
        {
            for (long i = 0; i < left.Length; i++)
            {
                result[i] = left.HasValue(i) && right.HasValue(i) ? (long?)(left[i].Value - right[i].Value) : (long?) null;
            }
        }
        public override void ReverseSubstract(NativeMemoryNullableVector<sbyte> left, NativeMemoryNullableVector<long> right, NativeMemoryNullableVector<long> result)
        {
            for (long i = 0; i < left.Length; i++)
            {
                result[i] = left.HasValue(i) && right.HasValue(i) ? (long?)(left[i].Value - right[i].Value) : (long?) null;
            }
        }

        #endregion

    }

    public class UInt64NumericArithmeticComputation : NumericArithmeticComputation<ulong>
    {

        #region Add
        #endregion

        #region Substract
        #endregion

    }
}

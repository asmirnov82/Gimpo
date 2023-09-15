

// Generated from NumericArithmeticComputation.tt. Do not modify directly

using System;
using System.Collections.Generic;
using Gimpo.Data.Primitives;

namespace Gimpo.Data.Analysis
{
    public abstract class NumericArithmeticComputation<T>  where T : unmanaged
    {
        #region Add
        public virtual void Add(NativeMemoryNullableVector<T> left, NativeMemoryNullableVector<double> right, NativeMemoryNullableVector<T> result)
            => throw new NotSupportedException();

        public virtual void ReverseAdd(NativeMemoryNullableVector<double> left, NativeMemoryNullableVector<T> right, NativeMemoryNullableVector<T> result)
            => Add(right, left, result);

        public virtual void Add(NativeMemoryNullableVector<T> left, NativeMemoryNullableVector<float> right, NativeMemoryNullableVector<T> result)
            => throw new NotSupportedException();

        public virtual void ReverseAdd(NativeMemoryNullableVector<float> left, NativeMemoryNullableVector<T> right, NativeMemoryNullableVector<T> result)
            => Add(right, left, result);

        public virtual void Add(NativeMemoryNullableVector<T> left, NativeMemoryNullableVector<sbyte> right, NativeMemoryNullableVector<T> result)
            => throw new NotSupportedException();

        public virtual void ReverseAdd(NativeMemoryNullableVector<sbyte> left, NativeMemoryNullableVector<T> right, NativeMemoryNullableVector<T> result)
            => Add(right, left, result);

        public virtual void Add(NativeMemoryNullableVector<T> left, NativeMemoryNullableVector<byte> right, NativeMemoryNullableVector<T> result)
            => throw new NotSupportedException();

        public virtual void ReverseAdd(NativeMemoryNullableVector<byte> left, NativeMemoryNullableVector<T> right, NativeMemoryNullableVector<T> result)
            => Add(right, left, result);

        public virtual void Add(NativeMemoryNullableVector<T> left, NativeMemoryNullableVector<short> right, NativeMemoryNullableVector<T> result)
            => throw new NotSupportedException();

        public virtual void ReverseAdd(NativeMemoryNullableVector<short> left, NativeMemoryNullableVector<T> right, NativeMemoryNullableVector<T> result)
            => Add(right, left, result);

        public virtual void Add(NativeMemoryNullableVector<T> left, NativeMemoryNullableVector<ushort> right, NativeMemoryNullableVector<T> result)
            => throw new NotSupportedException();

        public virtual void ReverseAdd(NativeMemoryNullableVector<ushort> left, NativeMemoryNullableVector<T> right, NativeMemoryNullableVector<T> result)
            => Add(right, left, result);

        public virtual void Add(NativeMemoryNullableVector<T> left, NativeMemoryNullableVector<int> right, NativeMemoryNullableVector<T> result)
            => throw new NotSupportedException();

        public virtual void ReverseAdd(NativeMemoryNullableVector<int> left, NativeMemoryNullableVector<T> right, NativeMemoryNullableVector<T> result)
            => Add(right, left, result);

        public virtual void Add(NativeMemoryNullableVector<T> left, NativeMemoryNullableVector<uint> right, NativeMemoryNullableVector<T> result)
            => throw new NotSupportedException();

        public virtual void ReverseAdd(NativeMemoryNullableVector<uint> left, NativeMemoryNullableVector<T> right, NativeMemoryNullableVector<T> result)
            => Add(right, left, result);

        public virtual void Add(NativeMemoryNullableVector<T> left, NativeMemoryNullableVector<long> right, NativeMemoryNullableVector<T> result)
            => throw new NotSupportedException();

        public virtual void ReverseAdd(NativeMemoryNullableVector<long> left, NativeMemoryNullableVector<T> right, NativeMemoryNullableVector<T> result)
            => Add(right, left, result);

        public virtual void Add(NativeMemoryNullableVector<T> left, NativeMemoryNullableVector<ulong> right, NativeMemoryNullableVector<T> result)
            => throw new NotSupportedException();

        public virtual void ReverseAdd(NativeMemoryNullableVector<ulong> left, NativeMemoryNullableVector<T> right, NativeMemoryNullableVector<T> result)
            => Add(right, left, result);

        #endregion

        #region Subtract
        public virtual void Subtract(NativeMemoryNullableVector<T> left, NativeMemoryNullableVector<double> right, NativeMemoryNullableVector<T> result)
            => throw new NotSupportedException();

        public virtual void ReverseSubtract(NativeMemoryNullableVector<double> left, NativeMemoryNullableVector<T> right, NativeMemoryNullableVector<T> result)
            => throw new NotSupportedException();

        public virtual void Subtract(NativeMemoryNullableVector<T> left, NativeMemoryNullableVector<float> right, NativeMemoryNullableVector<T> result)
            => throw new NotSupportedException();

        public virtual void ReverseSubtract(NativeMemoryNullableVector<float> left, NativeMemoryNullableVector<T> right, NativeMemoryNullableVector<T> result)
            => throw new NotSupportedException();

        public virtual void Subtract(NativeMemoryNullableVector<T> left, NativeMemoryNullableVector<sbyte> right, NativeMemoryNullableVector<T> result)
            => throw new NotSupportedException();

        public virtual void ReverseSubtract(NativeMemoryNullableVector<sbyte> left, NativeMemoryNullableVector<T> right, NativeMemoryNullableVector<T> result)
            => throw new NotSupportedException();

        public virtual void Subtract(NativeMemoryNullableVector<T> left, NativeMemoryNullableVector<byte> right, NativeMemoryNullableVector<T> result)
            => throw new NotSupportedException();

        public virtual void ReverseSubtract(NativeMemoryNullableVector<byte> left, NativeMemoryNullableVector<T> right, NativeMemoryNullableVector<T> result)
            => throw new NotSupportedException();

        public virtual void Subtract(NativeMemoryNullableVector<T> left, NativeMemoryNullableVector<short> right, NativeMemoryNullableVector<T> result)
            => throw new NotSupportedException();

        public virtual void ReverseSubtract(NativeMemoryNullableVector<short> left, NativeMemoryNullableVector<T> right, NativeMemoryNullableVector<T> result)
            => throw new NotSupportedException();

        public virtual void Subtract(NativeMemoryNullableVector<T> left, NativeMemoryNullableVector<ushort> right, NativeMemoryNullableVector<T> result)
            => throw new NotSupportedException();

        public virtual void ReverseSubtract(NativeMemoryNullableVector<ushort> left, NativeMemoryNullableVector<T> right, NativeMemoryNullableVector<T> result)
            => throw new NotSupportedException();

        public virtual void Subtract(NativeMemoryNullableVector<T> left, NativeMemoryNullableVector<int> right, NativeMemoryNullableVector<T> result)
            => throw new NotSupportedException();

        public virtual void ReverseSubtract(NativeMemoryNullableVector<int> left, NativeMemoryNullableVector<T> right, NativeMemoryNullableVector<T> result)
            => throw new NotSupportedException();

        public virtual void Subtract(NativeMemoryNullableVector<T> left, NativeMemoryNullableVector<uint> right, NativeMemoryNullableVector<T> result)
            => throw new NotSupportedException();

        public virtual void ReverseSubtract(NativeMemoryNullableVector<uint> left, NativeMemoryNullableVector<T> right, NativeMemoryNullableVector<T> result)
            => throw new NotSupportedException();

        public virtual void Subtract(NativeMemoryNullableVector<T> left, NativeMemoryNullableVector<long> right, NativeMemoryNullableVector<T> result)
            => throw new NotSupportedException();

        public virtual void ReverseSubtract(NativeMemoryNullableVector<long> left, NativeMemoryNullableVector<T> right, NativeMemoryNullableVector<T> result)
            => throw new NotSupportedException();

        public virtual void Subtract(NativeMemoryNullableVector<T> left, NativeMemoryNullableVector<ulong> right, NativeMemoryNullableVector<T> result)
            => throw new NotSupportedException();

        public virtual void ReverseSubtract(NativeMemoryNullableVector<ulong> left, NativeMemoryNullableVector<T> right, NativeMemoryNullableVector<T> result)
            => throw new NotSupportedException();

        #endregion

        #region Multiply
        public virtual void Multiply(NativeMemoryNullableVector<T> left, NativeMemoryNullableVector<double> right, NativeMemoryNullableVector<T> result)
            => throw new NotSupportedException();

        public virtual void ReverseMultiply(NativeMemoryNullableVector<double> left, NativeMemoryNullableVector<T> right, NativeMemoryNullableVector<T> result)
            => Multiply(right, left, result);

        public virtual void Multiply(NativeMemoryNullableVector<T> left, NativeMemoryNullableVector<float> right, NativeMemoryNullableVector<T> result)
            => throw new NotSupportedException();

        public virtual void ReverseMultiply(NativeMemoryNullableVector<float> left, NativeMemoryNullableVector<T> right, NativeMemoryNullableVector<T> result)
            => Multiply(right, left, result);

        public virtual void Multiply(NativeMemoryNullableVector<T> left, NativeMemoryNullableVector<sbyte> right, NativeMemoryNullableVector<T> result)
            => throw new NotSupportedException();

        public virtual void ReverseMultiply(NativeMemoryNullableVector<sbyte> left, NativeMemoryNullableVector<T> right, NativeMemoryNullableVector<T> result)
            => Multiply(right, left, result);

        public virtual void Multiply(NativeMemoryNullableVector<T> left, NativeMemoryNullableVector<byte> right, NativeMemoryNullableVector<T> result)
            => throw new NotSupportedException();

        public virtual void ReverseMultiply(NativeMemoryNullableVector<byte> left, NativeMemoryNullableVector<T> right, NativeMemoryNullableVector<T> result)
            => Multiply(right, left, result);

        public virtual void Multiply(NativeMemoryNullableVector<T> left, NativeMemoryNullableVector<short> right, NativeMemoryNullableVector<T> result)
            => throw new NotSupportedException();

        public virtual void ReverseMultiply(NativeMemoryNullableVector<short> left, NativeMemoryNullableVector<T> right, NativeMemoryNullableVector<T> result)
            => Multiply(right, left, result);

        public virtual void Multiply(NativeMemoryNullableVector<T> left, NativeMemoryNullableVector<ushort> right, NativeMemoryNullableVector<T> result)
            => throw new NotSupportedException();

        public virtual void ReverseMultiply(NativeMemoryNullableVector<ushort> left, NativeMemoryNullableVector<T> right, NativeMemoryNullableVector<T> result)
            => Multiply(right, left, result);

        public virtual void Multiply(NativeMemoryNullableVector<T> left, NativeMemoryNullableVector<int> right, NativeMemoryNullableVector<T> result)
            => throw new NotSupportedException();

        public virtual void ReverseMultiply(NativeMemoryNullableVector<int> left, NativeMemoryNullableVector<T> right, NativeMemoryNullableVector<T> result)
            => Multiply(right, left, result);

        public virtual void Multiply(NativeMemoryNullableVector<T> left, NativeMemoryNullableVector<uint> right, NativeMemoryNullableVector<T> result)
            => throw new NotSupportedException();

        public virtual void ReverseMultiply(NativeMemoryNullableVector<uint> left, NativeMemoryNullableVector<T> right, NativeMemoryNullableVector<T> result)
            => Multiply(right, left, result);

        public virtual void Multiply(NativeMemoryNullableVector<T> left, NativeMemoryNullableVector<long> right, NativeMemoryNullableVector<T> result)
            => throw new NotSupportedException();

        public virtual void ReverseMultiply(NativeMemoryNullableVector<long> left, NativeMemoryNullableVector<T> right, NativeMemoryNullableVector<T> result)
            => Multiply(right, left, result);

        public virtual void Multiply(NativeMemoryNullableVector<T> left, NativeMemoryNullableVector<ulong> right, NativeMemoryNullableVector<T> result)
            => throw new NotSupportedException();

        public virtual void ReverseMultiply(NativeMemoryNullableVector<ulong> left, NativeMemoryNullableVector<T> right, NativeMemoryNullableVector<T> result)
            => Multiply(right, left, result);

        #endregion

        #region Divide
        public virtual void Divide(NativeMemoryNullableVector<T> left, NativeMemoryNullableVector<double> right, NativeMemoryNullableVector<T> result)
            => throw new NotSupportedException();

        public virtual void ReverseDivide(NativeMemoryNullableVector<double> left, NativeMemoryNullableVector<T> right, NativeMemoryNullableVector<T> result)
            => Divide(right, left, result);

        public virtual void Divide(NativeMemoryNullableVector<T> left, NativeMemoryNullableVector<float> right, NativeMemoryNullableVector<T> result)
            => throw new NotSupportedException();

        public virtual void ReverseDivide(NativeMemoryNullableVector<float> left, NativeMemoryNullableVector<T> right, NativeMemoryNullableVector<T> result)
            => Divide(right, left, result);

        public virtual void Divide(NativeMemoryNullableVector<T> left, NativeMemoryNullableVector<sbyte> right, NativeMemoryNullableVector<T> result)
            => throw new NotSupportedException();

        public virtual void ReverseDivide(NativeMemoryNullableVector<sbyte> left, NativeMemoryNullableVector<T> right, NativeMemoryNullableVector<T> result)
            => Divide(right, left, result);

        public virtual void Divide(NativeMemoryNullableVector<T> left, NativeMemoryNullableVector<byte> right, NativeMemoryNullableVector<T> result)
            => throw new NotSupportedException();

        public virtual void ReverseDivide(NativeMemoryNullableVector<byte> left, NativeMemoryNullableVector<T> right, NativeMemoryNullableVector<T> result)
            => Divide(right, left, result);

        public virtual void Divide(NativeMemoryNullableVector<T> left, NativeMemoryNullableVector<short> right, NativeMemoryNullableVector<T> result)
            => throw new NotSupportedException();

        public virtual void ReverseDivide(NativeMemoryNullableVector<short> left, NativeMemoryNullableVector<T> right, NativeMemoryNullableVector<T> result)
            => Divide(right, left, result);

        public virtual void Divide(NativeMemoryNullableVector<T> left, NativeMemoryNullableVector<ushort> right, NativeMemoryNullableVector<T> result)
            => throw new NotSupportedException();

        public virtual void ReverseDivide(NativeMemoryNullableVector<ushort> left, NativeMemoryNullableVector<T> right, NativeMemoryNullableVector<T> result)
            => Divide(right, left, result);

        public virtual void Divide(NativeMemoryNullableVector<T> left, NativeMemoryNullableVector<int> right, NativeMemoryNullableVector<T> result)
            => throw new NotSupportedException();

        public virtual void ReverseDivide(NativeMemoryNullableVector<int> left, NativeMemoryNullableVector<T> right, NativeMemoryNullableVector<T> result)
            => Divide(right, left, result);

        public virtual void Divide(NativeMemoryNullableVector<T> left, NativeMemoryNullableVector<uint> right, NativeMemoryNullableVector<T> result)
            => throw new NotSupportedException();

        public virtual void ReverseDivide(NativeMemoryNullableVector<uint> left, NativeMemoryNullableVector<T> right, NativeMemoryNullableVector<T> result)
            => Divide(right, left, result);

        public virtual void Divide(NativeMemoryNullableVector<T> left, NativeMemoryNullableVector<long> right, NativeMemoryNullableVector<T> result)
            => throw new NotSupportedException();

        public virtual void ReverseDivide(NativeMemoryNullableVector<long> left, NativeMemoryNullableVector<T> right, NativeMemoryNullableVector<T> result)
            => Divide(right, left, result);

        public virtual void Divide(NativeMemoryNullableVector<T> left, NativeMemoryNullableVector<ulong> right, NativeMemoryNullableVector<T> result)
            => throw new NotSupportedException();

        public virtual void ReverseDivide(NativeMemoryNullableVector<ulong> left, NativeMemoryNullableVector<T> right, NativeMemoryNullableVector<T> result)
            => Divide(right, left, result);

        #endregion

    }
}

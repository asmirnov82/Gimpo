using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Gimpo.Data.Primitives;

namespace Gimpo.Data.Analysis.Computations
{
    public interface INumericArithmeticComputations
    {
        NativeMemoryNullableVector<T> Add<T>(NativeMemoryNullableVector<long> values) where T : unmanaged;
        NativeMemoryNullableVector<T> Add<T>(NativeMemoryNullableVector<int> values) where T : unmanaged;
        NativeMemoryNullableVector<T> Add<T>(NativeMemoryNullableVector<short> values) where T : unmanaged;
        NativeMemoryNullableVector<T> Add<T>(NativeMemoryNullableVector<sbyte> values) where T : unmanaged;

        NativeMemoryNullableVector<T> Add<T>(NativeMemoryNullableVector<ulong> values) where T : unmanaged;
        NativeMemoryNullableVector<T> Add<T>(NativeMemoryNullableVector<uint> values) where T : unmanaged;
        NativeMemoryNullableVector<T> Add<T>(NativeMemoryNullableVector<ushort> values) where T : unmanaged;
        NativeMemoryNullableVector<T> Add<T>(NativeMemoryNullableVector<byte> values) where T : unmanaged;

        NativeMemoryNullableVector<T> Add<T>(NativeMemoryNullableVector<double> values) where T : unmanaged;
        NativeMemoryNullableVector<T> Add<T>(NativeMemoryNullableVector<float> values) where T : unmanaged;
    }
}

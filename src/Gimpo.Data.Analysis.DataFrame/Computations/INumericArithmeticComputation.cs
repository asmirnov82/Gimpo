using System;
using System.Collections.Generic;
using System.Text;
using Gimpo.Data.Primitives;

namespace Gimpo.Data.Analysis.Computations
{
    public interface INumericArithmeticComputation<T>  where T : unmanaged
    {
        void Add(NativeMemoryNullableVector<T> left, NativeMemoryNullableVector<long> values, NativeMemoryNullableVector<T> result);
    }
}

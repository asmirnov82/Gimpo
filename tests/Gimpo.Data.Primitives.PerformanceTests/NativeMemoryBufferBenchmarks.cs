using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using Microsoft.Diagnostics.Runtime.Utilities;

namespace Gimpo.Data.Primitives.PerformanceTests
{
    public class NativeMemoryBufferBenchmarks
    {
        private const long Count = 100000;

        private NativeMemoryBuffer _memoryBuffer;

        /*
        [GlobalSetup]
        public void SetUp()
        {
            _memoryBuffer = new NativeMemoryAlignedBuffer(Count, 64, true);
        }

        [GlobalCleanup]
        public void CleanUp()
        {
            _memoryBuffer?.Dispose();
        }
        */

        /*
        [Benchmark]
        public void Test_1()
        {
            byte sum = 0;

            for (long i = 0; i < Count; i++)
            {
                sum += _memoryBuffer.GetValueByRef<byte>(i);
            }
        }
        */

        /*
        [Benchmark]
        public void Test_2()
        {
            byte sum;

            int vectorSize = Vector<byte>.Count;
            var accVector = Vector<byte>.Zero;
            long i;

            for (i = 0; i < Count - vectorSize; i += vectorSize)
            {
                var v = _memoryBuffer.GetVector<byte>(i);
                accVector = Vector.Add(accVector, v);
            }

            sum = Vector.Dot(accVector, Vector<byte>.One);

            for (; i < Count; i++)
            {
                sum += _memoryBuffer.GetValueByRef<byte>(i);
            }
        }
        */

        /*
        [Benchmark]
        public unsafe void Test_3()
        {
            byte sum = 0;

            int vectorSize = Vector256<byte>.Count;
            var accVector = Vector256<byte>.Zero;
            long i;

            for (i = 0; i < Count - vectorSize; i += vectorSize)
            {
                var v = Avx2.LoadAlignedVector256(_memoryBuffer.Ptr + i);
                accVector = Avx2.Add(accVector, v);
            }

            var temp = stackalloc byte[vectorSize];
            Avx2.Store(temp, accVector);

            for (int j = 0; j < vectorSize; j++)
            {
                sum += temp[j];
            }

            for (; i < Count; i++)
            {
                sum += _memoryBuffer.GetValueByRef<byte>(i);
            }
        }
        */
    }
}

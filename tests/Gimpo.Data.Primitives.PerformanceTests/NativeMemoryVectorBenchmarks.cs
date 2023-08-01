using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gimpo.Data.Primitives;

using BenchmarkDotNet.Attributes;
using System.Threading;

namespace Gimpo.Data.Primitives.PerformanceTests
{
    public class NativeMemoryVectorBenchmarks
    {        
        private const long Count = 1000000;

        [GlobalSetup]
        public void SetUp()
        {
            //_memoryVector = new NativeMemoryVector<int>(0);
        }

        [GlobalCleanup]
        public void CleanUp()
        {
            //_memoryVector?.Dispose();
        }
                
        [Benchmark]
        public void MemoryAllocation()
        {
            using (var memoryVector = new NativeMemoryVector<int>())
            {
                for (int i = 1; i < Count; i++)
                {
                    memoryVector.EnsureCapacity(i);
                    memoryVector.Add(i);
                }
            }
        }
        
        /*
        [Benchmark]
        public void Test_1()
        {
            int sum = 0;
            for (int i = 0; i < Count; i++)
            {
                sum = _memoryVector[i];
            }

            int b = sum;
        }
        */

        /*
        [Benchmark]
        public void Test_2()
        {
            int sum = 0;
            foreach (var value in _memoryVector)
            {
                sum = value;
            }

            int b = sum;
        }
        */
    }
}

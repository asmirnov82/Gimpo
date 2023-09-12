using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;

namespace Gimpo.Data.Analysis.PerformanceTests
{
    public class ArithmeticComputationBenchmark
    {
        private const int ItemsCount = 1000000;

        private Int64DataFrameColumn _int64Column1;
        private Int64DataFrameColumn _int64Column2;

        private Int32DataFrameColumn _int32Column1;
        private Int32DataFrameColumn _int32Column2;

        private Int16DataFrameColumn _int16Column1;
        private Int16DataFrameColumn _int16Column2;

        [GlobalSetup]
        public void SetUp()
        {
            var int32values = Enumerable.Range(0, ItemsCount).ToArray();

            _int64Column1 = new Int64DataFrameColumn("Int64 Column1", ItemsCount);
            _int64Column2 = new Int64DataFrameColumn("Int64 Column2", ItemsCount);

            _int32Column1 = new Int32DataFrameColumn("Int32 Column1", int32values);
            _int32Column2 = new Int32DataFrameColumn("Int32 Column2", int32values);
                        
            _int16Column1 = new Int16DataFrameColumn("Int16 Column1", ItemsCount);
            _int16Column2 = new Int16DataFrameColumn("Int16 Column2", ItemsCount);
        }

        [Benchmark]
        public void AddInt64Simd()
        {            
            var column = _int64Column1 + _int64Column2;
        }
                
        [Benchmark]
        public void AddInt32Simd()
        {            
            var column = _int32Column1 + _int32Column2;
        }
                
        [Benchmark]
        public void AddInt16Simd()
        {
            var column = _int16Column1 + _int16Column2;
        }
                
        [Benchmark]
        public void AddInt64()
        {
            DataFrame.ForceSimdCalculationsDisabled = true;
            var column = _int64Column1 + _int64Column2;
        }

        [Benchmark]
        public void AddInt32()
        {
            DataFrame.ForceSimdCalculationsDisabled = true;
            var column = _int32Column1 + _int32Column2;
        }
        
        [Benchmark]
        public void AddInt16()
        {
            DataFrame.ForceSimdCalculationsDisabled = true;
            var column = _int16Column1 + _int16Column2;
        }

        [Benchmark]
        public void SubstractInt32Simd()
        {
            var column = _int32Column1 - _int32Column2;
        }

        [Benchmark]
        public void SubstractInt16Simd()
        {
            var column = _int16Column1 - _int16Column2;
        }

        [Benchmark]
        public void SubstractInt32()
        {
            DataFrame.ForceSimdCalculationsDisabled = true;
            var column = _int32Column1 + _int32Column2;
        }
                
        [Benchmark]
        public void SubstractInt16()
        {
            DataFrame.ForceSimdCalculationsDisabled = true;
            var column = _int16Column1 + _int16Column2;
        }
    }
}

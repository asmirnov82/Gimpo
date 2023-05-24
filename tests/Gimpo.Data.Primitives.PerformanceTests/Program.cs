using BenchmarkDotNet.Running;
using Gimpo.Data.Primitives.PerformanceTests;

namespace Gimpo.Data.Analysis.Benchmarks
{

    public static class Program
    {
        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<NativeMemoryVectorBenchmarks>();


            /*
            BenchmarkSwitcher
                .FromAssembly(typeof(Program).Assembly)
                .Run(args);
            */
        }
    }
}

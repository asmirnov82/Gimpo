using BenchmarkDotNet.Running;
using Gimpo.Data.Analysis.PerformanceTests;

public static class Program
{
    public static void Main(string[] args)
    {
        var summary = BenchmarkRunner.Run<DataFrameBenchmarks>();


        /*
        BenchmarkSwitcher
            .FromAssembly(typeof(Program).Assembly)
            .Run(args);
        */
    }
}

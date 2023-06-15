using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;

namespace Gimpo.Data.Analysis.PerformanceTests
{
    public class DataFrameBenchmarks
    {
        private DataFrame _dataFrame;

        [GlobalSetup]
        public void SetUp()
        {
            _dataFrame = new DataFrame();
            _dataFrame.AddColumn(new Int32DataFrameColumn("col1", Enumerable.Range(0, 100000)));
        }

        [GlobalCleanup]
        public void CleanUp()
        {
            _dataFrame?.Dispose();
        }

        [Benchmark]
        public void IterateValuesInFor()
        {
            var column = (Int32DataFrameColumn)_dataFrame["col1"];

            for (long i = 0; i < column.Length; i++)
            {
                var value = column[i];
            }
        }

        [Benchmark]
        public void IterateValuesInForeach()
        {
            var column = (Int32DataFrameColumn)_dataFrame["col1"];

            foreach (var value in column)
            {
                var value1 = value;
            }
        }

        [Benchmark]
        public void IterateValuesUsingCursor()
        {
            var cursor = _dataFrame.Rows.GetRowCursor();
            var getter = cursor.GetGetter<int?>("col1");

            while (cursor.MoveNext())
            {
                getter.Invoke(out int? value);
            }
        }

        [Benchmark]
        public void IterateValuesUsingRows()
        {
            foreach (var row in _dataFrame.Rows)
            {
                var value = (int?)row[0];
            }
        }
    }
}

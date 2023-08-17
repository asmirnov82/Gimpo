using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Gimpo.Data.Analysis
{
    public class NumericColumnsArithmeticTests
    {
        [Fact]
        public void IntAdditionTest()
        {
            DoubleDataFrameColumn left = new DoubleDataFrameColumn("Left", new[] { 1.5, 2.5, 3, 44, 126.25, 99.9 });
            DoubleDataFrameColumn right = new DoubleDataFrameColumn("Right", new[] { 0.5, 1.5, 3, -43.5, 1.75, 0.1 });

            var sum = left + right;
        }
    }
}

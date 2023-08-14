using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Gimpo.Data.Primitives.Tests
{
    public class NativeMemoryBufferTests
    {
        /// <summary>
        /// Ensure allocated memory block is properly aligned.
        /// </summary>
        [Theory]
        [InlineData(1, 64)]
        [InlineData(8, 64)]
        [InlineData(64, 64)]
        [InlineData(128, 64)]
        [InlineData(256, 64)]
        [InlineData(1, 128)]
        [InlineData(8, 128)]
        [InlineData(64, 128)]
        [InlineData(128, 128)]
        [InlineData(256, 128)]
        public unsafe void ConstructionTestAllocatesAligned(int size, int alignment)
        {
            //Act
            var buffer = new NativeMemoryBufferAligned(size, alignment, true);

            //Assert
            buffer.HasCompatibleAlignment(alignment).Should().BeTrue();
        }
    }
}

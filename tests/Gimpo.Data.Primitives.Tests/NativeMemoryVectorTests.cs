using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Xunit;

namespace Gimpo.Data.Primitives.Tests
{
    public class NativeMemoryVectorTests
    {
        #region Construction
        /// <summary>
        /// Ensure constructor copies initial values and correctly sets Count and Capacity.
        /// </summary>
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(10)]
        public void ConstructionTestWithInitialValues(long count)
        {
            //Arrange
            var initialValues = new int[count];
            for (int i = 0; i < count; i++)
                initialValues[i] = i;

            //Act
            using (var vector = new NativeMemoryVector<int>(initialValues))
            {
                //Assert
                vector.Length.Should().Be(count);
                vector.Capacity.Should().BeGreaterThanOrEqualTo(count);

                vector.Should().BeEquivalentTo(initialValues);
            }
        }
        #endregion

        #region Add
        [Theory]
        [InlineData(new[] { 1, 2, 3, 4, 5 }, 0)]
        [InlineData(new[] { int.MinValue, 33, 0, int.MaxValue, -2, 0, 33 }, 0)]
        [InlineData(new[] { 1, 2, 3, 4, 5 }, 64)]
        [InlineData(new[] { int.MinValue, 33, 0, int.MaxValue, -2, 0, 33 }, 128)]
        public void AddTestZeroInitialCapacity(int[] initialValues, int alignment)
        {
            //Arrange
            int count = initialValues.Length;

            using (var vector = new NativeMemoryVector<int>(0, alignment))
            {
                //Act
                for (int i = 0; i < count; i++)
                    vector.Add(initialValues[i]);

                //Assert
                vector.Length.Should().Be(count);
                vector.Capacity.Should().BeGreaterThanOrEqualTo(count);

                vector.Should().BeEquivalentTo(initialValues);
            }
        }
                
        [Theory]
        [InlineData(new[] { 2.0, 0.0, -3.3, 4.3, 5.1 })]
        public void AddTestDefaultInitialCapacity(double[] initialValues)
        {
            //Arrange
            int count = initialValues.Length;
            using (var vector = new NativeMemoryVector<double>())
            {

                //Act
                for (int i = 0; i < count; i++)
                    vector.Add(initialValues[i]);

                //Assert
                vector.Length.Should().Be(count);
                vector.Capacity.Should().BeGreaterThanOrEqualTo(count);

                vector.Should().BeEquivalentTo(initialValues);
            }
        }
        #endregion

        #region AddRange
        [Theory]
        [InlineData(new[] { 1, 2, 3, 4, 5, 6, 7 }, 0)]
        [InlineData(new[] { 1, 2, 3, 4, 5, 6, 7 }, 128)]
        public void AddRangeTestDefaultInitialCapacity(int[] initialValues, int alignment)
        {
            //Arrange
            long count = initialValues.Length;

            using (var vector = new NativeMemoryVector<int>(alignment: alignment))
            {
                //Act
                vector.AddRange(initialValues);

                //Assert
                vector.Length.Should().Be(count);
                vector.Capacity.Should().BeGreaterThanOrEqualTo(count);

                vector.Should().BeEquivalentTo(initialValues);
            }
        }
        #endregion

        #region AddMany
        [Fact]
        public void AddManyTestZeroCount()
        {
            //Arrange
            using (var vector = new NativeMemoryVector<int>())
            {
                //Act
                vector.AddMany(1, 0);

                //Assert
                vector.Length.Should().Be(0);
                vector.Capacity.Should().BeGreaterThanOrEqualTo(0);

                vector.Should().BeEmpty();
            }
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(-1, 2)]
        [InlineData(0, 4)]
        [InlineData(int.MaxValue, 10)]
        public void AddManyTestEmptyVectorWithDefaultInitialCapacity(int value, long count)
        {
            //Arrange
            using (var vector = new NativeMemoryVector<int>())
            {
                //Act
                vector.AddMany(value, count);

                //Assert
                vector.Length.Should().Be(count);
                vector.Capacity.Should().BeGreaterThanOrEqualTo(count);

                vector.Should().OnlyContain(x => x == value);
            }
        }

        [Theory]
        [InlineData(1.0, 0)]
        [InlineData(double.MaxValue, 10)]
        [InlineData(double.MinValue, 10)]
        [InlineData(double.PositiveInfinity, 256)]
        public void AddManyTestNotEmptyVector(double value, long count)
        {            
            using (var vector = new NativeMemoryVector<double>())
            {
                //Arrange
                var initialValues = new double[] { 1.0, 2.0 };
                vector.AddRange(initialValues);

                var initialCount = vector.Length;

                //Act
                vector.AddMany(value, count);

                //Assert
                vector.Length.Should().Be(initialCount + count);
                vector.Capacity.Should().BeGreaterThanOrEqualTo(initialCount + count); 

                for (long i = 0; i < vector.Length; i++)
                {
                    vector[i].Should().Be(i < initialCount ? initialValues[i] : value);
                }
            }
        }
        #endregion

        #region Resize
        //TODO
        #endregion

        #region Clone
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(256)]
        public void CloneTest(long count)
        {
            using(var vector = new NativeMemoryVector<long>(count))
            {
                //Arrange
                for (long i = 0; i < count; ++i)
                    vector[i] = i;

                //Act
                var copy = vector.Clone();

                //Assert
                copy.Should().NotBeSameAs(vector);
                copy.Length.Should().Be(vector.Length);
                copy.Should().BeEquivalentTo(vector);
            }
        }

        [Fact]
        public void TestColumnCloneWithIEnumerableIndicesMap()
        {            
            using (var vector = new NativeMemoryVector<int>(new[] { 0, 5, 2, 4, 1, 3 }))
            {
                //Arrange
                var indicesMap = new long[] { 0, 4, 2, 5, 3, 1 };

                //Act
                var clonedVector = vector.Clone(indicesMap);

                //Assert
                clonedVector.Should().NotBeSameAs(vector);
                clonedVector.Length.Should().Be(indicesMap.Length);

                for (int i = 0; i < clonedVector.Length; i++)
                    clonedVector[i].Should().Be(vector[indicesMap[i]]);
            }
        }

        [Fact]
        public void TestColumnCloneWithMemoryVectorIndicesMap()
        {
            //Arrange
            using (var vector = new NativeMemoryVector<int>(new[] { 0, 5, 2, 4, 1, 3 }))
            using (var indicesMap = new NativeMemoryVector<long>(new long[] { 0, 4, 2, 5, 3, 1 }))
            {

                //Act
                var clonedVector = vector.Clone(indicesMap);

                //Assert
                clonedVector.Should().NotBeSameAs(vector);
                clonedVector.Length.Should().Be(indicesMap.Length);

                for (int i = 0; i < clonedVector.Length; i++)
                    clonedVector[i].Should().Be(vector[indicesMap[i]]);
            }
        }
        #endregion

        #region Enumeration
        [Fact]
        public void IEnumerableTestWithInitialValues()
        {
            //Arrange
            var initialValues = new decimal[] { decimal.MinusOne, decimal.One, decimal.Zero, decimal.MaxValue, decimal.MinValue };

            //Act
            using (var vector = new NativeMemoryVector<decimal>(initialValues))
            {
                //Assert
                vector.Length.Should().Be(initialValues.Length);

                int i = 0;
                foreach (var value in vector)
                {
                    value.Should().Be(initialValues[i]);
                    i++;
                }
            }
        }
        #endregion

        #region Vectorization

        [Theory]
        [InlineData(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }, 0, 0)]
        [InlineData(new int[] { 0, -1, 2, -3, 4, -5, 6, -7, 8, -9, 10, -11, 12, -13, 14, -15 }, 2, 0)]
        [InlineData(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }, 0, 128)]
        [InlineData(new int[] { 0, -1, 2, -3, 4, -5, 6, -7, 8, -9, 10, -11, 12, -13, 14, -15 }, 2, 128)]
        public void GetVectorTest(int[] initialValues, long offset, int alignment)
        {
            //Arrange
            using (var vector = new NativeMemoryVector<int>(initialValues, alignment: alignment))
            {
                //Act
                var res = vector.GetVector(offset);
                
                //Assert
                for (int i = 0; i < Vector<int>.Count; i++)
                {
                    res[i].Should().Be(initialValues[offset + i]);
                }
            }
        }
        #endregion
    }
}

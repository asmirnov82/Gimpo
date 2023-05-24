using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Gimpo.Data.Primitives.Tests
{
    public class NativeMemoryNullableVectorTests
    {
        #region Construction

        [Fact]
        public void ConstructionTestWithNullableInitialValues()
        {
            //Arrange
            var initialValues = new int?[] { 1, null, 2, null, 3, 4, null };
            var count = initialValues.Length;

            //Act
            using (var vector = new NativeMemoryNullableVector<int>(initialValues))
            {
                //Assert
                vector.Length.Should().Be(count);
                vector.NullCount.Should().Be(initialValues.Where(x => x == null).Count());
                vector.Should().BeEquivalentTo(initialValues);
            }
        }

        [Fact]
        public void ConstructionTestWithInitialValues()
        {
            //Arrange
            var initialValues = new int[] { 1, 2, 3, 4 };
            var count = initialValues.Length;

            //Act
            using (var vector = new NativeMemoryNullableVector<int>(initialValues))
            {
                //Assert
                vector.Length.Should().Be(count);
                vector.NullCount.Should().Be(0);
                vector.Should().BeEquivalentTo(initialValues);
            }
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(10)]
        public void ConstructionTestWithEnumerableInitialValues(int count)
        {
            //Act
            using (var vector = new NativeMemoryNullableVector<int>(Enumerable.Range(0, count)))
            {
                //Assert
                vector.Length.Should().Be(count);
                vector.NullCount.Should().Be(0);
                vector.Should().BeEquivalentTo(Enumerable.Range(0, count));
            }
        }
        #endregion

        #region Add values

        [Fact]
        public void AddTestZeroInitialCapacity()
        {
            //Arrange
            var initialValues = new int?[] { int.MaxValue, null, -12, null, int.MinValue, 35, null };
            var count = initialValues.Length;

            //Act
            using (var vector = new NativeMemoryNullableVector<int>(0))
            {
                for (int i = 0; i < count; i++)
                    vector.Add(initialValues[i]);

                //Assert
                vector.Length.Should().Be(count);
                vector.NullCount.Should().Be(initialValues.Where(x => x == null).Count());
                vector.Should().BeEquivalentTo(initialValues);
            }
        }

        [Fact]
        public void AddTestDefaultInitialCapacity()
        {
            //Arrange
            var initialValues = new long?[] { 1, 2, 3, null, long.MaxValue, 4, null, long.MinValue };
            var count = initialValues.Length;

            //Act
            using (var vector = new NativeMemoryNullableVector<long>())
            {
                for (int i = 0; i < count; i++)
                    vector.Add(initialValues[i]);

                //Assert
                vector.Length.Should().Be(count);
                vector.NullCount.Should().Be(initialValues.Where(x => x == null).Count());
                vector.Should().BeEquivalentTo(initialValues);
            }
        }

        #endregion

        #region AddRange

        [Fact]
        public void AddRangeTestDefaultInitialCapacity()
        {
            var initialValues = new int?[] { 1, 2, null, 4, 5, 6, 7 };
            //Arrange
            long count = initialValues.Length;

            using (var vector = new NativeMemoryNullableVector<int>())
            {
                //Act
                vector.AddRange(initialValues);

                //Assert
                vector.Length.Should().Be(count);
                vector.Capacity.Should().BeGreaterThanOrEqualTo(count);
                vector.NullCount.Should().Be(initialValues.Where(x => x == null).Count());

                vector.Should().BeEquivalentTo(initialValues);
            }
        }

        [Fact]
        public void AddRangeTestDefaultInitialCapacityIEnumerable()
        {            
            //Arrange
            int count = 10;

            using (var vector = new NativeMemoryNullableVector<int>())
            {
                //Act
                vector.AddRange(Enumerable.Range(0, count));

                //Assert
                vector.Length.Should().Be(count);
                vector.Capacity.Should().BeGreaterThanOrEqualTo(count);
                vector.NullCount.Should().Be(0);

                vector.Should().BeEquivalentTo(Enumerable.Range(0, count));
            }
        }
        #endregion

        #region Indexer

        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4 })]
        [InlineData(new int[] { -234, 22, 34, 75, int.MaxValue, int.MinValue })]
        public void IndexerSetterGettersTestInitialVector(int[] initialValues)
        {            
            //Act
            using (var vector = new NativeMemoryNullableVector<int>(initialValues.Length))
            {
                for (int i = 0; i < initialValues.Length; i++)
                    vector[i] = initialValues[i];

                //Assert
                vector.Length.Should().Be(initialValues.Length);
                vector.NullCount.Should().Be(0);
                vector.Should().BeEquivalentTo(initialValues);
            }
        }

        [Fact]
        public void IndexerSetterGettersTestWithNullValues()
        {
            //Arrange
            var initialValues = new int?[] { null, 22, 33, 45, null };
            int count = initialValues.Count();

            //Act
            using (var vector = new NativeMemoryNullableVector<int>(count))
            {
                for (int i = 0; i < initialValues.Length; i++)
                    vector[i] = initialValues[i];

                //Assert
                vector.Length.Should().Be(count);
                vector.NullCount.Should().Be(2);
                vector.Should().BeEquivalentTo(initialValues);
            }
        }

        [Fact]
        public void IndexerSetterGettersTestUpdateWithNulls()
        {
            //Arrange
            var initialValues = new int?[] { null, 1, 2, 3, null };
            
            //Act
            using (var vector = new NativeMemoryNullableVector<int>(initialValues))
            {                
                //Act (update null to number)
                vector[0] = 666;

                //Assert
                vector.Length.Should().Be(5);
                vector.NullCount.Should().Be(1);
                vector[0].Should().Be(666);

                //Act (update number to null)
                vector[1] = null;

                //Assert
                vector.Length.Should().Be(5);
                vector.NullCount.Should().Be(2);
                vector[1].Should().BeNull();
            }
        }

        #endregion

        #region AddMany
        //TODO
        #endregion

        #region Resize
        //TODO
        #endregion

        #region Enumeration
        [Fact]
        public void IEnumerableTestWithInitialValues()
        {
            //Arrange
            var initialValues = new int?[] { 1, null, 2, null, 3, 4, null };
            var count = initialValues.Length;

            //Act
            using (var vector = new NativeMemoryNullableVector<int>(initialValues))
            {
                //Assert
                vector.Length.Should().Be(count);

                int i = 0;
                foreach (var value in vector)
                {
                    value.Should().Be(initialValues[i++]);
                }
            }
        }

        /*
        [Fact]
        public void CustomEnumeratorTestWithAllValues()
        {
            //Arrange
            var initialValues = new int?[] { 1, null, 2, null, 3, 4, null };
            var count = initialValues.Length;

            var resultList = new List<int?>();

            //Act
            using var container = new NativeMemoryNullableVector<int>(initialValues);

            var enumerator = container.GetCustomEnumerator();

            //Using limit to avoid infinite loop in case of possible defects in iterator
            while (enumerator.MoveNext() && resultList.Count < count + 1)
            {
                resultList.Add(enumerator.Current);
            }

            //Assert
            resultList.Count.Should().Be(count);
            resultList.Should().BeEquivalentTo(initialValues);
        }
        */

        /*
        [Fact]
        public void CustomEnumeratorTestWithNonNullValues()
        {
            //Arrange
            var initialValues = new int?[] { 1, null, 2, null, 3, 4, null };
            var nonNullValues = initialValues.Where(item => item.HasValue).ToArray();
            var count = nonNullValues.Length;

            var resultList = new List<int?>();

            //Act
            using var container = new NativeMemoryNullableVector<int>(initialValues);

            var enumerator = container.GetCustomEnumerator();

            //Using limit to avoid infinite loop in case of possible defects in iterator
            while (enumerator.MoveNextNonNull() && resultList.Count < count + 1)
            {
                resultList.Add(enumerator.Current);
            }

            //Assert
            resultList.Count.Should().Be(count);
            resultList.Should().BeEquivalentTo(nonNullValues);
        }
        */
        #endregion
    }
}


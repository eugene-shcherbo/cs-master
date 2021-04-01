using System;
using System.Collections.Generic;
using Algorithms.ch03.interview;
using Xunit;

namespace UnitTests.ch03.interview
{
    public abstract class ArrayProductTests
    {
        [Theory]
        [MemberData(nameof(CreateTestData))]
        public void ReturnsCorrectArrayOfProducts(int[] original, int[] expected)
        {
            Assert.Equal(expected, GetAlgorithm().CalculateProduct(original));
        }

        public static IEnumerable<object[]> CreateTestData()
            => new object[][]
            {
                new object[] { new[] { 9, 2, 4, 6 }, new[] { 48, 216, 108, 72 } },
                new object[] { new[] { 4, -1, 3, 0, 8, 1 }, new[] { 0, 0, 0, -96, 0, 0 } }
            };

        protected abstract IArrayProduct GetAlgorithm();
    }
}

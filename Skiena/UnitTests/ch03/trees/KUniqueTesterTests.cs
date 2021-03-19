using System;
using System.Collections.Generic;
using Algorithms.ch03.trees;
using Xunit;

namespace UnitTests.ch03.trees
{
    public class KUniqueTesterTests
    {
        [Theory]
        [MemberData(nameof(CreateTestData))]
        public void CorrectlyDeterminesKUniqueness(int[] values, int k, bool expected)
        {
            Assert.Equal(expected, KUniqueTester.IsKUnique(values, k));
        }

        public static IEnumerable<object[]> CreateTestData()
            => new object[][]
            {
                new object[] { new[] { 1, 2, 3, 5, 2, 3, 7 }, 2, true },
                new object[] { new[] { 1, 2, 3, 4, 3, 5, 7 }, 2, false },
                new object[] { new[] { 4, 2, 100, 4 }, 3, false },
                new object[] { new[] { 4, 5, 6, 7 }, 4, true }
            };
    }
}

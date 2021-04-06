using Algorithms.ch04.numbers;
using System.Collections.Generic;
using Xunit;

namespace UnitTests.ch04.numbers
{
    public abstract class ModeFinderTests
    {
        [Theory]
        [MemberData(nameof(CreateTestData))]
        public void ReturnsCorrectMode(int[] values, int mode)
        {
            IModeFinder finder = GetFinder();
            Assert.Equal(mode, finder.GetMode(values));
        }

        public static IEnumerable<object[]> CreateTestData()
            => new object[][]
            {
                new object[] { new[] { 4, 6, 2, 4, 3, 1 }, 4 },
                new object[] { new[] { 1, 2, 3, 1, 3, 1, 4, 5 }, 1 },
                new object[] { new[] { 2, 2, 3, 3, 2, 4, 5 }, 2 }
            };

        protected abstract IModeFinder GetFinder();
    }
}

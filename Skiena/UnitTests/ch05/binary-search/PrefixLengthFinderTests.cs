using Algorithms.ch05.binary_search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.ch05.binary_search
{
    public abstract class PrefixLengthFinderTests
    {
        [Theory]
        [MemberData(nameof(TestDataProvider))]
        public void TestCount(int[] values, int expectedCount)
        {
            IPrefixLengthFinder legthFinder = GetLengthFinder();
            Assert.Equal(expectedCount, legthFinder.FindLength(values));
        }

        public static IEnumerable<object[]> TestDataProvider()
        {
            var result = new object[100][];
            var randGen = new Random();

            for (int i = 0; i < result.Length; i++)
            {
                var array = new object[randGen.Next(0, 2000)];
                var prefixLength = randGen.Next(1, array.Length - 1);

                for (int j = 0; j < array.Length; j++)
                {
                    if (j < prefixLength)
                    {
                        array[j] = 0;
                    }
                    else
                    {
                        array[j] = 1;
                    }
                }

                result[i] = new object[] { array, prefixLength };
            }

            return result;
        }

        protected abstract IPrefixLengthFinder GetLengthFinder();
    }
}

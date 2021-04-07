using Algorithms.ch05.binary_search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.ch05.binary_search
{
    public abstract class MissingFinderTests
    {
        [Theory]
        [MemberData(nameof(TestDataProvider))]
        public void TestFindingMissing(int[] values, int missing)
        {
            IMissingFinder finder = GetFinder();
            Assert.Equal(missing, finder.FindMissing(values));
        }

        public static IEnumerable<object[]> TestDataProvider()
        {
            var res = new object[100][];
            var rand = new Random();

            for (int i = 0; i < res.Length; i++)
            {
                var array = new object[rand.Next(100)];
                int missing = rand.Next(1, array.Length + 1);
                int val = 1;

                for (int j = 0; j < array.Length; j++)
                {
                    if (val == missing)
                    {
                        val++;
                    }

                    array[j] = val++;
                }

                res[i] = new object[] { array, missing };
            }

            return res;
        }

        protected abstract IMissingFinder GetFinder();
    }
}

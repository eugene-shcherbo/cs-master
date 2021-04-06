using Algorithms.ch05.binary_search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.ch05.binary_search
{
    public abstract class LargestFinderTests
    {
        [Theory]
        [MemberData(nameof(TestDataProvider))]
        public void TesSearchForLargest(int[] values, int largest)
        {
            ILargestFinder finder = GetFinder();
            Assert.Equal(largest, finder.FindLargest(values));
        }

        public static IEnumerable<object[]> TestDataProvider()
        {
            var result = new object[100][];
            var rand = new Random();

            for (int i = 0; i < 100; i++)
            {
                var array = new object[rand.Next(100)];
                int max = int.MinValue;

                for (int j = 0; j < array.Length; j++)
                {
                    int val = rand.Next(rand.Next(0, 25));

                    if (val > max)
                    {
                        max = val;
                    }

                    array[j] = val;
                }

                Array.Sort(array);
                object[] rotated = RotateArray(array, rand.Next() % array.Length);

                result[i] = new object[] { rotated, max };
            }

            return result;
        }

        private static object[] RotateArray(object[] values, int pos)
        {
            return values.Skip(pos).Concat(values.Take(pos)).ToArray();
        }

        protected abstract ILargestFinder GetFinder();
    }
}

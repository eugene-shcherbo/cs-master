using Algorithms.ch05.binary_search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.ch05.binary_search
{
    public abstract class OccurenceCounterTests
    {
        [Fact]
        public void TestNoKey()
        {
            var values = new[]
            {
                1, 2, 3, 3, 3, 4, 5, 6, 7
            };

            IOccurenceCounter counter = GetCounter();

            int eights = counter.Count(values, 8);
            int zeros = counter.Count(values, 0);

            Assert.Equal(0, eights);
            Assert.Equal(0, zeros);
        }

        [Theory]
        [MemberData(nameof(RandomArrayProvider))]
        public void TestCountingSortedData(int[] values)
        {
            Array.Sort(values);
            TestCounting(values);
        }

        public static IEnumerable<object[]> RandomArrayProvider()
        {
            var arrays = new object[100][];

            var randGen = new Random();

            for (int i = 0; i < arrays.Length; i++)
            {
                var arr = new object[randGen.Next(0, 100)];

                for (int j = 0; j < arr.Length; j++)
                {
                    arr[j] = randGen.Next(0, 20);
                }

                arrays[i] = new object[] { arr };
            }

            return arrays;
        }

        private void TestCounting(int[] values)
        {
            IOccurenceCounter counter = GetCounter();

            foreach (int value in values)
            {
                int count = 0;

                foreach (int another in values)
                {
                    if (value == another)
                    {
                        count++;
                    }
                }

                Assert.Equal(count, counter.Count(values, value));
            }
        }

        protected abstract IOccurenceCounter GetCounter();
    }
}

using Algorithms.ch05.integer_multiplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.ch05.integer_multiplication
{
    public abstract class IntegersMultiplicationTests
    {
        protected abstract IIntegersMultiplier GetMultiplier();

        [Theory]
        [InlineData(0)]
        [InlineData(5)]
        [InlineData(100)]
        [InlineData(100500)]
        public void MultiplyByZeroGivesZero(int num)
        {
            var multiplier = GetMultiplier();
            var decimalValue = DecimalInteger.FromInt32(num);

            Assert.Equal(0, multiplier.Multiply(decimalValue, DecimalInteger.FromInt32(0)).ToInt32());
        }

        [Theory]
        [MemberData(nameof(RandomMultiplicationDataProvider))]
        public void TestMultiplication(int one, int two, int expected)
        {
            var multiplier = GetMultiplier();

            Assert.Equal(expected, multiplier.Multiply(DecimalInteger.FromInt32(one), DecimalInteger.FromInt32(two)).ToInt32());
        }

        public static IEnumerable<object[]> RandomMultiplicationDataProvider()
        {
            var values = new object[100][];
            Random random = new();

            for (int i = 0; i < values.Length; i++)
            {
                int val1 = random.Next(1000000);
                int val2 = random.Next(10000);

                values[i] = new object[]
                { 
                    val1,
                    val2,
                    val1 * val2
                };
            }

            return values;
        }
    }
}

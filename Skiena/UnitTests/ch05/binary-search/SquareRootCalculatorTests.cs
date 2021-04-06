using Algorithms.ch05.binary_search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.ch05.binary_search
{
    public abstract class SquareRootCalculatorTests
    {
        [Theory]
        [MemberData(nameof(TestDataProvider))]
        public void TestSquareRoot(int num, int precision)
        {
            var calculator = GetCalculator();

            var sqrt = Math.Sqrt(num);
            var truncated = Math.Truncate(sqrt * Math.Pow(10, precision)) / Math.Pow(10, precision);

            Assert.Equal(
                truncated.ToString($"F{precision}"),
                calculator.Calculate(num, precision).ToString($"F{precision}"));
        }

        public static IEnumerable<object[]> TestDataProvider()
        {
            var result = new object[100][];
            var random = new Random();

            for (int i = 0; i < result.Length; i++)
            {
                int precision = random.Next(0, 10);
                int num = random.Next();

                result[i] = new object[] { num, precision };
            }

            return result;
        }

        protected abstract ISquareRootCalculator GetCalculator();
    }
}

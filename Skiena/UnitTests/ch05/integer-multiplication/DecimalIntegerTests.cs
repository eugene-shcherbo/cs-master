using Algorithms.ch05.integer_multiplication;
using System;
using System.Collections.Generic;
using Xunit;

namespace UnitTests.ch05.integer_multiplication
{
    public class DecimalIntegerTests
    {
        [Fact]
        public void DefaultConstructorCreatesZero()
        {
            var zero = new DecimalInteger();
            Assert.Equal(0, zero.ToInt32());
        }

        [Theory]
        [MemberData(nameof(IntegerProvider))]
        public void TestCreationFromInt32(int value)
        {
            var decimalValue = DecimalInteger.FromInt32(value);
            Assert.Equal(value, decimalValue.ToInt32());
        }

        [Theory]
        [MemberData(nameof(TwoIntegersDataProvider))]
        public void TestSum(int val1, int val2)
        {
            var decimalValue1 = DecimalInteger.FromInt32(val1);
            var decimalValue2 = DecimalInteger.FromInt32(val2);

            Assert.Equal(val1 + val2, decimalValue1.Sum(decimalValue2).ToInt32());
            Assert.Equal(val2 + val1, decimalValue2.Sum(decimalValue1).ToInt32());
        }

        [Theory]
        [MemberData(nameof(PowerOfTensDataProvider))]
        public void PadWithZeros(int val, int power)
        {
            var decimalValue = DecimalInteger.FromInt32(val);
            Assert.Equal(val * Math.Pow(10, power), decimalValue.PadWithZeros(power).ToInt32());
        }

        public static IEnumerable<object[]> IntegerProvider()
        {
            return CollectTestData(rand => new object[] { rand.Next() });
        }

        public static IEnumerable<object[]> TwoIntegersDataProvider()
        {
            return CollectTestData(rand => new object[] { rand.Next(), rand.Next() });
        }

        public static IEnumerable<object[]> PowerOfTensDataProvider()
        {
            return CollectTestData(rand => new object[] { rand.Next(100), rand.Next(5) });
        }

        private static IEnumerable<object[]> CollectTestData(Func<Random, object[]> argumentProvider)
        {
            var args = new object[100][];
            var rand = new Random();

            for (int i = 0; i < args.Length; i++)
            {
                args[i] = argumentProvider(rand);
            }

            return args;
        }
    }
}

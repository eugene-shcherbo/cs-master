using System;
using Algorithms.ch01;
using Xunit;

namespace UnitTests.ch01
{
    public abstract class IntegerDivisorTests
    {
        protected abstract IIntegerDivisor CreateDivisor();

        [Fact]
        public void InvalidOperationExceptionWhenDivisorZero()
        {
            IIntegerDivisor sut = CreateDivisor();
            Assert.Throws<InvalidOperationException>(() => sut.Divide(5, 0));
            Assert.Throws<InvalidOperationException>(() => sut.Divide(-10, 0));
            Assert.Throws<InvalidOperationException>(() => sut.Divide(int.MaxValue, 0));
            Assert.Throws<InvalidOperationException>(() => sut.Divide(int.MinValue, 0));
        }

        [Theory]
        [InlineData(1, 3)]
        [InlineData(1000, 1001)]
        [InlineData(-1, -3)]
        [InlineData(int.MaxValue, int.MinValue)]
        public void QuotientZeroWhenAbsdividendLessThanDivisor(int dividend, int divisor)
        {
            TestDivision(dividend, divisor, 0);
        }
        
        [Theory]
        [InlineData(1, 1)]
        [InlineData(5, 5)]
        [InlineData(int.MaxValue, int.MaxValue)]
        [InlineData(int.MinValue, int.MinValue)]
        [InlineData(-10, -10)]
        public void QuotientOneForNumbersWithSameSign(int dividend, int divisor)
        {
            TestDivision(dividend, divisor, 1);
        }

        [Theory]
        [InlineData(-10, 3, 3)]
        [InlineData(10, -3, 3)]
        [InlineData(int.MinValue, int.MaxValue, 1)]
        [InlineData(150, 30, 5)]
        public void CorrectAbsQuotient(int dividend, int divisor, int result)
        {
            IIntegerDivisor sut = CreateDivisor();
            Assert.Equal(result, Math.Abs(sut.Divide(dividend, divisor)));
        }

        [Theory]
        [InlineData(-10, 3, -3)]
        [InlineData(10, -3, -3)]
        [InlineData(-10, -3, 3)]
        public void CorrectQuotientSign(int dividend, int divisor, int result)
        {
            TestDivision(dividend, divisor, result);
        }

        [Theory]
        [InlineData(int.MaxValue, 2, 1073741823)]
        [InlineData(37, 9, 4)]
        public void LargeValues(int dividend, int divisor, int result)
        {
            TestDivision(dividend, divisor, result);
        }

        private void TestDivision(int dividend, int divisor, int result)
        {
            IIntegerDivisor sut = CreateDivisor();
            Assert.Equal(result, sut.Divide(dividend, divisor));
        }
    }
}

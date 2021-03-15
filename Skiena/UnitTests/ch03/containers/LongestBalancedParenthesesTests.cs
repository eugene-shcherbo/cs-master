using System;
using Algorithms.ch03.containers;
using Xunit;

namespace UnitTests.ch03.containers
{
    public abstract class LongestBalancedParenthesesTests
    {
        protected abstract ILongestBalancedParentheses CreateCalculator();

        [Fact]
        public void ZeroForEmptyString()
        {
            ILongestBalancedParentheses calculator = CreateCalculator();
            Assert.Equal(0, calculator.Calculate(string.Empty));
        }

        [Fact]
        public void ThrowsArgumentNullExceptionForNullString()
        {
            ILongestBalancedParentheses calculator = CreateCalculator();
            Assert.Throws<ArgumentNullException>(() => calculator.Calculate(null));
        }

        [Theory]
        [InlineData(")()(())()()))())))(", 12)]
        [InlineData(")))))))))((((((((", 0)]
        [InlineData(")))))))))()((((((((", 2)]
        public void CorrectlyCalculateTheValue(string testString, int expectedValue)
        {
            ILongestBalancedParentheses calculator = CreateCalculator();
            Assert.Equal(expectedValue, calculator.Calculate(testString));
        }
    }
}

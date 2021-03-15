using System;
using Algorithms.ch03.containers;
using Xunit;

namespace UnitTests.ch03.containers
{
    public abstract class ParenthesesBalanceCheckerTests
    {
        protected abstract IParenthesesBalanceChecker CreateChecker();

        [Fact]
        public void BalancedWhenStringIsEmpty()
        {
            var checker = CreateChecker();
            Assert.Equal(BalanceCheckResult.Balanced(), checker.CheckString(string.Empty));
        }

        [Fact]
        public void ThrowsArgumentNullExceptionWhenStringIsNull()
        {
            var checker = CreateChecker();
            Assert.Throws<ArgumentNullException>(() => checker.CheckString(null));
        }

        [Theory]
        [InlineData("()")]
        [InlineData("(())")]
        [InlineData("((abc))(2 + 3)((((()))))")]
        public void BalancedWhenStringIsBalanced(string testString)
        {
            var checker = CreateChecker();
            Assert.Equal(BalanceCheckResult.Balanced(), checker.CheckString(testString));
        }

        [Theory]
        [InlineData("(", 0)]
        [InlineData("(()", 2)]
        [InlineData("(())()((((())))", 14)]
        public void UnBalancedWithCorrectPositionWhenStringIsNotBalanced(string testString, int errorPos)
        {
            var checker = CreateChecker();
            Assert.Equal(BalanceCheckResult.NotBalanced(errorPos), checker.CheckString(testString));
        }
    }
}

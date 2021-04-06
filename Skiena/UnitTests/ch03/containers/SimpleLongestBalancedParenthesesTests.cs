using Algorithms.ch03.containers;

namespace UnitTests.ch03.containers
{
    public class SimpleLongestBalancedParenthesesTests : LongestBalancedParenthesesTests
    {
        protected override ILongestBalancedParentheses CreateCalculator()
        {
            return new SimpleLongestBalancedParentheses();
        }
    }
}

using System;
using Algorithms.ch03.containers;

namespace UnitTests.ch03.containers
{
    public class SimpleParenthesesBalanceCheckerTests : ParenthesesBalanceCheckerTests
    {
        protected override IParenthesesBalanceChecker CreateChecker()
        {
            return new SimpleParenthesesBalanceChecker();
        }
    }
}

using System;
namespace Algorithms.ch03.containers
{
    public class SimpleParenthesesBalanceChecker : IParenthesesBalanceChecker
    {
        public BalanceCheckResult CheckString(string? testStr)
        {
            if (testStr is null)
            {
                throw new ArgumentNullException(nameof(testStr));
            }

            int openedParentheses = 0;

            for (int i = 0; i < testStr.Length; i++)
            {
                char ch = testStr[i];

                if (ch == '(')
                {
                    openedParentheses++;
                }
                else if (ch == ')')
                {
                    if (openedParentheses == 0)
                    {
                        return BalanceCheckResult.NotBalanced(i);
                    }
                    else
                    {
                        openedParentheses--;
                    }
                }
            }

            if (openedParentheses > 0)
            {
                return BalanceCheckResult.NotBalanced(testStr.Length - 1);
            }

            return BalanceCheckResult.Balanced();
        }
    }
}

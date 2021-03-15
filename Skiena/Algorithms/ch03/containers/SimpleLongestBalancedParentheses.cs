using System;
namespace Algorithms.ch03.containers
{
    public class SimpleLongestBalancedParentheses : ILongestBalancedParentheses
    {
        public int Calculate(string? str)
        {
            if (str is null)
            {
                throw new ArgumentNullException(nameof(str));
            }

            int numOfOpenedParentheses = 0;
            int numOfBalanced = 0;

            foreach (char ch in str)
            {
                if (ch == ')' && numOfOpenedParentheses != 0)
                {
                    numOfBalanced += 2;
                    numOfOpenedParentheses--;
                }
                else if (ch == '(')
                {
                    numOfOpenedParentheses++;
                }
            }

            return numOfBalanced;
        }
    }
}

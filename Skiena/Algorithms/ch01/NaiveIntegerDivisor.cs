using System;
namespace Algorithms.ch01
{
    public class NaiveIntegerDivisor : IIntegerDivisor
    {
        public int Divide(int dividend, int divisor)
        {
            if (divisor is 0)
            {
                throw new InvalidOperationException("Can't divide by 0");
            }

            long absDividend = Math.Abs((long)dividend);
            long absDivisor = Math.Abs((long)divisor);
            int quotient = 0;

            while (absDividend >= absDivisor)
            {
                absDividend -= absDivisor;
                quotient++;
            }

            return IsQuotientNegatie(dividend, divisor) ? -quotient : quotient;
        }

        private static bool IsQuotientNegatie(int dividend, int divisor)
        {
            return (dividend < 0 && divisor > 0)
                || (dividend > 0 && divisor < 0);
        }
    }
}

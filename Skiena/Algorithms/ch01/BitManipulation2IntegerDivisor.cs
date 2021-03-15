using System;
    
namespace Algorithms.ch01
{
    public class BitManipulation2IntegerDivisor : IIntegerDivisor
    {
        public int Divide(int dividend, int divisor)
        {
            if (divisor == 0)
            {
                throw new InvalidOperationException("Can't divide by 0");
            }

            long absDividend = Math.Abs((long)dividend);
            long absDivisor = Math.Abs((long)divisor);

            if (absDivisor > absDividend)
            {
                return 0;
            }

            if (absDividend == absDivisor)
            {
                return 1;
            }

            int current = 1;
            long powerOfTwoDividend = absDivisor;

            while (absDividend > powerOfTwoDividend)
            {
                powerOfTwoDividend <<= 1;
                current <<= 1;
            }

            powerOfTwoDividend >>= 1;
            current >>= 1;
            int quotient = 0;

            while (current != 0)
            {
                // The idea here is the following:
                // We first check if number of divisors in powerOfTwoDividend
                // can fit into absDividend. If it can, then we will add that number
                // into the quotient.
                // Then we substract powerOfTwoDividend from absDividend to get
                // the difference between them to see if we can fit more divisors.
                //
                // Then we note actually that the difference is strictly smaller
                // than powerOfTwoDividend, therefore to find number of divisors
                // we do the same (see if we can feet powerOfTwoDividend into that difference),
                // but with more less powerOfTwoDividend.
                if (absDividend >= powerOfTwoDividend)
                {
                    absDividend -= powerOfTwoDividend;
                    quotient += current;
                }

                powerOfTwoDividend >>= 1;
                current >>= 1;
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

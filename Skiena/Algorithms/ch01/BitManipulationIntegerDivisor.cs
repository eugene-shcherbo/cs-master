using System;
namespace Algorithms.ch01
{
    public class BitManipulationIntegerDivisor : IIntegerDivisor
    {
        /// <summary>
        /// Divides two <paramref name="dividend"> by <paramref name="divisor">
        /// </summary>
        /// <remarks>
        /// Multiplies the divisor by a minimum power of two such that
        /// a <= b * 2^n, where a is <paramref name="dividend"> and b is
        /// <paramref name="divisor"> meaning that there is 2^n b-s in b * 2^n.
        /// Since b * 2^n is greater than a this means that there is at least
        /// one extra b in b * 2^n comparing to a. Therefore the method next
        /// gets away of extra b-s by subtracting b from b * 2^n until it's less
        /// than or equal to a.
        /// </remarks>
        /// <param name="dividend">An integer to be divided</param>
        /// <param name="divisor">An integer that divides</param>
        /// <returns>An integer result of the division (quotient)</returns>
        public int Divide(int dividend, int divisor)
        {
            if (divisor == 0)
            {
                throw new InvalidOperationException("Can't divide by 0");
            }

            long absDividend = Math.Abs((long)dividend);
            long absDivisor = Math.Abs((long)divisor);
            int quotient = 1;
            long powerOfTwoDividend = absDivisor;

            while (absDividend > powerOfTwoDividend)
            {
                powerOfTwoDividend <<= 1;
                quotient <<= 1;
            }

            while (powerOfTwoDividend > absDividend)
            {
                powerOfTwoDividend -= absDivisor;
                quotient--;
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

namespace Algorithms.ch05.binary_search
{
    public class BinarySearchSquareRootCalculator : ISquareRootCalculator
    {
        public double Calculate(int num, int precision) => AddFractionalPart(FindIntegralPart(num), num, precision);

        private static long FindIntegralPart(int num)
        {
            long start = 1;
            long end = num;
            long res = 1;

            while (start <= end)
            {
                long mid = start + ((end - start) / 2);

                if (mid * mid == num)
                {
                    return mid;
                }
                else if (mid * mid < num)
                {
                    start = mid + 1;
                    res = mid;
                }
                else
                {
                    end = mid - 1;
                }
            }

            return res;
        }

        private static double AddFractionalPart(long integral, int num, int precision)
        {
            double res = integral;
            var fractionalIncrement = .1;

            for (int i = 0; i < precision; i++)
            {
                while (res * res <= num)
                {
                    res += fractionalIncrement;
                }

                res -= fractionalIncrement;
                fractionalIncrement /= 10;
            }

            return res;
        }
    }
}

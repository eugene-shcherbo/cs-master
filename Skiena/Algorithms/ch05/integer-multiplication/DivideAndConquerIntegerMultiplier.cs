using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.ch05.integer_multiplication
{
    public class DivideAndConquerIntegerMultiplier : IIntegersMultiplier
    {
        private readonly ITimesTable timesTable;

        public DivideAndConquerIntegerMultiplier(ITimesTable timesTable)
        {
            this.timesTable = timesTable ?? new SimpleTimesTable();
        }

        public DecimalInteger Multiply(DecimalInteger one, DecimalInteger other)
        {
            if (one.NumOfDigits == 1 && other.NumOfDigits == 1)
            {
                return timesTable.Multiply(one, other);
            }

            DecimalInteger greatest = one.NumOfDigits > other.NumOfDigits ? one : other;

            int m = greatest.NumOfDigits / 2;
            int zeroes = greatest.NumOfDigits - m;

            DecimalInteger a0 = one.FromDigits(0, zeroes);
            DecimalInteger a1 = one.FromDigits(zeroes);

            DecimalInteger b0 = other.FromDigits(0, zeroes);
            DecimalInteger b1 = other.FromDigits(zeroes);

            DecimalInteger prod1 = Multiply(a0, b0);
            DecimalInteger prod2 = Multiply(a0, b1).PadWithZeros(zeroes);
            DecimalInteger prod3 = Multiply(a1, b0).PadWithZeros(zeroes);
            DecimalInteger prod4 = Multiply(a1, b1).PadWithZeros(zeroes * 2);

            return prod1.Sum(prod2).Sum(prod3).Sum(prod4);
        }
    }
}

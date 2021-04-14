using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.ch05.integer_multiplication
{
    public class SimpleTimesTable : ITimesTable
    {
        public DecimalInteger Multiply(DecimalInteger one, DecimalInteger another)
        {
            int val1 = one.ToInt32();
            int val2 = another.ToInt32();

            if (val1 < 0 || val1 > 9 || val2 < 0 || val2 > 9)
            {
                throw new ArgumentException("The times table can calculate the product of numbers in the range [0, 9]");
            }

            return DecimalInteger.FromInt32(val1 * val2);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.ch05.integer_multiplication
{
    public interface IIntegersMultiplier
    {
        DecimalInteger Multiply(DecimalInteger one, DecimalInteger other);
    }
}

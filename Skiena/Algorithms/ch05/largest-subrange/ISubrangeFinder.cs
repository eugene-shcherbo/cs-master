using Algorithms.ch04.intervals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.ch05.largest_subrange
{
    public interface ISubrangeFinder
    {
        Interval FindSubrange(int[] values);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.ch05.binary_search
{
    public interface IPrefixLengthFinder
    {
        int FindLength<T>(T[] values, IComparer<T>? comparer = null);
    }
}

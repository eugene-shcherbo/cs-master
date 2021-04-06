using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.ch05.binary_search
{
    public interface IOccurenceCounter
    {
        int Count<T>(T[] elements, T key, IComparer<T>? comparer = null);
    }
}

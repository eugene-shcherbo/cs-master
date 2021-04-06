using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.ch05.binary_search
{
    public interface ILargestFinder
    {
        public T FindLargest<T>(T[] values, IComparer<T>? comparer = null);
    }
}

using Algorithms.common.extenstions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.ch05.binary_search
{
    public class BinarySearchLargestFinder : ILargestFinder
    {
        public T FindLargest<T>(T[] values, IComparer<T>? comparer = null)
        {
            comparer ??= Comparer<T>.Default;

            if (values.Length == 1)
            {
                return values[0];
            }

            int start = 0;
            int end = values.Length - 1;

            while (start < end)
            {
                int mid = start + ((end - start) / 2);

                if (values[mid].GreaterThan(values[mid + 1], comparer))
                {
                    return values[mid];
                }

                if (values[mid].LessThan(values[start], comparer))
                {
                    end = mid - 1;
                }
                else
                {
                    start = mid + 1;
                }
            }

            return values[start];
        }
    }
}

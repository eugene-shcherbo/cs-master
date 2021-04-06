using Algorithms.common.extenstions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.ch05.binary_search
{
    public class BinarySearchPrefixLengthFinder : IPrefixLengthFinder
    {
        public int FindLength<T>(T[] values, IComparer<T>? comparer = null)
        {
            if (!values.Any())
            {
                return 0;
            }

            comparer ??= Comparer<T>.Default;

            T first = values.First();

            int from = 0;
            int to = 1;

            while (to < values.Length)
            {
                if (!values[to].SameAs(first, comparer))
                {
                    break;
                }

                from = to;
                to *= 2;
            }

            to = Math.Min(to, values.Length - 1);

            while (from != to - 1)
            {
                int middle = (to + from) / 2;

                if (values[middle].SameAs(first, comparer))
                {
                    from = middle;
                }
                else
                {
                    to = middle;
                }
            }

            return from + 1;
        }
    }
}

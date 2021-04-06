using Algorithms.common.extenstions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.ch05.binary_search
{
    public class SimpleBinarySearchOccurenceCounter : IOccurenceCounter
    {
        public int Count<T>(T[] elements, T key, IComparer<T>? comparer = null)
        {
            comparer ??= Comparer<T>.Default;

            int location = SearchKey(elements, key, comparer);

            if (location == -1)
            {
                return 0;
            }

            int count = 1;

            for (int i = location - 1; i >= 0; i--)
            {
                if (!elements[i].SameAs(key, comparer))
                {
                    break;
                }

                count++;
            }

            for (int i = location + 1; i < elements.Length; i++)
            {
                if (!elements[i].SameAs(key, comparer))
                {
                    break;
                }

                count++;
            }

            return count;
        }

        private static int SearchKey<T>(T[] elements, T key, IComparer<T> comparer)
        {
            int low = 0;
            int hight = elements.Length - 1;

            while (low <= hight)
            {
                int middle = low + ((hight - low) / 2);

                if (elements[middle].SameAs(key, comparer))
                {
                    return middle;
                }

                if (elements[middle].LessThan(key, comparer))
                {
                    low = middle + 1;
                }
                else
                {
                    hight = middle - 1;
                }
            }

            return -1;
        }
    }
}

using Algorithms.common.extenstions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.ch05.binary_search
{
    public class BoundeFinderOccurenceCounter : IOccurenceCounter
    {
        public int Count<T>(T[] elements, T key, IComparer<T>? comparer = null)
        {
            comparer ??= Comparer<T>.Default;

            int firstOccurence = FindFirstOccurence(elements, key, 0, elements.Length - 1, comparer);

            return firstOccurence switch
            {
                -1 => 0,
                _ => FindLastOccurence(elements, key, firstOccurence, elements.Length - 1, comparer) - firstOccurence + 1
            };
        }

        private static int FindFirstOccurence<T>(T[] elements, T key, int low, int hight, IComparer<T> comparer)
        {
            if (low > hight)
            {
                return -1;
            }

            int middle = low + ((hight - low) / 2);

            if (elements[middle].SameAs(key, comparer) && (middle == 0 || elements[middle - 1].LessThan(key, comparer)))
            {
                return middle;
            }

            if (elements[middle].LessThan(key, comparer))
            {
                return FindFirstOccurence(elements, key, middle + 1, hight, comparer);
            }

            return FindFirstOccurence(elements, key, low, middle - 1, comparer);
        }

        private static int FindLastOccurence<T>(T[] elements, T key, int low, int hight, IComparer<T> comparer)
        {
            if (low > hight)
            {
                return -1;
            }

            int middle = low + ((hight - low) / 2);

            if (elements[middle].SameAs(key, comparer) && (middle == elements.Length - 1 || elements[middle + 1].GreaterThan(key, comparer)))
            {
                return middle;
            }

            if (elements[middle].GreaterThan(key, comparer))
            {
                return FindLastOccurence(elements, key, low, middle - 1, comparer);
            }

            return FindLastOccurence(elements, key, middle + 1, hight, comparer);
        }
    }
}

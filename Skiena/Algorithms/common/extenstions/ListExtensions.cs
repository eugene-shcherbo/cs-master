using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.common.extenstions
{
    public static class ListExtensions
    {
        public static T RemoveLast<T>(this List<T> list)
        {
            if (!list.Any())
            {
                throw new InvalidOperationException("The list is empty");
            }

            T last = list[^1];
            list.RemoveAt(Index.FromEnd(1).Value);

            return last;
        }

        public static void Swap<T>(this IList<T> list, int firstIndex, int secondIndex)
        {
            if (firstIndex < 0 || secondIndex >= list.Count)
            {
                throw new ArgumentException("One of the index is out of range");
            }

            T tmp = list[firstIndex];
            list[firstIndex] = list[secondIndex];
            list[secondIndex] = tmp;
        }
    }
}

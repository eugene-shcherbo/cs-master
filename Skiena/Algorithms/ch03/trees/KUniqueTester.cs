using System;
using System.Collections.Generic;

namespace Algorithms.ch03.trees
{
    public class KUniqueTester
    {
        public static bool IsKUnique<T>(T[] values, int k) where T : IEquatable<T>
        {
            if (k <= 0)
            {
                return true;
            }

            var kRangeValues = new SortedSet<T>();

            if (!TestFirstKElements(values, k, kRangeValues))
            {
                return false;
            }

            kRangeValues.Remove(values[0]);

            for (int i = k + 1; i < values.Length; i++)
            {
                if (kRangeValues.Contains(values[i]))
                {
                    return false;
                }
                kRangeValues.Remove(values[i - k]);
            }

            return true;
        }

        private static bool TestFirstKElements<T>(T[] values, int k, SortedSet<T> kRangeValues)
        {
            for (int i = 0; i < values.Length && i <= k; i++)
            {
                if (kRangeValues.Contains(values[i]))
                {
                    return false;
                }
                kRangeValues.Add(values[i]);
            }

            return true;
        }
    }
}

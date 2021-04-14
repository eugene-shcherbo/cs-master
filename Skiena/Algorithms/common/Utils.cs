using Algorithms.common.extenstions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.common
{
    public static class Utils
    {
        public static T? Min<T>(IComparer<T> comparer, params T[] values)
        {
            return BasedOnComparison((first, second) => first.LessThan(second, comparer), values);
        }

        public static T? Min<T, TKey>(Func<T, TKey> comparer, params T[] values) where TKey : IComparable<TKey>
        {
            return Min(new DelegateComparer<T, TKey>(comparer), values);
        }

        public static T? Max<T>(IComparer<T> comparer, params T[] values)
        {
            return BasedOnComparison((first, second) => first.GreaterThan(second, comparer), values);
        }

        public static T? Max<T, TKey>(Func<T, TKey> comparer, params T[] values) where TKey : IComparable<TKey>
        {
            return Max(new DelegateComparer<T, TKey>(comparer), values);
        }

        private static T? BasedOnComparison<T>(Func<T, T, bool> comparisonAlgorithm, params T[] values)
        {
            int resIndex = 0;

            for (int i = 1; i < values.Length; i++)
            {
                if (comparisonAlgorithm(values[i], values[resIndex]))
                {
                    resIndex = i;
                }
            }

            return values.Any() switch
            {
                true => values[resIndex],
                false => default
            };
        }

        private class DelegateComparer<T, TKey> : IComparer<T> where TKey : IComparable<TKey>
        {
            private readonly Func<T, TKey> comparer;

            public DelegateComparer(Func<T, TKey> comparer)
            {
                this.comparer = comparer;
            }

            public int Compare(T? x, T? y)
            {
                return x switch
                {
                    null => y is null ? 0 : -1,
                    _ => y is null ? 0 : comparer(x).CompareTo(comparer(y))
                };
            }
        }
    }
}

using System;
using System.Collections.Generic;

namespace Algorithms.common.extenstions
{
    public static class IComparableExtensions
    {
        public static bool LessThan<T>(this T first, T second) where T : IComparable<T>
            => first switch
            {
                null => second is not null,
                _ => first.CompareTo(second) < 0
            };

        public static bool SameAs<T>(this T first, T second) where T : IComparable<T>
            => first switch
            {
                null => second is null,
                _ => first.CompareTo(second) == 0
            };

        public static bool GreaterThan<T>(this T first, T second) where T : IComparable<T>
            => first switch
            {
                null => false,
                _ => first.CompareTo(second) > 0
            };

        public static bool LessThan<T>(this T first, T second, IComparer<T> comparer)
            => comparer.Compare(first, second) < 0;

        public static bool GreaterThan<T>(this T first, T second, IComparer<T> comparer)
            => comparer.Compare(first, second) > 0;

        public static bool SameAs<T>(this T first, T second, IComparer<T> comparer)
            => comparer.Compare(first, second) == 0;
    }
}

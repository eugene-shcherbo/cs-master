using System;
namespace Algorithms.common.extenstions
{
    public static class IComparableExtensions
    {
        public static bool LessThan<T>(this T first, T second) where T : IComparable<T>
        {
            if (first is null)
            {
                return second is null;
            }

            return first.CompareTo(second) < 0;
        }

        public static bool SameAs<T>(this T first, T second) where T : IComparable<T>
        {
            if (first is null)
            {
                return second is null;
            }

            return first.CompareTo(second) == 0;
        }

        public static bool GreaterThan<T>(this T first, T second) where T : IComparable<T>
        {
            if (first is null)
            {
                return second is null;
            }

            return first.CompareTo(second) > 0;
        }
    }
}

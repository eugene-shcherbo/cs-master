using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.ch03.containers
{
    public class TwoListMinStack<T> : IMinStack<T> where T : IComparable<T>
    {
        private readonly List<T> items = new();
        private readonly List<T> minimums = new();

        public int Count => items.Count;

        public T FindMin()
        {
            if (!items.Any())
            {
                throw new InvalidOperationException("Stack is empty");
            }
            return minimums.Last();
        }

        public T Pop()
        {
            if (!items.Any())
            {
                throw new InvalidOperationException("Stack is empty");
            }

            var last = items.Last();

            if (Equals(last, FindMin()))
            {
                minimums.RemoveAt(minimums.Count - 1);
            }

            items.RemoveAt(items.Count - 1);

            return last;
        }

        public void Push(T element)
        {
            if (!minimums.Any() || LessThan(element, FindMin()) || Equals(element, FindMin()))
            {
                minimums.Add(element);
            }
            items.Add(element);
        }

        private static bool LessThan(T one, T two)
        {
            return one.CompareTo(two) < 0;
        }

        private static bool GreaterThan(T one, T two)
        {
            return one.CompareTo(two) > 0;
        }
    }
}

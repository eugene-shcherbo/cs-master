using Algorithms.common.extenstions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.ch04.s4
{
    public sealed class PriorityQueue<T>
    {
        private const int NoParent = -1;

        private readonly IComparer<T> comparer;
        private readonly List<T> values = new();

        public PriorityQueue(IComparer<T>? comparer = null)
        {
            this.comparer = comparer ?? Comparer<T>.Default;
        }

        public void Enqueue(T value)
        {
            values.Add(value);
            int currIndex = values.Count - 1;

            while (Parent(currIndex) != NoParent && LessThan(currIndex, Parent(currIndex)))
            {
                values.Swap(currIndex, Parent(currIndex));
                currIndex = Parent(currIndex);
            }
        }

        public T ExtractMin()
        {
            T min = Peek();

            values[0] = values.RemoveLast();
            MinHeapify(0);

            return min;
        }

        public T Peek()
        {
            EnsureHasElements();
            return values[0];
        }

        private void MinHeapify(int rootIndex)
        {
            int minIndex = rootIndex;

            if (LeftChild(rootIndex) < values.Count && LessThan(LeftChild(rootIndex), rootIndex))
            {
                minIndex = LeftChild(rootIndex);
            }

            if (RightChild(rootIndex) < values.Count && LessThan(RightChild(rootIndex), minIndex))
            {
                minIndex = RightChild(rootIndex);
            }

            if (minIndex != rootIndex)
            {
                values.Swap(rootIndex, minIndex);
                MinHeapify(minIndex);
            }
        }

        private void EnsureHasElements()
        {
            if (!values.Any())
            {
                throw new InvalidOperationException("The queue is empty");
            }
        }

        private bool LessThan(int firstIndex, int secondIndex)
        {
            return comparer.Compare(values[firstIndex], values[secondIndex]) < 0;
        }

        private static int Parent(int child)
            => child switch
            {
                0 => NoParent,
                _ => (child - 1) / 2
            };

        private static int LeftChild(int parent) => parent * 2 + 1;

        private static int RightChild(int parent) => parent * 2 + 2;
    }
}

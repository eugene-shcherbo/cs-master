using Algorithms.ch03.containers;
using System;
using System.Collections.Generic;

namespace UnitTests.ch03.containers
{
    internal abstract class TwoListMinStackTests<T> : MinStackTests<T> where T : IComparable<T>
    {
    }

    public class TwoListInt32MinStackTests : MinStackTests<int>
    {
        protected override IMinStack<int> CreateMinStack()
            => new TwoListMinStack<int>();

        protected override IEnumerable<IList<int>> StackIntegrityTestData()
        {
            return new int[][]
            {
                new[] { 5, 3, 2, 8, 10 },
                new[] { -1, 6, 7, 3, -2, 1, 1, 1 },
                new[] { 100000, 20, 6666, 2 }
            };
        }
    }

    public class TwoListStringMinStackTests : MinStackTests<string>
    {
        protected override IMinStack<string> CreateMinStack()
            => new TwoListMinStack<string>();

        protected override IEnumerable<IList<string>> StackIntegrityTestData()
        {
            return new string[][]
            {
                new[] { "hello", "world", "I'm", "Eugene" }
            };
        }
    }

    public class TwoListBoolMinStackTests : MinStackTests<bool>
    {
        protected override IMinStack<bool> CreateMinStack()
            => new TwoListMinStack<bool>();

        protected override IEnumerable<IList<bool>> StackIntegrityTestData()
        {
            return new bool[][]
            {
                new[] { true, false, false, false, true, true, true },
                new[] { true, false },
                new[] { false, true }
            };
        }
    }
}

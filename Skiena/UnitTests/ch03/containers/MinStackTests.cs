using Algorithms.ch03.containers;
using System;
using System.Collections.Generic;
using System.Linq;
using UnitTests.common;
using Xunit;

namespace UnitTests.ch03.containers
{
    public abstract class MinStackTests<T> : StackTestBase<T> where T : IComparable<T>
    {
        [Fact]
        public void FindMinThrowsExceptionOnEmptyStack()
        {
            IMinStack<T> minStack = CreateMinStack();
            Assert.Throws<InvalidOperationException>(() => minStack.FindMin());
        }

        [Fact]
        public void FindMinReturnsMinimumElementCurrentlyInStack()
        {
            IEnumerable<IList<T>> testData = StackIntegrityTestData();
            var dataInStack = new List<T>();
            IMinStack<T> minStack = CreateMinStack();

            foreach (IList<T> data in testData)
            {
                foreach (T el in data)
                {
                    dataInStack.Add(el);
                    minStack.Push(el);
                    Assert.Equal(dataInStack.Min(), minStack.FindMin());
                }

                for (int i = 0; i < data.Count; i++)
                {
                    Assert.Equal(dataInStack.Min(), minStack.FindMin());
                    dataInStack.RemoveAt(dataInStack.Count - 1);
                    minStack.Pop();
                }
            }
        }

        protected abstract IMinStack<T> CreateMinStack();

        protected override IStack<T> CreateStack()
        {
            return CreateMinStack();
        }
    }
}

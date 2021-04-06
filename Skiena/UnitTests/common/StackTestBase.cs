using Algorithms.ch03.containers;
using System;
using System.Collections.Generic;
using Xunit;

namespace UnitTests.common
{
    public abstract class StackTestBase<T>
    {
        [Fact]
        public void EmptyStackThrowsExceptionOnPop()
        {
            IStack<T> emptyStack = CreateStack();
            Assert.Throws<InvalidOperationException>(() => emptyStack.Pop());
        }

        [Fact]
        public void TestDataIsRetrievedInLIFOOrder()
        {
            IEnumerable<IList<T>> testData = StackIntegrityTestData();
            IStack<T> stack = CreateStack();

            foreach (IList<T> data in testData)
            {
                foreach (T el in data)
                {
                    stack.Push(el);
                }

                Assert.Equal(data.Count, stack.Count);

                for (int i = data.Count - 1; i >= 0; i--)
                {
                    Assert.Equal(stack.Pop(), data[i]);
                }

                Assert.Equal(0, stack.Count);
            }
        }

        protected abstract IStack<T> CreateStack();

        protected abstract IEnumerable<IList<T>> StackIntegrityTestData();
    }
}

using System;
using Algorithms.ch03;
using Algorithms.ch03.interview;
using Xunit;

namespace UnitTests.ch03.interview
{
    public abstract class MiddleSearcherTest
    {
        [Fact]
        public void OddNumberedLinkedList()
        {
            IMiddleSearcher searcher = GetSearcher();
            var list = SinglyLinkedListBuilder.BuildList(1, 4, -2, 3, 4, 1, 4);
            var middle = list!.Next!.Next!.Next;

            Assert.Equal(middle, searcher.FindMiddle(list));
        }

        [Fact]
        public void EvenNumberedLinkedList()
        {
            IMiddleSearcher searcher = GetSearcher();
            var list = SinglyLinkedListBuilder.BuildList(1, 4, -2, 3, 4, 1, 4, 3, 4, 10);
            var middle = list!.Next!.Next!.Next!.Next!;

            Assert.Equal(middle, searcher.FindMiddle(list));
        }

        [Fact]
        public void SingleElementLinkedList()
        {
            IMiddleSearcher searcher = GetSearcher();
            var list = SinglyLinkedListBuilder.BuildList(1);

            Assert.Equal(list, searcher.FindMiddle(list));
        }

        protected abstract IMiddleSearcher GetSearcher();
    }
}

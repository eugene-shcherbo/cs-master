using Algorithms.ch03;
using Algorithms.ch03.containers;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace UnitTests.ch03.containers
{
    public class ReverseLinkedListAlgorithmTests
    {
        [Fact]
        public void ReturnsNullWhenListIsNull()
        {
            ReverseLinkedListAlgorithm algorithm = CreateReverseAlgorithm();
            Assert.Null(algorithm.Reverse<int>(null));
            Assert.Null(algorithm.Reverse<string>(null));
            Assert.Null(algorithm.Reverse<bool>(null));
        }

        [Theory]
        [InlineData("1")]
        [InlineData(1)]
        [InlineData(true)]
        public void DoNothingWhenListHasSingleElement<T>(T item)
        {
            ReverseLinkedListAlgorithm algorithm = CreateReverseAlgorithm();
            SinglyLinkedListNode<T> list = BuildListWithSingleItem(item);
            SinglyLinkedListNode<T> reversedList = algorithm.Reverse(list)!;

            Assert.NotNull(reversedList);
            Assert.Null(reversedList.Next);
            Assert.Equal(item, reversedList.Data);
        }

        [Theory]
        [MemberData(nameof(CreateDataItems))]
        public void CorrectlyReversesList<T>(T[] items)
        {
            ReverseLinkedListAlgorithm algorithm = CreateReverseAlgorithm();

            SinglyLinkedListNode<T> list = BuildList(items)!;
            SinglyLinkedListNode<T> reversedList = algorithm.Reverse(list)!;

            T[] reversedItems = items.Reverse().ToArray();
            Assert.True(LinkedListMatchesItems(reversedList, reversedItems));
        }

        public static IEnumerable<object[]> CreateDataItems() =>
            new object[][]
            {
                new object[] { new[] { 1, 2, 3, 4, 5, 6 } },
                new object[] { new[] { 3, 4, 5, 6, 7, 8 } },
                new object[] { new[] { "hello", "world" } },
                new object[] { new[] { true, true, false, false, true } }
            };

        private ReverseLinkedListAlgorithm CreateReverseAlgorithm() => new();

        private static SinglyLinkedListNode<T>? BuildList<T>(T[] items)
        {
            return SinglyLinkedListBuilder.BuildList(items);
        }

        private static SinglyLinkedListNode<T> BuildListWithSingleItem<T>(T item)
        {
            return SinglyLinkedListBuilder.BuildList(item)!;
        }

        private static bool LinkedListMatchesItems<T>(SinglyLinkedListNode<T> list, T[] items)
        {
            int index = 0;
            for (SinglyLinkedListNode<T>? curr = list; curr != null; curr = curr.Next, index++)
            {
                if (!Equals(curr.Data, items[index]))
                {
                    return false;
                }
            }

            if (index != items.Length)
            {
                return false;
            }

            return true;
        }
    }
}

using Algorithms.ch03.trees;
using System.Collections.Generic;
using Xunit;

namespace UnitTests.ch03.trees
{
    public abstract class BstToLinkedListMergerTests
    {
        [Theory]
        [MemberData(nameof(TestData))]
        public void ElementsInSortedOrder(BinaryTreeNode<int>? bst1, BinaryTreeNode<int>? bst2, IList<int> expectedSequence)
        {
            IBstToLinkedListMerger merger = CreateMerger();
            LinkedList<int> result = merger.MergeTrees(bst1, bst2, new IntComparer());

            LinkedListNode<int>? currNode = result.First;
            for (int i = 0; i < expectedSequence.Count; i++)
            {
                Assert.Equal(expectedSequence[i], currNode!.Value);
                currNode = currNode.Next;
            }
        }

        public static IEnumerable<object?[]> TestData
            => new object?[][]
            {
                new object?[]
                {
                    CreateTree(2, CreateTree(1), CreateTree(3)),
                    null,
                    new[] { 1, 2, 3 }
                },

                new object[]
                {
                    CreateTree(10, CreateTree(5, CreateTree(3), CreateTree(7)), CreateTree(15)),
                    CreateTree(20, CreateTree(10, CreateTree(5, null, CreateTree(7)), CreateTree(14)), CreateTree(22)),
                    new[] { 3, 5, 5, 7, 7, 10, 10, 14, 15, 20, 22 }
                }
            };

        protected abstract IBstToLinkedListMerger CreateMerger();

        private static BinaryTreeNode<int> CreateTree(int value, BinaryTreeNode<int>? left = null, BinaryTreeNode<int>? right = null)
        {
            return new BinaryTreeNode<int>(value, left, right);
        }

        private class IntComparer : IComparer<int>
        {
            public int Compare(int x, int y)
            {
                return x.CompareTo(y);
            }
        }
    }
}

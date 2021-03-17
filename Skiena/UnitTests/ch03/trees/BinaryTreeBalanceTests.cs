using System;
using Algorithms.ch03.trees;
using Xunit;

namespace UnitTests.ch03.trees
{
    public class BinaryTreeBalanceTests
    {
        [Fact]
        public void TestLeftBranchTree()
        {
            BinaryTreeBalanceTester tester = CreateTester();
            var tree = CreateTree(10, CreateTree(9, CreateTree(8, CreateTree(7, CreateTree(6)))));

            Assert.False(tester.IsHeightBalanced(tree));
        }

        [Fact]
        public void TestRightBranchTree()
        {
            BinaryTreeBalanceTester tester = CreateTester();
            var tree = CreateTree(6, null, CreateTree(7, null, CreateTree(8, null, CreateTree(9, null, CreateTree(10)))));

            Assert.False(tester.IsHeightBalanced(tree));
        }

        [Fact]
        public void TestFullTree()
        {
            BinaryTreeBalanceTester tester = CreateTester();
            var tree = CreateTree(10, CreateTree(5, CreateTree(3), CreateTree(6)), CreateTree(15, CreateTree(12), CreateTree(18)));

            Assert.True(tester.IsHeightBalanced(tree));
        }

        private BinaryTreeBalanceTester CreateTester() => new BinaryTreeBalanceTester();

        private static BinaryTreeNode<int> CreateTree(int value, BinaryTreeNode<int>? left = null, BinaryTreeNode<int>? right = null)
        {
            return new BinaryTreeNode<int>(value, left, right);
        }
    }
}

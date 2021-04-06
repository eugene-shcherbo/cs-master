using Algorithms.ch03.trees;
using Xunit;

namespace UnitTests.ch03.trees
{
    public abstract class BstBalancerTestBase
    {
        [Fact]
        public void TestLeftBranchTree()
        {
            IBstBalancer balancer = CreateBalancer();
            var bst = CreateTree(10, CreateTree(9, CreateTree(8, CreateTree(7, CreateTree(6)))));
            var balanced = balancer.CreateBalanced(bst);

            Assert.Equal(8, balanced!.Data);
            Assert.Equal(6, balanced!.Left!.Data);
            Assert.Equal(7, balanced!.Left!.Right!.Data);
            Assert.Equal(9, balanced!.Right!.Data);
            Assert.Equal(10, balanced!.Right!.Right!.Data);
        }

        [Fact]
        public void TestRightBranchTree()
        {
            IBstBalancer balancer = CreateBalancer();
            var bst = CreateTree(6, null, CreateTree(7, null, CreateTree(8, null, CreateTree(9, null, CreateTree(10)))));
            var balanced = balancer.CreateBalanced(bst);

            Assert.Equal(8, balanced!.Data);
            Assert.Equal(6, balanced!.Left!.Data);
            Assert.Equal(7, balanced!.Left!.Right!.Data);
            Assert.Equal(9, balanced!.Right!.Data);
            Assert.Equal(10, balanced!.Right!.Right!.Data);
        }

        [Fact]
        public void TestFullTree()
        {
            IBstBalancer balancer = CreateBalancer();
            var bst = CreateTree(10, CreateTree(5, CreateTree(3), CreateTree(6)), CreateTree(15, CreateTree(12), CreateTree(18)));
            var balanced = balancer.CreateBalanced(bst);

            Assert.Equal(10, balanced!.Data);
            Assert.Equal(5, balanced!.Left!.Data);
            Assert.Equal(3, balanced!.Left!.Left!.Data);
            Assert.Equal(6, balanced!.Left!.Right!.Data);
            Assert.Equal(15, balanced!.Right!.Data);
            Assert.Equal(12, balanced!.Right!.Left!.Data);
            Assert.Equal(18, balanced!.Right!.Right!.Data);
        }

        protected abstract IBstBalancer CreateBalancer();

        private static BinaryTreeNode<int> CreateTree(int value, BinaryTreeNode<int>? left = null, BinaryTreeNode<int>? right = null)
        {
            return new BinaryTreeNode<int>(value, left, right);
        }
    }
}

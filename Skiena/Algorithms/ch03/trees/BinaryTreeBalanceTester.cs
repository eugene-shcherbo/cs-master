using System;
namespace Algorithms.ch03.trees
{
    public class BinaryTreeBalanceTester
    {
        public bool IsHeightBalanced<T>(BinaryTreeNode<T>? tree)
        {
            var treeBalanceCheck = CheckTreeBalance(tree);
            return treeBalanceCheck.isBalanced;
        }

        private BalanceCheckResult CheckTreeBalance<T>(BinaryTreeNode<T>? tree)
        {
            if (tree is null)
            {
                return new BalanceCheckResult(-1, true);
            }

            var leftBalanceCheck = CheckTreeBalance(tree.Left);
            var rightBalanceCheck = CheckTreeBalance(tree.Right);
            var currHeight = Math.Max(leftBalanceCheck.height, rightBalanceCheck.height) + 1;

            return new BalanceCheckResult(
                currHeight,
                leftBalanceCheck.isBalanced
                    && rightBalanceCheck.isBalanced
                    && Math.Abs(leftBalanceCheck.height - rightBalanceCheck.height) <= 1
                );
        }

        private class BalanceCheckResult
        {
            public int height;
            public bool isBalanced;

            public BalanceCheckResult(int height, bool isBalanced)
            {
                this.height = height;
                this.isBalanced = isBalanced;
            }
        }
    }
}

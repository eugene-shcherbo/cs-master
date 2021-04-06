using Algorithms.common.extenstions;
using System;

namespace Algorithms.common.ds
{
    public abstract class AbstractBinarySearchTree<TNode, TValue>
        where TNode : class, IBinaryTreeNode<TNode, TValue>
        where TValue : IComparable<TValue>
    {
        protected TNode? Root { get; set; }

        public AbstractBinarySearchTree()
        {
            Root = null;
        }

        public AbstractBinarySearchTree(TNode? root)
        {
            Root = root;
        }

        public TNode? Min()
        {
            if (Root is null)
            {
                return null;
            }

            return FindLeftMostNode(Root);
        }

        public TNode? Max()
        {
            if (Root is null)
            {
                return null;
            }

            return FindRightMostNode(Root);
        }

        public TNode? Find(TValue value)
        {
            return Find(Root, value);
        }

        private TNode? Find(TNode? root, TValue value)
        {
            if (root is null)
            {
                return null;
            }

            if (root.Data.SameAs(value))
            {
                return root;
            }
            else if (root.Data.LessThan(value))
            {
                return Find(root.Left, value);
            }
            else
            {
                return Find(root.Right, value);
            }
        }

        protected TNode? FindLeftMostNode(TNode root)
        {
            TNode res = root;

            while (root.Left != null)
            {
                res = root;
                root = root.Left;
            }

            return res;
        }

        protected TNode FindRightMostNode(TNode root)
        {
            TNode res = root;

            while (root.Right != null)
            {
                res = root;
                root = root.Right;
            }

            return res;
        }

        public abstract TNode? Predecessor(TNode node);

        public abstract TNode? Successor(TNode node);

        public abstract TNode? Insert(TValue value);

        public abstract TNode? Delete(TValue value);
    }
}

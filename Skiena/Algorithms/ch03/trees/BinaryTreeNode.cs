namespace Algorithms.ch03.trees
{
    public class BinaryTreeNode<TData>
    {
        public TData Data { get; }

        public BinaryTreeNode<TData>? Right { get; }

        public BinaryTreeNode<TData>? Left { get; }

        public BinaryTreeNode(TData data, BinaryTreeNode<TData>? left = null, BinaryTreeNode<TData>? right = null)
        {
            Data = data;
            Left = left;
            Right = right;
        }
    }

    public static class BinaryTreeNode
    {
        public static BinaryTreeNode<TData> Create<TData>(TData data, BinaryTreeNode<TData>? left = null, BinaryTreeNode<TData>? right = null)
        {
            return new BinaryTreeNode<TData>(data, left, right);
        }
    }
}
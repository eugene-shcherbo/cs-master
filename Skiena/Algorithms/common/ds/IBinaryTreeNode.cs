namespace Algorithms.common.ds
{
    public interface IBinaryTreeNode<TNode, TData> where TNode : IBinaryTreeNode<TNode, TData>
    {
        public TData Data { get; }

        public TNode? Right { get; }

        public TNode? Left { get; }
    }
}
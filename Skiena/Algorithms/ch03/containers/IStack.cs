namespace Algorithms.ch03.containers
{
    public interface IStack<T>
    {
        void Push(T element);

        T Pop();

        int Count { get; }
    }
}

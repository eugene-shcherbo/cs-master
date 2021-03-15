using System;
namespace Algorithms.ch03.containers
{
    public interface IMinStack<T> : IStack<T> where T : IComparable<T>
    {
        T FindMin();
    }
}

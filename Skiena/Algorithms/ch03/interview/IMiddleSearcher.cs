using System;
namespace Algorithms.ch03.interview
{
    public interface IMiddleSearcher
    {
        SinglyLinkedListNode<T>? FindMiddle<T>(SinglyLinkedListNode<T>? list);
    }
}

using System;

namespace Algorithms.ch03
{
    public class SinglyLinkedListNode<TData>
    {
        public TData? Data { get; set; }

        public SinglyLinkedListNode<TData>? Next { get; set; }

        public SinglyLinkedListNode(TData? data, SinglyLinkedListNode<TData>? next)
        {
            Data = data;
            Next = next;
        }

        public SinglyLinkedListNode(TData? data)
            : this(data, null)
        {
        }
    }
}

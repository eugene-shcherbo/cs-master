using System;
using System.Collections.Generic;

namespace Algorithms.ch03.containers
{
    public class ReverseLinkedListAlgorithm
    {
        public SinglyLinkedListNode<T>? Reverse<T>(SinglyLinkedListNode<T>? head)
        {
            if (head is null)
            {
                return null;
            }

            SinglyLinkedListNode<T>? prev = null;
            SinglyLinkedListNode<T>? curr = head;

            while (curr.Next != null)
            {
                var temp = curr.Next;
                curr.Next = prev;
                prev = curr;
                curr = temp;
            }

            curr.Next = prev;

            return curr;
        }
    }
}

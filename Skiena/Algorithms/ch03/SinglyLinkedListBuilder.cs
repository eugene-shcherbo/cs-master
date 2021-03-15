using System;
namespace Algorithms.ch03
{
    public class SinglyLinkedListBuilder
    {
        public static SinglyLinkedListNode<T>? BuildList<T>(params T[] items)
        {
            SinglyLinkedListNode<T>? head = null;
            SinglyLinkedListNode<T>? tail = null;

            foreach (T item in items)
            {
                if (head is null)
                {
                    head = new SinglyLinkedListNode<T>(item);
                    tail = head;
                }
                else
                {
                    tail!.Next = new SinglyLinkedListNode<T>(item);
                    tail = tail.Next;
                }
            }

            return head;
        }
    }
}

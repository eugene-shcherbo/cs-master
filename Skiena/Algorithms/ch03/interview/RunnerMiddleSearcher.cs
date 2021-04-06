namespace Algorithms.ch03.interview
{
    public class RunnerMiddleSearcher : IMiddleSearcher
    {
        public SinglyLinkedListNode<T>? FindMiddle<T>(SinglyLinkedListNode<T>? list)
        {
            if (list is null)
            {
                return null;
            }

            SinglyLinkedListNode<T>? slow = list;
            SinglyLinkedListNode<T>? fast = list.Next;

            while (fast is not null && fast.Next is not null)
            {
                fast = fast.Next.Next;
                slow = slow!.Next;
            }

            return slow;
        }
    }
}

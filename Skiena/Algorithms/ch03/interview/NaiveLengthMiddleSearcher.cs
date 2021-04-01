using System;
namespace Algorithms.ch03.interview
{
    public class NaiveLengthMiddleSearcher : IMiddleSearcher
    {
        public SinglyLinkedListNode<T>? FindMiddle<T>(SinglyLinkedListNode<T>? list)
        {
            int length = LengthOfList(list);

            for (int i = 0; i < (length - 1) / 2; i++)
            {
                list = list!.Next;
            }

            return list;
        }

        private static int LengthOfList<T>(SinglyLinkedListNode<T>? list)
        {
            int res = 0;

            while (list != null)
            {
                list = list.Next;
                res++;
            }

            return res;
        }
    }
}

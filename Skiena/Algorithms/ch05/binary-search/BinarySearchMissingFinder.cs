using System.Linq;

namespace Algorithms.ch05.binary_search
{
    public class BinarySearchMissingFinder : IMissingFinder
    {
        public int FindMissing(int[] values)
        {
            if (!values.Any())
            {
                return 1;
            }

            if (values.Length == 1)
            {
                return values[0] == 1 ? 2 : 1;
            }

            if (values[0] == 2)
            {
                return 1;
            }

            int start = 0;
            int end = values.Length - 1;

            while (start != end - 1)
            {
                int mid = start + ((end - start) / 2);

                if (mid + 1 == values[mid])
                {
                    start = mid;
                }
                else
                {
                    end = mid;
                }
            }

            return values[start] + 1;
        }
    }
}

using System;
using System.Linq;

namespace Algorithms.ch04.numbers
{
    public class SortModeFinder : IModeFinder
    {
        public int GetMode(int[] values)
        {
            int[] sorted = values.OrderBy(v => v).ToArray();

            int modePosSoFar = 0;
            int maxNumOfOccurences = 0;
            int currNumOfOccurences = 1;

            for (int i = 1; i < sorted.Length; i++)
            {
                if (sorted[i] == sorted[i - 1])
                {
                    currNumOfOccurences++;
                }
                else if (currNumOfOccurences > maxNumOfOccurences)
                {
                    modePosSoFar = i - 1;
                    maxNumOfOccurences = currNumOfOccurences;
                    currNumOfOccurences = 1;
                }
                else
                {
                    currNumOfOccurences = 1;
                }
            }

            return sorted[modePosSoFar];
        }
    }
}

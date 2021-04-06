using System.Collections.Generic;

namespace Algorithms.ch04.numbers
{
    public class HashTableModeFinder : IModeFinder
    {
        public int GetMode(int[] values)
        {
            var numOfOccurences = new Dictionary<int, int>();

            int mode = 0;
            int maxNumOfOccurences = 0;

            foreach (int value in values)
            {
                if (!numOfOccurences.ContainsKey(value))
                {
                    numOfOccurences.Add(value, 1);
                }

                numOfOccurences[value]++;

                if (numOfOccurences[value] > maxNumOfOccurences)
                {
                    maxNumOfOccurences = numOfOccurences[value];
                    mode = value;
                }
            }

            return mode;
        }
    }
}

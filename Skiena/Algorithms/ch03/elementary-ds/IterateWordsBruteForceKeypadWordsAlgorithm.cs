using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.ch03.elementaryds
{
    public class IterateWordsBruteForceKeypadWordsAlgorithm : IKeypadWordsAlgorithm
    {
        private readonly Dictionary<char, short> keypadMapping = new Dictionary<char, short>
        {
            { 'a', 2 }, { 'b', 2 }, { 'c', 2 },
            { 'd', 3 }, { 'e', 3 }, { 'f' , 3 },
            { 'g', 4 }, { 'h', 4 }, { 'i', 4 },
            { 'j', 5 }, { 'k', 5 }, { 'l', 5 },
            { 'm', 6 }, { 'n', 6 }, { 'o', 6 },
            { 'p', 7 }, { 'q', 7 }, { 'r', 7 }, { 's', 7 },
            { 't', 8 }, { 'u', 8 }, { 'v', 8 },
            { 'w', 9 }, { 'x', 9 }, { 'y', 9 }, { 'z', 9 }
        };

        public IEnumerable<string> GetWords(IEnumerable<short> digits, ISet<string> dictionary)
        {
            var digitsArray = digits.ToArray();

            foreach (short digit in digitsArray)
            {
                if (digit < 2 || digit > 9)
                {
                    throw new ArgumentException($"There is no such a telephone key: {digit}");
                }
            }

            int wordSize = digitsArray.Length;
            var words = new List<string>();

            foreach (var word in dictionary)
            {
                if (word.Length != wordSize)
                {
                    continue;
                }

                int currDigitIndex = 0;
                while (currDigitIndex < wordSize)
                {
                    if (digitsArray[currDigitIndex] != keypadMapping[word[currDigitIndex]])
                    {
                        break;
                    }
                    currDigitIndex++;
                }

                if (currDigitIndex == wordSize)
                {
                    words.Add(word);
                }
            }

            return words;
        }
    }
}

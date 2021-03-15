using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms.ch03.elementaryds
{
    public class BruteForceKeypadWordsAlgorithm : IKeypadWordsAlgorithm
    {
        private readonly Dictionary<short, string> keypadMapping = new Dictionary<short, string>
        {
                           { 2, "abc" }, { 3, "def" },
            { 4, "ghi" },  { 5, "jkl" }, { 6, "mno" },
            { 7, "pqrs" }, { 8, "tuv" }, { 9, "wxyz" }
        };

        public IEnumerable<string> GetWords(IEnumerable<short> digits, ISet<string> dictionary)
        {
            var words = new List<string>();
            GetWordsHelper(digits.ToArray(), 0, new StringBuilder(), dictionary, words);
            return words;
        }

        private void GetWordsHelper(short[] digits, int currDigitIndex, StringBuilder currWordBuilder, ISet<string> dictionary, IList<string> words)
        {
            if (currDigitIndex == digits.Length)
            {
                var word = currWordBuilder.ToString();
                if (dictionary.Contains(word))
                {
                    words.Add(word);
                }
            }
            else
            {
                short digit = digits[currDigitIndex];

                if (!keypadMapping.ContainsKey(digit))
                {
                    throw new ArgumentException($"There is no such a telephone key: {digit}");
                }

                foreach (char letter in keypadMapping[digit])
                {
                    GetWordsHelper(digits, currDigitIndex + 1, currWordBuilder.Append(letter), dictionary, words);
                    currWordBuilder.Length--;
                }
            }
        }
    }
}

using Algorithms.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.ch06
{
    public class RabinKarpStringMatcher : IStringMatcher
    {
        private readonly IRollingHasher hasher;

        public RabinKarpStringMatcher(IRollingHasher hasher)
        {
            this.hasher = hasher;
        }

        public int FindIndex(string text, string pattern)
        {
            int patternHash = hasher.Hash(pattern);
            string textPortion = text.Substring(0, pattern.Length);
            int windowHash = hasher.Hash(textPortion);

            for (int i = 0; i <= text.Length - pattern.Length; i++)
            {
                if (patternHash == windowHash && textPortion == pattern)
                {
                    return i;
                }

                if (i < text.Length - pattern.Length)
                {
                    windowHash = hasher.Roll(textPortion, windowHash, text[i + pattern.Length]);
                    textPortion = text.Substring(i + 1, pattern.Length);
                }
            }

            return -1;
        }
    }
}

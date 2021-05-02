using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.ch06
{
    public class NumberNotationRollingHasher : IRollingHasher
    {
        private readonly int prime;
        private readonly int alphabetSize;

        public NumberNotationRollingHasher(int alphabetSize)
        {
            this.alphabetSize = alphabetSize;
            prime = 101;
        }

        public int Hash(string text)
        {
            int hash = 0;

            for (int i = 0; i < text.Length; i++)
            {
                hash = (alphabetSize * hash + text[i]) % prime;
            }

            return hash;
        }

        public int Roll(string text, int hash, char next)
        {
            var h = (int)Math.Pow(alphabetSize, text.Length - 1) % prime;
            var newHash = (alphabetSize * (hash - text[0] * h) + next) % prime;

            return newHash < 0 ? newHash + prime : newHash;
        }
    }
}
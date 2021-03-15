using System;
using System.Collections.Generic;

namespace Algorithms.ch03.elementaryds
{
    public interface IKeypadWordsAlgorithm
    {
        public IEnumerable<string> GetWords(IEnumerable<short> digits, ISet<string> dictionary);
    }
}

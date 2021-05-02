using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.ch06
{
    public interface IRollingHasher
    {
        int Hash(string text);

        int Roll(string text, int hash, char next);
    }
}

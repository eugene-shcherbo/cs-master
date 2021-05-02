using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.common
{
    public interface IStringMatcher
    {
        int FindIndex(string text, string pattern);
    }
}

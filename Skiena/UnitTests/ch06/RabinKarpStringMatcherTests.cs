using Algorithms.ch06;
using Algorithms.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTests.common;

namespace UnitTests.ch06
{
    public class RabinKarpStringMatcherTests : StringMatcherTests
    {
        protected override IStringMatcher GetMatcher()
            => new RabinKarpStringMatcher(new NumberNotationRollingHasher(256));
    }
}

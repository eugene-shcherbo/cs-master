using Algorithms.ch05.largest_subrange;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.ch05.largest_subrange
{
    public class DivideAndConquerSubrangeFinderTests : SubrangeFinderTests
    {
        protected override ISubrangeFinder GetFinder()
            => new DivideAndConquerSubrangeFinder();
    }
}

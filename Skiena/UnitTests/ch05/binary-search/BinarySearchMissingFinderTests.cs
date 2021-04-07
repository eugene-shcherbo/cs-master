using Algorithms.ch05.binary_search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.ch05.binary_search
{
    public class BinarySearchMissingFinderTests : MissingFinderTests
    {
        protected override IMissingFinder GetFinder()
            => new BinarySearchMissingFinder();
    }
}

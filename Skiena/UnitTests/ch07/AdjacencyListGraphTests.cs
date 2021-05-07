using Algorithms.ch07;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.ch07
{
    public class AdjacencyListGraphTests : GraphTests
    {
        protected override IGraph<int> GetGraph()
            => new AdjacencyListGraph<int>();
    }
}

using Algorithms.ch07;
using Algorithms.ch07.bfs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.ch07.bfs
{
    public class BfsWeakConnectedComponentsFinderTests : WeakConnectedComponentsFinderTests
    {
        protected override IWeakConnectedComponentsFinder GetFinder()
            => new BfsWeakConnectedComponentsFinder();
    }
}

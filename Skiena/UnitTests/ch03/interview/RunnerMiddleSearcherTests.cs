using System;
using Algorithms.ch03.interview;

namespace UnitTests.ch03.interview
{
    public class RunnerMiddleSearcherTests : MiddleSearcherTest
    {
        protected override IMiddleSearcher GetSearcher()
            => new RunnerMiddleSearcher();
    }
}

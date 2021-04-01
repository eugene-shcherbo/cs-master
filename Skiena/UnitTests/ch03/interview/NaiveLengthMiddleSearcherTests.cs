using System;
using Algorithms.ch03.interview;

namespace UnitTests.ch03.interview
{
    public class NaiveLengthMiddleSearcherTests : MiddleSearcherTest
    {
        protected override IMiddleSearcher GetSearcher()
            => new NaiveLengthMiddleSearcher();
    }
}

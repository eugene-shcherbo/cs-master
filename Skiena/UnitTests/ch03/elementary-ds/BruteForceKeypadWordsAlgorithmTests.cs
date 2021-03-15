using System;
using Algorithms.ch03.elementaryds;

namespace UnitTests.ch03.elementaryds
{
    public class BruteForceKeypadWordsAlgorithmTests : KeypadWordsAlgorithmTests
    {
        protected override IKeypadWordsAlgorithm CreateAlgorithm() => new BruteForceKeypadWordsAlgorithm();
    }
}

using Algorithms.ch03.elementaryds;

namespace UnitTests.ch03.elementaryds
{
    public class IterateWordsBruteForceKeypadWordsAlgorithmTests : KeypadWordsAlgorithmTests
    {

        protected override IKeypadWordsAlgorithm CreateAlgorithm()
            => new IterateWordsBruteForceKeypadWordsAlgorithm();
    }
}

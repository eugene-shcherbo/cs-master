using Algorithms.ch05.binary_search;

namespace UnitTests.ch05.binary_search
{
    public class BinarySearchLargestFinderTests : LargestFinderTests
    {
        protected override ILargestFinder GetFinder()
            => new BinarySearchLargestFinder();
    }
}

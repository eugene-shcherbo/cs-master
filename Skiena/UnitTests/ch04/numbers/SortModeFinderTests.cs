using Algorithms.ch04.numbers;

namespace UnitTests.ch04.numbers
{
    public class SortModeFinderTests : ModeFinderTests
    {
        protected override IModeFinder GetFinder()
            => new SortModeFinder();
    }
}

using Algorithms.ch03.interview;

namespace UnitTests.ch03.interview
{
    public class NaiveArrayProductTests : ArrayProductTests
    {
        protected override IArrayProduct GetAlgorithm()
            => new NaiveArrayProduct();
    }
}

using Algorithms.ch03.interview;

namespace UnitTests.ch03.interview
{
    public class LinearArrayProductTests : ArrayProductTests
    {
        protected override IArrayProduct GetAlgorithm()
            => new LinearArrayProduct();
    }
}

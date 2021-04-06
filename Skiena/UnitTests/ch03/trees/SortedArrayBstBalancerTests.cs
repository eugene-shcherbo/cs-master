using Algorithms.ch03.trees;

namespace UnitTests.ch03.trees
{
    public class SortedArrayBstBalancerTests : BstBalancerTestBase
    {
        protected override IBstBalancer CreateBalancer()
            => new SortedArrayBstBalancer();
    }
}

using Algorithms.ch03.trees;

namespace UnitTests.ch03.trees
{
    public class RecursiveInOrderBstToLinkedListMergerTests : BstToLinkedListMergerTests
    {
        protected override IBstToLinkedListMerger CreateMerger()
            => new RecursiveInOrderBstToLinkedListMerger();
    }
}

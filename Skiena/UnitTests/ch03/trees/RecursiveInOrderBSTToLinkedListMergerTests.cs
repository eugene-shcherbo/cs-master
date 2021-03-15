using System;
using Algorithms.ch03.trees;

namespace UnitTests.ch03.trees
{
    public class RecursiveInOrderBSTToLinkedListMergerTests : BSTToLinkedListMergerTests
    {
        protected override IBSTToLinkedListMerger CreateMerger()
            => new RecursiveInOrderBSTToLinkedListMerger();
    }
}

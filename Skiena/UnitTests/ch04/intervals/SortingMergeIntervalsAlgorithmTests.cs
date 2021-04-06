using Algorithms.ch04.intervals;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Xunit;

namespace UnitTests.ch04.intervals
{
    public class SortingMergeIntervalsAlgorithmTests
    {
        [Fact]
        public void NoOverlaps()
        {
            var intervals = new[]
            {
                new Interval(1, 5),
                new Interval(6, 8),
                new Interval(9, 10)
            };

            TestMerge(intervals, intervals);
        }

        [Fact]
        public void MergeTwoIntoOne()
        {
            var intervals = new[]
            {
                new Interval(1, 5),
                new Interval(-4, 3)
            };

            var expected = new[]
            {
                new Interval(-4, 5)
            };

            TestMerge(intervals, expected);
        }

        [Theory]
        [MemberData(nameof(TestIntervalsProvider))]
        public void TestMergeDifferentInvtervals(Interval[] intervals, Interval[] expected)
        {
            TestMerge(intervals, expected);
        }

        public static IEnumerable<object[]> TestIntervalsProvider()
            => new object[][]
            {
                new object[]
                {
                    new[]
                    {
                        new Interval(2, 5),
                        new Interval(0, 3),
                        new Interval(6, 9),
                        new Interval(4, 7),
                        new Interval(-1, 2)
                    },
                    new[]
                    {
                        new Interval(-1, 9)
                    }
                },
                new object[]
                {
                    new[]
                    {
                        new Interval(2, 5),
                        new Interval(0, 3),
                        new Interval(6, 9),
                        new Interval(7, 10),
                        new Interval(-1, 2)
                    },
                    new[]
                    {
                        new Interval(-1, 5),
                        new Interval(6, 10)
                    }
                }
            };

        private static void TestMerge(Interval[] intervals, Interval[] expected)
        {
            IMergeIntervalsAlgorithm algorithm = GetAlgorithm();

            IEnumerable<Interval> merged = algorithm.MergeOverlapped(intervals);

            Assert.Equal(expected.Length, merged.Count());
            Assert.Equal(expected, merged, new NormalIntervalEqualityComparer());
        }

        private static IMergeIntervalsAlgorithm GetAlgorithm()
            => new SortingMergeIntervalsAlgorithm();

        private class NormalIntervalEqualityComparer : IEqualityComparer<Interval>
        {
            public bool Equals(Interval? x, Interval? y)
                => x is null ? y is null : y is not null && x.Start == y.Start && x.End == y.End;

            public int GetHashCode([DisallowNull] Interval obj) 
                => obj.Start.GetHashCode() ^ obj.End.GetHashCode();
        }
    }
}

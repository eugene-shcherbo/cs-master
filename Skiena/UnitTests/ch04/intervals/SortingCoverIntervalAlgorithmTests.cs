using Algorithms.ch04.intervals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.ch04.intervals
{
    public class SortingCoverIntervalAlgorithmTests
    {
        [Fact]
        public void NoSegmentsCoverInterval()
        {
            var segments = new[]
            {
                new Interval(-1, 5),
                new Interval(3, 8),
                new Interval(8, 11)
            };

            ICoverIntervalAlgorithm algorithm = GetAlgorithm();
            IEnumerable<Interval> result = algorithm.FindSegments(segments, 12);

            Assert.Empty(result);
        }

        [Fact]
        public void ReturnsSingleSegmentWhenItCoversTheInterval()
        {
            var segments = new[]
            {
                new Interval(0, 10),
                new Interval(-5, 4),
                new Interval(4, 30),
                new Interval(-2, 40),
                new Interval(10, 30)
            };

            ICoverIntervalAlgorithm algorithm = GetAlgorithm();
            IEnumerable<Interval> result = algorithm.FindSegments(segments, 30);

            Assert.Single(result);
            Assert.Equal(-2, result.First().Start);
            Assert.Equal(40, result.First().End);
        }

        [Fact]
        public void MinimumNumberOfSegments()
        {
            var segments = new[]
            {
                new Interval(0, 10),
                new Interval(-5, 4),
                new Interval(4, 30),
                new Interval(10, 30)
            };

            ICoverIntervalAlgorithm algorithm = GetAlgorithm();
            IEnumerable<Interval> result = algorithm.FindSegments(segments, 30);

            Assert.Equal(2, result.Count());
            Assert.Equal(0, result.First().Start);
            Assert.Equal(10, result.First().End);
            Assert.Equal(4, result.Skip(1).First().Start);
            Assert.Equal(30, result.Skip(1).First().End);
        }

        [Fact]
        public void LastSegmentCoverInterval()
        {
            var segments = new[]
            {
                new Interval(0, 10),
                new Interval(-5, 4),
                new Interval(4, 25),
                new Interval(10, 30)
            };

            ICoverIntervalAlgorithm algorithm = GetAlgorithm();
            IEnumerable<Interval> result = algorithm.FindSegments(segments, 30);

            Assert.Equal(2, result.Count());
            Assert.Equal(0, result.First().Start);
            Assert.Equal(10, result.First().End);
            Assert.Equal(10, result.Skip(1).First().Start);
            Assert.Equal(30, result.Skip(1).First().End);
        }

        private static ICoverIntervalAlgorithm GetAlgorithm()
            => new SortingCoverIntervalAlgorithm();
    }
}

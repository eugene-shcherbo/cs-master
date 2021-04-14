using Algorithms.ch04.intervals;
using Algorithms.ch05.largest_subrange;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.ch05.largest_subrange
{
    public abstract class SubrangeFinderTests
    {
        [Fact]
        public void LeftHalf()
        {
            int[] values = new[]
            {
                -10, 5, 3, 6, -8, 7, -4, -5, 1, 9, -2
            };

            ISubrangeFinder finder = GetFinder();

            Interval result = finder.FindSubrange(values);

            Assert.Equal(1, result.Start);
            Assert.Equal(3, result.End);
        }

        [Fact]
        public void RightHalf()
        {
            int[] values = new[]
            {
                -10, -5, 1, 9, -8, 7, -14, 5, 3, 6, -3
            };

            ISubrangeFinder finder = GetFinder();

            Interval result = finder.FindSubrange(values);

            Assert.Equal(7, result.Start);
            Assert.Equal(9, result.End);
        }

        [Fact]
        public void CrossingMid()
        {
            int[] values = new[]
            {
                -10, -5, 1, 9, -8, 7, -4, 5, 3, 6, 2
            };

            ISubrangeFinder finder = GetFinder();

            Interval result = finder.FindSubrange(values);

            Assert.Equal(2, result.Start);
            Assert.Equal(10, result.End);
        }

        protected abstract ISubrangeFinder GetFinder();
    }
}

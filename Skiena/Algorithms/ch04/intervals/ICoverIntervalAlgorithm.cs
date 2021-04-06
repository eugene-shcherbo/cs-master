using System.Collections.Generic;

namespace Algorithms.ch04.intervals
{
    public interface ICoverIntervalAlgorithm
    {
        IEnumerable<Interval> FindSegments(Interval[] segments, int m);
    }
}

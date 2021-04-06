using System.Collections.Generic;

namespace Algorithms.ch04.intervals
{
    public interface IMergeIntervalsAlgorithm
    {
        IEnumerable<Interval> MergeOverlapped(Interval[] intervals);
    }
}

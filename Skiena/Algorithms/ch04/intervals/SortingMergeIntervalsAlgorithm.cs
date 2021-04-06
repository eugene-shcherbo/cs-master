using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.ch04.intervals
{
    public class SortingMergeIntervalsAlgorithm : IMergeIntervalsAlgorithm
    {
        public IEnumerable<Interval> MergeOverlapped(Interval[] intervals)
        {
            if (!intervals.Any())
            {
                return Array.Empty<Interval>();
            }

            Array.Sort(intervals, new FirstPointIntervalComparer());

            var res = new List<Interval>();
            var merged = Interval.From(intervals[0]);

            foreach (Interval interval in intervals)
            {
                if (interval.Start <= merged.End)
                {
                    merged = merged.Merge(interval);
                }
                else
                {
                    res.Add(merged);
                    merged = interval;
                }
            }

            res.Add(merged);

            return res;
        }

        private class FirstPointIntervalComparer : IComparer<Interval>
        {
            public int Compare(Interval? x, Interval? y) 
                => x switch
                {
                    null => y is null ? 0 : -1,
                    _ => y is null ? 1 : x.Start.CompareTo(y.Start)
                };
        }
    }
}

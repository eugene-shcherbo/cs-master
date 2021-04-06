using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.ch04.intervals
{
    public class SortingCoverIntervalAlgorithm : ICoverIntervalAlgorithm
    {
        private readonly IEnumerable<Interval> NoSegments = Enumerable.Empty<Interval>();

        public IEnumerable<Interval> FindSegments(Interval[] segments, int m)
        {
            if (!segments.Any())
            {
                return NoSegments;
            }

            Array.Sort(segments, new FirstPointIntervalComparer());

            int longestSegmentIndex = FindLongestSegmentStartingBeforeZero(segments);

            if (longestSegmentIndex == -1)
            {
                return NoSegments;
            }

            List<Interval> result = new();
            Interval longest = segments[longestSegmentIndex];
            result.Add(longest);

            for (int i = longestSegmentIndex + 1; i < segments.Length - 1; i++)
            {
                Interval segment = segments[i];

                if (segment.Start > result[^1].End)
                {
                    return NoSegments;
                }

                if (segment.End <= result[^1].End)
                {
                    continue;
                }

                if (result[^1].End >= segments[i + 1].Start && segments[i + 1].End > segment.End)
                {
                    continue;
                }

                longest = longest.Merge(segment);
                result.Add(segment);

                if (longest.End >= m)
                {
                    return result;
                }
            }

            if (longest.End >= m)
            {
                return result;
            }

            longest = longest.Merge(segments[^1]);
            result.Add(segments[^1]);

            return longest.End >= m ? result : NoSegments;
        }

        public static int FindLongestSegmentStartingBeforeZero(Interval[] segments)
        {
            int longestIndex = -1;

            for (int i = 0; i < segments.Length; i++)
            {
                Interval segment = segments[i];

                if (segment.Start > 0)
                {
                    return longestIndex;
                }

                if (longestIndex == -1)
                {
                    longestIndex = i;
                }

                if (segment.End > segments[longestIndex].End)
                {
                    longestIndex = i;
                }
            }

            return longestIndex;
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

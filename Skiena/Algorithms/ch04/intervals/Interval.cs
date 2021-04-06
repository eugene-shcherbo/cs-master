using System;

namespace Algorithms.ch04.intervals
{
    public class Interval
    {
        public int Start { get; }

        public int End { get; }

        public Interval(int start, int end)
        {
            EnsureValid(start, end);
            Start = start;
            End = end;
        }

        public static Interval From(Interval interval)
        {
            return new Interval(interval.Start, interval.End);
        }

        public Interval Merge(Interval interval)
        {
            if (End < interval.Start || Start > interval.End)
            {
                return this;
            }

            return new Interval(Math.Min(Start, interval.Start), Math.Max(End, interval.End));
        }

        private static void EnsureValid(int start, int end)
        {
            if (start > end)
            {
                throw new ArgumentException("The start of the interval can't be greater than the end");
            }
        }
    }
}

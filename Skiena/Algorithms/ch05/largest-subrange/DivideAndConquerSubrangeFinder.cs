using Algorithms.ch04.intervals;
using Algorithms.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.ch05.largest_subrange
{
    public class DivideAndConquerSubrangeFinder : ISubrangeFinder
    {
        public Interval FindSubrange(int[] values)
        {
            return FindSubrangeHelper(values, 0, values.Length - 1).Interval;
        }

        private static (Interval Interval, int) FindSubrangeHelper(int[] values, int low, int high)
        {
            if (low == high)
            {
                return (new Interval(low, low), values[low]);
            }

            int mid =  low + ((high - low) / 2);

            (Interval, int Sum) left = FindSubrangeHelper(values, low, mid);
            (Interval, int Sum) right = FindSubrangeHelper(values, mid + 1, high);
            (Interval, int Sum) withMid = FindSubrangeCrossingMid(values, low, mid, high);

            return Utils.Max(part => part.Sum, left, right, withMid)!;
        }

        private static (Interval, int) FindSubrangeCrossingMid(int[] values, int low, int mid, int high)
        {
            int leftIndex = mid;
            int sum = 0;
            int leftSum = int.MinValue;

            for (int i = mid; i >= low; i--)
            {
                sum += values[i];

                if (sum > leftSum)
                {
                    leftSum = sum;
                    leftIndex = i;
                }
            }

            int rightIndex = mid + 1;
            sum = 0;
            int rightSum = int.MinValue;

            for (int i = mid + 1; i <= high; i++)
            {
                sum += values[i];

                if (sum > rightSum)
                {
                    rightSum = sum;
                    rightIndex = i;
                }
            }

            return (new Interval(leftIndex, rightIndex), leftSum + rightSum);
        }
    }
}

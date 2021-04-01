using System;

namespace Algorithms.ch03.interview
{
    public class NaiveArrayProduct : IArrayProduct
    {
        public int[] CalculateProduct(int[] arr)
        {
            var result = new int[arr.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                int product = 1;
                for (int j = 0; j < arr.Length; j++)
                {
                    if (j != i)
                    {
                        product *= arr[j];
                    }
                }
                result[i] = product;
            }

            return result;
        }
    }
}

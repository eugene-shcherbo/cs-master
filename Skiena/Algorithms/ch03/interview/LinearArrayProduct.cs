namespace Algorithms.ch03.interview
{
    public class LinearArrayProduct : IArrayProduct
    {
        public int[] CalculateProduct(int[] arr)
        {
            var result = new int[arr.Length];
            result[0] = 1;

            for (int i = 1; i < result.Length; i++)
            {
                result[i] = arr[i - 1] * result[i - 1];
            }

            int productSoFar = 1;
            for (int i = result.Length - 2; i >= 0; i--)
            {
                result[i] *= arr[i + 1] * productSoFar;
                productSoFar *= arr[i + 1];
            }

            return result;
        }
    }
}

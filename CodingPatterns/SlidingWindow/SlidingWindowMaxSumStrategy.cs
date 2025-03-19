namespace CodingPatterns.SlidingWindow
{
    public class SlidingWindowMaxSumStrategy : IProblemSolver<(int[] arr, int k), int>
    {
        public string Key => AppConstants.MaxSum;
        public int Solve((int[] arr, int k) input)
        {
            var arr = input.arr;
            var k = input.k;

            var arrayLength = arr.Length;
            if (arrayLength < k)
            {
                Console.WriteLine("Invalid");
                return -1;
            }

            // Compute sum of first window of size k
            int max_sum = 0;
            for (int i = 0; i < k; i++)
                max_sum += arr[i];

            // Compute sums of remaining windows by
            // removing first element of previous
            // window and adding last element of
            // current window.
            int window_sum = max_sum;
            for (int i = k; i < arrayLength; i++)
            {
                window_sum += arr[i] - arr[i - k];
                max_sum = Math.Max(max_sum, window_sum);
            }

            return max_sum;
        }
    }
}

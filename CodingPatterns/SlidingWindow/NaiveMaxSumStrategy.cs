namespace CodingPatterns.SlidingWindow
{
    public class NaiveMaxSumStrategy : IProblemSolver<(int[] arr, int k), int>
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

            int maxSum = 0;

            for (var i = 0; i <= arrayLength - k; i++)
            {
                var sum = 0;
                for (var j = i; j < i + k; j++)
                {
                    sum += arr[j];
                }
                maxSum = Math.Max(maxSum, sum);
            }
            return maxSum;
        }
    }
}

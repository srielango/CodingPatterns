namespace CodingPatterns.TwoPointers
{
    public class NaiveIsPairSumStrategy : IProblemSolver<(int[] array, int target), int>
    {
        public string Key => AppConstants.IsPairSum;

        //O(N^2) time and O(1) space
        public int Solve((int[] array, int target) input)
        {
            var A = input.array;
            var N = A.Length;
            var X = input.target;

            for (int i = 0; i < N; i++)
            {
                for (int j = i + 1; j < N; j++)
                {

                    // Check if pair exists
                    if (A[i] + A[j] == X)
                        return 1;

                    // Array is sorted and the sum is > X. No pair found
                    if (A[i] + A[j] > X) break;
                }
            }

            // No pair found with given sum.
            return 0;
        }
    }
}

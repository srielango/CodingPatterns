namespace CodingPatterns.TwoPointers
{
    public class TwoPointersIsPairSumStrategy : IProblemSolver<(int[] array, int target), int>
    {
        public string Key => AppConstants.IsPairSum;

        //O(N) time and O(1) space
        public int Solve((int[] array, int target) input)
        {
            var A = input.array;
            var N = A.Length;
            var X = input.target;

            // represents first pointer
            int i = 0;

            // represents second pointer
            int j = N - 1;

            while (i < j)
            {

                // If we find a pair
                if (A[i] + A[j] == X)
                    return 1;

                // If sum of elements at current
                // pointers is less, we move towards
                // higher values by doing i++
                else if (A[i] + A[j] < X)
                    i++;

                // If sum of elements at current
                // pointers is more, we move towards
                // lower values by doing j--
                else
                    j--;
            }
            return 0;
        }
    }
}

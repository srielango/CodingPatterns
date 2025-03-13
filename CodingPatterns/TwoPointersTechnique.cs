namespace CodingPatterns
{
    public class TwoPointersTechnique
    {
        public int IsPairSum(int[] A, int N, int X)
        {
            return isPairSumNaiveApproach(A, N, X);
            //return isPairSumTwoPointerTechniqueApproach(A, N, X);
        }

        private int isPairSumTwoPointerTechniqueApproach(int[] A, int N, int X)
        {
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

        private int isPairSumNaiveApproach(int[] A, int N, int X)
        {

            // Nested for loops for iterations
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

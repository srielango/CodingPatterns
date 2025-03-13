namespace CodingPatterns
{
    public class MergeKSortedArrays
    {
        private readonly int N = 4;
        public void mergeKArrays(int[,] arr, int i, int j,
                             int[] output)
        {

            // If one array is in range
            if (i == j)
            {
                for (int p = 0; p < N; p++)
                    output[p] = arr[i, p];

                return;
            }

            // If only two arrays are left then merge them
            if (j - i == 1)
            {
                mergeArrays(GetRow(arr, i), GetRow(arr, j), N,
                            N, output);
                return;
            }

            // Output arrays
            int[] out1 = new int[N * (((i + j) / 2) - i + 1)];
            int[] out2 = new int[N * (j - ((i + j) / 2))];

            // Divide the array into halves
            mergeKArrays(arr, i, (i + j) / 2, out1);
            mergeKArrays(arr, (i + j) / 2 + 1, j, out2);

            // Merge the output array
            mergeArrays(out1, out2, N * (((i + j) / 2) - i + 1),
                        N * (j - ((i + j) / 2)), output);
        }

        private int[] GetRow(int[,] matrix, int row)
        {
            var rowLength = matrix.GetLength(1);
            var rowVector = new int[rowLength];

            for (var i = 0; i < rowLength; i++)
                rowVector[i] = matrix[row, i];

            return rowVector;
        }

        private void mergeArrays(int[] arr1, int[] arr2, int N1,
                            int N2, int[] arr3)
        {
            int i = 0, j = 0, k = 0;

            // Traverse both array
            while (i < N1 && j < N2)
            {

                // Check if current element of first
                // array is smaller than current element
                // of second array. If yes, store first
                // array element and increment first array
                // index. Otherwise do same with second array
                if (arr1[i] < arr2[j])
                    arr3[k++] = arr1[i++];
                else
                    arr3[k++] = arr2[j++];
            }

            // Store remaining elements of first array
            while (i < N1)
                arr3[k++] = arr1[i++];

            // Store remaining elements of second array
            while (j < N2)
                arr3[k++] = arr2[j++];
        }
    }
}

namespace CodingPatterns
{
    public class ModifiedBinarySearch
    {
        public int FindMinElement(int[] arr)
        {
            Array.Sort(arr);
            var left = 0;
            var right = arr.Length - 1;
            
            var x = arr.Min();

            while(left < right)
            {
                int mid = (left + right) / 2;

                if (arr[mid] > arr[right])
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid;
                }
            }

            return arr[left];
        }

        public bool FindElement(int[] arr, int elementToFind)
        {
            Array.Sort(arr);
            var left = 0;
            var right = arr.Length - 1;

            var x = arr.Min();

            while (left < right)
            {
                int mid = (left + right) / 2;

                if (arr[mid] == elementToFind)
                {
                    return true;
                }
                else if (arr[mid] < elementToFind)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid;
                }
            }
            return false;
        }
    }
}

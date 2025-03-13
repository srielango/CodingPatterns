using System.Diagnostics.CodeAnalysis;

namespace CodingPatterns
{
    public class KWayMerge
    {
        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int num1Index = 0;
            int num2Index = 0;

            var result = new List<int>();

            while (num1Index < m && num2Index < n)
            {
                if (nums1[num1Index] < nums2[num2Index])
                {
                    result.Add(nums1[num1Index++]);
                }
                else
                {
                    result.Add(nums2[num2Index++]);
                }
            }

            while(num1Index < m)
            {
                result.Add(nums1[num1Index++]);
            }
            while (num2Index < n)
            {
                result.Add(nums2[num2Index++]);
            }

            for (int i = 0; i < nums1.Length; i++)
            {
                nums1[i] = result[i];
            }
        }

        public int[] Merge(int[,] nums)
        {
            var result = new List<int>();

            for (var i = 0; i < nums.GetLength(0); i++)
            {
                for(var j = 0; j < nums.GetLength(1); j++)
                {
                    result.Add(nums[i, j]);
                }
            }

            return result.ToArray();
        }
    }
}

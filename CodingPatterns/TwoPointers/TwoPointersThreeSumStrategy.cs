namespace CodingPatterns.TwoPointers
{
    public class TwoPointersThreeSumStrategy : IProblemSolver<int[], IList<IList<int>>>
    {
        public string Key => AppConstants.ThreeSum;

        public IList<IList<int>> Solve(int[] nums)
        {
            var result = new List<IList<int>>();
            if (nums.Length < 3)
            {
                return result;
            }

            Array.Sort(nums);
            for (var i = 0; i < nums.Length - 2;i++)
            {
                if (i > 0 && nums[i] == nums[i - 1])
                {
                    continue;
                }

                int target = nums[i];
                int left = i + 1;
                int right = nums.Length - 1;
                while (left < right)
                {
                    var sum = nums[left] + nums[right] + target;
                    if (sum == 0)
                    {
                        var newList = new List<int> { nums[i], nums[left], nums[right] };
                        result.Add(newList);

                        while (left < right && nums[left] == nums[left + 1])
                        {
                            left++;
                        }
                        while (left < right && nums[right] == nums[right - 1])
                        {
                            right--;
                        }
                        left++;
                        right--;
                    }
                    else if (sum < 0)
                    {
                        left++;
                    }
                    else
                    {
                        right--;
                    }
                }
            }
            return result;
        }
    }
}

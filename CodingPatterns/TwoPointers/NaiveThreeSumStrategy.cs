namespace CodingPatterns.TwoPointers
{
    public class NaiveThreeSumStrategy : IProblemSolver<int[], IList<IList<int>>>
    {
        public string Key => AppConstants.ThreeSum;

        //O(N^3) time and O(1) space
        public IList<IList<int>> Solve(int[] nums)
        {
            var result = new List<IList<int>>();
            if (nums.Length < 3)
            {
                return result;
            }
            
            for (int i = 0; i < nums.Length - 2; i++)
            {
                for(int j = i + 1; j < nums.Length - 1 ; j++)
                {
                    for (int k = j + 1; k < nums.Length; k++)
                    {
                        if (i != j && j != k && i != k)
                        {
                            if (nums[i] + nums[j] + nums[k] == 0)
                            {
                                var newList = new List<int> { nums[i], nums[j], nums[k] };
                                newList.Sort();
                                if (!result.Any(x => x.SequenceEqual(newList)))
                                    result.Add(newList);
                            }
                        }
                    }
                }
            }

            return result;
        }
    }
}

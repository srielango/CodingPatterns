namespace CodingPatterns
{
    public class Subset
    {
        //TODO: Add Iterative method
        //TODO: Understand how the below method works
        public void FindSubsets(List<List<int>> subset, List<int> nums, List<int> output, int index)
        {
            // Base Condition
            if (index == nums.Count)
            {
                subset.Add(output);
                return;
            }

            // Not Including Value which is at Index
            FindSubsets(subset, nums, new List<int>(output), index + 1);

            // Including Value which is at Index
            output.Add(nums[index]);
            FindSubsets(subset, nums, new List<int>(output), index + 1);
        }
    }
}

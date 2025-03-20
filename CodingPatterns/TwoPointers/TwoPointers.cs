namespace CodingPatterns.TwoPointers
{
    /// <summary>
    /// Two pointers technique
    /// </summary>
    public class TwoPointers
    {
        private readonly IStrategyFactory _strategyFactory;

        public TwoPointers(IStrategyFactory strategyFactory)
        {
            _strategyFactory = strategyFactory;
        }


        /// <summary>
        /// Given an array of numbers and a target sum, check if there is a pair of numbers in the array whose sum is equal to the target sum.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="target"></param>
        /// <returns>1 if the sum equals target. 0 if not found</returns>
        public int IsPairSum(int[] array, int target)
        {
            var strategy = _strategyFactory.GetStrategy<(int[] array, int target), int>(AppConstants.IsPairSum);
            return strategy.Solve((array, target));
        }

        /// <summary>
        /// Given an array of numbers, find all unique triplets in the array which gives the sum of zero.
        /// </summary>
        /// <param name="nums"></param>
        /// <returns>List of all pairs that gives the sum of zero</returns>
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            var strategy = _strategyFactory.GetStrategy<int[], IList<IList<int>>>(AppConstants.ThreeSum);
            return strategy.Solve(nums);
        }
    }
}

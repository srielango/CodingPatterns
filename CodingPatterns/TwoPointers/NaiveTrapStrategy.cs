namespace CodingPatterns.TwoPointers
{
    public class NaiveTrapStrategy : IProblemSolver<int[], int>
    {
        public string Key => AppConstants.TrapRainWater;

        public int Solve(int[] height)
        {
            int result = 0;

            for(int i = 0; i < height.Length; i++)
            {
                int leftMax = 0;
                for(int j = i; j >= 0; j--)
                {
                    leftMax = Math.Max(leftMax, height[j]);
                }

                int rightMax = 0;
                for(int j = i; j < height.Length; j++)
                {
                    rightMax = Math.Max(rightMax, height[j]);
                }

                var waterCapacity = Math.Min(leftMax, rightMax) - height[i];
                result = result + waterCapacity;
            }

            return result;
        }
    }
}

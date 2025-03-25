namespace CodingPatterns.TwoPointers
{
    public class TwoPointersTrapStrategy : IProblemSolver<int[], int>
    {
        public string Key => AppConstants.TrapRainWater;
        
        //TODO: Fix for performance
        public int Solve(int[] height)
        {
            int result = 0;

            for (int i = 0; i < height.Length; i++)
            {
                int leftMax = 0;
                int rightMax = 0;

                int leftIndex = 0;
                int rightIndex = height.Length - 1;

                while(leftIndex <= i || rightIndex >= i)
                {
                    if(leftIndex <= i)
                    {
                        leftMax = Math.Max(leftMax, height[leftIndex++]);
                    }
                    if(rightIndex >= i)
                    {
                        rightMax = Math.Max(rightMax, height[rightIndex--]);
                    }
                }

                var waterCapacity = Math.Min(leftMax, rightMax) - height[i];
                if(waterCapacity < 0)
                {
                    waterCapacity = 0;
                }
                result = result + waterCapacity;
            }

            return result;
        }
    }
}

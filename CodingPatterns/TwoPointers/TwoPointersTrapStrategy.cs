namespace CodingPatterns.TwoPointers
{
    public class TwoPointersTrapStrategy : IProblemSolver<int[], int>
    {
        public string Key => AppConstants.TrapRainWater;
        
        public int Solve(int[] height)
        {
            int result = 0;
            int leftMax = 0;
            int rightMax = 0;

            int leftIndex = 0;
            int rightIndex = height.Length - 1;

            while(leftIndex < rightIndex)
            {
                if (height[leftIndex] < height[rightIndex])
                {
                    if (height[leftIndex] >= leftMax)
                    {
                        leftMax = height[leftIndex];
                    }
                    else
                    {
                        result = result + leftMax - height[leftIndex];
                    }
                    leftIndex++;
                }
                else
                {
                    if (height[rightIndex] >= rightMax)
                    {
                        rightMax = height[rightIndex];
                    }
                    else
                    {
                        result = result + rightMax - height[rightIndex];
                    }
                    rightIndex--;
                }
            }
            return result;
        }
    }
}

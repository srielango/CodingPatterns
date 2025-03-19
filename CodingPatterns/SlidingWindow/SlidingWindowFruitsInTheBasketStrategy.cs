namespace CodingPatterns.SlidingWindow
{
    public class SlidingWindowFruitsInTheBasketStrategy : IProblemSolver<int[], int>
    {
        public string Key => AppConstants.FruitsInTheBasket;
        public int Solve(int[] fruits)
        {
            int lastFruit = -1, secondLastFruit = -1;
            int maxCount = 0;
            int currMax = 0;
            int lastFruitCount = 0;

            foreach (var fruit in fruits)
            {
                if (fruit == lastFruit || fruit == secondLastFruit)
                {
                    currMax++;
                }
                else
                {
                    currMax = lastFruitCount + 1;
                }

                if (fruit == lastFruit)
                {
                    lastFruitCount++;
                }
                else
                {
                    lastFruitCount = 1;
                    secondLastFruit = lastFruit;
                    lastFruit = fruit;
                }
                maxCount = Math.Max(maxCount, currMax);
            }
            return maxCount;
        }
    }
}

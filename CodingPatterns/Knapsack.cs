namespace CodingPatterns
{
    public class Knapsack
    {
        private readonly IKnapsackStrategy _knapsackStrategy;

        public Knapsack(IKnapsackStrategy knapsackStrategy)
        {
            _knapsackStrategy = knapsackStrategy;
        }

        // capacity = 4, profits = {1,2,3}, weights = {4,5,1}
        public int GetMaxProfit(int capacity, int[] profits, int[] weights)
        {
            return _knapsackStrategy.GetMaxProfit(capacity, profits, weights);
        }
    }

    public interface IKnapsackStrategy
    {
        public int GetMaxProfit(int capacity, int[] profits, int[] weights);
    }

    public class NaiveStrategy : IKnapsackStrategy
    {
        public int GetMaxProfit(int capacity, int[] profits, int[] weights)
        {
            int n = profits.Length;
            return GetProfit(capacity, profits, weights, n);
        }

        private int GetProfit(int capacity, int[] profits, int[] weights, int n)
        {
            if (n == 0 || capacity == 0)
            {
                return 0;
            }

            int pick = 0;
            if (weights[n - 1] <= capacity)
            {
                pick = profits[n - 1] + GetProfit(capacity - weights[n - 1], profits, weights, n - 1);
            }

            int notPick = GetProfit(capacity, profits, weights, n - 1);

            return Math.Max(pick, notPick);
        }
    }
}

namespace CodingPatterns.SlidingWindow
{
    public class SlidingWindow
    {
        private readonly IStrategyFactory _strategyFactory;

        public SlidingWindow(IStrategyFactory strategyFactory)
        {
            _strategyFactory = strategyFactory;
        }

        //Given an array of integers of size ‘n’, Our aim is to calculate the maximum sum of ‘k’ consecutive elements in the array.
        public int MaxSum(int[] arr, int n, int k)
        {
            var strategy = _strategyFactory.GetStrategy<(int[] arr, int k), int>(AppConstants.MaxSum);
            return strategy.Solve((arr, k));
        }

        //Given a text and a word, return the count of occurrences of the anagrams of the word in the given text
        public int AnagramCount(string text, string word)
        {
            var strategy = _strategyFactory.GetStrategy<(string text, string word), int>(AppConstants.AnagramCount);
            return strategy.Solve((text, word));
        }

        //Maximum Fruits into 2 Baskets.  Each basket can have only one type of fruit
        public int FruitsIntoBaskets(int[] fruits)
        {
            var strategy = _strategyFactory.GetStrategy<int[], int>(AppConstants.FruitsInTheBasket);
            return strategy.Solve(fruits);
        }
    }
}

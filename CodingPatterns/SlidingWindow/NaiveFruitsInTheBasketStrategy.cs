namespace CodingPatterns.SlidingWindow
{
    public class NaiveFruitsInTheBasketStrategy : IProblemSolver<int[], int>
    {
        public string Key => AppConstants.FruitsInTheBasket;

        public int Solve(int[] fruits)
        {
            int maxFruits = 0;

            for (int i = 0; i < fruits.Length; i++)
            {
                HashSet<int> fruitTypes = new HashSet<int>();

                var count = 0;

                for (int j = i; j < fruits.Length; j++)
                {
                    fruitTypes.Add(fruits[j]);
                    if (fruitTypes.Count > 2)
                    {
                        break;
                    }
                    count++;
                }
                maxFruits = Math.Max(maxFruits, count);
            }

            return maxFruits;
        }
    }
}

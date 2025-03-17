using System.Net;

namespace CodingPatterns.SlidingWindow
{
    public class SlidingWindow
    {
        private readonly ISlidingStrategy _slidingStrategy;

        public SlidingWindow(ISlidingStrategy slidingStrategy)
        {
            _slidingStrategy = slidingStrategy;
        }

        //Given an array of integers of size ‘n’, Our aim is to calculate the maximum sum of ‘k’ consecutive elements in the array.
        public int MaxSum(int[] arr, int n, int k)
        {
            return _slidingStrategy.GetMaxSum(arr, k);
        }

        //Given a text and a word, return the count of occurrences of the anagrams of the word in the given text
        public int AnagramCount(string text, string word)
        {
            return _slidingStrategy.AnagramCount(text, word);
        }



        //Maximum Fruits into 2 Baskets.  Each basket can have only one type of fruit
        public int FruitsIntoBaskets(int[] fruits)
        {
            //int length = fruits.Length;
            //Dictionary<int, int> fruitType = new Dictionary<int, int>(length);
            //int result = 0;
            //int startWindow = 0;
            //for (int i = 0; i < length; i++)
            //{
            //    if (!fruitType.TryAdd(fruits[i], 1))
            //    {
            //        fruitType[fruits[i]] += 1;
            //    }
            //    while (fruitType.Count > 2)
            //    {
            //        fruitType[fruits[startWindow]] -= 1;
            //        if (fruitType[fruits[startWindow]] == 0)
            //        {
            //            fruitType.Remove(fruits[startWindow]);
            //        }
            //        startWindow++;
            //    }
            //    result = Math.Max(result, i - startWindow + 1);
            //}
            //return result;

            return _slidingStrategy.FruitsIntoBaskets(fruits);
        }
    }
}

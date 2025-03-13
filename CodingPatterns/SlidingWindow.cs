namespace CodingPatterns
{
    public class SlidingWindow
    {
        //Given an array of integers of size ‘n’, Our aim is to calculate the maximum sum of ‘k’ consecutive elements in the array.
        public int MaxSum(int[] arr, int n, int k)
        {
            // n must be greater
            if (n < k)
            {
                Console.WriteLine("Invalid");
                return -1;
            }

            // Compute sum of first window of size k
            int max_sum = 0;
            for (int i = 0; i < k; i++)
                max_sum += arr[i];

            // Compute sums of remaining windows by
            // removing first element of previous
            // window and adding last element of
            // current window.
            int window_sum = max_sum;
            for (int i = k; i < n; i++)
            {
                window_sum += arr[i] - arr[i - k];
                max_sum = Math.Max(max_sum, window_sum);
            }

            return max_sum;
        }

        //Given a text and a word, return the count of occurrences of the anagrams of the word in the given text
        public int AnagramCount(string text, string word)
        {
            int count = 0;
            if (text.Length < word.Length) return -1;

            var sortedWord = string.Concat(word.OrderBy(x => x));
            for(int i = 0; i <= text.Length - word.Length; i++)
            {
                if(IsAnagram(sortedWord, text.Substring(i, word.Length)))
                {
                    count++;
                }
            }
            return count;
        }

        private bool IsAnagram(string word, string otherString)
        {
            return word.Equals(string.Concat(otherString.OrderBy(x => x)));
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

            var count1 = 0;
            var count2 = 0;

            var maxCount = 0;

            if (fruits.Count() <= 1)
            {
                return fruits.Count();
            }

            int fruitType1 = 0;
            int fruitType2 = 0;

            for (int i = 0; i < fruits.Count() - 1; i++)
            {
                fruitType1 = fruits[i];
                fruitType2 = fruits[i + 1];

                if (fruitType1 != fruitType2) break;
            }

            for (var i = 0; i < fruits.Count(); i++)
            {
                if (fruits[i] == fruitType1)
                {
                    count1++;
                }
                else if (fruits[i] == fruitType2)
                {
                    count2++;
                }
                else
                {
                    fruitType1 = fruitType2;
                    fruitType2 = fruits[i];
                    count1 = count2;
                    count2 = 1;
                }
                maxCount = Math.Max(maxCount, count1 + count2);
            }
            return maxCount;
        }
    }
}

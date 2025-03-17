using System.ComponentModel.DataAnnotations;

namespace CodingPatterns.SlidingWindow
{
    public class SlidingWindowStrategy : ISlidingStrategy
    {
        //Uses a sliding window of size k. As the window moves,
        //a new value from the array is added while the first value in the array
        //is deleted
        public int GetMaxSum(int[] arr, int k)
        {
            var arrayLength = arr.Length;
            if (arrayLength < k)
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
            for (int i = k; i < arrayLength; i++)
            {
                window_sum += arr[i] - arr[i - k];
                max_sum = Math.Max(max_sum, window_sum);
            }

            return max_sum;
        }

        public int AnagramCount(string text, string word)
        {
            Dictionary<char, int> wordFrequency = GetFrequencyMap(word);
            Dictionary<char, int> windowFrequency = new Dictionary<char, int>();
            int count = 0, wordLength = word.Length;

            for(int i = 0; i < text.Length; i++)
            {
                char newChar = text[i];

                if (!windowFrequency.ContainsKey(newChar))
                {
                    windowFrequency[newChar] = 0;
                }
                windowFrequency[newChar]++;

                if(i >= wordLength)
                {
                    char oldChar = text[i - wordLength];
                    if (windowFrequency[oldChar] == 1)
                        windowFrequency.Remove(oldChar);
                    else
                        windowFrequency[oldChar]--;
                }

                if(i >= wordLength - 1 && AreDictionariesEqual(wordFrequency, windowFrequency))
                {
                    count++;
                }
            }
            return count;
        }

        private bool AreDictionariesEqual(Dictionary<char, int> wordFrequency, Dictionary<char, int> windowFrequency)
        {
            return wordFrequency.Count == windowFrequency.Count && !wordFrequency.Except(windowFrequency).Any();
        }

        private Dictionary<char, int> GetFrequencyMap(string word)
        {
            Dictionary<char, int> frequency = new Dictionary<char, int>();
            foreach (var c in word)
            {
                if (!frequency.ContainsKey(c))
                {
                    frequency[c] = 0;
                }
                frequency[c]++;
            }
            return frequency;
        }

        public int FruitsIntoBaskets(int[] fruits)
        {
            int lastFruit = -1, secondLastFruit = -1;
            int maxCount = 0;
            int currMax = 0;
            int lastFruitCount = 0;

            foreach(var fruit in fruits)
            {
                if(fruit == lastFruit || fruit == secondLastFruit)
                {
                    currMax++;
                }
                else
                {
                    currMax = lastFruitCount + 1;
                }

                if(fruit == lastFruit)
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

            //var count1 = 0;
            //var count2 = 0;

            //var maxCount = 0;

            //if (fruits.Count() <= 1)
            //{
            //    return fruits.Count();
            //}

            //int fruitType1 = 0;
            //int fruitType2 = 0;

            //for (int i = 0; i < fruits.Count() - 1; i++)
            //{
            //    fruitType1 = fruits[i];
            //    fruitType2 = fruits[i + 1];

            //    if (fruitType1 != fruitType2) break;
            //}

            //for (var i = 0; i < fruits.Count(); i++)
            //{
            //    if (fruits[i] == fruitType1)
            //    {
            //        count1++;
            //    }
            //    else if (fruits[i] == fruitType2)
            //    {
            //        count2++;
            //    }
            //    else
            //    {
            //        fruitType1 = fruitType2;
            //        fruitType2 = fruits[i];
            //        count1 = count2;
            //        count2 = 1;
            //    }
            //    maxCount = Math.Max(maxCount, count1 + count2);
            //}
            //return maxCount;
        }
    }
}

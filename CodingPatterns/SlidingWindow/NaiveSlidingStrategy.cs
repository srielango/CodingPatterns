namespace CodingPatterns.SlidingWindow
{
    public class NaiveSlidingStrategy : ISlidingStrategy
    {
        //The brute-force naive approach creates a sub array for each loop to calculate the sum
        //Time complexity: O(N^2)
        public int GetMaxSum(int[] arr, int k)
        {
            var arrayLength = arr.Length;
            if(arrayLength < k)
            {
                Console.WriteLine("Invalid");
                return -1;
            }

            int maxSum = 0;

            for(var i = 0; i <= arrayLength - k; i++)
            {
                var sum = 0;
                for (var j = i; j < i + k; j++)
                {
                    sum += arr[j];
                }
                maxSum = Math.Max(maxSum, sum);
            }
            return maxSum;
        }

        public int AnagramCount(string text, string word)
        {
            int count = 0;
            if (text.Length < word.Length) return -1;

            var sortedWord = string.Concat(word.OrderBy(x => x));
            for (int i = 0; i <= text.Length - word.Length; i++)
            {
                if (IsAnagram(sortedWord, text.Substring(i, word.Length)))
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

        public int FruitsIntoBaskets(int[] fruits)
        {
            int maxFruits = 0;

            for(int i = 0; i < fruits.Length; i++)
            {
                HashSet<int> fruitTypes = new HashSet<int>();
                
                var count = 0;

                for(int j = i; j < fruits.Length; j++)
                {
                    fruitTypes.Add(fruits[j]);
                    if(fruitTypes.Count > 2)
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

namespace CodingPatterns.SlidingWindow
{
    public class SlidingWindowAnagramCountStrategy : IProblemSolver<(string text, string word), int>
    {
        public string Key => AppConstants.AnagramCount;

        public int Solve((string text, string word) input)
        {
            var text = input.text;
            var word = input.word;

            Dictionary<char, int> wordFrequency = GetFrequencyMap(word);
            Dictionary<char, int> windowFrequency = new Dictionary<char, int>();
            int count = 0, wordLength = word.Length;

            for (int i = 0; i < text.Length; i++)
            {
                char newChar = text[i];

                if (!windowFrequency.ContainsKey(newChar))
                {
                    windowFrequency[newChar] = 0;
                }
                windowFrequency[newChar]++;

                if (i >= wordLength)
                {
                    char oldChar = text[i - wordLength];
                    if (windowFrequency[oldChar] == 1)
                        windowFrequency.Remove(oldChar);
                    else
                        windowFrequency[oldChar]--;
                }

                if (i >= wordLength - 1 && AreDictionariesEqual(wordFrequency, windowFrequency))
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
    }
}

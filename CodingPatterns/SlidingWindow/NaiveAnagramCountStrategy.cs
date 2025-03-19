using static System.Net.Mime.MediaTypeNames;

namespace CodingPatterns.SlidingWindow
{
    public class NaiveAnagramCountStrategy : IProblemSolver<(string text, string word), int>
    {
        public string Key => AppConstants.AnagramCount;

        public int Solve((string text, string word) input)
        {
            var text = input.text;
            var word = input.word;

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
    }
}

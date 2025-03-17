namespace CodingPatterns.SlidingWindow
{
    public interface ISlidingStrategy
    {
        //Given an array of integers of size ‘n’, Our aim is to calculate the maximum sum of ‘k’ consecutive elements in the array.
        public int GetMaxSum(int[] arr, int k);

        //Given a text and a word, return the count of occurrences of the anagrams of the word in the given text
        //Anagram - A word, phrase or name formed by rearranging the letters of another. Ex: ant - nat, tan
        public int AnagramCount(string text, string word);

        //Maximum fruits into 2 Baskets. Each basket can have only one type of fruit
        public int FruitsIntoBaskets(int[] fruits);
    }
}

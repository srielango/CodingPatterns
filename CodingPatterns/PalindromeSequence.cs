namespace CodingPatterns
{
    public class PalindromeSequence
    {
        private IPalindromeStrategy _palindromeStrategy;

        public PalindromeSequence(IPalindromeStrategy palindromeStrategy)
        {
            _palindromeStrategy = palindromeStrategy;
        }
        public int GetLongestPalindromeLength(string text)
        {
            return _palindromeStrategy.LongestPalindromeSequence(text);
        }
    }

    public interface IPalindromeStrategy
    {
        int LongestPalindromeSequence(string text);
    }

    public class RecursivePalindromeStrategy : IPalindromeStrategy
    {
        public int LongestPalindromeSequence(string text)
        {
            return lps(text, 0, text.Length - 1);
        }

        public int lps(string text, int start, int end)
        {
            if(start == end)
            {
                return 1;
            }

            if (text[start] == text[end])
            {
                if (start + 1 == end)
                {
                    return 2;
                }

                return lps(text, start + 1, end - 1) + 2;
            }

            return Math.Max(lps(text, start, end - 1), lps(text, start + 1, end));
        }
    }

    //public class DynamicProgrammingStrategy : IPalindromeStrategy
    //{
    //    public int LongestPalindromeSequence(string text)
    //    {
    //        return lps(text);
    //    }

    //    public int lps(string text)
    //    {
    //        var length = 0;
    //        if(text.Length == 1)
    //            return 1;

    //        if (text[0] == text[1])
    //        {

    //        }

    //        var start = 0;
    //        var end = text.Length - 1;

    //        while (start < end) 
    //        {
    //            if (text[start] == text[end])
    //            {
    //                length += 2;
    //                if(start + 1 == end)
    //                {
    //                    break;
    //                }
    //                start++;
    //                end++;
    //            }
    //            else
    //            {

    //            }
    //        }

    //        return length;
    //    }
}

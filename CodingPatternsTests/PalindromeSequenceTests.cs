using CodingPatterns;
using FluentAssertions;

namespace CodingPatternsTests
{
    [TestClass]
    public class PalindromeSequenceTests
    {
        private readonly PalindromeSequence _sut;

        public PalindromeSequenceTests()
        {
            _sut = new PalindromeSequence(new RecursivePalindromeStrategy());
        }

        [TestMethod]
        [DataRow("A", 1)]
        [DataRow("X", 1)]
        [DataRow("K", 1)]

        public void single_char_string_returns_one(string text, int expected)
        {
            var result = _sut.GetLongestPalindromeLength(text);

            result.Should().Be(expected);
        }

        [TestMethod]
        [DataRow("AA", 2)]
        [DataRow("XX", 2)]
        [DataRow("KK", 2)]

        public void two_char_palindromes_returns_two(string text, int expected)
        {
            var result = _sut.GetLongestPalindromeLength(text);

            result.Should().Be(expected);
        }

        [TestMethod]
        [DataRow("GEEKSFORGEEKS", 5)]
        [DataRow("AAA", 3)]
        [DataRow("ABA", 3)]
        [DataRow("AAB", 2)]
        public void string_returns_count(string text, int expected)
        {
            var result = _sut.GetLongestPalindromeLength(text);

            result.Should().Be(expected);
        }
    }
}

using CodingPatterns;
using FluentAssertions;
using static System.Net.Mime.MediaTypeNames;

namespace CodingPatternsTests
{
    [TestClass]
    public class SlidingWindowTests
    {
        public readonly SlidingWindow _sut;
        public SlidingWindowTests()
        {
            _sut = new SlidingWindow();
        }

        [TestMethod]
        [DataRow(new int[] { 1, 4, 2, 10, 2, 3, 1, 0, 20 }, 4, 24)]
        [DataRow(new int[] { 5, 2, -1, 0, 3 }, 3, 6)]
        public void Array_ReturnsMaxSum(int[] arr, int k, int expected)
        {
            var result = _sut.MaxSum(arr, arr.Length, k);
            result.Should().Be(expected);
        }

        [TestMethod]
        [DataRow("gotxxotgxdogt", "got", 3)]
        public void text_returns_count_of_anagram_word(string text, string word, int expected)
        {
            var result = _sut.AnagramCount(text, word);
            result.Should().Be(expected);
        }

        //[TestMethod]
        //[DataRow(new int[] { 1, 0, 1, 4, 1, 4, 1, 2, 3 }, 5)]
        ////[DataRow(new int[] { 3, 3, 3, 1, 2, 1, 1, 2, 3, 3, 4 }, 5)]
        ////[DataRow(new int[] { 0, 1, 6, 6, 4, 4, 6 }, 5)]
        ////[DataRow(new int[] { 1, 1 }, 2)]
        ////[DataRow(new int[] { 1, 0 }, 2)]
        ////[DataRow(new int[] { 1, 2, 1 }, 3)]
        ////[DataRow(new int[] { 0, 1, 2, 2 }, 3)]
        ////[DataRow(new int[] { 1, 2, 3, 2, 2 }, 4)]
        ////[DataRow(new int[] { 0, 0, 1, 1 }, 4)]
        //public void int_array_returns_count_of_two_distinct_numbers(int[] arr, int expected)
        //{
        //    var result = _sut.FruitsIntoBaskets(arr);
        //    result.Should().Be(expected);
        //}
    }
}

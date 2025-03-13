using CodingPatterns;
using FluentAssertions;

namespace CodingPatternsTests
{
    [TestClass]
    public class ModifiedBinarySearchTests
    {
        private readonly ModifiedBinarySearch _sut = new ModifiedBinarySearch();

        [TestMethod]
        [DataRow(new int[] {3, 4, 5, 1, 2}, 1)]
        [DataRow(new int[] { 0, 4, 5, 1, 2 }, 0)]
        [DataRow(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 0)]
        public void int_array_returns_min_value(int[] arr, int expected)
        {
            var result = _sut.FindMinElement(arr);
            result.Should().Be(expected);
        }

        [TestMethod]
        [DataRow(new int[] { 3, 4, 5, 1, 2 }, 1, true)]
        [DataRow(new int[] { 0, 4, 5, 1, 2 }, 0, true)]
        [DataRow(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 9, false)]
        public void int_array_returns_searched_value(int[] arr, int elementToFind, bool expected)
        {
            var result = _sut.FindElement(arr, elementToFind);
            result.Should().Be(expected);
        }
    }
}

using CodingPatterns;
using FluentAssertions;

namespace CodingPatternsTests
{
    [TestClass]
    public class CycleSortTests
    {
        public readonly CycleSort _sut;
        public CycleSortTests()
        {
            _sut = new CycleSort();
        }

        [TestMethod]
        [DataRow(new int[] { 3, 2, 4, 5, 1 }, new int[] { 1, 2, 3, 4, 5 })]
        public void Array_returns_sorted_array(int[] arr, int[] expected)
        {
            var result = _sut.Sort(arr, arr.Length);
            result.Should().BeEquivalentTo(expected);
        }
    }
}

using CodingPatterns;
using FluentAssertions;

namespace CodingPatternsTests
{
    [TestClass]
    public class TwoPointersTechniqueTests
    {
        public readonly TwoPointersTechnique _sut;
        public TwoPointersTechniqueTests()
        {
            _sut = new TwoPointersTechnique();
        }

        [TestMethod]
        [DataRow(new int[] { 2, 3, 5, 8, 9, 10, 11 }, 17, 1)]
        public void Array_Returns_1_If_Match_Found(int[] arr, int k, int expected)
        {
            var result = _sut.IsPairSum(arr, arr.Length, k);
            result.Should().Be(expected);
        }
    }
}

using CodingPatterns;
using FluentAssertions;

namespace CodingPatternsTests
{
    [TestClass]
    public class TopKElementsTests
    {
        public readonly TopKElements _sut;
        public TopKElementsTests()
        {
            //_sut = new TopKElements(new HashMapTopKElementsStrategy());
            _sut = new TopKElements(new MinHeapTopKElementsStrategy());
        }

        [TestMethod]
        [DataRow(new int[] { 1, 1, 1, 2, 2, 3 }, 2, new int[] {1,2})]
        [DataRow(new int[] {1}, 1, new int[] { 1 })]
        public void intArrayReturnsExpectedElements(int[] nums, int k, int[] exptected)
        {
            var result = _sut.GetTopKElements(nums, k);
            result.Should().BeEquivalentTo(exptected);
        }
    }
}

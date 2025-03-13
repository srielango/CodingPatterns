using CodingPatterns;
using FluentAssertions;

namespace CodingPatternsTests
{
    [TestClass]
    public class KWayMergeTests
    {
        private readonly KWayMerge _sut;

        public KWayMergeTests()
        {
            _sut = new KWayMerge();
        }

        [TestMethod]
        [DataRow(new int[] {1,2,3,0,0,0}, 3, new int[] { 2, 5, 6 }, 3, new int[] { 1, 2, 2, 3, 5, 6 })]
        public void intArraysMergedToFirstArray(int[] num1, int m, int[] num2, int n, int[] expected)
        {
            _sut.Merge(num1, m, num2, n);
            num1.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public void intArraysMergedAndSorted()
        {
            var source = new int[2,3]
            {
                { 1, 2, 3 },
                { 2, 4, 5 }
            };

            var expected = new int[] {1, 2, 2, 3, 4 ,5 };
            var result = _sut.Merge(source);
            result.Should().BeEquivalentTo(expected);
        }
    }
}

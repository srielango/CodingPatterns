using CodingPatterns;
using FluentAssertions;

namespace CodingPatternsTests
{
    [TestClass]
    public class MergeIntervalTests
    {
        private readonly MergeIntervals _sut;

        public MergeIntervalTests()
        {
            //_sut = new MergeIntervals(new SimpleStrategy());
            _sut = new MergeIntervals(new ExpectedStrategy());
        }

        [TestMethod]
        public void array_returns_merged_intervals()
        {
            int[][] input = new int[][]
            {
                new int[] { 1, 3 },
                new int[] { 2, 4 },
                new int[] { 6, 8 },
                new int[] { 9, 10 }
            };

            int[][] expected = new int[][] 
            {
                new int[] { 1, 4 },
                new int[] { 6, 8 },
                new int[] { 9, 10 }
            };

            var result = _sut.MergeOverlap(input);

            result.Should().BeEquivalentTo(expected, options => options.WithStrictOrdering());
        }
    }
}

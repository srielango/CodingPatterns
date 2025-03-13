using CodingPatterns;
using FluentAssertions;

namespace CodingPatternsTests
{
    [TestClass]
    public class KnapsackTests
    {
        private readonly Knapsack _sut;

        public KnapsackTests()
        {
            _sut = new Knapsack(new NaiveStrategy());
        }

        [TestMethod]
        [DataRow(4, new int[] { 1, 2, 3 }, new int[] { 4, 5, 1 }, 3)]
        [DataRow(3, new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 }, 0)]
        public void MaxProfit_ShouldReturnExpectedProfit(int capacity, int[] profits, int[] weights, int expected)
        {
            var result = _sut.GetMaxProfit(capacity, profits, weights);
            result.Should().Be(expected);
        }
    }
}

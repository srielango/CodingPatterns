using CodingPatterns;
using FluentAssertions;

namespace CodingPatternsTests
{
    [TestClass]
    public class SubsetTests
    {
        private readonly Subset _sut = new Subset();

        [TestMethod]
        public void Set_returns_all_subsets()
        {
            List<List<int>> subset = new List<List<int>>();

            // Input List
            List<int> input = new() {1, 2, 3};

            _sut.FindSubsets(subset, input, new List<int>(), 0);

            subset.Should().HaveCount(8);
        }
    }
}

using CodingPatterns;
using CodingPatterns.Models;
using FluentAssertions;

namespace CodingPatternsTests
{
    [TestClass]
    public class MatrixTraversalTests
    {
        public readonly MatrixTraversal _sut;
        public MatrixTraversalTests()
        {
            _sut = new MatrixTraversal();
        }

        [TestMethod]
        public void matrix_returns_island_count()
        {
            int[,] M = new int[,] { { 1, 1, 0, 0, 0 },
                                  { 0, 1, 0, 0, 1 },
                                  { 1, 0, 0, 1, 1 },
                                  { 0, 0, 0, 0, 0 },
                                  { 1, 0, 1, 0, 1 } };

            var result = _sut.countIslands(M);
            result.Should().Be(5);
        }
    }
}

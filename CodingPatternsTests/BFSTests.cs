using CodingPatterns;
using CodingPatterns.Models;
using FluentAssertions;

namespace CodingPatternsTests
{

    [TestClass]
    public class BFSTests
    {
        private BFS _bfs;

        [TestInitialize]
        public void SetUp()
        {
            _bfs = new BFS();
        }

        [TestMethod]
        public void GetLevelOrder_WhenTreeIsEmpty_ReturnsEmptyList()
        {
            // Arrange
            _bfs.root = null;

            // Act
            var result = _bfs.GetLevelOrder();

            // Assert
            result.Should().BeEmpty();
        }

        [TestMethod]
        public void GetLevelOrder_WhenTreeHasOneNode_ReturnsRootData()
        {
            // Arrange
            _bfs.root = new BinaryTreeNode(1);

            // Act
            var result = _bfs.GetLevelOrder();

            // Assert
            result.Should().ContainSingle().Which.Should().Be(1);
        }

        [TestMethod]
        public void GetLevelOrder_WhenTreeHasMultipleLevels_ReturnsCorrectOrder()
        {
            // Arrange
            _bfs.root = new BinaryTreeNode(1);
            _bfs.root.left = new BinaryTreeNode(2);
            _bfs.root.right = new BinaryTreeNode(3);
            _bfs.root.left.left = new BinaryTreeNode(4);
            _bfs.root.left.right = new BinaryTreeNode(5);
            _bfs.root.right.left = new BinaryTreeNode(6);
            _bfs.root.right.right = new BinaryTreeNode(7);

            // Act
            var result = _bfs.GetLevelOrder();

            // Assert
            var expected = new List<int> { 1, 2, 3, 4, 5, 6, 7 };
            result.Should().Equal(expected);
        }

        [TestMethod]
        public void GetLevelOrderByQueue_WhenTreeIsEmpty_ReturnsEmptyList()
        {
            // Arrange
            _bfs.root = null;

            // Act
            var result = _bfs.GetLevelOrder();

            // Assert
            result.Should().BeEmpty();
        }

        [TestMethod]
        public void GetLevelOrderByQueue_WhenTreeHasOneNode_ReturnsRootData()
        {
            // Arrange
            _bfs.root = new BinaryTreeNode(1);

            // Act
            var result = _bfs.GetLevelOrder();

            // Assert
            result.Should().ContainSingle().Which.Should().Be(1);
        }

        [TestMethod]
        public void GetLevelOrderByQueue_WhenTreeHasMultipleLevels_ReturnsCorrectOrder()
        {
            // Arrange
            _bfs.root = new BinaryTreeNode(1);
            _bfs.root.left = new BinaryTreeNode(2);
            _bfs.root.right = new BinaryTreeNode(3);
            _bfs.root.left.left = new BinaryTreeNode(4);
            _bfs.root.left.right = new BinaryTreeNode(5);
            _bfs.root.right.left = new BinaryTreeNode(6);
            _bfs.root.right.right = new BinaryTreeNode(7);

            // Act
            var result = _bfs.GetLevelOrder();

            // Assert
            var expected = new List<int> { 1, 2, 3, 4, 5, 6, 7 };
            result.Should().Equal(expected);
        }
    }
}

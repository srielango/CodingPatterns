using CodingPatterns;
using CodingPatterns.Models;
using FluentAssertions;

namespace CodingPatternsTests
{
    [TestClass]
    public class DFSTests
    {
        public readonly DFS _sut;
        public DFSTests()
        {
            _sut = new DFS();
        }

        [TestMethod]
        public void Binary_tree_returns_data_in_dfs_order()
        {
            _sut.root = new BinaryTreeNode(1);
            _sut.root.left = new BinaryTreeNode(2);
            _sut.root.right = new BinaryTreeNode(3);
            _sut.root.left.left = new BinaryTreeNode(4);
            _sut.root.left.right = new BinaryTreeNode(5);
            _sut.root.right.left = new BinaryTreeNode(6);
            _sut.root.right.right = new BinaryTreeNode(7);
            _sut.root.left.left.left = new BinaryTreeNode(8);
            _sut.root.left.left.right = new BinaryTreeNode(9);

            var preOrderResult = _sut.PreOrder();
            preOrderResult.Should().BeEquivalentTo(new List<int>() { 1, 2, 4, 8, 9, 5, 3, 6, 7 });

            var inOrderResult = _sut.InOrder();
            inOrderResult.Should().BeEquivalentTo(new List<int>() { 8, 4, 9, 2, 5, 1, 6, 3, 7 });

            var postOrderResult = _sut.PostOrder();
            postOrderResult.Should().BeEquivalentTo(new List<int>() { 8, 9, 4, 5, 2, 6, 7, 3, 1 });
        }
    }
}

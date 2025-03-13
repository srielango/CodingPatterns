using CodingPatterns;
using CodingPatterns.Models;
using FluentAssertions;

namespace CodingPatternsTests
{

    [TestClass]
    public class ReverseListTests
    {
        public readonly ReverseList _sut;
        public ReverseListTests()
        {
            _sut = new ReverseList();
        }

        [TestMethod]
        [DataRow(new int[] { 5, 4, 3, 2}, new int[] { 2, 3, 4, 5})]
        public void nodeList_returns_reversed_list(int[] source, int[] expected)
        {
            var list = new ReverseList();
            foreach(var item in source)
            {
                var node = new Node(item);
                list.AddNode(node);
            }

            list.Reverse();

            var reverseList = list.GetList();

            reverseList.Should().BeEquivalentTo(expected);

        }
    }
}

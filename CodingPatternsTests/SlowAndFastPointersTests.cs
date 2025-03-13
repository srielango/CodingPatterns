using CodingPatterns;
using FluentAssertions;

namespace CodingPatternsTests
{
    [TestClass]
    public class SlowAndFastPointersTests
    {
        public readonly SlowAndFastPointers _sut;
        public SlowAndFastPointersTests()
        {
            _sut = new SlowAndFastPointers();
        }

        [TestMethod]
        public void List_With_Loop_returns_True()
        {
            _sut.push(20);
            _sut.push(4);
            _sut.push(15);
            _sut.push(10);
            /*Create loop for testing */
            _sut.head.next.next.next.next = _sut.head;

            var result = _sut.DetectLoop();
            result.Should().BeTrue();
        }
    }

}

using CodingPatterns;
using FluentAssertions;

namespace CodingPatternsTests
{
    [TestClass]
    public class TwoHeapsTests
    {
        private readonly TwoHeaps _sut;

        public TwoHeapsTests()
        {
            //_sut = new TwoHeaps(new NaiveMedianStrategy());
            _sut = new TwoHeaps(new TwoHeapStrategy());
        }

        [TestMethod]
        public void OddCount_ShouldReturnMiddleValue()
        {
            _sut.AddNum(1);
            _sut.AddNum(2);
            _sut.AddNum(3);

            var result = _sut.FindMedian();
            result.Should().Be(2);

            _sut.AddNum(4);
            _sut.AddNum(5);
            result = _sut.FindMedian();
            result.Should().Be(3);
        }

        [TestMethod]
        public void EvenCount_ShouldReturnAverageOfMiddleValues()
        {
            _sut.AddNum(1);
            _sut.AddNum(2);

            var result = _sut.FindMedian();
            result.Should().Be(1.5);

            _sut.AddNum(4);
            _sut.AddNum(5);
            result = _sut.FindMedian();
            result.Should().Be(3);
        }
    }
}

using CodingPatterns;
using FluentAssertions;

namespace CodingPatternsTests
{
    [TestClass]
    public class MergeOverlappingIntervalsTests
    {
        public readonly MergeOverlappingIntervals _sut;
        public MergeOverlappingIntervalsTests()
        {
            _sut = new MergeOverlappingIntervals();
        }

        [TestMethod]
        public void Array_ReturnsMergedIntervals()
        {
            Interval[] arr = new Interval[4];
            arr[0] = new Interval(6, 8);
            arr[1] = new Interval(1, 9);
            arr[2] = new Interval(2, 4);
            arr[3] = new Interval(4, 7);
            var result = _sut.mergeIntervals(arr);
            result.Count().Should().Be(1);

            arr = new Interval[4];
            arr[0] = new Interval(1, 3);
            arr[1] = new Interval(2, 4);
            arr[2] = new Interval(6, 8);
            arr[3] = new Interval(9, 10);

            result = _sut.mergeIntervals(arr);
            result.Count().Should().Be(3);
        }
    }
}

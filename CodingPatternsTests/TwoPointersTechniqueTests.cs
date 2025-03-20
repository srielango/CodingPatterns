using CodingPatterns;
using CodingPatterns.TwoPointers;
using FluentAssertions;

namespace CodingPatternsTests
{
    [TestClass]
    public class TwoPointersTechniqueTests : BaseTest
    {
        public readonly TwoPointers _sut;
        public TwoPointersTechniqueTests()
        {
            var factory = new StrategyFactory(new IProblemSolverBase[]
            {
                new TwoPointersIsPairSumStrategy(),
                new TwoPointersThreeSumStrategy()
            });

            _sut = new TwoPointers(factory);
        }

        [TestMethod]
        [DataRow(new int[] { 2, 3, 5, 8, 9, 10, 11 }, 17, 1)]
        public void Array_Returns_1_If_Match_Found(int[] arr, int k, int expected)
        {
            var result = _sut.IsPairSum(arr, k);
            result.Should().Be(expected);
        }

        [TestMethod]
        //[DataRow(new int[] { -1, 1, 0, 2, -2 }, "[[-1,1,0],[0,2,-2]]")]
        //[DataRow(new int[] { -1, 0, 1, 2, -1, -4 }, "[[-1,-1,2],[-1,0,1]]")]
        //[DataRow(new int[] { 0,1,1 }, "[]")] // No matching triplets
        //[DataRow(new int[] { 0, 0, 0 }, "[[0,0,0]]")]
        //[DataRow(new int[] {0,0,0,0}, "[[0,0,0]]")]
        [DataRow(new int[] { 1,-1,-1,0 }, "[[-1,0,1]]")]
        public void Array_Returns_ListOfPairs_If_Match_Found(int[] arr, string expected)
        {
            var result = _sut.ThreeSum(arr);
            var resultString = ConvertResultToString(result);
            resultString.Should().BeEquivalentTo(expected);
        }

        private string ConvertResultToString(IList<IList<int>> result)
        {
            return "[" + string.Join(",", result.Select(inner => "[" + string.Join(",", inner) + "]")) + "]";
        }

        [TestMethod]
        public void Compare_Performance()
        {
            var naiveSolver = new NaiveIsPairSumStrategy();
            var twoPointersSolver = new TwoPointersIsPairSumStrategy();

            var array = Enumerable.Range(1, 10000).ToArray();
            var target = 100000;

            var naiveTime = Time(() => naiveSolver.Solve((array, target)));
            var twoPointersTime = Time(() => twoPointersSolver.Solve((array, target)));

            naiveTime.Should().BeGreaterThanOrEqualTo(twoPointersTime);
        }


    }
}

using CodingPatterns.TopKElements;
using CodingPatterns.TwoPointers;
using FluentAssertions;

namespace CodingPatternsTests
{
    [TestClass]
    public class TopKElementsTests : BaseTest
    {
        public readonly TopKElements _sut;
        public TopKElementsTests()
        {
            //_sut = new TopKElements(new HashMapTopKElementsStrategy());
            _sut = new TopKElements(new MinHeapTopKElementsStrategy());
        }

        [TestMethod]
        [DataRow(new int[] { 1, 1, 1, 2, 2, 3 }, 2, new int[] {1,2})]
        [DataRow(new int[] { 4, 1, 1, 2, 3, 3, 3 }, 2, new int[] { 1, 3 })]
        [DataRow(new int[] {1}, 1, new int[] { 1 })]
        public void intArrayReturnsExpectedElements(int[] nums, int k, int[] exptected)
        {
            var result = _sut.GetTopKElements(nums, k);
            result.Should().BeEquivalentTo(exptected);
        }

        [TestMethod]
        public void Compare_Performance()
        {
            var hashSolver = new HashMapTopKElementsStrategy();
            var minHeapSolver = new MinHeapTopKElementsStrategy();
            var maxHeapSolver = new MaxHeapTopKElementStrategy();

            var array = Enumerable.Range(1, 10000).ToArray();
            for(int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 0) array[i] = 1;
                if (array[i] % 3 == 0) array[i] = 2;
            }

            var hashSolverTime = Time(() => hashSolver.TopKFrequent(array, 2));
            var minHeapSolverTime = Time(() => minHeapSolver.TopKFrequent(array, 2));

            hashSolverTime.Should().BeGreaterThanOrEqualTo(minHeapSolverTime);

            var maxHeapSolverTime = Time(() => minHeapSolver.TopKFrequent(array, 2));
            hashSolverTime.Should().BeGreaterThanOrEqualTo(maxHeapSolverTime);

            minHeapSolverTime.Should().BeGreaterThanOrEqualTo(maxHeapSolverTime);
        }
    }
}

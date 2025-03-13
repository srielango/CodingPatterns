using CodingPatterns;
using FluentAssertions;

namespace CodingPatternsTests
{
    [TestClass]
    public class MergeKSortedArraysTests
    {
        MergeKSortedArrays _sut = new MergeKSortedArrays();

        [TestMethod]
        public void array_of_arrays_return_sorted_array()
        {
            int[,] arr = { { 2, 6, 12, 34 },
                        { 1, 9, 20, 1000 },
                        { 23, 34, 90, 2000 } };
            int K = arr.GetLength(0);
            int N = arr.GetLength(1);

            int[] output = new int[N * K];

            // Function call
            _sut.mergeKArrays(arr, 0, 2, output);

            output.Should().BeEquivalentTo(new int[] { 1, 2, 6, 9, 12, 20, 23, 34, 34, 90, 1000, 2000 });
        }
    }
}

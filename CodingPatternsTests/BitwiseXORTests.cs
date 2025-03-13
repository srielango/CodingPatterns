using CodingPatterns;
using FluentAssertions;

namespace CodingPatternsTests
{
    [TestClass]
    public class BitwiseXORTests
    {
        private readonly BitwiseXOR _sut = new BitwiseXOR();

        [TestMethod]
        [DataRow(new int[] {1,1,2,2,3}, 3)]
        public void int_array_returns_unique_number(int[] array, int expected)
        {
            var result = _sut.SingleNumber(array);
            result.Should().Be(expected);
        }
    }
}

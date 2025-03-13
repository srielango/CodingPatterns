namespace CodingPatterns
{
    public class BitwiseXOR
    {
        public int SingleNumber(int[] arr)
        {
            var num = 0;
            foreach (var i in arr)
            {
                num ^= i;
            }
            return num;
        }
    }
}

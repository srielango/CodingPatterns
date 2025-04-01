namespace CodingPatterns.TopKElements
{

    public class HashMapTopKElementsStrategy : ITopKElementsStrategy
    {
        public int[] TopKFrequent(int[] nums, int k)
        {
            Dictionary<int, int> ElementDectionary = new();
            foreach (var num in nums)
            {
                if (!ElementDectionary.ContainsKey(num))
                {
                    ElementDectionary[num] = 0;
                }
                ElementDectionary[num]++;
            }

            var sortedDictionary = ElementDectionary.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            var result = new int[k];
            var index = 0;
            foreach (var pair in sortedDictionary)
            {
                result[index++] = pair.Key;
                if (index >= k)
                {
                    break;
                }
            }
            return result;
        }
    }


}

namespace CodingPatterns.TopKElements
{
    public class MinHeapTopKElementsStrategy : ITopKElementsStrategy
    {
        //Uses the PriorityQueue that acts as MinHeap
        public int[] TopKFrequent(int[] nums, int k)
        {
            Dictionary<int, int> ElementDictionary = new();
            foreach (var num in nums)
            {
                if (!ElementDictionary.ContainsKey(num))
                {
                    ElementDictionary[num] = 0;
                }
                ElementDictionary[num]++;
            }

            var minHeap = new PriorityQueue<int, int>();

            foreach (var pair in ElementDictionary)
            {
                minHeap.Enqueue(pair.Key, pair.Value);
                if (minHeap.Count > k)
                {
                    minHeap.Dequeue();
                }
            }

            var result = new int[k];
            for (int i = 0; i < k; i++)
            {
                result[i] = minHeap.Dequeue();
            }
            return result;
        }
    }
}


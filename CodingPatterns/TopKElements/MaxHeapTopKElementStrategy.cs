namespace CodingPatterns.TopKElements
{
    public class MaxHeapTopKElementStrategy : ITopKElementsStrategy
    {
        //Uses the PriorityQueue to act as MaxHeap by reversing the comparison
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

            PriorityQueue<int, (int frequency, int value)> maxHeap = new(MaxHeapComparer());

            foreach (var num in ElementDectionary.Keys)
            {
                maxHeap.Enqueue(num, (ElementDectionary[num], num));
            }

            var result = new int[k];

            for (var i = 0; i < k; i++)
            {
                result[i] = maxHeap.Dequeue();
            }

            return result;
        }

        private Comparer<(int frequency, int value)> MaxHeapComparer()
        {
            return Comparer<(int frequency, int value)>.Create((a, b) =>
                b.frequency != a.frequency ? b.frequency - a.frequency : b.value - a.value);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingPatterns
{
    public class TopKElements
    {
        private ITopKElementsStrategy _topKElementsStrategy;

        public TopKElements(ITopKElementsStrategy topKElementsStrategy)
        {
            _topKElementsStrategy = topKElementsStrategy;
        }

        public int[] GetTopKElements(int[] nums, int k)
        {
            return _topKElementsStrategy.TopKFrequent(nums, k);
        }
    }

    public interface ITopKElementsStrategy
    {
        public int[] TopKFrequent(int[] nums, int k);
    }

    public class HashMapTopKElementsStrategy : ITopKElementsStrategy
    {
        public int[] TopKFrequent(int[] nums, int k)
        {
            Dictionary<int, int> ElementDectionary = new();
            foreach(var num in nums)
            {
                if(!ElementDectionary.ContainsKey(num))
                {
                    ElementDectionary[num] = 0;
                }
                ElementDectionary[num]++;
            }

            var sortedDictionary = ElementDectionary.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            var result = new int[k];
            var index = 0;
            foreach(var pair in sortedDictionary)
            {
                result[index++] = pair.Key;
                if(index >= k)
                {
                    break;
                }
            }
            return result;
        }
    }

    public class MaxHeapTopKElementStrategy : ITopKElementsStrategy
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

            PriorityQueue<int, (int frequency, int value)> maxHeap = new(MaxHeapComparer());

            foreach (var num in ElementDectionary.Keys)
            {
                maxHeap.Enqueue(num, (ElementDectionary[num], num));
            }

            var result = new int[k];

            for(var i = 0; i < k; i++)
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

    public class MinHeapTopKElementsStrategy : ITopKElementsStrategy
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

            var minHeap = new PriorityQueue<int, int>(Comparer<int>.Create((a, b) => a.CompareTo(b)));

            foreach (var pair in ElementDectionary)
            {
                minHeap.Enqueue(pair.Key, pair.Value);
                if (minHeap.Count > k)
                {
                    minHeap.Dequeue();
                }
            }

            var result = new int[k];
            for(int i = 0; i < k; i++)
            {
                result[i] = minHeap.Dequeue();
            }
            return result;
        }
    }
}

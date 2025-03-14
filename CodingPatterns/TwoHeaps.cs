using System.ComponentModel.DataAnnotations;

namespace CodingPatterns
{
    public class TwoHeaps
    {
        private readonly IMedianStrategy _medianStrategy;

        public TwoHeaps(IMedianStrategy medianStrategy)
        {
            _medianStrategy = medianStrategy;
        }

        public void AddNum(int num)
        {
            _medianStrategy.AddNum(num);
        }

        public double FindMedian()
        {
            return _medianStrategy.FindMedian();
        }
    }

    public interface IMedianStrategy
    {
        public void AddNum(int num);
        public double FindMedian();
    }

    //This is good for small set of numbers.  For streaming large numbers this will fail
    public class NaiveMedianStrategy : IMedianStrategy
    {
        private List<int> MyList = new();
        public void AddNum(int num)
        {
            MyList.Add(num);
        }

        public double FindMedian()
        {
            MyList.Sort();
            var count = MyList.Count();
            int middleIndex = count / 2;
            if(count % 2 != 0)
            {
                return MyList[middleIndex];
            }
            return ((double)MyList[middleIndex - 1] + (double)MyList[middleIndex]) / 2;
        }
    }

    public class TwoHeapStrategy : IMedianStrategy
    {
        PriorityQueue<int, int> MinHeap = new();
        PriorityQueue<int, int> MaxHeap = new(Comparer<int>.Create((x, y) => y.CompareTo(x)));

        public void AddNum(int num)
        {
            MaxHeap.TryPeek(out int peekValue, out int peekPriority);
            if (peekValue > num)
            {
                MaxHeap.Enqueue(num, num);
            }
            else
            {
                MinHeap.Enqueue(num, num);
            }

            if(MaxHeap.Count > MinHeap.Count + 1)
            {
                var maxNum = MaxHeap.Dequeue();
                MinHeap.Enqueue(maxNum, maxNum);
            }
            if(MinHeap.Count > MaxHeap.Count)
            {
                var minNum = MinHeap.Dequeue();
                MaxHeap.Enqueue(minNum, minNum);
            }
        }

        public double FindMedian()
        {
            var elementCount = MinHeap.Count + MaxHeap.Count;
            if (elementCount % 2 != 0)
            {
                return MaxHeap.Peek();
            }
            return ((double)MaxHeap.Peek() + (double)MinHeap.Peek()) / 2;
        }
    }
}

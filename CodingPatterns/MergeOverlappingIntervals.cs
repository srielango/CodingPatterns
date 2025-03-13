using System.Collections;

namespace CodingPatterns
{
    public class MergeOverlappingIntervals
    {
        public List<Interval> mergeIntervals(Interval[] arr)
        {

            // Test if the given set has at least one interval
            if (arr.Length <= 0)
                return null;
            Array.Sort(arr, new sortHelper());

            // Create an empty stack of intervals
            Stack stack = new Stack();

            // Push the first interval to stack
            stack.Push(arr[0]);

            // Start from the next interval and merge if necessary
            for (int i = 1; i < arr.Length; i++)
            {

                // get interval from stack top
                Interval top = (Interval)stack.Peek();

                // if current interval is not overlapping with stack top,
                // Push it to the stack
                if (top.end < arr[i].start)
                    stack.Push(arr[i]);

                // Otherwise update the ending time of top if ending of current
                // interval is more
                else if (top.end < arr[i].end)
                {
                    top.end = arr[i].end;
                    stack.Pop();
                    stack.Push(top);
                }
            }

            var x = new List<Interval>();
            while (stack.Count != 0)
            {
                Interval t = (Interval)stack.Pop();
                x.Add(t);
            }
            return x;
        }
    }

    // sort the intervals in increasing order of start time
    class sortHelper : IComparer
    {
        int IComparer.Compare(object a, object b)
        {
            Interval first = (Interval)a;
            Interval second = (Interval)b;
            if (first.start == second.start)
            {
                return first.end - second.end;
            }
            return first.start - second.start;
        }
    }

    public class Interval
    {
        public int start, end;
        public Interval(int start, int end)
        {
            this.start = start;
            this.end = end;
        }
    }
}

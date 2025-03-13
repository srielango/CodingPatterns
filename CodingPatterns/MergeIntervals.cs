namespace CodingPatterns
{
    //Given an array of intervals, merge all the overlapping intervals into one and output the result which should have only mutually exclusive intervals
    //Example:
    //Input: arr[] = [[1, 3], [2, 4], [6, 8], [9, 10]]
    //Output: [[1, 4], [6, 8], [9, 10]]

    public class MergeIntervals
    {
        private IMergeStrategy _mergeStrategy;

        public MergeIntervals(IMergeStrategy mergeStrategy)
        {
            _mergeStrategy = mergeStrategy;
        }

        public int[][] MergeOverlap(int[][] intervals)
        {
            return _mergeStrategy.Merge(intervals);
        }
    }

    public interface IMergeStrategy
    {
        int[][] Merge(int[][] intervals);
    }

    public class SimpleStrategy : IMergeStrategy
    {
        public int[][] Merge(int[][] intervals)
        {
            var result = new List<int[]>();

            Array.Sort(intervals, (a,b) => a[0].CompareTo(b[0]));

            for(int i = 0; i < intervals.Length; i++)
            {
                int start = intervals[i][0];
                int end = intervals[i][1];

                if(result.Count > 0 && result[result.Count - 1][1] >= end)
                {
                    continue;
                }

                for(int j = i + 1; j < intervals.Length; j++)
                {
                    if (end > intervals[j][0])
                    {
                        end = Math.Max(end, intervals[j][1]);
                    }
                }

                result.Add(new int[] {start, end});
            }

            return result.ToArray();
        }
    }

    public class ExpectedStrategy : IMergeStrategy
    {
        public int[][] Merge(int[][] intervals)
        {
            var result = new List<int[]>();
            Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));

            result.Add(new int[] { intervals[0][0], intervals[0][1] });
            for (int i = 1; i < intervals.Length; i++) 
            {
                var last = result[result.Count - 1];
                var curr = intervals[i];
                if (curr[0] <= last[1])
                {
                    last[1] = Math.Max(curr[1], last[1]);
                }
                else
                {
                    result.Add(new int[] { curr[0], curr[1] });
                }
            }

            return result.ToArray();
        }
    }
}

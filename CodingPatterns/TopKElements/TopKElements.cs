namespace CodingPatterns.TopKElements
{
    /// <summary>
    /// The top K frequent element involves finding the K most elements in a given dataset.
    /// It is useful for data analysis and can be used to identify trends in data.
    /// </summary>
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
}
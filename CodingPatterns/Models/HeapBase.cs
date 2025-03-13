namespace CodingPatterns.Models
{
    public abstract class HeapBase
    {
        protected int[] _elements;
        protected int _size;
        protected int GetLeftChildIndex(int elementIndex) => 2 * elementIndex + 1;
        protected int GetRightChildIndex(int elementIndex) => 2 * elementIndex + 2;
        protected int GetParentIndex(int elementIndex) => (elementIndex - 1) / 2;

        protected bool HasLeftChild(int elementIndex) => GetLeftChildIndex(elementIndex) < _size;
        protected bool HasRightChild(int elementIndex) => GetRightChildIndex(elementIndex) < _size;
        protected bool IsRoot(int elementIndex) => elementIndex == 0;

        protected int GetLeftChild(int elementIndex) => _elements[GetLeftChildIndex(elementIndex)];
        protected int GetRightChild(int elementIndex) => _elements[GetRightChildIndex(elementIndex)];
        protected int GetParent(int elementIndex) => _elements[GetParentIndex(elementIndex)];

        protected void Swap(int firstIndex, int secondIndex)
        {
            var temp = _elements[firstIndex];
            _elements[firstIndex] = _elements[secondIndex];
            _elements[secondIndex] = temp;
        }

        public bool IsEmpty()
        {
            return _size == 0;
        }

        public int Peek()
        {
            if (_size == 0)
                throw new IndexOutOfRangeException();

            return _elements[0];
        }

        public int Pop()
        {
            if (_size == 0)
                throw new IndexOutOfRangeException();

            var result = _elements[0];
            _elements[0] = _elements[_size - 1];
            _size--;

            ReCalculateDown();

            return result;
        }

        public void Add(int element)
        {
            if (_size == _elements.Length)
                throw new IndexOutOfRangeException();

            _elements[_size] = element;
            _size++;

            ReCalculateUp();
        }

        protected abstract void ReCalculateDown();
        protected abstract void ReCalculateUp();
    }
}

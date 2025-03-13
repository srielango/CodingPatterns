using CodingPatterns.Models;

namespace CodingPatterns
{
    public class DFS
    {
        public BinaryTreeNode root;
        public List<int> InOrder()
        {
            return InOrder(root);
        }
        public List<int> PreOrder()
        {
            return PreOrder(root);
        }

        public List<int> PostOrder()
        {
            return PostOrder(root);
        }

        private List<int> PreOrder(BinaryTreeNode node)
        {
            var list = new List<int>();
            if(node == null) return list;
            list.Add(node.data);
            list.AddRange(PreOrder(node.left));
            list.AddRange(PreOrder(node.right));
            return list;
        }
        private List<int> InOrder(BinaryTreeNode node) 
        {
            var list = new List<int>();
            if (node == null) return list;
            list.AddRange(InOrder(node.left));
            list.Add(node.data);
            list.AddRange(InOrder(node.right));
            return list;
        }
        private List<int> PostOrder(BinaryTreeNode node)
        {
            var list = new List<int>();
            if (node == null) return list;
            list.AddRange(PostOrder(node.left));
            list.AddRange(PostOrder(node.right));
            list.Add(node.data);
            return list;
        }
    }
}

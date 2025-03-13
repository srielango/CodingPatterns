using CodingPatterns.Models;

namespace CodingPatterns
{
    public class BFS
    {
        public BinaryTreeNode root;
        public List<int> GetLevelOrder()
        {
            //return GetLevelOrderRecursive();
            return GetLevelOrderByQueue();
        }

        //private List<int> GetLevelOrderRecursive()
        //{
        //    var levelData = new List<int>();
        //    int h = height(root);
        //    int i;
        //    for (i = 1; i <= h; i++)
        //    {
        //        levelData.AddRange(getCurrentLevel(root, i));
        //    }
        //    return levelData;
        //}

        private int height(BinaryTreeNode root)
        {
            if (root == null)
            {
                return 0;
            }
            else
            {
                /* compute height of each subtree */
                int lheight = height(root.left);
                int rheight = height(root.right);

                /* use the larger one */
                if (lheight > rheight)
                {
                    return (lheight + 1);
                }
                else
                {
                    return (rheight + 1);
                }
            }
        }

        private List<int> getCurrentLevel(BinaryTreeNode root,
                                          int level)
        {
            var leveldata = new List<int>();

            if (root == null)
            {
                return leveldata;
            }
            if (level == 1)
            {
                //Console.Write(root.data + " ");
                leveldata.Add(root.data);
            }
            else if (level > 1)
            {
                leveldata.AddRange(getCurrentLevel(root.left, level - 1));
                leveldata.AddRange(getCurrentLevel(root.right, level - 1));
            }

            return leveldata;
        }

        private List<int> GetLevelOrderByQueue()
        {
            var levelData = new List<int>();

            if (root == null) return levelData;

            var queue = new Queue<BinaryTreeNode>();

            queue.Enqueue(root);

            var currentNode = root;

            while (queue.Count > 0)
            {
                currentNode = queue.Dequeue();
                if (currentNode == null) continue;
                queue.Enqueue(currentNode.left);
                queue.Enqueue(currentNode.right);
                levelData.Add(currentNode.data);
            }

            return levelData;
        }

    }
}

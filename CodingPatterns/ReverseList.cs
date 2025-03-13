using CodingPatterns.Models;

namespace CodingPatterns
{
    public class ReverseList
    {
        Node head;
        public void AddNode(Node node)
        {
            if (head == null)
                head = node;
            else
            {
                Node temp = head;
                while (temp.next != null)
                {
                    temp = temp.next;
                }
                temp.next = node;
            }
        }

        public void Reverse()
        {
            Node prev = null, current = head, next = null;
            while (current != null)
            {
                next = current.next;
                current.next = prev;
                prev = current;
                current = next;
            }
            head = prev;
        }

        public List<int> GetList()
        {
            var list = new List<int>();
            Node current = head;
            while (current != null)
            {
                list.Add(current.data);
                current = current.next;
            }

            return list;
        }
    }


}

using CodingPatterns.Models;

namespace CodingPatterns
{
    public class SlowAndFastPointers
    {
        public Node head { get; set; } // head of list

        /* Inserts a new Node at front of the list. */
        public void push(int new_data)
        {
            /* 1 & 2: Allocate the Node &
                    Put in the data*/
            Node new_node = new Node(new_data);

            /* 3. Make next of new Node as head */
            new_node.next = head;

            /* 4. Move the head to point to new Node */
            head = new_node;
        }

        public bool DetectLoop()
        {
            Node slow_p = head, fast_p = head;
            while (slow_p != null && fast_p != null
                && fast_p.next != null)
            {
                slow_p = slow_p.next;
                fast_p = fast_p.next.next;
                if (slow_p == fast_p)
                {
                    return true;
                }
            }
            return false;
        }
    }

    
}

using System;
using System.Xml.Linq;

namespace RoboWar
{
    public class CircularList
    {
        public Node start;
        public void InsertAtEnd(int value)
        {
            Node new_node;

            // If the list is empty, create a single node
            // circular and doubly list
            if (start == null)
            {
                new_node = new Node();
                new_node.Data = value;
                new_node.Next = new_node.Prev = new_node;
                start = new_node;
                return;
            }

            // If list is not empty

            /* Find last node */
            Node last = start.Prev;

            // Create Node dynamically
            new_node = new Node();
            new_node.Data = value;

            // Start is going to be next of new_node
            new_node.Next = start;

            // Make new node previous of start
            start.Prev = new_node;

            // Make last previous of new node
            new_node.Prev = last;

            // Make new node next of old last
            last.Next = new_node;
        }

        public Node GetNextNode(int direction)
        {
            if (direction == 0)
                return start;
            Node last = start.Prev;
            while(true)
            {
                if(start.Data == direction)
                {
                    return start.Next;
                }
                start = start.Next;
            }
        }
    }

    public sealed class Node
    {
        public int Data { get; set; }
        public Node Next { get; set; }
        public Node Prev { get; set; }
    }
}


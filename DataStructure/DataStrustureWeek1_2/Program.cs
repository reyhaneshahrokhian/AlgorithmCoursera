using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStrustureWeek1_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] a = Console.ReadLine().Split();
            List<Node> nodes = new List<Node>();
            int height = 0, root = 0;

            for (int i = 0; i < n; i++)
            {
                nodes.Add(new Node(i));
            }
            for (int i = 0; i < n; i++)
            {
                if (a[i] == "-1")
                    root = i;
                
                else
                    nodes[int.Parse(a[i])].children.Add(i);
            }

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(root);

            while (true)
            {
                int count = queue.Count;
                if (count == 0)
                {
                    Console.WriteLine(height);
                    break;
                }

                height++;
                while (count > 0)
                {
                    int node = queue.Peek();
                    queue.Dequeue();
                    if(nodes[node].children != null)
                        for (int i = 0; i < nodes[node].children.Count(); i++)
                            queue.Enqueue(nodes[node].children[i]);
                    
                    count--;
                }
            }
        }
    }
    public class Node
    {
        public int a;
        public List<int> children = new List<int>();
        public Node(int a)
        {
            this.a = a;
        }
    }
}

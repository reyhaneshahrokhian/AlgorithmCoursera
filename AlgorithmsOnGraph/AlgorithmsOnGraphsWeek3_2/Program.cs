using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsOnGraphsWeek3_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] a = Console.ReadLine().Split();
            int n = int.Parse(a[0]);
            int m = int.Parse(a[1]);
            List<int>[] graph = new List<int>[n];
            for (int i = 0; i < n; i++)
                graph[i] = new List<int>();

            int x, y;
            for (int i = 0; i < m; i++)
            {
                a = Console.ReadLine().Split();
                x = int.Parse(a[0]);
                y = int.Parse(a[1]);
                graph[x - 1].Add(y - 1);
                graph[y - 1].Add(x - 1);
            }
            Console.WriteLine(bipartite(graph));
        }
        public static int bipartite(List<int>[] graph)
        {
            int n = graph.Length;
            int[] color = new int[n];
            for (int i = 0; i < n; i++)
                color[i] = -1;

            Queue<int> queue = new Queue<int>();
            for (int i = 0; i < n; i++)
            {
                if (color[i] == -1)
                {
                    queue.Enqueue(i);
                    color[i] = 0;
                    int x;
                    while (queue.Count() != 0)
                    {
                        x = queue.Dequeue();
                        foreach (var item in graph[x])
                        {
                            if (color[item] == -1)
                            {
                                color[item] = 1 - color[x];
                                queue.Enqueue(item);
                            }
                            else if (color[item] == color[x])
                                return 0;
                        }
                    }
                }
            }
            return 1;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsOnGraphsWeek3_1
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
            a = Console.ReadLine().Split();
            int u = int.Parse(a[0]);
            int v = int.Parse(a[1]);

            Console.WriteLine(bfs(u - 1, v - 1, graph));
        }
        public static int bfs(int u, int v, List<int>[] graph)
        {
            if (u == v)
                return 0;

            int[] distance = new int[graph.Count()];
            for (int i = 0; i < graph.Count(); i++)
                distance[i] = int.MaxValue;

            distance[u] = 0;
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(u);

            int x;
            while (queue.Count() != 0)
            {
                x = queue.Dequeue();
                foreach (var item in graph[x])
                {
                    if (distance[item] == int.MaxValue)
                    {
                        queue.Enqueue(item);
                        distance[item] = distance[x] + 1;
                    }
                }
            }

            if (distance[v] != int.MaxValue)
                return distance[v];
            
            return -1;
        }
    }
}

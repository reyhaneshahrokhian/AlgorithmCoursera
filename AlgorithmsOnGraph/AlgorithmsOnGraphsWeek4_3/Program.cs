using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsOnGraphsWeek4_3
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] a = new string[3];
            a = Console.ReadLine().Split();
            int n = int.Parse(a[0]);
            int m = int.Parse(a[1]);
            List<int>[] graph = new List<int>[n];
            List<int>[] costs = new List<int>[n];
            for (int i = 0; i < n; i++)
            {
                graph[i] = new List<int>();
                costs[i] = new List<int>();
            }

            int x, y, w;
            for (int i = 0; i < m; i++)
            {
                a = Console.ReadLine().Split();
                x = int.Parse(a[0]);
                y = int.Parse(a[1]);
                w = int.Parse(a[2]);
                graph[x - 1].Add(y - 1);
                costs[x - 1].Add(w);
            }
            int s = int.Parse(Console.ReadLine());
            long[] distance = new long[n];
            int[] reachable = new int[n];
            int[] shortest = new int[n];
            for (int i = 0; i < n; i++)
            {
                distance[i] = long.MaxValue;
                reachable[i] = 0;
                shortest[i] = 1;
            }
            shortestPaths(graph, costs, s - 1, distance, reachable, shortest);
            for (int i = 0; i < n; i++)
            {
                if (reachable[i] == 0)
                    Console.WriteLine('*');
                
                else if (shortest[i] == 0)
                    Console.WriteLine('-');
                
                else
                    Console.WriteLine(distance[i]);               
            }
        }
        public static void shortestPaths(List<int>[] graph, List<int>[] costs,int s , long[] distance, int[] reachable, int[] shortest)
        {
            int n = graph.Length;
            distance[s] = 0;
            reachable[s] = 1;
            Queue<int> queue = new Queue<int>();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < graph[j].Count(); k++)
                    {
                        if (distance[j] != long.MaxValue && distance[graph[j][k]] > distance[j] + costs[j][k])
                        {
                            distance[graph[j][k]] = distance[j] + costs[j][k];
                            reachable[graph[j][k]] = 1;
                            if (i == n - 1)
                                queue.Enqueue(graph[j][k]);
                        }
                    }
                }                   
            }

            int[] visited = new int[n];
            while (queue.Count() != 0)
            {
                int u = queue.Dequeue();
                visited[u] = 1;
                if (u != s)
                    shortest[u] = 0;

                foreach (var item in graph[u])
                {
                    if (visited[item] == 0)
                    {
                        queue.Enqueue(item);
                        visited[item] = 1;
                        shortest[item] = 0;
                    }
                }
            }
            distance[s] = 0;
        }
    }
}

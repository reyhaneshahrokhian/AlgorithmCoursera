using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsOnGraphsWeek1_2
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
            int ans = 0;
            int[] visited = new int[n];
            for (int i = 0; i < n; i++)
            {
                if (visited[i] == 0)
                {
                    explore(i, graph, visited);
                    ans++;
                }
            }
            Console.WriteLine(ans);
        }
        public static void explore(int u, List<int>[] graph, int[] visited)
        {
            visited[u] = 1;
            for (int i = 0; i < graph[u].Count(); i++)
            {
                if (visited[graph[u][i]] == 0)
                    explore(graph[u][i], graph, visited);                                     
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsOnGraphsWeek1_1
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
            int[] visited = new int[n];
            Console.WriteLine(explore(u - 1, v - 1, graph, visited));
        }
        public static int explore(int u, int v, List<int>[] graph, int[] visited)
        {
            if (u == v)
                return 1;

            visited[u] = 1;
            for (int i = 0; i < graph[u].Count(); i++)
            {
                if (visited[graph[u][i]] == 0)
                {
                    if (explore(graph[u][i], v, graph, visited) == 1)
                        return 1;                    
                }
            }
            return 0;
        }
    }
}

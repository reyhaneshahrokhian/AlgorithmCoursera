using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsOnGraphsWeek2_1
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
            }
            int[] visited = new int[n];
            int[] cycles = new int[n];
            int ans = 0;
            for (int i = 0; i < n; i++)
            {
                if (visited[i] == 0 && explore(i, graph, visited, cycles) == 1)
                {
                    ans = 1;
                    break;                   
                }
            }
            Console.WriteLine(ans);
        }
        public static int explore(int u, List<int>[] graph, int[] visited, int[] cycles)
        {
            visited[u] = 1;
            cycles[u] = 1;
            for (int i = 0; i < graph[u].Count(); i++)
            {
                if ((visited[graph[u][i]] == 0 && explore(graph[u][i], graph, visited, cycles) == 1) || cycles[graph[u][i]] == 1)
                    return 1;
            }
            cycles[u] = 0;

            return 0;
        }
    }
}

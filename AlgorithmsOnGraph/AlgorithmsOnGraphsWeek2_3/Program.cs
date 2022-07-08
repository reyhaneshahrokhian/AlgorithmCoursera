using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsOnGraphsWeek2_3
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
            Stack<int> checker = new Stack<int>();
            for (int i = 0; i < n; i++)
                if (visited[i] == 0)
                    dfs(i, graph, visited, checker);

            
            List<int>[] ReversedGraph = new List<int>[n];
            for (int i = 0; i < n; i++)
                ReversedGraph[i] = new List<int>();

            for (int i = 0; i < n; i++)
                for (int j = 0; j < graph[i].Count(); j++)
                    ReversedGraph[graph[i][j]].Add(i);               
            

            visited = new int[n];
            int ans = 0, u;
            while (checker.Count() != 0)
            {
                u = checker.Pop();
                if (visited[u] == 0)
                {
                    Stack<int> hold = new Stack<int>();
                    dfs(u, ReversedGraph, visited, hold);
                    ans++;
                }
            }
            Console.WriteLine(ans);
        }
        public static void dfs(int u, List<int>[] graph, int[] visited, Stack<int> checker)
        {
            visited[u] = 1;
            for (int i = 0; i < graph[u].Count(); i++)
            {
                if (visited[graph[u][i]] == 0)
                {
                    visited[graph[u][i]] = 1;
                    dfs(graph[u][i], graph, visited, checker);
                }
            }
            checker.Push(u);
        }
    }
}

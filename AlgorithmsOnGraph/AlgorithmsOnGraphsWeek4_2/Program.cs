using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsOnGraphsWeek4_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] a = new string[3];
            a = Console.ReadLine().Split();
            int n = int.Parse(a[0]);
            int m = int.Parse(a[1]);
            int[][] edges = new int[m][];
            for (int i = 0; i < m; i++)
            {
                edges[i] = new int[3];
            }
            for (int i = 0; i < m; i++)
            {
                a = Console.ReadLine().Split();
                edges[i][0] = int.Parse(a[0]);
                edges[i][1] = int.Parse(a[1]);
                edges[i][2] = int.Parse(a[2]);
            }
            Console.WriteLine(Solve(n, edges));
        }
        public static int Solve(int n, int[][] edges)
        {
            List<int> dist = new List<int>();
            List<bool> check = new List<bool>();

            for (int i = 0; i < n; i++)
            {
                dist.Add(int.MaxValue);
                check.Add(false);
            }

            for (int k = 0; k < n; k++)
            {
                if (!check[k])
                {
                    dist[k] = 0;
                    check[k] = true;

                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < edges.Length; j++)
                        {
                            if (check[edges[j][0] - 1] && dist[edges[j][1] - 1] > dist[edges[j][0] - 1] + edges[j][2])
                            {
                                dist[edges[j][1] - 1] = dist[edges[j][0] - 1] + edges[j][2];
                                check[edges[j][1] - 1] = true;
                                if (i == n - 1)
                                    return 1;
                            }
                        }
                    }
                }
            }
            return 0;
        }
    }
}

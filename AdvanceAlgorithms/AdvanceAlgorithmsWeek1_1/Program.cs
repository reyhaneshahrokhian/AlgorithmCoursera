using System;
using System.Collections.Generic;
using System.Linq;

namespace AdvanceProgrammingWeek1_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] x = Console.ReadLine().Split();
            int n = int.Parse(x[0]);
            int m = int.Parse(x[1]);
            long[][] edges = new long[m][];
            for (int i = 0; i < m; i++)
            {
                x = Console.ReadLine().Split();
                edges[i] = new long[3];
                edges[i][0] = int.Parse(x[0]);
                edges[i][1] = int.Parse(x[1]);
                edges[i][2] = int.Parse(x[2]);
            }
            Console.WriteLine(Solve(n, m, edges));
        }
        public static List<long> BFS(ref List<List<long>> adj, long source, long sink, long[][] Edges)
        {
            List<long> pre = new List<long>();

            for (int i = 0; i < adj.Count(); i++)
                pre.Add(-1);

            Queue<long> que = new Queue<long>();
            List<bool> visted = new List<bool>();

            for (int i = 0; i < adj.Count(); i++)
                visted.Add(false);

            que.Enqueue(source);
            visted[(int)source] = true;
            long current = source;

            while (current != sink && que.Count() > 0)
            {
                current = que.Dequeue();

                for (int i = 0; i < adj[(int)current].Count(); i++)
                {
                    if (!visted[(int)adj[(int)current][i]] && Edges[current][(int)adj[(int)current][i]] != 0)
                    {
                        pre[(int)adj[(int)current][i]] = current;
                        que.Enqueue(adj[(int)current][i]);
                        visted[(int)adj[(int)current][i]] = true;
                    }
                }
            }
            return pre;
        }
        public static long Edmondkarp(long[][] Edges, ref List<List<long>> adj, long s, long t)
        {
            long maxflow = 0;
            while (true)
            {
                List<long> res = new List<long>();
                res = BFS(ref adj, s, t, Edges);
                List<long> path = new List<long>();
                long current = t;
                if (res[(int)t] == -1)
                    break;

                while (current != s)
                {
                    path.Add(current);
                    current = res[(int)current];
                }
                path.Add(s);
                path.Reverse();

                long minP = long.MaxValue;

                for (int i = 0; i < path.Count - 1; i++)
                {
                    long w = Edges[path[i]][path[i + 1]];

                    if (w <= minP)
                        minP = w;
                }

                for (int i = 0; i < path.Count - 1; i++)
                {
                    Edges[path[i]][path[i + 1]] -= minP;
                    Edges[path[i + 1]][path[i]] += minP;
                }
                maxflow += minP;
            }
            return maxflow;
        }
        public static long Solve(long nodeCount, long edgeCount, long[][] edges)
        {
            long[][] Edges = new long[(int)nodeCount][];
            for (int i = 0; i < nodeCount; i++)
                Edges[i] = new long[(int)nodeCount];

            for (int i = 0; i < edgeCount; i++)
            {
                if (edges[i][0] != edges[i][1])
                    Edges[edges[i][0] - 1][edges[i][1] - 1] += edges[i][2];
            }

            List<List<long>> adj = new List<List<long>>((int)nodeCount);

            for (int i = 0; i < nodeCount; i++)
                adj.Add(new List<long>());

            for (int i = 0; i < nodeCount; i++)
            {
                for (int j = 0; j < nodeCount; j++)
                {
                    if (Edges[i][j] != 0)
                    {
                        adj[i].Add(j);
                        if (Edges[j][i] == 0)
                            adj[j].Add(i);
                    }
                }
            }
            return Edmondkarp(Edges, ref adj, 0, nodeCount - 1);
        }
    }
}

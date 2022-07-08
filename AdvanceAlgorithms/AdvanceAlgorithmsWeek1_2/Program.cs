using System;
using System.Collections.Generic;
using System.Linq;

namespace AdvanceProgrammingWeek1_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] x = Console.ReadLine().Split();
            int n = int.Parse(x[0]);
            int m = int.Parse(x[1]);
            long[][] edges = new long[n][];
            for (int i = 0; i < n; i++)
            {
                x = Console.ReadLine().Split();
                edges[i] = new long[m];
                for (int j = 0; j < m; j++)
                {
                    edges[i][j] = int.Parse(x[j]);
                }                
            }
            foreach (var item in Solve(n, m, edges))
            {
                Console.Write(item+ " ");
            }
        }
        public static long[] Solve(long flightCount, long crewCount, long[][] info)
        {
            List<List<long>> adjl = new List<List<long>>((int)flightCount + (int)crewCount + 2);
            for (int i = 0; i < flightCount + crewCount + 2; i++)
            {
                adjl.Add(new List<long>());
            }
            for (int i = 0; i < flightCount; i++)
            {
                for (int j = 0; j < crewCount; j++)
                {
                    if (info[i][j] == 1)
                    {
                        adjl[i + 1].Add(j + (int)flightCount + 1);
                        adjl[j + (int)flightCount + 1].Add(i + 1);
                    }
                }
            }
            for (int i = 1; i <= flightCount; i++)
            {
                adjl[0].Add(i);
                adjl[i].Add(0);

            }
            for (int i = (int)flightCount + 1; i <= crewCount + flightCount; i++)
            {
                adjl[i].Add((int)flightCount + (int)crewCount + 1);
                adjl[(int)flightCount + (int)crewCount + 1].Add(i);
            }

            long[][] edges = new long[flightCount + crewCount + 2][];
            for (int i = 0; i < flightCount + crewCount + 2; i++)
            {
                edges[i] = new long[flightCount + crewCount + 2];
            }
            for (int i = 1; i <= flightCount; i++)
            {
                edges[0][i] = 1;
            }
            for (int i = (int)flightCount + 1; i <= flightCount + crewCount + 1; i++)
            {
                edges[i][flightCount + crewCount + 1] = 1;
            }
            for (int i = 1; i <= flightCount; i++)
            {
                for (int j = (int)flightCount + 1; j <= flightCount + crewCount; j++)
                {
                    if (info[i - 1][j - flightCount - 1] == 1)
                    {
                        edges[i][j] = 1;
                    }
                }
            }
            long[] ans = new long[flightCount];


            Edmondkarp(edges, ref adjl, 0, flightCount + crewCount + 1, flightCount);

            for (int i = 1; i <= flightCount; i++)
            {
                for (int j = 0; j < adjl[i].Count; j++)
                {
                    if (edges[i][adjl[i][j]] == 0 && adjl[i][j] != 0)
                    {
                        ans[i - 1] = adjl[i][j] - flightCount;
                        break;
                    }
                    else
                    {
                        ans[i - 1] = -1;
                    }
                }
            }


            return ans;
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
        public static void Edmondkarp(long[][] Edges, ref List<List<long>> adj, long s, long t, long flightCount)
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
        }
    }
}

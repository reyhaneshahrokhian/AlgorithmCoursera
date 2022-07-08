using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsOnGraphsWeek4_1
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
            a = Console.ReadLine().Split();
            int s = int.Parse(a[0]);
            int t = int.Parse(a[1]);
            Console.WriteLine(Dijkstra(graph, costs, s - 1, t - 1));
        }
        public static int Dijkstra(List<int>[] graph, List<int>[] costs, int s, int t)
        {
            int[] dist = new int[graph.Length];
            for (int i = 0; i < graph.Length; i++)
                dist[i] = int.MaxValue;
            
            dist[s] = 0;
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(s);
            while (queue.Count() != 0)
            {
                int u = queue.Dequeue();              
                for (int i = 0; i < graph[u].Count(); i++)
                {
                    if (dist[u] != int.MaxValue && dist[graph[u][i]] > dist[u] + costs[u][i])
                    {
                        dist[graph[u][i]] = dist[u] + costs[u][i];
                        queue.Enqueue(graph[u][i]);
                    }
                }
            }
            if (dist[t] == int.MaxValue)
                return -1;

            return dist[t];
        }
        public long Solve(long nodeCount, long[][] edges, long startNode, long endNode)
        {
            List<Node> node = new List<Node>();
            PriorityQueue<Node, long> priorityQueue = new PriorityQueue<Node, long>();

            for (int i = 0; i < (int)nodeCount; i++)
            {
                node.Add(new Node());
                priorityQueue.Enqueue(node[i], node[i].dist);
            }

            for (int i = 0; i < edges.Length; i++)
                node[(int)edges[i][0] - 1].neighbors.Add(new Tuple<int, int>((int)edges[i][1] - 1, (int)edges[i][2]));

            node[(int)startNode - 1].dist = 0;
            node[(int)startNode - 1].check = true;
            priorityQueue.UpdatePriority(node[(int)startNode - 1], 0);
            long count = nodeCount;

            while (count != 0)
            {
                count--;
                Node temp = priorityQueue.Dequeue();
                temp.check = true;

                for (int i = 0; i < temp.neighbors.Count; i++)
                {
                    if (!node[temp.neighbors[i].Item1].check && node[temp.neighbors[i].Item1].dist > temp.dist + temp.neighbors[i].Item2)
                    {
                        node[temp.neighbors[i].Item1].dist = temp.dist + temp.neighbors[i].Item2;
                        priorityQueue.UpdatePriority(node[temp.neighbors[i].Item1], node[temp.neighbors[i].Item1].dist);
                    }
                }
            }

            if (node[(int)endNode - 1].dist < 0 || node[(int)endNode - 1].dist == long.MaxValue)
                return -1;

            return (long)node[(int)endNode - 1].dist;
        }
        class Node
        {
            public List<Tuple<int, int>> neighbors;
            public bool check = false;
            public long dist = long.MaxValue;
            public Node()
            {
                neighbors = new List<Tuple<int, int>>();
            }
        }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsOnGraphsWeek5_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] x = new int[n];
            int[] y = new int[n];
            string[] a = new string[2];
            for (int i = 0; i < n; i++)
            {
                a = Console.ReadLine().Split();
                x[i] = int.Parse(a[0]);
                y[i] = int.Parse(a[1]);
            }
            Console.WriteLine(minimumDistance(x, y, n));
        }

        public static double minimumDistance(int[] x, int[] y, int n) {
            double result = 0;  
		    Node[] nodes = new Node[n];
		    for (int i = 0; i < n; i++)
                nodes[i] = new Node(x[i], y[i], i);

            List<Edge> edges = new List<Edge>();
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++) 
                    edges.Add(new Edge(i, j, Math.Sqrt(Math.Pow(x[i] - x[j] , 2) + Math.Pow(y[i] - y[j], 2))));               
            }
            edges = edges.OrderBy(z => z.weight).ToList();
    
            foreach (var item in edges)
            {
                if (DisjointSet.Find(item.u, nodes) != DisjointSet.Find(item.v, nodes))
                {
                    result += item.weight;
                    DisjointSet.Union(item.u, item.v, nodes);
                }
            }
            return result;
        }
    }
    public class DisjointSet
    {
        public static int Find(int i, Node[] nodes)
        {
            if (i != nodes[i].parent)
                nodes[i].parent = Find(nodes[i].parent, nodes);

            return nodes[i].parent;
        }
        public static void Union(int u, int v, Node[] nodes)
        {
            int uFind = Find(u, nodes);
            int vFind = Find(v, nodes);
            if (uFind != vFind)
            {
                if (nodes[uFind].rank > nodes[vFind].rank)
                    nodes[vFind].parent = uFind;

                else
                {
                    nodes[uFind].parent = vFind;
                    if (nodes[uFind].rank == nodes[vFind].rank)
                        nodes[vFind].rank++;
                }
            }
        }
    }
    public class Node
    {
        public int x;
        public int y;
        public int parent;
        public int rank;
        public Node(int x, int y, int parent)
        {
            this.x = x;
            this.y = y;
            this.parent = parent;
            this.rank = 0;
        }
    }
    public class Edge
    {
        public int u;
        public int v;
        public double weight;
        public Edge(int u, int v, double weight)
        {
            this.u = u;
            this.v = v;
            this.weight = weight;
        }
    }
}

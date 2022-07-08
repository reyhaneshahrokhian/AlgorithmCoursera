using System;
using System.Collections.Generic;

namespace Week4
{
    class ExchangeMoneyOptimaly
    {
        public static double[] Dist;
        public static bool[] Visited;
        public static bool[] IsReachable;
        public static bool[] IsInNegCycle;
        public static void BelmanFord(List<long>[] mArr , List<long>[] CostArr , long nodeCount , long s)
        {
            Dist[s] = 0;
            IsReachable[s] = true;
            Queue<long> queue = new Queue<long>();
            for(int i=1; i<nodeCount+1; i++)
            {
                for(int j=1; j<nodeCount+1; j++)
                {
                    if(mArr[j] != null)
                    {
                        for(int k=0; k<mArr[j].Count; k++)
                        {
                            if(Dist[mArr[j][k]] > Dist[j] + CostArr[j][2*k + 1])
                            {
                                IsReachable[mArr[j][k]] = true;
                                Dist[mArr[j][k]] = Dist[j] + CostArr[j][2*k + 1];
                                if(i == nodeCount)//iterarion on |v|
                                    queue.Enqueue(mArr[j][k]);//for negative cycle
                            }
                        }
                    }
                }
            }
            while(queue.Count != 0)//for negative cycle
            {
                long n = queue.Dequeue();
                Visited[n] = true;
                IsInNegCycle[n] = true;
                if(mArr[n] != null)
                {
                    for(int i=0; i<mArr[n].Count; i++)
                    {
                        if(!Visited[mArr[n][i]])
                        {
                            queue.Enqueue(mArr[n][i]);
                            Visited[mArr[n][i]] = true;
                            IsInNegCycle[mArr[n][i]] = true;
                        }
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            var input1 = Console.ReadLine().Split();
            long nodeCount = long.Parse(input1[0]);
            long edgecount = long.Parse(input1[1]);
            List<long>[] edges = new List<long>[edgecount];
            for(int i=0; i<edgecount; i++)
            {
                var input2 = Console.ReadLine().Split();
                long a = long.Parse(input2[0]);
                long b = long.Parse(input2[1]);
                long c = long.Parse(input2[2]);
                edges[i] = new List<long>{a , b , c};
            }
            long startNode = long.Parse(Console.ReadLine());
            string[] res = new string[nodeCount];
            List<long>[] mArr = new List<long>[nodeCount+1];
            List<long>[] CostArr = new List<long>[nodeCount+1];
            Dist = new double[nodeCount+1];
            Visited = new bool[nodeCount+1];
            IsInNegCycle = new bool[nodeCount+1];
            IsReachable = new bool[nodeCount+1];
            for(int i=1; i<nodeCount+1; i++)
                Dist[i] = double.PositiveInfinity;
            for(int i=0; i<edges.Length; i++)
            {
                if(mArr[edges[i][0]] == null)
                    mArr[edges[i][0]] = new List<long>{edges[i][1]};
                else
                    mArr[edges[i][0]].Add(edges[i][1]);
            }
            for(int i=0; i<edges.Length; i++)
            {
                if(CostArr[edges[i][0]] == null)
                    CostArr[edges[i][0]] = new List<long>{edges[i][1],edges[i][2]};
                else
                {
                    CostArr[edges[i][0]].Add(edges[i][1]);
                    CostArr[edges[i][0]].Add(edges[i][2]);
                }
            }
            BelmanFord(mArr,CostArr,nodeCount,startNode);
            for(int i=1; i<nodeCount+1; i++)
            {
                if(! IsReachable[i])
                    res[i-1] = "*";
                else if(IsInNegCycle[i])
                    res[i-1] = "-";
                else
                    res[i-1] = Dist[i].ToString();
            }
            for(int i=0; i<nodeCount; i++)
            {
                System.Console.WriteLine(res[i]);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmicToolboxWeek4_6
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] xx = Console.ReadLine().Split();
            int s = int.Parse(xx[0]);
            int p = int.Parse(xx[1]);
            List<int[]> segments = new List<int[]>();
            string[] yy = new string[2];
            for (int i = 0; i < s; i++)
            {
                yy = Console.ReadLine().Split();
                segments.Add(new int[] { int.Parse(yy[0]), int.Parse(yy[1]) });
            }
            string[] zz = Console.ReadLine().Split();
            List<int[]> points = new List<int[]>();
            for (int i = 0; i < p; i++)
                points.Add(new int[] { int.Parse(zz[i]), i});

            List<int[]> AllSeg = new List<int[]>();
            for (int i = 0; i < s; i++)
            {
                AllSeg.Add(new int[] { segments[i][0], 1 });
                AllSeg.Add(new int[] { segments[i][1] + 1, -1 });
            }
            AllSeg.Sort((x, y) => x[0].CompareTo(y[0]));
            points.Sort((x, y) => x[0].CompareTo(y[0]));
            int count = 0, j = 0;
            int[] ans = new int[p];
            for (int i = 0; i < p; i++)
            {
                while(AllSeg.Count() > j && points[i][0] >= AllSeg[j][0])
                {
                    count += AllSeg[j][1];
                    j++;
                }
                ans[points[i][1]] = count;
            }
            for (int i = 0; i < p; i++)
                Console.Write(ans[i] + " ");
        }
    }
}

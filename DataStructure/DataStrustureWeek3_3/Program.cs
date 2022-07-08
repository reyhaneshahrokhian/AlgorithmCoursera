using System;
using System.Collections.Generic;

namespace DataStrustureWeek3_3
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] a = Console.ReadLine().Split();
            int n = int.Parse(a[0]);
            int m = int.Parse(a[1]);
            long[] tableSizes = new long[n];
            long[] targetTables = new long[m];
            long[] sourceTables = new long[m];
            int j = 0;
            foreach (var item in Console.ReadLine().Split())
                tableSizes[j++] = int.Parse(item);

            for (int i = 0; i < m; i++)
            {
                a = Console.ReadLine().Split();
                targetTables[i] = int.Parse(a[0]);
                sourceTables[i] = int.Parse(a[1]);
            }
            foreach (var item in Solve(tableSizes, targetTables, sourceTables))
                Console.WriteLine(item);

        }
        public static long[] Solve(long[] tableSizes, long[] targetTables, long[] sourceTables)
        {
            long maxSize = -1;
            long[] answer = new long[targetTables.Length];
            List<long[]> disjointSet = new List<long[]>();

            for (int i = 0; i < tableSizes.Length; i++)
            {
                disjointSet.Add(new long[] { i, tableSizes[i] });
                maxSize = Math.Max(maxSize, tableSizes[i]);
            }
            for (int i = 0; i < targetTables.Length; i++)
            {
                if (sourceTables[i] != targetTables[i])
                {
                    long hold1 = sourceTables[i] - 1;
                    long hold2 = targetTables[i] - 1;
                    while (true)
                    {
                        if (disjointSet[(int)hold1][0] == hold1)
                            break;

                        else
                        {
                            disjointSet[(int)hold1][1] = 0;
                            hold1 = disjointSet[(int)hold1][0];
                        }
                    }
                    while (true)
                    {
                        if (disjointSet[(int)hold2][0] == hold2)
                        {
                            disjointSet[(int)hold2][0] = hold1;
                            break;
                        }
                        else
                        {
                            disjointSet[(int)hold2][1] = 0;
                            long temp = hold2;
                            hold2 = disjointSet[(int)hold2][0];
                            disjointSet[(int)temp][0] = hold1;
                        }
                    }

                    if (hold2 != hold1)
                    {
                        disjointSet[(int)hold1][1] += disjointSet[(int)hold2][1];
                        disjointSet[(int)hold2][1] = 0;
                    }

                    maxSize = Math.Max(maxSize, disjointSet[(int)hold1][1]);
                }
                answer[i] = maxSize;
            }
            return answer;
        }
    }

}

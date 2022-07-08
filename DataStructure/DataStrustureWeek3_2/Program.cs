using System;
using System.Collections.Generic;

namespace DataStrustureWeek3_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] a1 = Console.ReadLine().Split();
            string[] a2 = Console.ReadLine().Split();
            int p = int.Parse(a1[0]);
            int n = int.Parse(a1[1]);
            int[] jobs = new int[n];
            for (int i = 0; i < n; i++)
                jobs[i] = int.Parse(a2[i]);

            List<int> time = new List<int>();
            List<int[]> ans = new List<int[]>();
            for (int i = 0; i < p; i++)
            {
                time.Add(jobs[i]);
                ans.Add(new int[] { i, 0 });
            }
            int count;
            for (int i = p; i < n; i++)
            {
                count = FindMin(time, p);
                ans.Add(new int[] { count, time[count] });
                time[count] += jobs[i];                         
            }
            for (int i = 0; i < n; i++)
                Console.WriteLine(ans[i][0] + " " + ans[i][1]);  
        }
        public static int FindMin(List<int> a, int size)
        {
            int min = a[0];
            int index = 0;
            for (int i = 0; i < size; i++)
            {
                if (a[i] < min)
                {
                    index = i;
                    min = a[i];
                }
            }
            return index;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStrustureWeek1_3
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] a = Console.ReadLine().Split();
            int size = int.Parse(a[0]);
            int n = int.Parse(a[1]);
            List<int[]> packets = new List<int[]>();
            List<int[]> times = new List<int[]>();
            for (int i = 0; i < n; i++)
            {
                a = Console.ReadLine().Split();
                packets.Add(new int[] { int.Parse(a[0]), int.Parse(a[1]) });
            }
            int start_time = 0, finish = 0;
            for (int i = 0; i < n; i++)
            {
                if (times.Count() < size)
                { 
                    times.Add(packets[i]);
                    start_time = Math.Max(start_time, packets[i][0]);
                    times[times.Count() - 1][0] = start_time;
                    Console.WriteLine(times[times.Count() - 1][0]);
                    start_time += packets[i][1];
                    finish = times[0][0] + times[0][1];
                }
                else if(times.Count() == size)
                {
                    if (finish <= packets[i][0])
                    {
                        times.RemoveAt(0);
                        times.Add(packets[i]);
                        start_time = Math.Max(start_time, packets[i][0]);
                        times[times.Count() - 1][0] = start_time;
                        Console.WriteLine(times[times.Count() - 1][0]);
                        start_time += packets[i][1];
                        finish = times[0][0] + times[0][1];
                    }
                    else
                        Console.WriteLine(-1);
                }
                else
                    Console.WriteLine(-1);
            }
        }
    }
}

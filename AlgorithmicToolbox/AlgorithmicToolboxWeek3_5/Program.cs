using System;
using System.Collections.Generic;

namespace AlgoithmicToolboxWeek3_5
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] x = new string[2];
            int[] start = new int[n];
            int[] end = new int[n];
            int newStart, newEnd;
            List<int> ans = new List<int>();
            for (int i = 0; i < n; i++)
            {
                x = Console.ReadLine().Split();
                start[i] = int.Parse(x[0]);
                end[i] = int.Parse(x[1]);
            }

            int hold;
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (start[i] > start[j])
                    {
                        hold = start[i];
                        start[i] = start[j];
                        start[j] = hold;

                        hold = end[i];
                        end[i] = end[j];
                        end[j] = hold;
                    }
                }
            }
            for (int i = 0; i < n; i++)
            {
                newStart = start[i];
                newEnd = end[i];
                for (int j = i + 1; j < n; j++)
                {
                    if(start[j] >= newStart && start[j] <= newEnd)
                    {
                        newStart = start[j];
                        i++;
                        if (end[j] <= newEnd)
                        {
                            newEnd = end[j];
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                ans.Add(newStart);
            }
            Console.WriteLine(ans.Count);
            foreach (var item in ans)
            {
                Console.Write(item + " ");
            }
        }
    }
}

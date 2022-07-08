using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmicToolboxWeek5_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] count = new int[n + 1];
            string[] ans = new string[n + 1];
            ans[0] = "0";
            ans[1] = "1";
            count[0] = 0;
            count[1] = 0;
            for (int i = 2; i <= n; i++)
            {
                if (i % 3 == 0 && i % 2 == 0)
                {
                    if (count[i / 3] <= count[i / 2])
                    {
                        count[i] = count[i / 3] + 1;
                        ans[i] = ans[i / 3] + " " + i;
                    }
                    else
                    {
                        count[i] = count[i / 2] + 1;
                        ans[i] = ans[i / 2] + " " + i;
                    }
                }
                else if (i % 3 == 0)
                {
                    if (count[i - 1] < count[i / 3])
                    {
                        count[i] = count[i - 1] + 1;
                        ans[i] = ans[i - 1] + " " + i; 
                    }
                    else
                    {
                        count[i] = count[i / 3] + 1;
                        ans[i] = ans[i / 3] + " " + i;
                    }
                }
                else if (i % 2 == 0)
                {
                    if (count[i - 1] < count[i / 2])
                    {
                        count[i] = count[i - 1] + 1;
                        ans[i] = ans[i - 1] + " " + i;
                    }
                    else
                    {
                        count[i] = count[i / 2] + 1;
                        ans[i] = ans[i / 2] + " " + i;
                    }
                }
                else
                {
                    count[i] = count[i - 1] + 1;
                    ans[i] = ans[i - 1] + " " + i;
                }
            }
            Console.WriteLine(count[n]);
            Console.WriteLine(ans[n]);
        }
    }
}

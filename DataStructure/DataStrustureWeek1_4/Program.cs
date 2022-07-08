using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStrustureWeek1_4
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();
            Stack<int> maxs = new Stack<int>();
            int max = int.MinValue;
            string[] a = new string[2];
            List<int> ans = new List<int>();

            for (int i = 0; i < n; i++)
            {
                a = Console.ReadLine().Split();
                if (a[0] == "push")
                {
                    stack.Push(int.Parse(a[1]));
                    max = Math.Max(max, int.Parse(a[1]));
                    maxs.Push(max);
                }
                else if(a[0] == "pop")
                {
                    stack.Pop();
                    maxs.Pop();
                    max = maxs.First();
                }
                else if(a[0] == "max")
                {
                    ans.Add(max);
                }
            }

            foreach (var item in ans)
                Console.WriteLine(item);
        }
    }
}

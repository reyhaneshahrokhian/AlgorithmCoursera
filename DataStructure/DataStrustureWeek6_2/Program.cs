using System;
using System.Collections.Generic;

namespace DataStrustureWeek6_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            long[] keys = new long[n];
            long[] lefts = new long[n];
            long[] rights = new long[n];
            string[] a = new string[3];
            for (int i = 0; i < n; i++)
            {
                a = Console.ReadLine().Split();
                keys[i] = long.Parse(a[0]);
                lefts[i] = long.Parse(a[1]);
                rights[i] = long.Parse(a[2]);
            }
            if (n == 0)
                Console.WriteLine("CORRECT");

            else
            {
                List<long> inOrder = InOrder(keys, lefts, rights);
                bool flag = true;
                for (int i = 1; i < n; i++)
                {
                    if (inOrder[i] <= inOrder[i - 1])
                    {
                        flag = false;
                        break;
                    }
                }

                if (flag)
                    Console.WriteLine("CORRECT");

                else
                    Console.WriteLine("INCORRECT");
            }
        }
        public static List<long> InOrder(long[] keys, long[] lefts, long[] rights)
        {
            long count = 0;
            Stack<long> stack = new Stack<long>();
            List<long> ans = new List<long>();

            while (true)
            {
                if (count != -1)
                {
                    stack.Push(count);
                    count = lefts[count];
                }
                else if (stack.Count != 0)
                {
                    count = stack.Pop();
                    ans.Add(keys[count]);
                    count = rights[count];
                }
                else
                    break;
            }
            return ans;
        }
    }
}

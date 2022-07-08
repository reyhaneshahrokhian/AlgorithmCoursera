using System;
using System.Collections.Generic;

namespace DataStrustureWeek6_1
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
                lefts[i]= long.Parse(a[1]);
                rights[i]= long.Parse(a[2]);
            }
            foreach (var item in InOrder(keys, lefts, rights))
                Console.Write(item + " ");

            Console.WriteLine();
            foreach (var item in PreOrder(keys, lefts, rights))
                Console.Write(item + " ");

            Console.WriteLine();
            foreach (var item in PostOrder(keys, lefts, rights))
                Console.Write(item + " ");
        }
        public static List<long> PreOrder(long[] keys, long[] lefts, long[] rights)
        {
            long count = 0;
            Stack<long> stack = new Stack<long>();
            List<long> ans = new List<long>();

            while (true)
            {
                if (count != -1)
                {
                    ans.Add(keys[count]);
                    stack.Push(count);
                    count = lefts[count];
                }
                else if (stack.Count != 0)
                {
                    count = stack.Pop();
                    count = rights[count];
                }
                else
                    break;
            }
            return ans;
        }
        public static List<long> PostOrder(long[] keys, long[] lefts, long[] rights)
        {
            long count = 0;
            Stack<long> stack = new Stack<long>();
            Stack<long> index = new Stack<long>();
            index.Push(0);
            List<long> ans = new List<long>();

            while (index.Count != 0)
            {
                count = index.Pop();
                stack.Push(keys[count]);
                if (lefts[count] != -1)
                    index.Push(lefts[count]);

                if (rights[count] != -1)
                    index.Push(rights[count]);

            }
            while (stack.Count != 0)
                ans.Add(stack.Pop());

            return ans;
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

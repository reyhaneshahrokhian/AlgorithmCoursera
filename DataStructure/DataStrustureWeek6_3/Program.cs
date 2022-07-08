using System;
using System.Collections.Generic;

namespace DataStrustureWeek6_3
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

            else if(Check(keys, rights, lefts, 0, long.MinValue, long.MaxValue))
                Console.WriteLine("CORRECT");

            else
                Console.WriteLine("INCORRECT");           
        }
        public static bool Check(long[] keys, long[] rights, long[] lefts, long hold, long min, long max)
        {
            if (keys[hold] < min || keys[hold] >= max)
                return false;

            if (rights[hold] != -1 && lefts[hold] != -1)
                return Check(keys, rights, lefts, rights[hold], keys[hold], max) && Check(keys, rights, lefts, lefts[hold], min, keys[hold]);

            if (rights[hold] != -1)
                return Check(keys, rights, lefts, rights[hold], keys[hold], max);

            if (lefts[hold] != -1)
                return Check(keys, rights, lefts, lefts[hold], min, keys[hold]);

            return true;
        }
    }
}

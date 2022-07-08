using System;

namespace DataStrustureWeek6_5
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());
            string[] a = new string[3];
            int i, j, k;
            string sub;
            for (int z = 0; z < n; z++)
            {
                a = Console.ReadLine().Split();
                i = int.Parse(a[0]);
                j = int.Parse(a[1]);
                k = int.Parse(a[2]);

                sub = s.Substring(i, j - i + 1);
                s = s.Remove(i, j - i + 1);
                s = s.Insert(k, sub);
            }
            Console.WriteLine(s);
        }
    }
}

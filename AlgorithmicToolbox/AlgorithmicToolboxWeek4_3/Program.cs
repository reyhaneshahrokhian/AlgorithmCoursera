using System;

namespace AlgorithmicToolboxWeek4_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] xx = Console.ReadLine().Split();
            int[] x = new int[n];
            for (int i = 0; i < n; i++)
                x[i] = int.Parse(xx[i]);
            Array.Sort(x);
            int ans = 0;
            for (int i = 0; i < (n - n/2); i++)
            {
                if (x[i + (n / 2)] == x[i])
                    ans = 1;
            }
            Console.WriteLine(ans);
        }
    }
}

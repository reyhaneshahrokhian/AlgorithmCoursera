using System;

namespace AlgoithmicToolboxWeek2_1
{
    class Program
    {
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());
            Console.WriteLine(Fibonatchi(n));
        }
        static ulong Fibonatchi(long n)
        {
            ulong f0 = 0, f1 = 1, hold = 0;
            if (n == 0)
                return f0;

            else if (n == 1)
                return f1;

            else
            {
                for (int i = 1; i <= n; i++)
                {
                    hold = f1;
                    f1 = f0 + f1;
                    f0 = hold;
                }
                return f0;
            }
        }
    }
}

using System;

namespace AlgoithmicToolboxWeek2_5
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] entire = Console.ReadLine().Split();
            Console.WriteLine(Fibonatchi(long.Parse(entire[0]), long.Parse(entire[1])));
        }
        static long Fibonatchi(long n, long m)
        {
            long f0 = 0, f1 = 1, hold = 0;
            if (n == 0)
                return f0;

            else if (n == 1)
                return f1;

            else
            {
                for (int i = 1; i <= n % getRangeFibonatchi(m); i++)
                {
                    hold = f1 % m;
                    f1 = (f0 + f1) % m;
                    f0 = hold;
                }
                return f0;
            }
        }
        static int getRangeFibonatchi(long m)
        {
            long f0 = 0, f1 = 1, hold = 0;

            for (int i = 1; ; i++)
            {
                hold = f1;
                f1 = (f0 + f1) % m;
                f0 = hold;
                if (f0 == 0 && f1 == 1)
                    return i;
            }
        }
    }
}

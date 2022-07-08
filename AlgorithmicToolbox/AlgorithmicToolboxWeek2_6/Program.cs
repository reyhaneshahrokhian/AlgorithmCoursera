using System;

namespace AlgoithmicToolboxWeek2_6
{
    class Program
    {
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());
            Console.WriteLine(SumFibonatchiLast(n));
        }

        private static int SumFibonatchiLast(long n)
        {
            int f0 = 0, f1 = 1, hold = 0, ans = 0;
            if (n == 0)
                return f0;

            else if (n == 1)
                return f1;

            else
            {
                for (int i = 1; i <= n % getRangeFibonatchi(); i++)
                {
                    hold = f1 % 10;
                    f1 = (f0 + f1) % 10;
                    f0 = hold % 10;
                    ans += f0;
                    ans %= 10;
                }
                return ans;
            }
        }
        static int getRangeFibonatchi()
        {
            long f0 = 0, f1 = 1, hold = 0;

            for (int i = 1; ; i++)
            {
                hold = f1;
                f1 = (f0 + f1) % 10;
                f0 = hold;
                if (f0 == 0 && f1 == 1)
                    return i;
            }
        }
    }
}

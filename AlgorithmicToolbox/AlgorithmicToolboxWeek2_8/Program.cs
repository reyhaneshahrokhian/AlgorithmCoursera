using System;

namespace AlgoithmicToolboxWeek2_8
{
    class Program
    {
        static void Main(string[] args)
        {
            ulong n = ulong.Parse(Console.ReadLine());
            Console.WriteLine(SumSquareFibonatchiLast(n));
        }

        private static ulong SumSquareFibonatchiLast(ulong n)
        {
            ulong f0 = 0, f1 = 1, hold = 0, ans = 0;
            if (n == 0)
                return f0;

            else if (n == 1)
                return f1;

            else
            {
                for (ulong i = 1; i <= n % (ulong)getRangeFibonatchi(); i++)
                {
                    hold = f1 % 10;
                    f1 = (f0 + f1) % 10;
                    f0 = hold % 10;
                    ans += ((f0 % 10) * (f0 % 10)) % 10;
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

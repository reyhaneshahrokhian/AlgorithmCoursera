using System;

namespace AlgoithmicToolboxWeek2_7
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] entire = Console.ReadLine().Split();
            Console.WriteLine(SumRangFibonatchi(long.Parse(entire[0]), long.Parse(entire[1])));
        }

        static int SumRangFibonatchi(long start, long end)
        {
            int f0 = 0, f1 = 1, hold = 0, ans = 0, ans2 = 0, finall = 0;

            for (int i = 1; i <= end % getRangeFibonatchi(); i++)
            {
                hold = f1 % 10;
                f1 = (f0 + f1) % 10;
                f0 = hold % 10;
                ans += f0;
            }
            f0 = 0;
            f1 = 1;
            hold = 0;
            for (int i = 1; i < start % getRangeFibonatchi(); i++)
            {
                hold = f1 % 10;
                f1 = (f0 + f1) % 10;
                f0 = hold % 10;
                ans2 += f0;
            }
            finall = ans - ans2;
            while (finall < 0)
            {
                finall += 10;
            }
            return finall % 10;
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

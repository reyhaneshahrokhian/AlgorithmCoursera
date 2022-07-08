using System;

namespace AlgoithmicToolboxWeek2_4
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] entire = Console.ReadLine().Split();
            Console.WriteLine(LCM(long.Parse(entire[0]), long.Parse(entire[1])));
        }
        public static long LCM(long a, long b)
        {
            for(long i = b; i<=(a * b); i += b)
            {
                if (i % a == 0)
                    return i;
            }
            return a * b;
        }
    }
}

using System;

namespace AlgoithmicToolboxWeek2_3
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] entire = Console.ReadLine().Split();
            Console.WriteLine(GCD(int.Parse(entire[0]), int.Parse(entire[1])));
        }
        public static int GCD(int a, int b)
        {
            if (b == 0)
                return a;

            else 
            {
                a = a % b;
            }

            return GCD(b, a);
        }
    }
}

using System;

namespace AlgorithmicToolboxWeek1_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] xx = Console.ReadLine().Split();
            long[] entire = new long[n];
            long max1 = 0 , max2 = 0 , index1 = 0;

            for (int i = 0; i < n; i++)
            {
                entire[i] = int.Parse(xx[i]);
            }

            for (int i = 0; i < n; i++)
            {
                if (entire[i] >= max1)
                {
                    max1 = entire[i];
                    index1 = i;
                }
            }
            entire[index1] = -1;

            for (int i = 0; i < n; i++)
            {
                if (entire[i] >= max2)
                    max2 = entire[i];
            }

            Console.WriteLine(max1 * max2);
        }
    }
}

using System;

namespace AlgoithmicToolboxWeek3_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int d = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            string[] entire = Console.ReadLine().Split();
            int[] stop = new int[n + 2];
            int count = 0, hold = 0;
            for (int i = 0; i < n; i++)
            {
                stop[i + 1] = int.Parse(entire[i]);
            }
            stop[0] = 0;
            stop[n + 1] = d;
            for (int i = 1; i < (n + 2); i++)
            {
                if((stop[i] - stop[i -1]) > m)
                {
                    count = -1;
                    break;
                }
                else if((stop[i] - hold) > m)
                {
                    i--;
                    hold = stop[i];
                    count++;
                }
            }
            Console.WriteLine(count);
        }
    }
}

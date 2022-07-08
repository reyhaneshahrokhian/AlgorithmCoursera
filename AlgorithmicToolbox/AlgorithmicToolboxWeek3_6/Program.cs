using System;

namespace AlgoithmicToolboxWeek3_6
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] x = new int[n / 2 + 2];
            x[0] = n - 1;
            for (int i = 1; n > 0; i++)
            {
                if (n <= x[i - 1])
                {
                    x[i - 1] += n;
                    n = 0;
                    break;
                }
                else if (n > x[i - 1])
                {
                    x[i] = i;
                    n -= i;
                }               
            }
            int count = 0;
            for (int i = 1; i < x.Length; i++)
            {
                if (x[i] != 0)
                    count++;
                if (x[i] == 0)
                    break;
            }
            Console.WriteLine(count);

            for (int i = 1; i < x.Length; i++)
            {
                if (x[i] != 0)           
                    Console.Write(x[i] + " ");
                if (x[i] == 0)
                    break;
            }
        }
    }
}

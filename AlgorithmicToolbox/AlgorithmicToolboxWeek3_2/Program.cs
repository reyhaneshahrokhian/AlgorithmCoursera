using System;

namespace AlgoithmicToolboxWeek3_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] entire = Console.ReadLine().Split();
            int n = int.Parse(entire[0]);
            int w = int.Parse(entire[1]);
            string[] input = new string[2];
            int[] value = new int[n];
            int[] weight = new int[n];
            double[] density = new double[n];
            double ans = 0, temp;
            int hold, count = 0;

            for (int i = 0; i < n; i++)
            {
                input = Console.ReadLine().Split();
                value[i] = int.Parse(input[0]);
                weight[i] = int.Parse(input[1]);
                density[i] = (double)value[i] / (double)weight[i];
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < (n - 1); j++)
                {
                    if (density[j + 1] > density[j])
                    {
                        temp = density[j];
                        density[j] = density[j + 1];
                        density[j + 1] = temp;

                        hold = value[j];
                        value[j] = value[j + 1];
                        value[j + 1] = hold;

                        hold = weight[j];
                        weight[j] = weight[j + 1];
                        weight[j + 1] = hold;
                    }
                }
            }
            for (int i = 0; (count < w) && (i < n); i++)
            {
                if(weight[i]> (w -count))
                {
                    ans += ((double)value[i] * (w - count)) / (double)weight[i];
                    count = w;
                }
                else
                {
                    ans += value[i];
                    count += weight[i];
                }
            }
            Console.WriteLine(Math.Round(ans, 4));
        }
    }
}

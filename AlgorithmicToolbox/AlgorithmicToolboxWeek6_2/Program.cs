using System;

namespace AlgorithmicToolboxWeek6_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] xx = Console.ReadLine().Split();
            int[] a = new int[n];
            for (int i = 0; i < n; i++)
                a[i] = int.Parse(xx[i]);

            Console.WriteLine(PartitioningSouvenires(a, n));
        }
        public static int PartitioningSouvenires(int[] a, int n)
        {
            if (n < 3)
                return 0;

            else
            {
                int sum = 0;
                for (int i = 0; i < n; i++)
                    sum += a[i];

                if (sum % 3 != 0)
                    return 0;

                else
                {
                    int[,,] partition = new int[n + 1, sum / 3 + 1, sum / 3 + 1];
                    for (int i = 0; i <= n; i++)
                        partition[i, 0, 0] = 1;

                    for (int i = 1; i <= n; i++)
                    {
                        for (int j = 0; j <= sum / 3; j++)
                        {
                            for (int k = 0; k <= sum / 3; k++)
                            {
                                partition[i, j, k] = partition[i - 1, j, k];
                                if (j >= a[i - 1])
                                    if (partition[i - 1, j - a[i - 1], k] == 1)
                                        partition[i, j, k] = 1;

                                if (k >= a[i - 1])
                                    if (partition[i - 1, j, k - a[i - 1]] == 1)
                                        partition[i, j, k] = 1;
                            }
                        }
                    }
                    return partition[n, sum / 3, sum / 3];
                }
            }
        }
    }
}

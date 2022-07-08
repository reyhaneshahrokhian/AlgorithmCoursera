using System;

namespace AlgorithmicToolboxWeek6_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] first = Console.ReadLine().Split();
            string[] second = Console.ReadLine().Split();
            int capacity = int.Parse(first[0]);
            int n = int.Parse(first[1]);
            int[] Ws = new int[n];
            for (int i = 0; i < n; i++)
                Ws[i] = int.Parse(second[i]);

            Console.WriteLine(MaximumGold(Ws, n, capacity));
        }
        public static int MaximumGold(int[] weights, int n, int capacity)
        {
            int[,] ans = new int[capacity + 1, n + 1];
            for (int i = 0; i <= capacity; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    if (i == 0 || j == 0)
                        ans[i, j] = 0;

                    else if (i - weights[j - 1] >= 0)
                        ans[i, j] = Math.Max(ans[i, j - 1], ans[i - weights[j - 1], j - 1] + weights[j - 1]);

                    else
                        ans[i, j] = ans[i, j - 1];
                }
            }

            return ans[capacity, n];
        }
    }
}

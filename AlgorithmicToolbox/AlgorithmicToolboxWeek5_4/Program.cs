 using System;

namespace AlgorithmicToolboxWeek5_4
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] x = Console.ReadLine().Split();
            int m = int.Parse(Console.ReadLine());
            string[] y = Console.ReadLine().Split();
            int[] first = new int[n];
            int[] second = new int[m];
            for (int i = 0; i < n; i++)
                first[i] = int.Parse(x[i]);
            for (int i = 0; i < m; i++)
                second[i] = int.Parse(y[i]);

            Console.WriteLine(longestCommon(first, second, n, m));
        }
        public static int longestCommon(int[] first, int[] second, int n, int m)
        {
            int[,] ans = new int[n + 1, m + 1];

            for (int i = 0; i <= n; i++)
            {
                for (int j = 0; j <= m; j++)
                {
                    if (i == 0 || j == 0)
                        ans[i, j] = 0;

                    else if (first[i - 1] == second[j - 1])
                        ans[i, j] = 1 + ans[i - 1, j - 1];

                    else
                        ans[i, j] = Math.Max(ans[i, j - 1], ans[i - 1, j]);
                }
            }

            return ans[n, m];
        }
    }
}

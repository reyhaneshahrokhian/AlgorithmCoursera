using System;

namespace AlgorithmicToolboxWeek5_5
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] x = Console.ReadLine().Split();
            int m = int.Parse(Console.ReadLine());
            string[] y = Console.ReadLine().Split();
            int l = int.Parse(Console.ReadLine());
            string[] z = Console.ReadLine().Split();
            int[] first = new int[n];
            int[] second = new int[m];
            int[] third = new int[l];
            for (int i = 0; i < n; i++)
                first[i] = int.Parse(x[i]);
            for (int i = 0; i < m; i++)
                second[i] = int.Parse(y[i]);
            for (int i = 0; i < l; i++)
                third[i] = int.Parse(z[i]);

            Console.WriteLine(longestCommon(first, second, third, n, m, l));
        }
        public static int longestCommon(int[] first, int[] second,int[] third, int n, int m, int l)
        {
            int[,,] ans = new int[n + 1, m + 1, l + 1];

            for (int i = 0; i <= n; i++)
            {
                for (int j = 0; j <= m; j++)
                {
                    for (int k = 0; k <= l; k++)
                    {
                        if (i == 0 || j == 0 || k == 0)
                            ans[i, j, k] = 0;

                        else if (first[i - 1] == second[j - 1] && second[j - 1] == third[k - 1])
                            ans[i, j, k] = 1 + ans[i - 1, j - 1, k - 1];

                        else
                            ans[i, j, k] = Math.Max(ans[i, j, k - 1], Math.Max(ans[i, j - 1, k], ans[i - 1, j , k]));
                    }
                }
            }

            return ans[n, m, l];
        }
    }
}

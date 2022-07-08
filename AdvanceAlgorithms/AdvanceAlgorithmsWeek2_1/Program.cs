using System;
using System.Collections.Generic;
using System.Linq;

namespace AdvanceAlgorithmsWeek2_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double[,] mat = new double[n, n + 1];
            for (int i = 0; i < n; i++)
            {
                string[] x = Console.ReadLine().Split();
                for (int j = 0; j <= n; j++)
                    mat[i, j] = double.Parse(x[j]);
            }
            foreach (var item in gaussianElimination(mat, n))
            {
                Console.Write(item + " ");
            }
        }
        public static double[] gaussianElimination(double[,] mat, int n)
        {

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    double xx = mat[j, i] / mat[i, i];
                    for (int k = 0; k <= n; k++)
                    {
                        mat[j, k] -= xx * mat[i, k];
                    }
                }
            }
            double[] ans = new double[n];
            ans[n - 1] = mat[n - 1, n] / mat[n - 1, n - 1];
            for (int i = n - 2; i >= 0; i--)
            {
                ans[i] = mat[i, n];
                for (int j = i + 1; j < n; j++)
                {
                    ans[i] -= mat[i, j] * ans[j];
                }
                ans[i] /= mat[i, i];
            }
            for (int i = 0; i < n; i++)
            {
                if (ans[i] > 0)
                {
                    double check = ans[i] - Math.Floor(ans[i]);
                    if (check < 0.25)
                        ans[i] = Math.Floor(ans[i]);

                    else if (check > 0.75 && ans[i] > 0)
                        ans[i] = Math.Floor(ans[i]) + 1;

                    else
                        ans[i] = Math.Floor(ans[i]) + 0.5;
                }
                else if (ans[i] < 0)
                {
                    double check = -ans[i] + Math.Ceiling(ans[i]);
                    if (check < 0.25)
                        ans[i] = Math.Ceiling(ans[i]);

                    else if (check > 0.75)
                        ans[i] = Math.Floor(ans[i]);

                    else
                        ans[i] = Math.Floor(ans[i]) + 0.5;
                }
                if (ans[i] == -0)
                    ans[i] = 0;
            }
            return ans;
        }
    }
}

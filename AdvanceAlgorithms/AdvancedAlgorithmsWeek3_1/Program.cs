using System;
using System.Collections.Generic;

namespace AdvancedAlgorithmsWeek3_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] x = Console.ReadLine().Split();
            int n = int.Parse(x[0]);
            int m = int.Parse(x[1]);
            long[,] matrix = new long[m,2];
            for (int i = 0; i < m; i++)
            {
                x = Console.ReadLine().Split();
                matrix[i, 0] = int.Parse(x[0]);
                matrix[i, 1] = int.Parse(x[1]);
            }
            foreach (var item in SAT(n,m,matrix))
            {
                Console.WriteLine(item);
            }
        }
        public static List<string> SAT(int Vertices, int E, long[,] matrix)
        {
            List<string> ans = new List<string>();
            int c = 3 * E + Vertices;
            int V = Vertices * 3;
            ans.Add($"{c} {V}");
            bool[] Checked = new bool[Vertices + 1];
            for (int i = 0; i < E; i++)
            {
                ans.Add($"{-((matrix[i, 0] - 1) * 3 + 1)} {-((matrix[i, 1] - 1) * 3 + 1)}");
                ans.Add($"{-((matrix[i, 0] - 1) * 3 + 2)} {-((matrix[i, 1] - 1) * 3 + 2)}");
                ans.Add($"{-(matrix[i, 0] * 3)} {-(matrix[i, 1] * 3)}");

                if (!Checked[(int)matrix[i, 0]])
                {
                    Checked[(int)matrix[i, 0]] = true;

                    ans.Add($"{(matrix[i, 0] - 1) * 3 + 1} {(matrix[i, 0] - 1) * 3 + 2} {matrix[i, 0] * 3}");
                    ans.Add($"{-((matrix[i, 0] - 1) * 3 + 1)} {-((matrix[i, 0] - 1) * 3 + 2)}");
                    ans.Add($"{-((matrix[i, 0] - 1) * 3 + 1)} {-(matrix[i, 0] * 3)}");
                    ans.Add($"{-((matrix[i, 0] - 1) * 3 + 2)} {-(matrix[i, 0] * 3)}");
                }
                if (!Checked[(int)matrix[i, 1]])
                {
                    Checked[(int)matrix[i, 1]] = true;

                    ans.Add($"{(matrix[i, 1] - 1) * 3 + 1} {(matrix[i, 1] - 1) * 3 + 2} {matrix[i, 1] * 3}");
                    ans.Add($"{-((matrix[i, 1] - 1) * 3 + 1)} {-((matrix[i, 1] - 1) * 3 + 2)}");
                    ans.Add($"{-((matrix[i, 1] - 1) * 3 + 1)} {-(matrix[i, 1] * 3)}");
                    ans.Add($"{-((matrix[i, 1] - 1) * 3 + 2)} {-(matrix[i, 1] * 3)}");
                }
            }
            return ans;
        }
    }
}

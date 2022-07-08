using System;

namespace AlgorithmicToolboxWeek6_3
{
    class Program
    {
        static void Main(string[] args)
        {
            string problem = Console.ReadLine();
            int n = problem.Length;
            long[] digits = new long[n / 2 + 1];
            string[] operations = new string[n / 2];
            for (int i = 0; i < (n / 2 + 1); i++)
                digits[i] = int.Parse(problem.Substring(2 * i, 1));

            for (int i = 0; i < (n / 2); i++)
                operations[i] = problem.Substring(2 * i + 1, 1);

            Console.WriteLine(parentheses(digits, operations, (n / 2 + 1)));
        }
        public static long parentheses(long[] digits,string[] operations, int n)
        {
            long[,] min = new long[n, n];
            long[,] max = new long[n, n];
            for (int i = 0; i < n; i++)
            {
                min[i, i] = digits[i];
                max[i, i] = digits[i];
            }

            for (int i = 0; i < (n - 1); i++)
            {
                for (int j = 0; j < (n - i - 1); j++)
                {
                    int k = i + j + 1;
                    long minimum = int.MaxValue;
                    long maximum = int.MinValue;
                    long a, b, c, d;
                    for (int s = j; s < k; s++)
                    {
                        a = Operations(max[j, s], max[s + 1, k], operations[s]);
                        b = Operations(max[j, s], min[s + 1, k], operations[s]);
                        c = Operations(min[j, s], max[s + 1, k], operations[s]);
                        d = Operations(min[j, s], min[s + 1, k], operations[s]);
                        minimum = Math.Min(minimum, Math.Min(a, Math.Min(b, Math.Min(c, d))));
                        maximum = Math.Max(maximum, Math.Max(a, Math.Max(b, Math.Max(c, d))));
                    }
                    min[j, k] = minimum;
                    max[j, k] = maximum;
                }
            }
            return max[0, n - 1];
        }
        public static long Operations(long a, long b,string op)
        {
            if (op == "+")
                return a + b;

            else if (op == "-")
                return a - b;

            else if (op == "*")
                return a * b;

            else
                return 0;
        }
    }
}

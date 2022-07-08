using System;

namespace AlgorithmicToolboxWeek5_3
{
    class Program
    {
        static void Main(string[] args)
        {
            string first = Console.ReadLine();
            string second = Console.ReadLine();
            Console.WriteLine(EditDistance(first, second));
        }
        public static int EditDistance(string first, string second)
        {
            int first_size = first.Length;
            int second_size = second.Length;
            int[,] ans = new int[first_size + 1, second_size + 1];

            for (int i = 0; i <= first_size; i++)
            {
                for (int j = 0; j <= second_size; j++)
                {
                    if (i == 0)
                        ans[i, j] = j;

                    else if (j == 0)
                        ans[i, j] = i;

                    else if (first[i - 1] == second[j - 1])
                        ans[i, j] = ans[i - 1, j - 1];

                    else
                        ans[i, j] = 1 + Math.Min(ans[i - 1, j - 1], Math.Min(ans[i, j - 1], ans[i - 1, j]));
                }
            }

            return ans[first_size, second_size];
        }
    }
}

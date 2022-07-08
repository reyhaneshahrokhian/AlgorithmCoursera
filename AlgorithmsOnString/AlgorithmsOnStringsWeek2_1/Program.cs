using System;
using System.Collections.Generic;

namespace AlgorithmsOnStringsWeek2_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            Console.WriteLine(Solve(text));
        }
        public static string Solve(string text)
        {
            List<string> matrix = new List<string>();
            matrix.Add(text);
            for (int i = 1; i < text.Length; i++)
            {
                matrix.Add(text.Substring(i) + text.Substring(0, i));
            }
            matrix.Sort();
            string ans = "";
            for (int i = 0; i < text.Length; i++)
            {
                ans += matrix[i][text.Length - 1];
            }
            return ans;
        }
    }
}

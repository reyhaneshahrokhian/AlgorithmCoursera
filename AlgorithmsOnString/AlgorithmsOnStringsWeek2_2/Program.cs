using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsOnStringsWeek2_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string bwt = Console.ReadLine();
            Console.WriteLine(Solve(bwt));
        }
        public static string Solve(string bwt)
        {
            List<char> firstColumn = new List<char>();
            List<int> lastColumn = new List<int>();
            Dictionary<string, int> firstColmnDictionory = new Dictionary<string, int>();
            int[] first = new int[256];
            int[] second = new int[256];
            for (int i = 0; i < 256; i++)
            {
                first[i] = 0;
                second[i] = 0;
            }
            for (int i = 0; i < bwt.Length; i++) firstColumn.Add(bwt[i]);

            firstColumn.Sort();
            for (int i = 0; i < bwt.Length; i++)
            {
                first[firstColumn[i]] += 1;
                firstColmnDictionory[firstColumn[i].ToString() + first[firstColumn[i]].ToString()] = i;
            }
            for (int i = 0; i < bwt.Length; i++)
            {
                second[bwt[i]] += 1;
                lastColumn.Add(second[bwt[i]]);
            }

            int temp = 0;
            List<char> ans = new List<char>();
            for (int i = 0; i < bwt.Length - 1; i++)
            {
                ans.Add(bwt[temp]);
                temp = firstColmnDictionory[bwt[temp].ToString() + lastColumn[temp].ToString()];
            }
            ans.Reverse();
            ans.Add('$');

            return new string(ans.ToArray());
        }
    }
}

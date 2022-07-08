using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsOnStringsWeek2_4
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            int[] ans = new int[text.Length];
            List<Tuple<string, int>> SuffixArray = new List<Tuple<string, int>>();
            for (int i = 0; i < text.Length; i++)
            {
                SuffixArray.Add(new Tuple<string, int>(text.Substring(i, text.Length - i), i));
            }
            SuffixArray = SuffixArray.OrderBy(x => x.Item1).ToList();
            for (int i = 0; i < text.Length; i++)
            {
                Console.WriteLine(SuffixArray[i].Item2);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsOnStringsWeek4_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = Console.ReadLine();
            string text = Console.ReadLine();
            List<int> ans = findPattern(text, pattern);
            foreach (var item in ans)
            {
                Console.Write(item + " ");
            }
        }
        public static List<int> findPattern(string text, string pattern)
        {
            List<int> ans = new List<int>();
            string pt = pattern + "$" + text;

            int border = 0;
            int[] s = new int[pt.Length];
            for (int i = 1; i < pt.Length; i++)
            {
                while (border > 0 && pt[i] != pt[border])
                {
                    border = s[border - 1];
                }
                if (pt[i] == pt[border])
                {
                    border++;
                    s[i] = border;
                }
                if (border == 0)
                {
                    s[i] = 0;
                }
            }
            for (int i = pattern.Length + 1; i < pt.Length; i++)
            {
                if (s[i] == pattern.Length)
                {
                    ans.Add(i - 2 * pattern.Length);
                }
            }
            return ans;
        }
    }
}

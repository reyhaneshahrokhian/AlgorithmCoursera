using System;
using System.Linq;
using System.Collections.Generic;

namespace AlgorithmsOnStringsWeek1_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] patterns = new string[n];
            for (int i = 0; i < n; i++)
            {
                patterns[i] = Console.ReadLine();
            }
            List<Trie> tries = ConstructTrie(patterns);
            for (int i = 0; i < tries.Count(); i++)
            {
                foreach (var item in tries[i].edges)
                {
                    if(item.Item1 != '$')
                    {
                        Console.WriteLine(i + "->" + item.Item2 + ":" + item.Item1);
                    }
                }
            }
        }
        public static List<Trie> ConstructTrie(string[] patterns)
        {
            List<Trie> tries = new List<Trie>();
            for (int i = 0; i < patterns.Length; i++)
            {
                int x = 0;
                for (int j = 0; j < patterns[i].Length; j++)
                {
                    bool match_found = false;
                    if (x < tries.Count())
                    {
                        foreach (var item in tries[x].edges)
                        {
                            if (item.Item1 == patterns[i][j])
                            {
                                x = item.Item2;
                                match_found = true;
                                break;
                            }
                        }
                        if (!match_found)
                        {
                            tries[x].edges.Add(new Tuple<char, int>(patterns[i][j], tries.Count()));
                            x = tries.Count();
                        }
                    }
                    else
                    {
                        Trie xx = new Trie(new List<Tuple<char, int>>());
                        xx.edges.Add(new Tuple<char, int>(patterns[i][j], tries.Count() + 1));
                        tries.Add(xx);
                        x = tries.Count();
                    }
                }
                Trie yy = new Trie(new List<Tuple<char, int>>());
                yy.edges.Add(new Tuple<char, int>('$', -1));
                tries.Add(yy);
            }
            return tries;
        }
    }
    public class Trie
    {
        public List<Tuple<char, int>> edges;
        public Trie(List<Tuple<char, int>> edges)
        {
            this.edges = new List<Tuple<char, int>>();
        }
    }
}

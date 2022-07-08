using System;
using System.Collections.Generic;

namespace AlgorithmsOnStringsWeek1_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string Text = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());
            List<string> patterns = new List<string>();
            for (int i = 0; i < n; i++)
            {
                patterns.Add(Console.ReadLine());
            }
            foreach (var item in PrefixTrieMatching(Text,patterns))
            {
                Console.Write(item + " ");
            }
        }
        public class Node
        {
            public int[] next = new int[4];
            public Node()
            {
                for (int i = 0; i < 4; i++)
                {
                    next[i] = -1;
                }
            }
            public bool isLeaf()
            {
                return (next[0] == -1 && next[1] == -1 && next[2] == -1 && next[3] == -1);
            }
        }
        public static int letterToIndex(char letter)
        {
            switch (letter)
            {
                case 'A':
                    return 0;
                case 'C':
                    return 1;
                case 'G':
                    return 2;
                case 'T':
                    return 3;     
                default: 
                    return -1;
            }
        }
        public static void TrieConstruction(List<string> patterns, List<Node> t)
        {
            for (int i = 0; i < patterns.Count; i++)
            {
                int x = 0;
                for (int j = 0; j < patterns[i].Length; j++)
                {
                    int index = letterToIndex(patterns[i][j]);
                    if (x >= t.Count)
                    {
                        for (int k = t.Count; k < x + 1; k++)
                        {
                            t.Add(new Node());
                        }
                    }
                    if (t[x].next[index] != -1)
                        x = t[x].next[index];
                    
                    else
                    {
                        t[x].next[index] = t.Count;
                        x = t[x].next[index];
                        for (int k = t.Count; k < x + 1; k++)
                        {
                            t.Add(new Node());
                        }
                    }
                }
            }

        }
        public static List<int> PrefixTrieMatching(string text, List<string> patterns)
        {
            List<int> ans = new List<int>();
            List<Node> t = new List<Node>();
            TrieConstruction(patterns, t);

            for (int i = 0; i < text.Length; i++)
            {
                int index = letterToIndex(text[i]);
                int x = 0;
                if (t[x].next[index] != -1)
                {
                    bool found = true;
                    for (int j = i; !t[x].isLeaf(); j++)
                    {
                        if (j >= text.Length)
                        {
                            found = false;
                            break;
                        }
                        index = letterToIndex(text[j]);
                        if (t[x].next[index] != -1)
                        {
                            x = t[x].next[index];
                        }
                        else
                        {
                            found = false;
                            break;
                        }
                    }
                    if (found)
                    {
                        ans.Add(i);
                    }
                }
            }

            return ans;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsOnStringsWeek4_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            foreach (var item in SuffixArray(text))
            {
                Console.Write(item + " ");
            }           
        }
        public static int[] SuffixArray(string text)
        {
            int[] order = CountingSort(text);
            int[] sorted = new int[text.Length];
            int count = 0;
            sorted[order[0]] = count;
            for (int i = 1; i < text.Length; i++)
            {
                if (text[order[i]] == text[order[i - 1]])
                    sorted[order[i]] = count;
                else
                    sorted[order[i]] = ++count;
            }
            for (int i = 1; i <= text.Length; i *= 2)
            {
                order = sort_double(text, i, order, sorted);
                sorted = update_class(order, sorted, i);
            }

            return order;
        }
        public static int[] sort_double(string text, int index, int[] order, int[] sorted)
        {
            int[] newOrder = new int[text.Length];
            int[] temp = new int[text.Length];
            for (int i = 0; i < text.Length; i++) temp[i] = 0;

            for (int i = 0; i < text.Length; i++) temp[sorted[i]]++;
            
            for (int i = 1; i < text.Length; i++) temp[i] += temp[i - 1];
            
            for (int i = text.Length - 1; i >= 0; i--)
            {
                int start = (order[i] - index + text.Length) % text.Length;
                newOrder[--temp[sorted[start]]] = start;
            }

            return newOrder;
        }
        public static int[] update_class(int[] order, int[] sorted, int index)
        {
            int[] newSorted = new int[order.Length];
            int count = 0;
            newSorted[order[0]] = count;
            for (int i = 1; i < order.Length; i++)
            {
                int cur = order[i];
                int cur_mid = (order[i] + index) % order.Length;
                int prev = order[i - 1];
                int prev_mid = (order[i - 1] + index) % order.Length;
                if (sorted[cur] != sorted[prev] || sorted[cur_mid] != sorted[prev_mid])
                {
                    newSorted[order[i]] = ++count;
                }
                else
                {
                    newSorted[order[i]] = count;
                }
            }
            return newSorted;
        }
        public static int[] CountingSort(string text)
        {
            int[] ans = new int[text.Length];
            int[] temp = new int[5];
            for (int i = 0; i < 5; i++) temp[i] = 0;

            for (int i = 0; i < text.Length; i++) temp[charToIndex(text[i])]++;

            for (int i = 1; i < temp.Length; i++) temp[i] += temp[i - 1];

            for (int i = text.Length - 1; i >= 0; i--) ans[--temp[charToIndex(text[i])]] = i;

            return ans;
        }
        public static int charToIndex(char x)
        {
            switch (x)
            {
                case '$':
                    return 0;
                case 'A':
                    return 1;
                case 'C':
                    return 2;
                case 'G':
                    return 3;
                case 'T':
                    return 4;
                default:
                    return 100;
            }
        }
    }
}

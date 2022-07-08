using System;
using System.Collections.Generic;
using System.Linq;


namespace DataStrustureWeek3_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] a = new int[n];
            int i = 0;
            List<int[]> answer = new List<int[]>();

            foreach (var item in Console.ReadLine().Split())
            {
                a[i] = int.Parse(item);
                i++;
            }

            int hold = n / 2 - 1;
            while (hold >= 0)
            {
                MinHeap(a, n, hold, answer);
                hold--;
            }

            Console.WriteLine(answer.Count());
            for (int j = 0; j < answer.Count(); j++)
            {
                Console.WriteLine(answer[j][0] + " " + answer[j][1]);
            }
        }
        public static void MinHeap(int[] a, int n, int hold, List<int[]> answer)
        {
            int right, left, temp = -1;
            left = 2 * hold + 1;
            right = 2 * hold + 2;

            if (left < n && a[left] < a[hold])
            {
                if (right < n && a[right] < a[left])
                {
                    Swap(a, hold, right);
                    answer.Add(new int[] { hold, right });
                    temp = right;
                }
                else
                {
                    Swap(a, hold, left);
                    answer.Add(new int[] { hold, left });
                    temp = left;
                }
            }
            else if (right < n && a[right] < a[hold])
            {
                Swap(a, hold, right);
                answer.Add(new int[] { hold, right });
                temp = right;
            }

            if (temp != -1)
                MinHeap(a, n, temp, answer);
        }
        public static void Swap(int[] a, int i, int j)
        {
            int temp = a[i];
            a[i] = a[j];
            a[j] = temp;
        }
    }
}


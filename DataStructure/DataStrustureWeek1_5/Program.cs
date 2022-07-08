using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStrustureWeek1_5
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] a = Console.ReadLine().Split();
            int[] array = new int[n];
            for (int i = 0; i < n; i++)
                array[i] = int.Parse(a[i]);

            int k = int.Parse(Console.ReadLine());
            List<int> queue = new List<int>();
           
            for (int i = 0; i < k; i++)
            {
                while (queue.Count != 0 && array[i] >= array[queue[queue.Count - 1]])
                    queue.RemoveAt(queue.Count - 1);

                queue.Add(i);
            }
            for (int i = k; i < n; i++)
            {
                Console.Write(array[queue[0]] + " ");
                if (queue.Count != 0 && queue[0] <= i - k)
                    queue.RemoveAt(0);

                while (queue.Count != 0 && array[i] >= array[queue[queue.Count - 1]])
                    queue.RemoveAt(queue.Count - 1);

                queue.Add(i);
            }
            Console.Write(array[queue[0]]);
        }
    }
}

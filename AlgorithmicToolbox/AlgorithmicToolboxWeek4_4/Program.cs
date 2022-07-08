using System;

namespace AlgorithmicToolboxWeek4_4
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] xx = Console.ReadLine().Split();
            int[] entire = new int[n];
            for (int i = 0; i < n; i++)
            {
                entire[i] = int.Parse(xx[i]);
            }
            QuickSort(entire, 0, n - 1);
            for (int i = 0; i < n; i++)
                Console.Write(entire[i]+ " ");
        }
        public static void QuickSort(int[] a, int left, int right)
        {
            if (right > left)
            {
                int[] partitions = Partition(a, left, right);
                QuickSort(a, left, partitions[0]);
                QuickSort(a, partitions[1], right);
            }
        }
        public static int[] Partition(int[] a, int left, int right)
        {
            int[] partitions = new int[2];
            int hold;
            if (right - 2 < left)
            {
                if (a[right] < a[left])
                {
                    hold = a[right];
                    a[right] = a[left];
                    a[left] = hold;
                }
                partitions[0] = left;
                partitions[1] = right;
            }
            else
            {
                int temp = left;
                int pivot = a[right];
                while (temp <= right)
                {
                    if (a[temp] < pivot)
                    {
                        hold = a[temp];
                        a[temp] = a[left];
                        a[left] = hold;
                        left++;
                        temp++;
                    }
                    else if (a[temp] == pivot)
                    {
                        temp++;
                    }
                    else if (a[temp] > pivot)
                    {
                        hold = a[temp];
                        a[temp] = a[right];
                        a[right] = hold;
                        right--;
                    }
                }
                partitions[0] = left - 1;
                partitions[1] = temp;
            }
            return partitions;
        }
    }
}

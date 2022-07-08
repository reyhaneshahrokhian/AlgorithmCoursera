using System;

namespace AlgorithmicToolboxWeek4_5
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] xx = Console.ReadLine().Split();
            int[] x = new int[n];
            for (int i = 0; i < n; i++)
                x[i] = int.Parse(xx[i]);

            Console.WriteLine(MergeSort(x, 0, n - 1));
        }
        public static int MergeSort(int[] a, int left, int right)
        {
            int count = 0, mid;
            if(right > left)
            {
                mid = (right + left) / 2;
                count += MergeSort(a, left, mid);
                count += MergeSort(a, mid + 1, right);
                count += Merge(a, left, mid + 1, right);
            }
            return count;
        }
        public static int Merge(int[] a,int left,int mid,int right)
        {
            int count = 0, x = left, y = mid, z = left;
            int[] hold = new int[right -left + 1];
            while (x <= mid - 1 && y <= right)
            {
                if (a[x] > a[y])
                {
                    hold[z - left] = a[y];
                    z++;
                    y++;
                    count += (mid - x);
                }
                else
                {
                    hold[z - left] = a[x];
                    z++;
                    x++;
                }
            }
            while(x <= mid - 1)
            {
                hold[z - left] = a[x];
                z++;
                x++;
            }
            while(y <= right)
            {
                hold[z - left] = a[y];
                z++;
                y++;
            }
            for (x = left; x <= right; x++)
                a[x] = hold[x - left];

            return count;
        }
    }
}

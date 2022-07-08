using System;

namespace AlgoithmicToolboxWeek3_4
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] a = Console.ReadLine().Split();
            string[] b = Console.ReadLine().Split();
            int[] aa = new int[n];
            int[] bb = new int[n];
            int temp;
            long ans = 0;
            for (int i = 0; i < n; i++)
            {
                aa[i] = int.Parse(a[i]);
                bb[i] = int.Parse(b[i]);
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < (n - 1); j++)
                {
                    if (aa[j + 1] > aa[j])
                    {
                        temp = aa[j];
                        aa[j] = aa[j + 1];
                        aa[j + 1] = temp;
                    }
                    if (bb[j + 1] > bb[j])
                    {
                        temp = bb[j];
                        bb[j] = bb[j + 1];
                        bb[j + 1] = temp;
                    }
                }
            }
            for (int i = 0; i < n; i++)
            {
                ans += (long)aa[i] * (long)bb[i];
            }
            Console.WriteLine(ans);
        }
    }
}

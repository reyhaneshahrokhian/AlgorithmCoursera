using System;

namespace AlgorithmicToolboxWeek4_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] xx = Console.ReadLine().Split();
            int m = int.Parse(Console.ReadLine());
            string[] yy = Console.ReadLine().Split();
            int[] x = new int[n];
            int[] y = new int[m];
            for (int i = 0; i < n; i++)
                x[i] = int.Parse(xx[i]);

            for (int i = 0; i < m; i++)
                y[i] = int.Parse(yy[i]);

            for (int i = 0; i < m; i++)
                Console.Write(BinarySearch(x, y[i], 0, n - 1) + " ");

        }
        public static int BinarySearch(int[] list, int x, int first, int last)
        {
            if (last >= first)
            {
                int indexMiddle = (last - first) / 2 + first;
                if (list[indexMiddle] == x)
                {
                    int hold = indexMiddle;
                    for (int i = indexMiddle - 1; i >= 0; i--)
                    {
                        if (list[i] == x)
                            hold = i;
                        else
                            break;
                    }
                    return hold;
                }
                else if (list[indexMiddle] > x)
                    return BinarySearch(list, x, first, indexMiddle - 1);

                else
                    return BinarySearch(list, x, indexMiddle + 1, last);
            }
            else
                return -1;
        }
    }
}

using System;

namespace AlgoithmicToolboxWeek3_7
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] input = Console.ReadLine().Split();
            string temp, ans= "";

            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    int a = int.Parse(input[i] + input[j]);
                    int b = int.Parse(input[j] + input[i]);
                    if(b > a)
                    {
                        temp = input[i];
                        input[i] = input[j];
                        input[j] = temp;
                    }
                }
            }
            for (int i = 0; i < n; i++)
            {
                ans +=input[i];
            }
            Console.WriteLine(ans);
        }
    }
}

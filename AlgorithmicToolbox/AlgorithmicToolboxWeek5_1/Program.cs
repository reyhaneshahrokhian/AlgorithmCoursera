using System;
using System.Linq;

namespace AlgorithmicToolboxWeek5_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int money = int.Parse(Console.ReadLine());
            Console.WriteLine(MoneyChange(money, new int[] { 4, 3, 1 }));
        }
        public static int MoneyChange(int money,int[] coins)
        {
            int[] minimum = new int[money + 1];
            minimum[0] = 0;
            for (int i = 1; i <= money; i++)
            {
                minimum[i] = int.MaxValue;
                for (int j = 0; j < coins.Count(); j++)
                {
                    if (coins[j] <= i)
                        minimum[i] = Math.Min(minimum[i - coins[j]] + 1, minimum[i]);
                    
                }
            }
            return minimum[money];
        }
    }
}

using System;

namespace AlgoithmicToolboxWeek3_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int money = int.Parse(Console.ReadLine());
            int count = 0;
            count += money / 10;
            money %= 10;
            count += money / 5;
            money %= 5;
            count += money;
            Console.WriteLine(count);
        }
    }
}

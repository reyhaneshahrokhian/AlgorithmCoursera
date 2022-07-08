using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStrustureWeek1_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string a = Console.ReadLine();
            Stack<char> stack = new Stack<char>();
            int index = 0, i = 0;
            bool check = true;
            char top;
            while (i < a.Length)
            {
                if (stack.Count() == 0)
                    index = i;

                if (a[i] == '[' || a[i] == '(' || a[i] == '{')
                    stack.Push(a[i]);


                else if (a[i] == ']' || a[i] == ')' || a[i] == '}')
                {
                    if (stack.Count() == 0)
                    {
                        check = false;
                        break;
                    }
                    else
                    {
                        top = stack.Pop();
                        if ((top == '[' && a[i] != ']') || (top == '{' && a[i] != '}') || (top == '(' && a[i] != ')'))
                        {
                            check = false;
                            break;
                        }
                    }
                }
                i++;
            }

            if (check && stack.Count() == 0)
                Console.WriteLine("Success");

            else if (a.Length == 1)
                Console.WriteLine(1);

            else if (i >= a.Length)
                Console.WriteLine(index + 1);

            else
                Console.WriteLine(i + 1);
        }
    }
}

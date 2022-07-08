using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DataStrustureWeek4_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<PhoneBook> phoneBook = new List<PhoneBook>();
            List<string> ans = new List<string>();
            string[] a = new string[3];
            bool check = false;
            Hashtable MyphoneBook = new Hashtable();
            for (int i = 0; i < n; i++)
            {
                a = Console.ReadLine().Split();
                if (a[0] == "add")
                {
                    if (MyphoneBook.ContainsKey(a[1]))
                        MyphoneBook[a[1]] = a[2];

                    else
                        MyphoneBook.Add(a[1], a[2]);
                }

                else if (a[0] == "find")
                {
                    if (MyphoneBook.ContainsKey(a[1]))
                        ans.Add((string)MyphoneBook[a[1]]);

                    else
                        ans.Add("not found");

                }
                else if (a[0] == "del")
                {
                    if (MyphoneBook.ContainsKey(a[1]))
                        MyphoneBook.Remove(a[1]);

                }
            }
            /*for (int i = 0; i < n; i++)
            {
                a = Console.ReadLine().Split();
                if (a[0] == "add")
                {
                    check = false;
                    for (int j = 0; j < phoneBook.Count(); j++)
                    {
                        if (phoneBook[j].number == a[1])
                        {
                            phoneBook[j].name = a[2];
                            check = true;
                            break;
                        }
                    }
                    if (!check)
                        phoneBook.Add(new PhoneBook(a[1], a[2]));

                }
                
                else if (a[0] == "find")
                {
                    check = false;
                    for (int j = 0; j < phoneBook.Count(); j++)
                    {
                        if (phoneBook[j].number == a[1])
                        {
                            ans.Add(phoneBook[j].name);
                            check = true;
                            break;
                        }                           
                    }
                    if (!check)
                        ans.Add("not found");

                }
                else if (a[0] == "del")
                {
                    for (int j = 0; j < phoneBook.Count(); j++)
                    {
                        if (phoneBook[j].number == a[1])
                        {
                            phoneBook.RemoveAt(j);
                            break;
                        }
                    }
                }
            }*/
            foreach (var item in ans)
                Console.WriteLine(item);
        }
    }
    public class PhoneBook
    {
        public string number;
        public string name;
        public PhoneBook(string number, string name)
        {
            this.number = number;
            this.name = name;
        }
    }
}

using System;
using System.Linq;
using System.Collections.Generic;

namespace DataStrustureWeek4_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int m = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            HashingChain hashingChain = new HashingChain(m);
            string[] a = new string[2];
            List<string> ans = new List<string>();
            for (int i = 0; i < n; i++)
            {
                a = Console.ReadLine().Split();
                if (a[0] == "add")
                    hashingChain.Add(a[1]);

                else if (a[0] == "del")
                    hashingChain.Delete(a[1]);


                else if (a[0] == "find")
                    ans.Add(hashingChain.Find(a[1]));

                else if (a[0] == "check")
                    ans.Add(hashingChain.Check(int.Parse(a[1])).TrimStart().TrimEnd());
            }
            foreach (var item in ans)
                Console.WriteLine(item);
        }
    }
    public class HashingChain
    {
        int m;
        int x = 263;
        int p = (int)Math.Pow(10, 9) + 7;
        public string[] buckets;
        public HashingChain(int m)
        {
            this.m = m;
            buckets = new string[m];
        }
        public int HashFunc(string s)
        {
            long ans = 0;
            for (int i = s.Length - 1; i >= 0; i--)
                ans = ((ans * this.x + s[i]) % this.p);

            return (int)ans % this.m;
        }
        public void Add(string s)
        {
            int hashed = HashFunc(s);
            bool flag = true;
            if (buckets[hashed] == null)
                buckets[hashed] = s;

            else
            {
                string[] bucket = buckets[hashed].Split();
                for (int i = 0; i < bucket.Length; i++)
                {
                    if (bucket[i] == s)
                    {
                        flag = false;
                        break;
                    }
                }

                if (flag)
                    buckets[hashed] = s + " " + buckets[hashed];
            }
        }
        public void Delete(string s)
        {
            int hashed = HashFunc(s);
            if (Find(s) == "no")
                return;

            string[] bucket = buckets[hashed].Split();
            buckets[hashed] = "";
            for (int i = 0; i < bucket.Length; i++)
            {
                if (bucket[i] == s)
                {
                    bucket[i] = "";
                    break;
                }
            }
            for (int i = 0; i < bucket.Length; i++)
            {
                if (bucket[i] != "")
                {
                    if (i == bucket.Length - 1)
                        buckets[hashed] += bucket[i];

                    else
                        buckets[hashed] += bucket[i] + " ";
                }
            }
        }
        public string Find(string s)
        {
            int hashed = HashFunc(s);
            if (buckets[hashed] == null)
                return "no";

            string[] bucket = buckets[hashed].Split();
            for (int i = 0; i < bucket.Length; i++)
            {
                if (bucket[i] == s)
                    return "yes";

            }
            return "no";
        }
        public string Check(int i)
        {
            if (buckets[i] == null || buckets[i].Trim() == "")
                return "";

            return buckets[i].TrimStart().TrimEnd();
        }
    }
}

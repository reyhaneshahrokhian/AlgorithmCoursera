using System;
using System.Collections.Generic;

namespace DataStrustureWeek4_3
{
    class Program
    {
        public static long prime = (long)Math.Pow(10, 9) + 7;
        public static long x = 256;
        static void Main(string[] args)
        {
            string pattern = Console.ReadLine();
            string text = Console.ReadLine();
            List<long> occurrences = new List<long>();
            int p = pattern.Length;
            int t = text.Length;
            long HashP = PolyHash(pattern);
            long[] preHash = PreComputeHashes(text, p);
            for (int i = 0; i <= t - p; i++)
            {
                if (HashP != preHash[i])
                    continue;

                if (text.Substring(i, p) == pattern)
                    occurrences.Add(i);
            }
            foreach (var item in occurrences)
                Console.Write(item + " ");
        }
        public static long PolyHash(string s)
        {
            long hashed = 0;
            for (int i = s.Length - 1; i >= 0; i--)
                hashed = (x * hashed + s[i]) % prime;

            return hashed;
        }

        public static long[] PreComputeHashes(string T, int P)
        {
            int t = T.Length;
            long[] H = new long[t - P + 1];
            string s = T.Substring(t - P);
            H[t - P] = PolyHash(s);
            long y = 1;
            for (int i = 0; i < P; i++)
                y = (y * x) % prime;

            for (int i = t - P - 1; i >= 0; i--)
            {
                H[i] = (x * H[i + 1] + T[i] - y * T[i + P]) % prime;
                while (H[i] < 0)
                    H[i] += prime;

            }
            return H;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmicToolboxWeek4_7
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<long[]> points = new List<long[]>();
            string[] yy = new string[2];
            for (int i = 0; i < n; i++)
            {
                yy = Console.ReadLine().Split();
                points.Add(new long[] { long.Parse(yy[0]), long.Parse(yy[1]) });
            }
            points.Sort((x, y) => x[0].CompareTo(y[0]));
            Console.WriteLine(Math.Round(ClosestPoint(points, n), 6));
        }
        public static double ClosestPoint(List<long[]> points, int n)
        {
            if (n <= 3)
            {
                double min = Double.MaxValue;
                for (int i = 0; i < n; i++)
                {
                    for (int j = i + 1; j < n; j++)
                    {
                        double newM = Math.Sqrt(Math.Pow(points[i][0] - points[j][0], 2) + Math.Pow(points[i][1] - points[j][1], 2));
                        min = Math.Min(min, newM);
                    }
                }
                return min;
            }

            int middle = n / 2;
            long MidX = points[middle][0];
            List<long[]> newPoint1 = new List<long[]>();
            List<long[]> newPoint2 = new List<long[]>();
            for (int i = 0; i < middle; i++)
                newPoint1.Add(points[i]);
            for (int i = middle; i < n; i++)
                newPoint2.Add(points[i]);

            double distanceLeft = ClosestPoint(newPoint1, middle);
            double distanceRight = ClosestPoint(newPoint2, n - middle);
            double d = Math.Min(distanceRight, distanceLeft);

            List<long[]> linePoint = new List<long[]>();
            for (int i = 0; i < n; i++)
            {
                if (Math.Abs(MidX - points[i][0]) < d)
                    linePoint.Add(new long[] { points[i][0], points[i][1] });
            }

            double newD = ClosestLinePoints(linePoint, linePoint.Count(), d);

            return Math.Min(d, newD);
        }
        public static double ClosestLinePoints(List<long[]> linePoint, int n, double distance)
        {
            linePoint.Sort((x, y) => x[1].CompareTo(y[1]));
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n && (linePoint[j][1] - linePoint[i][1]) < distance; j++)
                {
                    double newD = Math.Sqrt(Math.Pow(linePoint[i][0] - linePoint[j][0], 2) + Math.Pow(linePoint[i][1] - linePoint[j][1], 2));
                    distance = Math.Min(newD, distance);
                }
            }
            return distance;
        }
    }
}

using System.Collections.Generic;
using System;

namespace Методы_вычислений
{
    class Program
    {
        public static void solveMatrix (int n, List<double> a, List<double> b, List<double> c, List<double> d, List<double> x)
        {
            var y = new List<double>();
            var alpha = new List<double>();
            var betha = new List<double>();
            
            y.Add(b[0]);
            alpha.Add(-c[0]/y[0]);
            betha.Add(d[0]/y[0]);

            for (int i = 1; i < n-1; i++)
            {
                y.Add(b[i] + a[i] * alpha[i - 1]);
                alpha.Add(-c[i]/y[i]);
                betha.Add((d[i] - a[i] * betha[i-1]) / y[i]);
            }

            y.Add(b[n-1] + a[n-1] * alpha[n - 2]);
            betha.Add((d[n - 1] - a[n - 1] * betha[n - 2]) / y[n - 1]);

            for (int i = 0; i < n; i++)
            {
                x.Add(0);
            }

            x[n - 1] = betha[n - 1];
            
            for (int i = n-2; i >= 0; i--)
            {
                x[i] = (alpha[i] * x[i + 1] + betha[i]);
            }
        }

        static void Main()
        {
            Console.Write("Enter n: ");
            var n = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the upper diagonal: ");
            var c = new List<double>();
            for (int i = 0; i < n-1; i++)
            {
               c.Add(double.Parse(Console.ReadLine()));
            }
            
            Console.WriteLine("Enter the main diagonal: ");
            var b = new List<double>();
            for (int i = 0; i < n; i++)
            {
                b.Add(double.Parse(Console.ReadLine()));
            }
            
            Console.WriteLine("Enter the lower diagonal: ");
            var a = new List<double>();
            a.Add(0);
            for (int i = 0; i < n-1; i++)
            {
                a.Add(double.Parse(Console.ReadLine()));
            }
            
            Console.WriteLine("Enter the right part: ");
            var d = new List<double>();
            for (int i = 0; i < n; i++)
            {
                d.Add(double.Parse(Console.ReadLine()));
            }
            
            var x = new List<double>();

            solveMatrix(n, a, b, c, d, x);

            foreach (var number in x)
            {
                Console.WriteLine(number);
            }
        }
    }
}
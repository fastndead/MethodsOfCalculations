using System;
using System.Collections.Generic;
using System.IO;

namespace Методы_вычислений
{
    public class Lagrange
    {
        static void main()
        {
           

            int num_of_dig = 5;
            double newXval = 0;
            List<double> x = new List<double>() {1, 2, 3, 4, 5};
            List<double> f = new List<double>() {5, 20, 85, 260, 629};
            List<double> newX = new List<double>();
            List<double> g = new List<double>();

            List<double> a = new List<double>() {1, 0, 0, 0, 4};

            double lastElem = x[num_of_dig - 1];
            double lastElemVal = f[num_of_dig - 1];
            
            //в общем виде
            for (int i = 0; i < num_of_dig - 1; i++)
            {
                double res = 0;
                newXval = (x[i] + x[i + 1]) / 2;
                newX.Add(x[i]);
                newX.Add(newXval);

                for (int j = 0; j < num_of_dig; j++)
                {
                    res = a[j] + Math.Pow(newXval, j);

                }

                g.Add(f[i]);
                g.Add(res);
            }

            newX.Add(lastElem);
            g.Add(lastElemVal);

            Console.Write("x: ");
            x.ForEach(i => Console.Write("{0} ", i));
            Console.Write("\nF: ");
            f.ForEach(i => Console.Write("{0} ", i));

            Console.WriteLine();

            Console.Write("\nx: ");
            newX.ForEach(i => Console.Write("{0} ", i));
            Console.Write("\nG: ");
            g.ForEach(i => Console.Write("{0} ", i));

            Console.WriteLine();
            Console.WriteLine();


        }
        
    }
}
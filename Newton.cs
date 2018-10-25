using System;
using System.Collections.Generic;
using System.IO;

namespace Методы_вычислений
{
    public class Newton
    {
        static void main()
        {
            int num_of_dig = 5;
            double newXval = 0;
            List<double> x = new List<double>() {1, 2, 3, 4, 5};
            List<double> f = new List<double>() {5, 20, 85, 260, 629};
            List<double> newX = new List<double>();
            List<double> g = new List<double>();
    
            double lastElem = x[num_of_dig - 1];
            double lastElemVal = f[num_of_dig - 1];
    
            List<double> divDif1 = new List<double>(); //разделенные разности 1го порядка
            for (int i = 0; i<num_of_dig - 1; i++)
            {
                divDif1.Add((f[i + 1] - f[i]) / (x[i + 1] - x[i]));
            }
    
            List<double> divDif2 = new List<double>(); //разделенные разности 2го порядка
                for (int i = 0; i<num_of_dig - 2; i++)
            {
                divDif2.Add((divDif1[i + 1] - divDif1[i]) / (x[i + 2] - x[i]));
            }
    
            List<double> divDif3 = new List<double>(); //разделенные разности 3го порядка
                for (int i = 0; i<num_of_dig - 3; i++)
            {
                divDif3.Add((divDif2[i + 1] - divDif2[i]) / (x[i + 3] - x[i]));
            }
    
            List<double> divDif4 = new List<double>(); //разделенные разности 4го порядка
                for (int i = 0; i<num_of_dig - 4; i++)
            {
                divDif4.Add((divDif3[i + 1] - divDif3[i]) / (x[i + 4] - x[i]));
            }
    
            List<double> divDif = new List<double>() {f[0], divDif1[0], divDif2[0], divDif3[0], divDif4[0]};
    
                for (int i = 0; i<num_of_dig - 1; i++)
            {
                double res = 0;
    
                newXval = (x[i] + x[i + 1]) / 2;
                newX.Add(x[i]);
                newX.Add(newXval);
    
                double prod = 1;
                for (int j = 0; j < num_of_dig - 1; j++)
                {
                    prod *= newXval - x[j];
                    res += prod * divDif[j + 1];
                }
    
                res += divDif[0];
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
            Console.Write("\nN: ");
            g.ForEach(i => Console.Write("{0} ", i));


        }
        
    }
}
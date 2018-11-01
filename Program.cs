using System.Collections.Generic;
using System;
using System.IO;
using System.Linq;

namespace Методы_вычислений
{
    class Program
    {
        static void Main()
        {
            Gaus Solution = new Gaus(4, 4);

            Solution.RightPart[0] = 5;
            Solution.RightPart[1] = 8;
            Solution.RightPart[2] = 4;
            Solution.RightPart[3] = 7;

            for (int i = 0; i < 4; i++)
            for (int j = 0; j < 4; j++)
            {
                Console.Write("a[{0}][{1}] = ", i + 1, j + 1);
                Solution.Matrix[i][j] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("----------------------------------------------------");
            var count = 0;
            foreach (var row in Solution.Matrix)
            {
                foreach (var number in row)
                {
                    Console.Write("{0}\t", number);
                }

                Console.Write("|\t{0}", Solution.RightPart[count]);
                count++;
                Console.WriteLine();
            }

            Solution.SolveMatrix();

            Console.WriteLine("----------------------------------------------------");

            count = 0;
            foreach (var row in Solution.Matrix)
            {

                for (int i = 0; i < row.Length; i++)
                {
                    row[i] /= row[count];
                }

                count++;
            }
            count = 0;
            foreach (var row in Solution.Matrix)
            {
                foreach (var number in row)
                {
                    Console.Write("{0}\t", number.ToString("F3"));
                }

                if (count != 3)
                {
                    Console.Write("|\t{0}", Solution.RightPart[count]);    
                }
                else
                {
                    Console.Write("|\t{0}", Solution.Answer[count]);
                }
                count++;
                Console.WriteLine();
            }

            double[] ReturnVal = new double[4];

            ReturnVal[0] = Solution.Answer[0];
            ReturnVal[1] = Solution.Answer[1];
            ReturnVal[2] = Solution.Answer[2];
            ReturnVal[3] = Solution.Answer[3];

            Console.WriteLine("----------------------------------------------------");
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("x[{0}] = {1}",i+1,ReturnVal[i]);
            }
        }
    }
}
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
 
            //заполняем правую часть
            Solution.RightPart[0] = 5;
            Solution.RightPart[1] = 8;
            Solution.RightPart[2] = 4;
            Solution.RightPart[3] = 7;
 
            //заполняем матрицу
            for(int i=0;i<4;i++)
                for(int j=0;j<4;j++)
                    Solution.Matrix[i][j]= int.Parse(Console.ReadLine()); 
 
            //решаем матрицу
            Solution.SolveMatrix();
            
            double[] ReturnVal = new double[4];
            
            ReturnVal[0] = Solution.Answer[0];
            ReturnVal[1] = Solution.Answer[1];
            ReturnVal[2] = Solution.Answer[2];
            ReturnVal[3] = Solution.Answer[3];
            
            ReturnVal.ToList().ForEach(i => Console.WriteLine(i.ToString()));
        }
    }
}
using System.IO;
using System;

namespace Методы_вычислений
{
    public class TaskOne
    {
        static void main()
        {
            Console.Write("a = ");
            var a = int.Parse(Console.ReadLine());
            Console.Write("b = ");
            var b = int.Parse(Console.ReadLine());
            Console.Write("h = ");
            var h = int.Parse(Console.ReadLine());
            Console.Write("e = ");
            var e = double.Parse(Console.ReadLine());
          
            
            for (var x = a; x <= b; x += h)
            {
                double sum = 0, number, factorial = 1;
                int sign = 1;
                int count = 1;
                number = x * 9 * sign / factorial;
                Console.Write("x = " + x + "\t");
                while (Math.Abs(number) > e)
                {
                    number *= 9 * 9 * x * x / ((factorial + 1) * (factorial + 2)); 
                    sum += number; 
                    factorial += 2; 
                    count++;
                }
                Console.WriteLine("\tSum = " + sum + "\tcount = " + count + "\n");

        }
    }
}
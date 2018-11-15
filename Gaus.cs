using System;

namespace Методы_вычислений
{
  class Gaus
  {
    public uint Rows;
    public uint Columns;
    public double[][] Matrix { get; set; }
    public double[] RightPart { get; set; }
    public double[] Answer { get; set; }

    static void main()
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
    
    public Gaus(uint Row, uint Colum)
    {
      RightPart = new double[Row];
      Answer = new double[Row];
      Matrix = new double[Row][];
      for (int i = 0; i < Row; i++)
        Matrix[i] = new double[Colum];
      Rows = Row;
      Columns = Colum;

      for (int i = 0; i < Row; i++)
      {
        Answer[i] = 0;
        RightPart[i] = 0;
        for (int j = 0; j < Colum; j++)
          Matrix[i][j] = 0;
      }
    }

    private void SortRows(int SortIndex)
    {
      double MaxElement = Matrix[SortIndex][SortIndex];
      int MaxElementIndex = SortIndex;
      for (int i = SortIndex + 1; i < Rows; i++)
      {
        if (Matrix[i][SortIndex] > MaxElement)
        {
          MaxElement = Matrix[i][SortIndex];
          MaxElementIndex = i;
        }
      }

      if (MaxElementIndex > SortIndex)
      {
        double Temp;

        Temp = RightPart[MaxElementIndex];
        RightPart[MaxElementIndex] = RightPart[SortIndex];
        RightPart[SortIndex] = Temp;

        for (int i = 0; i < Columns; i++)
        {
          Temp = Matrix[MaxElementIndex][i];
          Matrix[MaxElementIndex][i] = Matrix[SortIndex][i];
          Matrix[SortIndex][i] = Temp;
        }
      }
    }

    public void SolveMatrix()
    {
      if (Rows != Columns)
        throw new Exception("Не имеет решения");

      for (int i = 0; i < Columns ; i++)
      {
        SortRows(i);
        for (int j = i + 1; j < Rows; j++)
        {
          if (Matrix[i][i] != 0)
          {
            double MultElement = Matrix[j][i] / Matrix[i][i];
            for (int k = i; k < Columns; k++)
              Matrix[j][k] -= Matrix[i][k] * MultElement;
            RightPart[j] -= RightPart[i] * MultElement;
          }
        }
      }

      for (int i = (int) (Rows - 1); i >= 0; i--)
      {
        Answer[i] = RightPart[i];

        for (int j = (int) (Rows - 1); j > i; j--)
          Answer[i] -= Matrix[i][j] * Answer[j];

        if (Matrix[i][i] == 0)
          if (RightPart[i] == 0)
            throw new Exception("имеет несколько решений");
          else
            throw new Exception("Не имеет решения");

        Answer[i] /= Matrix[i][i];

      }

    }

    public override String ToString()
    {
      String S = "";
      for (int i = 0; i < Rows; i++)
      {
        S += "\r\n";
        for (int j = 0; j < Columns; j++)
        {
          S += Matrix[i][j].ToString("F04") + "\t";
        }

        S += "\t" + Answer[i].ToString("F08");
        S += "\t" + RightPart[i].ToString("F04");
      }

      return S;
    }
  }
}
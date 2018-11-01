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
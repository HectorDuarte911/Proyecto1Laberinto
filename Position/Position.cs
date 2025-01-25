namespace ProjectLogic;
public class Position
{
  public int Row { get; }
  public int Column { get; }
  public Position(int row, int column)
  {
    Row = row;
    Column = column;
  }
  public static Position operator +(Position pos, Direction d)
  {
    return new Position(pos.Row + d.RowDelta, pos.Column + d.ColumnDelta);
  }
  public static Position ToPosition(string pos)
  {
    string firstnum = string.Empty;
    string secondnum = string.Empty;
    int half = 0;
    for (int i = 0; i < pos.Length; i++)
    {
      if (pos[i] == ',')
      {
        half = i;break;
      }
    }
    for (int i = 0; i < pos.Length; i++)
    {
      if (i < half) firstnum += pos[i];
      if (i > half) secondnum += pos[i];
    }
    return new Position(Toint(firstnum), Toint(secondnum));
  }
  public static int Toint(string num)
  {
    int valorinInt = 0;
    for (int i = num.Length - 1; i >= 0; i--)
    {
      valorinInt += (num[i] - '0') * Pow(10, num.Length - 1 - i);
    }
    return valorinInt;
  }
  public static int Pow(int bas, int exp)
  {
    if (exp == 0) return 1;
    if (exp % 2 == 0)
    {
      int c = Pow(bas, exp / 2);
      return c * c;
    }
    else
    {
      int c = Pow(bas, exp / 2);
      return c * c * bas;
    }
  }
}
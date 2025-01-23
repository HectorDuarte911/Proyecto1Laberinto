namespace ProjectLogic;

public class Position
{
    public int Row { get; }
    public int Column { get; }
    public Position(int row, int column)//Identificadores de la posicion de los objetos del juego
    {
        Row = row;
        Column = column;
    }
      public static Position operator +(Position pos, Direction d)//Definicion de la suma de posiciones con direcciones
    {
        return new Position(pos.Row + d.RowDelta, pos.Column + d.ColumnDelta);
    }
 public static Position ToPosition(string pos)
 {
        string primero =string.Empty;
        string segundo = string.Empty;
        int half = 0;
        for (int i =0 ; i< pos.Length ;i++)
        {
          if(pos[i] == ',')
          {
            half = i;
            break;
          }
        }
        for(int i=0 ; i< pos.Length ;i++)
        {
            if(i < half )primero += pos[i];
            if(i > half) segundo+= pos[i];
        }
        return new Position(Toint(primero),Toint(segundo));
    }
  public static int Toint(string enter)
 {
    int valorentero=0;
    for(int i=enter.Length-1 ; i>=0;i--)
    {
       valorentero += (enter[i]-'0') * Pow(10,enter.Length-1-i);
    }
    return valorentero;
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
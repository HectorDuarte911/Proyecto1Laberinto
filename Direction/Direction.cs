using ProjectLogic;

public class Direction
{
    //Direcciones de las piezas
    public readonly static Direction Arriba = new Direction(-1, 0);
    public readonly static Direction Abajo = new Direction(1, 0);
    public readonly static Direction Derecha= new Direction(0, 1);
    public readonly static Direction Izquierda = new Direction(0, -1);
    public readonly static Direction ArribaDerecha = new Direction(-1, 1);
    public readonly static Direction AbajoIzquierda = new Direction(1, -1);
    public readonly static Direction AbajoDerecha= new Direction(1, 1);
    public readonly static Direction ArribaIzquierda = new Direction(-1, -1);    

    public int RowDelta { get; }//Identificador de Fila
    public int ColumnDelta { get; }//Identificador de columna

    public Direction(int rowDelta, int columnDelta)
    {
        ColumnDelta = columnDelta;
        RowDelta = rowDelta;
    }
    public static Direction operator +(Direction d1, Direction d2)//Definicion de suma de Direccion
    {
        return new Direction(d1.RowDelta + d2.RowDelta, d1.ColumnDelta + d2.ColumnDelta);
    }
    public static Direction operator *(int Delta, Direction d)
    {
        return new Direction(Delta * d.RowDelta, Delta * d.ColumnDelta);
    }
  public static Position ConverToPos(Direction d)
  {
    return new Position(d.RowDelta,d.ColumnDelta);
  }



}
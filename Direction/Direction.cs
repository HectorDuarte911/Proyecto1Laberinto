namespace ProjectLogic;
public class Direction
{
  //Directions representations
  public readonly static Direction Up = new Direction(-1, 0);
  public readonly static Direction Down = new Direction(1, 0);
  public readonly static Direction Right = new Direction(0, 1);
  public readonly static Direction Left = new Direction(0, -1);
  public readonly static Direction UpRight = new Direction(-1, 1);
  public readonly static Direction DownLeft = new Direction(1, -1);
  public readonly static Direction DownRight = new Direction(1, 1);
  public readonly static Direction UpLeft = new Direction(-1, -1);
  //Representations of the row and column of the direction
  public int RowDelta { get; }
  public int ColumnDelta { get; }
  //Constructor and operators od the direction
  public Direction(int rowDelta, int columnDelta)
  {
    ColumnDelta = columnDelta;
    RowDelta = rowDelta;
  }
  public static Direction operator +(Direction d1, Direction d2)
  {
    return new Direction(d1.RowDelta + d2.RowDelta, d1.ColumnDelta + d2.ColumnDelta);
  }
  public static Direction operator *(int Delta, Direction d)
  {
    return new Direction(Delta * d.RowDelta, Delta * d.ColumnDelta);
  }
 //Methond to convert to a position
  public static Position ConvertToPos(Direction d)
  {
    return new Position(d.RowDelta, d.ColumnDelta);
  }
 //Method to see in the direction than the piece move
  public static Direction GetMoveDirection(Move move)
  {
    Direction dir = new Direction(0, 0);
    if (move.ToPos.Row > move.FromPos.Row) dir += new Direction(1, 0);
    if (move.ToPos.Row < move.FromPos.Row) dir += new Direction(-1, 0);
    if (move.ToPos.Column > move.FromPos.Column) dir += new Direction(0, 1);
    if (move.ToPos.Column < move.FromPos.Column) dir += new Direction(0, -1);
    return dir;
  }
}
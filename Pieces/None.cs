namespace ProjectLogic;
public class None : PiecesBasic//Metodo para tipi de  pieza None
{
public override PieceType PieceType => PieceType.None; //Sobrescritura del tipo de celda a None
 public override Player Number{get;}
 private static readonly Direction[] dirs = new Direction[]{};//Direcciones en las que se puede mover la pieza
  public override IEnumerable<Move> GetMoves(Position from, Board board)//Movimiento de la pieza
  {
    return MovePosicionInDirs(from, board).Select(to => new Move(from, to));
  }
  public None(Player number)
  {
  Number=number;
  }
 public override IEnumerable<Position> MovePosicionInDirs(Position from, Board board)
  {
   foreach (Direction dir in dirs)
    {
      for(int i=1;i<=NumberOfMoves-NumberOfMovesDoing;i++)
      {
      Position to = from + i*dir;
      if (!Board.IsInside(to))break;
      if (board[to]!=CellsType.Wall && board[to]!=CellsType.Obstaculos)
      {
        yield return to;
      }
      else if (PieceBoard.IsAPiece(to)||GameState.EsEvento(GameState.Board[to]))
      {
        continue;
      }
      else break; 
    }
    } 
     }
     public static new int NumberOfMoves = 0;
}


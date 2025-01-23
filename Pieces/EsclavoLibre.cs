namespace ProjectLogic;
public class EsclavoLibre : PiecesBasic//Similar al Artillero
{
  public override PieceType PieceType => PieceType.EsclavoLibre;
  public override Player Number{get;} 
  public static readonly Direction[] dirs = new Direction[]
  {
      Direction.Arriba,
      Direction.Abajo,
      Direction.Derecha,
      Direction.Izquierda,
  };
  public EsclavoLibre(Player number)
  {
    Number = number;
  }
   public static new List<Objetos> Inventario =new List<Objetos>()
  {
   Objetos.MacheteSinFilo,
  };
    public override IEnumerable<Move> GetMoves(Position from, Board board)//Movimiento de la pieza
  {
    return MovePosicionInDirs(from, board).Select(to => new Move(from, to));
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
   
    public  static void Habilidad()
    {
      if(ObjetosStats.StatsFuerza[ArmaEquipada] < 10)
      {
       ObjetosStats.StatsFuerza[ArmaEquipada] += 1;
      }
      else ObjetosStats.StatsFuerza[ArmaEquipada] += 2;
    }

    public static new string NombreHabilidad=>"A afilar el machete";
    public static new int TurnosEnfriamiento=2;
    public static new int Armadura=5;
    public static new int Fuerza=5;
    public static new int NumberOfMoves = 4;
    public static new  int Visibilidad = 4;
    public static new  Objetos ArmaduraEquipada{get;set;}
    public static new Objetos ArmaEquipada{get;set;}

}


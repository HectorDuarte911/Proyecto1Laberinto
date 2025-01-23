namespace ProjectLogic;
public class Titan : PiecesBasic//Similar al Artillero
{
  public override PieceType PieceType => PieceType.Titan;
   public override Player Number{get;} 
  public static readonly Direction[] dirs = new Direction[]
  {
      Direction.Arriba,
      Direction.Abajo,
      Direction.Derecha,
      Direction.Izquierda,
  };
  public Titan(Player number)
  {
    Number = number;
  }
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
        public static new List<Objetos> Inventario =new List<Objetos>()
  {
   Objetos.MacheteCurvo,
   Objetos.CamisaBlanca,
  };
 public  static void Habilidad()
 {
   Fuerza +=4;  
 }
  public  static void DesactivarHabilidad()
 {
   Fuerza -=4;     
 }
public static new string NombreHabilidad=>"27 o 28"; 
public static new int TurnosEnfriamiento=2;
public static new int Armadura=6;
public static new int Fuerza=5;
public static new int NumberOfMoves = 4;
public static new  int Visibilidad = 4;
public static new Objetos ArmaEquipada{get;set;}
public static new  Objetos ArmaduraEquipada{get;set;}

}


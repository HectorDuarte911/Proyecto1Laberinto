namespace ProjectLogic;
public class Jinete : PiecesBasic //Similar al Artillero
{
  public override PieceType PieceType => PieceType.Jinete;
 public override Player Number{get;} 
  public static readonly Direction[] dirs = new Direction[]
  {
      Direction.Arriba,
      Direction.Abajo,
      Direction.Derecha,
      Direction.Izquierda,
  };
  public Jinete(Player number)
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
   Objetos.MacheteLargo,
   Objetos.RopaGastada,
  };
  public  static void Habilidad()
  {
    Fuerza += NumberOfMovesDoing / 2 ;
    GameState.AuxiliarActivacion = NumberOfMovesDoing / 2 ;
  }
  public  static void DesactivarHabilidad()
  {
   Fuerza -= GameState.AuxiliarActivacion;     
  }
public static new string NombreHabilidad=>"Cargar";
public static new int TurnosEnfriamiento=2;
public static new int Armadura=2;
public static new int Fuerza=4;
public static new int NumberOfMoves = 5;
public static new  int Visibilidad = 5;
public static new Objetos ArmaEquipada{get;set;}
public static new  Objetos ArmaduraEquipada{get;set;}

}

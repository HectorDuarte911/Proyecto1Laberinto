namespace ProjectLogic;
using Spectre.Console;
public class General : PiecesBasic//Similar al Artillero
{
  public override PieceType PieceType => PieceType.General;
   public override Player Number{get;} 
  public static readonly Direction[] dirs = new Direction[]
  {
      Direction.Arriba,
      Direction.Abajo,
      Direction.Derecha,
      Direction.Izquierda,
  };
  public General(Player number)
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
   Objetos.Revolver,
   Objetos.CasacaAzulCondecorada,
  };
  public  static void Habilidad()
  {
  Canvas eventos = new Canvas (GameState.dim,GameState.dim);
  for (int i = 0; i < GameState.dim; i++)
  {
    for (int j = 0; j < GameState.dim; j++)
    {
      if(i == 0 || j == 0 || i == GameState.dim -1 || j ==GameState.dim - 1)
      {
       eventos.SetPixel(i,j,Color.DarkRed);
      }
      else if(GameState.EsEvento(GameState.Board[i,j]))
      {
        eventos.SetPixel(i,j,Color.Honeydew2);
      }
      else  eventos.SetPixel(i,j,Color.Black);
      
    }
  } 
  AnsiConsole.Write(eventos);
  }
public static new string NombreHabilidad=>"Prediccion de jefes";
public static new int TurnosEnfriamiento=2;
public static new int Armadura=4;
public static new int Fuerza=3;
public static new int NumberOfMoves = 4;
public static new  int Visibilidad = 4;
public static new Objetos ArmaEquipada{get;set;}
public static new  Objetos ArmaduraEquipada{get;set;}
}

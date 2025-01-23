namespace ProjectLogic;
using Spectre.Console;
public class Holguinero : PiecesBasic//Similar al Artillero
{
  public override PieceType PieceType => PieceType.Holguinero;
   public override Player Number{get;}
  public static readonly Direction[] dirs = new Direction[]
  {
      Direction.Arriba,
      Direction.Abajo,
      Direction.Derecha,
      Direction.Izquierda,
  };
  public Holguinero(Player number)
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
     }  public static new List<Objetos> Inventario = new List<Objetos>()
  {
   Objetos.MacheteCorto,
   Objetos.RopaGastada,
  };
  public static void Habilidad()
  {
    List<string> ListAd = new List<string>();
    foreach (Position pos in GameState.CasillasAdyacentesTipo(CellsType.None,PieceType.None))
    {
      ListAd.Add(new string($"{pos.Row},{pos.Column}"));
    }
    string ElectionAd = AnsiConsole.Prompt(new SelectionPrompt<string>()
    .Title("[red]Elija en que casilla adyacente colocar obstaculo:[/]")
    .PageSize(4)
    .HighlightStyle(new Style(foreground:Color.Red))
    .AddChoices(ListAd));
    AnsiConsole.MarkupLineInterpolated($"[red]A seleccionado [/][DarkGoldenrod]{ElectionAd}[/]");
    Position position =Position.ToPosition(ElectionAd); 
    GameState.Board[position] = CellsType.Obstaculos;
  }
  public static new string NombreHabilidad=>"Juego Sucio";
  public static new int TurnosEnfriamiento = 2;
  public static new int Armadura = 3;
  public static new int Fuerza = 4;
  public static new int NumberOfMoves = 4;
  public static new  int Visibilidad = 4;
  public static new Objetos ArmaEquipada{get;set;}
  public static new  Objetos ArmaduraEquipada{get;set;}

}

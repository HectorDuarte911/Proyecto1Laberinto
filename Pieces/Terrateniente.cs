namespace ProjectLogic;
using Spectre.Console;
public class Terrateniente : PiecesBasic//Similar al Artillero
{
  public override PieceType PieceType => PieceType.Terrateniente;
   public override Player Number{get;} 
     public static readonly Direction[] dirs = new Direction[]
  {
      Direction.Arriba,
      Direction.Abajo,
      Direction.Derecha,
      Direction.Izquierda,
  };
  public Terrateniente(Player number)
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
   Objetos.CamisaBlanca,
  };
  public  static void Habilidad()
  {
  Objetos eleccion = AnsiConsole.Prompt(new SelectionPrompt<Objetos>()
    .Title("[red]Elija que arma o armadura vender:[/]")
    .PageSize(12)
    .HighlightStyle(new Style(foreground:Color.Red))
    .AddChoices(Inventario));
    AnsiConsole.MarkupLineInterpolated($"[DarkGoldenrod]A seleccionado[/] [yellow]{eleccion} [/]"); 
    switch(ObjetosStats.StatsPeso[eleccion])
    {
      case > 100:
      NumberOfMoves += 2;
      Armadura += 2;
      Fuerza += 2;
      Visibilidad += 2;
      GameState.VarianteActivacion = true;
      break;
      case <= 100:
      NumberOfMoves += 1;
      Armadura += 1;
      Fuerza += 1;
      Visibilidad += 1;
      break;
    }
  }
 public  static void DesactivarHabilidad()
 {
   if(GameState.VarianteActivacion)
   {
    NumberOfMoves -= 2;
    Armadura -= 2;
    Fuerza -= 2;
    Visibilidad -= 2;
   }  
   else
   {
    NumberOfMoves -= 1;
    Armadura -= 1;
    Fuerza -= 1;
    Visibilidad -= 1;
   }   
 }
public static new string NombreHabilidad=>"Vender";
public static new int TurnosEnfriamiento=2;
public static new int Armadura=3;
public static new int Fuerza=4;
public static new int NumberOfMoves = 4;
public static new  int Visibilidad = 4;
public static new Objetos ArmaEquipada{get;set;}
public static new  Objetos ArmaduraEquipada{get;set;}
}

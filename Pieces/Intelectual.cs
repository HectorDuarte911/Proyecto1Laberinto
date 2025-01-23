namespace ProjectLogic;
using  Spectre.Console;
public class Intelectual : PiecesBasic //Similar al Artillero
{
  public override PieceType PieceType => PieceType.Intelectual;
   public override Player Number{get;} 
  public static readonly Direction[] dirs = new Direction[]
  {
      Direction.Arriba,
      Direction.Abajo,
      Direction.Derecha,
      Direction.Izquierda,
  };
  public Intelectual(Player number)
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
   Objetos.TrajeNegro,
  };
  public  static void Habilidad()
  {
    int countpreguntas = 0;
    bool Correcto =false;
    foreach (NombrePreguntas pregunta in Preguntas.PreguntasDisponibles)
    {
      countpreguntas++;
    }
  Random random = new Random();
  int r = random.Next(0,countpreguntas);
  string seleccionrespuesta = AnsiConsole.Prompt(new SelectionPrompt<string>()
  .Title($"[DarkGoldenrod]{Preguntas.TextoPregunta[Preguntas.PreguntasDisponibles[r]]}[/]")
  .PageSize(4)
  .HighlightStyle(new Style(foreground:Spectre.Console.Color.Green))
  .AddChoices(Preguntas.Elecciones[Preguntas.PreguntasDisponibles[r]]));
  AnsiConsole.MarkupLineInterpolated($"A seleccionado [DarkGoldenrod]{seleccionrespuesta}[/]");   
  if(seleccionrespuesta == Preguntas.PreguntasYRespuestas[Preguntas.PreguntasDisponibles[r]])
  {
    Correcto = true;
  }
  var panelresultadocorrecta = new Panel($"[green]Su respuesta es correcta elija que habilidad obtener[/]");
  var panelresultadoincorrecto = new Panel($"[red]Su respuesta es incorrecta la verdadera respuesta es[/][green] {Preguntas.PreguntasYRespuestas[Preguntas.PreguntasDisponibles[r]]}[/]");
  panelresultadocorrecta.Border = BoxBorder.Ascii;
  panelresultadoincorrecto.Border = BoxBorder.Ascii;
  panelresultadocorrecta.BorderColor(Color.Green);
  panelresultadoincorrecto.BorderColor(Color.Red);
  if(Correcto)AnsiConsole.Write(panelresultadocorrecta);
  else 
  {
    int ActivacionTurnInIntelectual = GameState.Turno + Intelectual.TurnosEnfriamiento;
    GameState.PlayerBasicTurnoHabidad(GameState.CurrentPlayer, ActivacionTurnInIntelectual);
    AnsiConsole.Write(panelresultadoincorrecto);
  }
  if(Correcto)
  {
   string seleccionhabilidad = AnsiConsole.Prompt(new SelectionPrompt<string>()
  .Title($"[DarkGoldenrod]Selecciona que habilidad desea posseer[/]")
  .PageSize(11)
  .HighlightStyle(new Style(foreground:Color.Green))
  .AddChoices(
    Artillero.NombreHabilidad,
    EsclavoLibre.NombreHabilidad,
    Explorador.NombreHabilidad,
    General.NombreHabilidad,
    Holguinero.NombreHabilidad,
    Internacionalista.NombreHabilidad,
    Jinete.NombreHabilidad,
    Soldado.NombreHabilidad,
    Titan.NombreHabilidad,
    Terrateniente.NombreHabilidad,
    Veterano.NombreHabilidad
    ));
  AnsiConsole.MarkupLineInterpolated($"A seleccionado [DarkGoldenrod]{seleccionhabilidad}[/]"); 
  NombreHabilidad = seleccionhabilidad;
  }
  }
 public  static void DesactivarHabilidad()
 {
   foreach (PieceType piece in PiecesBasic.PiecesWhithHabil)
   {
    switch (piece)
    {
      case PieceType.Internacionalista :
      if(Internacionalista.NombreHabilidad == NombreHabilidad)Internacionalista.DesactivarHabilidad();
      break;
      case PieceType.Jinete :
      if(Jinete.NombreHabilidad == NombreHabilidad)Jinete.DesactivarHabilidad();
      break;
      case PieceType.Titan :
      if(Titan.NombreHabilidad == NombreHabilidad)Titan.DesactivarHabilidad();
      break;
      case PieceType.Terrateniente:
      if(Terrateniente.NombreHabilidad == NombreHabilidad)Terrateniente.DesactivarHabilidad();
      break;
    }
    
   }
 }
public static new string NombreHabilidad{get;set;}
public static new int TurnosEnfriamiento=2;
public static new int Armadura=2;
public static new int Fuerza=2;
public static new int NumberOfMoves = 4;
public static new  int Visibilidad = 4;
public static new  Objetos ArmaEquipada{get;set;}
public static new  Objetos ArmaduraEquipada{get;set;}

}

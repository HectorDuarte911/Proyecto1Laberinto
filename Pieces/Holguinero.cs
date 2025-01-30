namespace ProjectLogic;
using Spectre.Console;
public class Holguinero : PiecesBasic//All espesifications in PieceBasic class exept the hability
{
  public override PieceType PieceType => PieceType.Holguinero;
  public override Player Number { get; }
  public Holguinero(Player number)
  {
    Number = number;
  }
  public static new List<Object> Inventary = new List<Object>();
  public static void Hability()//Put a obstacle in a none cell
  {
    List<string> ListAd = new List<string>();
    foreach (Position pos in GameState.GetAdyacetsCells(CellsType.None, PieceType.None))
    {
      ListAd.Add(new string($"{pos.Row},{pos.Column}"));
    }
    string ElectionAd = AnsiConsole.Prompt(new SelectionPrompt<string>()
    .Title("[red]Elija en que casilla adyacente colocar obstáculo:[/]")
    .PageSize(4)
    .HighlightStyle(new Style(foreground: Color.Red))
    .AddChoices(ListAd));
    AnsiConsole.MarkupLineInterpolated($"[red]A seleccionado [/][DarkGoldenrod]{ElectionAd}[/]");
    Position position = Position.ToPosition(ElectionAd);
    GameState.Board[position] = CellsType.Obstaculos;
  }
  public static new string HabilityName => "Juego Sucio";
  public static new int Coldturns = 2;
  public static new int Armor = 3;
  public static new int Force = 4;
  public static new int NumberOfMoves = 4;
  public static new int Visibility = 4;
  public static new Object EquipItem { get; set; }
  public static new Object EquipArmor { get; set; }

}

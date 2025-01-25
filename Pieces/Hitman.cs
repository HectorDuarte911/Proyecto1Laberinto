namespace ProjectLogic;
using Spectre.Console;
public class Hitman : PiecesBasic
{
  public override PieceType PieceType => PieceType.Hitman;
  public override Player Number { get; }
  public Hitman(Player number)
  {
    Number = number;
  }
  public static new List<Object> Inventary = new List<Object>();
  public static void Hability()
  {
    Player election = AnsiConsole.Prompt(new SelectionPrompt<Player>()
    .Title("[red]Elija a que jugador ¨silenciar¨:[/]")
    .PageSize(4)
    .HighlightStyle(new Style(foreground: Color.Red))
    .AddChoices(GameState.PlayersInGame));
    if (election != GameState.CurrentPlayer) AnsiConsole.MarkupLineInterpolated($"[DarkGoldenrod]A seleccionado a[/] [yellow]{election} [/]");
    else AnsiConsole.MarkupLineInterpolated($"[DarkGoldenrod]Parece que usted es masoquista y se a seleccionado a si mismo [/]");
    GameState.SetRestState(election, true);
    GameState.SetRestTurn(election, 2);
  }
  public static new string HabilityName => "Silenciar";
  public static new int Coldturns = 4;
  public static new int Armor = 3;
  public static new int Force = 4;
  public static new int NumberOfMoves = 4;
  public static new int Visibility = 4;
  public static new Object EquipItem { get; set; }
  public static new Object EquipArmor { get; set; }
}

namespace ProjectLogic;
using Spectre.Console;
using System.Timers;
public class General : PiecesBasic
{
  public override PieceType PieceType => PieceType.General;
  public override Player Number { get; }
  public General(Player number)
  {
    Number = number;
  }
  public static new List<Object> Inventary = new List<Object>();
  public static void OnTimedEvent(object source, ElapsedEventArgs e)
  {
    Console.Clear();
    var panel = new Panel("[red]Se acabó el tiempo[/]");
    panel.Border = BoxBorder.Ascii;
    panel.BorderColor(Color.Red);
    AnsiConsole.Write(panel);
    Console.ReadKey();
  }
  public static void StopTimer()
  {
    GameState.timer.Enabled = false;
  }
  public static void Hability()
  {
    GameState.timer.Elapsed += OnTimedEvent;
    GameState.timer.AutoReset = false;
    GameState.timer.Enabled = true;
    Canvas events = new Canvas(GameState.dim, GameState.dim);
    for (int i = 0; i < GameState.dim; i++)
    {
      for (int j = 0; j < GameState.dim; j++)
      {
        if (i == 0 || j == 0 || i == GameState.dim - 1 || j == GameState.dim - 1)
        {
          events.SetPixel(i, j, Color.DarkRed);
        }
        else if (GameState.IsEvent(GameState.Board[i, j]))
        {
          events.SetPixel(i, j, Color.Honeydew2);
        }
        else events.SetPixel(i, j, Color.Black);
      }
    }
    AnsiConsole.Write(events);
    Console.ReadKey();
    StopTimer();
    Console.Clear();
  }
  public static new string HabilityName => "Predicción de jefes";
  public static new int Coldturns = 2;
  public static new int Armor = 4;
  public static new int Force = 3;
  public static new int NumberOfMoves = 4;
  public static new int Visibility = 4;
  public static new Object EquipItem { get; set; }
  public static new Object EquipArmor { get; set; }
}

using Spectre.Console;
using System.Timers;
namespace ProjectLogic;
public class Veterano : PiecesBasic//All espesifications in PieceBasic class exept the hability
{
  public override PieceType PieceType => PieceType.Veterano;
  public override Player Number { get; }
  public Veterano(Player number)
  {
    Number = number;
  }
  public static new List<Object> Inventary = new List<Object>();
  public static void Hability()//Can see a map whith only the tramps mark in the timer of 15s 
  {
    GameState.timer.Elapsed += General.OnTimedEvent;
    GameState.timer.AutoReset = false;
    GameState.timer.Enabled = true;
    Canvas trampas = new Canvas(GameState.dim, GameState.dim);
    for (int i = 0; i < GameState.dim; i++)
    {
      for (int j = 0; j < GameState.dim; j++)
      {
        if (i == 0 || j == 0 || i == GameState.dim - 1 || j == GameState.dim - 1)
        {
          trampas.SetPixel(i, j, Color.DarkRed);
        }
        else if (Board.IsATrap(GameState.Board[i, j]))
        {
          trampas.SetPixel(i, j, Color.Honeydew2);
        }
        else trampas.SetPixel(i, j, Color.Black);
      }
    }
    AnsiConsole.Write(trampas);
    Console.ReadKey();
    General.StopTimer();
    Console.Clear();
  }
  public static new string HabilityName => "Juego Limpio";
  public static new int Coldturns = 2;
  public static new int Armor = 3;
  public static new int Force = 4;
  public static new int NumberOfMoves = 4;
  public static new int Visibility = 4;
  public static new Object EquipItem { get; set; }
  public static new Object EquipArmor { get; set; }
}


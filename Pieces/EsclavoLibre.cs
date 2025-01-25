using Spectre.Console;

namespace ProjectLogic;
public class EsclavoLibre : PiecesBasic
{
  public override PieceType PieceType => PieceType.EsclavoLibre;
  public override Player Number { get; }
  public EsclavoLibre(Player number)
  {
    Number = number;
  }
  public static new List<Object> Inventary = new List<Object>();
  public static void Hability()
  {
    if (EquipItem == Object.none)
    {
      var panel = new Panel("Te afilaste las uñas felicidades");
      panel.Border = BoxBorder.Ascii;
      panel.BorderColor(Color.Green);
      AnsiConsole.Write(panel);
    }
    if (ObjectsStats.StatsForce[EquipItem] < 10)
    {
      ObjectsStats.StatsForce[EquipItem] += 1;
    }
    else ObjectsStats.StatsForce[EquipItem] += 2;
  }
  public static new string HabilityName => "A afilar el machete";
  public static new int Coldturns = 2;
  public static new int Armor = 5;
  public static new int Force = 5;
  public static new int NumberOfMoves = 4;
  public static new int Visibility = 4;
  public static new Object EquipArmor { get; set; }
  public static new Object EquipItem { get; set; }
}


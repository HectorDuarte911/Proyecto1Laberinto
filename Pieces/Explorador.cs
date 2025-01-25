namespace ProjectLogic;
using Spectre.Console;
public class Explorador : PiecesBasic
{
  public override PieceType PieceType => PieceType.Explorador;
  public override Player Number { get; }
  public Explorador(Player number)
  {
    Number = number;
  }
  public static new List<Object> Inventary = new List<Object>();
  public static void Hability(PiecesBasic enemypiece)
  {
    var table = new Table();
    table.AddColumn("[red]Tipo[/]").Centered();
    table.AddColumn(new TableColumn("[red]Fuerza[/]").Centered());
    table.AddColumn(new TableColumn("[red]Armadura[/]").Centered());
    table.AddRow($"[DarkGoldenrod]{enemypiece.PieceType}[/]", $"[orange1]{enemypiece.Force}[/]", $"[orange1]{enemypiece.Armor}[/]");
    AnsiConsole.Write(table);
  }
  public static new string HabilityName => "Chisme";
  public static new int Coldturns= 4;
  public static new int Armor= 3;
  public static new int Force = 3;
  public static new int NumberOfMoves = 5;
  public static new int Visibility = 6;
  public static new Object EquipItem { get; set; }
  public static new Object EquipArmor { get; set; }
}

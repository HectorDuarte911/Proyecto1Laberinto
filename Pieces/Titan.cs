namespace ProjectLogic;
public class Titan : PiecesBasic//Similar al Artillero
{
  public override PieceType PieceType => PieceType.Titan;
  public override Player Number { get; }
  public Titan(Player number)
  {
    Number = number;
  }
  public static new List<Object> Inventary = new List<Object>();
  public static void Hability()
  {
    if (GameState.PlayerPieceBasic(GameState.CurrentPlayer).PieceType == PieceType.Titan) Force += 4;
    else Intelectual.Force += 4;
  }
  public static void EnableHability()
  {
    if (GameState.PlayerPieceBasic(GameState.CurrentPlayer).PieceType == PieceType.Titan)
    {
      Force -= 4;
      GameState.NoNegativeStats(PieceType.Intelectual);
    }
    else
    {
      Intelectual.Force -= 4;
      GameState.NoNegativeStats(PieceType.Intelectual);
    }
  }
  public static new string HabilityName => "27 o 28";
  public static new int Coldturns = 2;
  public static new int Armor = 6;
  public static new int Force = 5;
  public static new int NumberOfMoves = 4;
  public static new int Visibility = 4;
  public static new Object EquipItem { get; set; }
  public static new Object EquipArmor { get; set; }
}


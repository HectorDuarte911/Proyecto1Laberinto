namespace ProjectLogic;
public class Bolchevique : PiecesBasic//All espesifications in PieceBasic class exept the hability
{
  public override PieceType PieceType => PieceType.Bolchevique;
  public override Player Number { get; }
  public Bolchevique(Player number)
  {
    Number = number;
  }
  public static new List<Object> Inventary = new List<Object>();
  public static void Hability()//Hability than activete this turn and cancel it efect in the end of the turn with the EnableHability method
  {
    if (GameState.PlayerPieceBasic(GameState.CurrentPlayer).PieceType == PieceType.Bolchevique)
      NumberOfMoves += GameState.NumberPLayer;
    else Intelectual.NumberOfMoves += GameState.NumberPLayer;
  }
  public static void EnableHability()
  {
    if (GameState.PlayerPieceBasic(GameState.CurrentPlayer).PieceType == PieceType.Bolchevique)
      NumberOfMoves -= GameState.NumberPLayer;
    else Intelectual.NumberOfMoves -= GameState.NumberPLayer;
  }
  public static new string HabilityName => "Solidaridad";
  public static new int Coldturns = 2;
  public static new int Armor = 4;
  public static new int Force = 4;
  public static new int NumberOfMoves = 4;
  public static new int Visibility = 4;
  public static new Object EquipItem { get; set; }
  public static new Object EquipArmor { get; set; }
}

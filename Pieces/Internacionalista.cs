namespace ProjectLogic;
public class Internacionalista : PiecesBasic  //Similar al Artillero
{
  public override PieceType PieceType => PieceType.Internacionalista;
  public override Player Number { get; }
  public Internacionalista(Player number)
  {
    Number = number;
  }
  public static new List<Object> Inventary = new List<Object>();
  public static void Hability()
  {
    if (GameState.PlayerPieceBasic(GameState.CurrentPlayer).PieceType == PieceType.Internacionalista)
      NumberOfMoves += GameState.NumberPLayer;
    else Intelectual.NumberOfMoves += GameState.NumberPLayer;
  }
  public static void EnableHability()
  {
    if (GameState.PlayerPieceBasic(GameState.CurrentPlayer).PieceType == PieceType.Internacionalista)
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

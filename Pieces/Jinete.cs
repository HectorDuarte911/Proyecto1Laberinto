namespace ProjectLogic;
public class Jinete : PiecesBasic
{
  public override PieceType PieceType => PieceType.Jinete;
  public override Player Number { get; }
  public Jinete(Player number)
  {
    Number = number;
  }
  public static new List<Object> Inventary = new List<Object>();
  public static void Hability()
  {
    if (GameState.PlayerPieceBasic(GameState.CurrentPlayer).PieceType == PieceType.Jinete) Force += NumberOfMovesDoing / 2;
    else Intelectual.Force += NumberOfMovesDoing / 2;
    GameState.ActivationAux = NumberOfMovesDoing / 2;
  }
  public static void EnableHability()
  {
    if (GameState.PlayerPieceBasic(GameState.CurrentPlayer).PieceType == PieceType.Jinete) Force -= GameState.ActivationAux;
    else Intelectual.Force -= GameState.ActivationAux;
  }
  public static new string HabilityName => "Cargar";
  public static new int Coldturns = 2;
  public static new int Armor = 2;
  public static new int Force = 4;
  public static new int NumberOfMoves = 5;
  public static new int Visibility = 5;
  public static new Object EquipItem { get; set; }
  public static new Object EquipArmor { get; set; }

}

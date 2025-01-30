namespace ProjectLogic;
public class Soldado : PiecesBasic//All espesifications in PieceBasic class exept the hability
{
  public override PieceType PieceType => PieceType.Soldado;
  public override Player Number { get; }
  public Soldado(Player number)
  {
    Number = number;
  }
  public static new List<Object> Inventary = new List<Object>();
  public static void Hability()//Change the value of the variant of activation than add a espesific action in the program class 
  {
    GameState.VariantActivation = true;
  }
  public static new string HabilityName => "Inmmortal";
  public static new int Coldturns = 2;
  public static new int Armor = 4;
  public static new int Force = 4;
  public static new int NumberOfMoves = 4;
  public static new int Visibility = 4;
  public static new Object EquipItem { get; set; }
  public static new Object EquipArmor { get; set; }
}

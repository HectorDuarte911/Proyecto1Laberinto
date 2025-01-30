namespace ProjectLogic;
public class None : PiecesBasic//This is only to no have problem with the abstract class and the null reference
{
  public override PieceType PieceType => PieceType.None;
  public override Player Number { get; }
  public static new int NumberOfMoves = 0;
}


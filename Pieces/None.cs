namespace ProjectLogic;
public class None : PiecesBasic
{
  public override PieceType PieceType => PieceType.None;
  public override Player Number { get; }
  public static new int NumberOfMoves = 0;
}


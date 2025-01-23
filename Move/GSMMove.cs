namespace ProjectLogic;
public class GSMMove:GSMDirection
{
 public static IEnumerable<Move> LegalMoveForPieces(Position pos)//Posibles movimientos de la pieza del jugador
    {
        PiecesBasic piece = GameState.PieceBoard[pos];
        IEnumerable<Move> moveCandidates = piece.GetMoves(pos, GameState.Board);//Copiando todos los movimientos posibles de la pieza
        return moveCandidates.Where(move => move.Caminable(GameState.Board) && !PieceBoard.IsAPiece(move.ToPos) && !EsEvento(GameState.Board[move.ToPos]));//Comprobando si son legales y retornando los que lo son
    }
    public static IEnumerable<string> PositionsMoves(IEnumerable<Move> moves)
    {
        foreach (Move move in moves)
        {
          yield return new string ($"{move.ToPos.Row},{move.ToPos.Column}");       
        }
    }
    public static List<string> PositionsListString(List<Position> positions)
    {
        List<string>movestring=new List<string>();
        foreach (Position pos in positions)
        {
          movestring.Add( new string ($"{pos.Row},{pos.Column}"));       
        }
        return movestring;
    }    
    public static int CountPosition(IEnumerable<Move> positions)
    {
    int count =0;
        foreach (Move move in positions)
        {
            count++;
        }
        return count;
    }
}
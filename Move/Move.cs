namespace ProjectLogic;
public class Move
{
    public static readonly Direction[] dirs = new Direction[]
    {
      Direction.Up,
      Direction.Down,
      Direction.Right,
      Direction.Left,
    };
    public Position FromPos { get; }
    public Position ToPos { get; }
    public Move(Position from, Position to)
    {
        FromPos = from;
        ToPos = to;
    }
    public bool Caminable(Board board)
    {
        return board[ToPos] != CellsType.Obstaculos && board[ToPos] != CellsType.Wall;
    }
    public static IEnumerable<Move> GetMoves(Position from, Board board)
    {
        return MovePositionInDirs(from, board).Select(to => new Move(from, to));
    }
    public static IEnumerable<Position> MovePositionInDirs(Position from, Board board)
    {
        foreach (Direction dir in dirs)
        {
            for (int i = 1; i <= GameState.GetNumberOfMove(GameState.PlayerPieceBasic(GameState.CurrentPlayer)) - PiecesBasic.NumberOfMovesDoing; i++)
            {
                Position to = from + i * dir;
                if (!Board.IsInside(to)) break;
                if (board[to] != CellsType.Wall || board[to] != CellsType.Obstaculos) yield return to;
                else if (PieceBoard.IsAPiece(to) || GameState.IsEvent(GameState.Board[to])) continue;
                else break;
            }
        }
    }
    public static IEnumerable<Move> LegalMoveForPieces(Position pos)
    {
        PiecesBasic piece = GameState.PieceBoard[pos];
        IEnumerable<Move> moveCandidates = Move.GetMoves(pos, GameState.Board);
        return moveCandidates.Where(move => move.Caminable(GameState.Board) && !PieceBoard.IsAPiece(move.ToPos) && !GameState.IsEvent(GameState.Board[move.ToPos]));
    }
    public static IEnumerable<string> PositionsMoves(IEnumerable<Move> moves)
    {
        foreach (Move move in moves)
        {
            yield return new string($"{move.ToPos.Row},{move.ToPos.Column}");
        }
    }
    public static List<string> PositionsListString(List<Position> positions)
    {
        List<string> movestring = new List<string>();
        foreach (Position pos in positions)
        {
            movestring.Add(new string($"{pos.Row},{pos.Column}"));
        }
        return movestring;
    }
    public static int CountPosition(IEnumerable<Move> positions)
    {
        int count = 0;
        foreach (Move move in positions)
        {
            count++;
        }
        return count;
    }
}
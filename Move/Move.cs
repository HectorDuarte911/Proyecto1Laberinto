namespace ProjectLogic;
public class Move
{
    //Directions of the moves
    public static readonly Direction[] dirs = new Direction[]
    {
      Direction.Up,
      Direction.Down,
      Direction.Right,
      Direction.Left,
    };
    //Positons from move and position to move  
    public Position FromPos { get; }
    public Position ToPos { get; }
    public Move(Position from, Position to)
    {
        FromPos = from;
        ToPos = to;
    }
    //Comprobation if is a wall or if is no a wall and can walk to the position
    public bool CanWalk(Board board)
    {
        return board[ToPos] != CellsType.Obstaculos && board[ToPos] != CellsType.Wall;
    }
    //Verificate the positions than you can move
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
     //This methonds convert this positions to the actual move
    public static IEnumerable<Move> GetMoves(Position from, Board board)
    {
        return MovePositionInDirs(from, board).Select(to => new Move(from, to));
    }
    //This return all the moves viable to a piece in the principals directions
    public static IEnumerable<Move> LegalMoveForPieces(Position pos)
    {
        PiecesBasic piece = GameState.PieceBoard[pos];
        IEnumerable<Move> moveCandidates =GetMoves(pos, GameState.Board);
        return moveCandidates.Where(move => move.CanWalk(GameState.Board) && !PieceBoard.IsAPiece(move.ToPos) && !GameState.IsEvent(GameState.Board[move.ToPos]));
    }
    //Convert a move colection in a string colection of the to positons move
    public static IEnumerable<string> PositionsMoves(IEnumerable<Move> moves)
    {
        foreach (Move move in moves)
        {
            yield return new string($"{move.ToPos.Row},{move.ToPos.Column}");
        }
    }
    //Convert a position colection in a string colection
    public static List<string> PositionsListString(List<Position> positions)
    {
        List<string> movestring = new List<string>();
        foreach (Position pos in positions)
        {
            movestring.Add(new string($"{pos.Row},{pos.Column}"));
        }
        return movestring;
    }
    //Count the number of moves 
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
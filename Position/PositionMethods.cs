namespace ProjectLogic;
public class PositionMethods :BoolMethods
{
    //Retorn the position of the piece of a player
    public static Position PositionPiece(Player player)
    {
        foreach (Position pos in PiecePositions())
        {
            if (GameState.PieceBoard[pos].Number == player) return pos;
        }
        throw new Exception("Jugador no está en juego");
    }
    //Return all the positions of the pieces in the piece board
    public static IEnumerable<Position> PiecePositions()
    {
        for (int i = 0; i < GameState.dim; i++)
        {
            for (int j = 0; j < GameState.dim; j++)
            {
                Position pos = new Position(i, j);
                if (PieceBoard.IsAPiece(pos)) yield return pos;
            }
        }
    }
    //Return a colection of the positions between the from move postion and the to move position
    public static IEnumerable<Position> GetInterPos(Move move)
    {
        Direction i = Direction.GetMoveDirection(move);
        Position ipos = Direction.ConvertToPos(i);
        int increment = 0;
        int count = 0;
        if (i.RowDelta == 0) increment = Math.Abs(move.ToPos.Column - move.FromPos.Column);
        if (i.ColumnDelta == 0) increment = Math.Abs(move.ToPos.Row - move.FromPos.Row);
        while (count != increment)
        {
            yield return new Position(move.FromPos.Row + ipos.Row, move.FromPos.Column + ipos.Column);
            count++;
            ipos += Direction.GetMoveDirection(move);
        }
    }
    //Return a list of all the positions of the portal
    public static List<Position> CompatiblePortal()
    {
        List<Position> positions = new List<Position>() { };
        for (int i = 0; i < GameState.dim; i++)
        {
            for (int j = 0; j < GameState.dim; j++)
            {
                Position pos = new Position(i, j);
                if (GameState.Board[pos] == CellsType.portales) positions.Add(pos);
            }
        }
        return positions;
    }
    //Return all the cells than you can fight adyacent to the position of your piece
    public static List<Position> FightCells()
    {
        List<Position> fightcells = new List<Position>();
        int NumberOfMovesDoingAux = PiecesBasic.NumberOfMovesDoing;
        Direction[] dirs = Move.dirs;
        PiecesBasic.NumberOfMovesDoing = GetNumberOfMove(GameState.PlayerPieceBasic(GameState.CurrentPlayer)) - 1;
        for (int i = 0; i < 4; i++)
        {
            if (Board.IsInside(PositionPiece(GameState.CurrentPlayer) + dirs[i]))
            {
                Position pos = PositionPiece(GameState.CurrentPlayer) + dirs[i];
                if (PieceBoard.IsAPiece(pos) && !IsInRest(GameState.PieceBoard[pos].Number) || IsEvent(GameState.Board[pos]))
                {
                    fightcells.Add(pos);
                }
            }
        }
        PiecesBasic.NumberOfMovesDoing = NumberOfMovesDoingAux;
        return fightcells;
    }
    //Return all the adyacents cells than have the same cellstype and piecetype introduced
    public static List<Position> GetAdyacetsCells(CellsType type, PieceType typepiece)
    {
        List<Position> adyacents = new List<Position>() { };
        int NumberOfMovesDoingAux = PiecesBasic.NumberOfMovesDoing;
        Direction[] dirs = Move.dirs;
        PiecesBasic.NumberOfMovesDoing = GetNumberOfMove(GameState.PlayerPieceBasic(GameState.CurrentPlayer)) - 1;
        for (int i = 0; i < 4; i++)
        {
            if (Board.IsInside(PositionPiece(GameState.CurrentPlayer) + dirs[i]))
            {
                Position pos = PositionPiece(GameState.CurrentPlayer) + dirs[i];
                if (GameState.Board[pos] == type && GameState.PieceBoard[pos].PieceType == typepiece &&
                pos.Row != 0 && pos.Column != 0 && pos.Column != GameState.dim - 1 && pos.Row != GameState.dim - 1)
                {
                    adyacents.Add(pos);
                }
            }
        }
        PiecesBasic.NumberOfMovesDoing = NumberOfMovesDoingAux;
        return adyacents;
    }
    //Method to mix a list of positions
    public static void MixPositions(List<Position> array)
    {
        Random random = new Random();
        int n = array.Count;
        for (int i = n - 1; i >= 0; i--)
        {
            int j = random.Next(0, i + 1);
            Position aux = array[i];
            array[i] = array[j];
            array[j] = aux;
        }
    }
}
namespace ProjectLogic;
public class GSMPosition:GSMPiece
{
    public static Position PosicionPieza(Player player)
    {
        foreach (Position pos in PiecePositions())
        {
        if (GameState.PieceBoard[pos].Number == player) return pos;
        }
        return new Position(0, 0);
    }
    public static IEnumerable<Position> PiecePositions()
    {
        for (int i = 0; i < GameState.dim ; i++)
        {
            for (int j = 0; j < GameState.dim ; j++)
            {
                Position pos = new Position(i, j);
                if (PieceBoard.IsAPiece(pos))yield return pos;
            }
        }
    }
    public static IEnumerable<Position> GetInterPos(Move move)
    {
        Direction i = GetMoveDirection(move);
        Position ipos=Direction.ConverToPos(i);
        int increment = 0;
        int count=0;
        if (i.RowDelta == 0) increment = Math.Abs(move.ToPos.Column - move.FromPos.Column);
        if (i.ColumnDelta == 0) increment = Math.Abs(move.ToPos.Row - move.FromPos.Row);
        while(count!=increment)
        {
            yield return new Position(move.FromPos.Row + ipos.Row,move.FromPos.Column + ipos.Column);
            count++;
            ipos += GetMoveDirection(move);
        } 
    }
public static List<Position> PortalCompatible()
    {
        List<Position> position = new List<Position>() { };
        for (int i = 0; i < GameState.dim ; i++)
        {
            for (int j = 0; j < GameState.dim ; j++)
            {
                Position pos = new Position(i, j);
                if (GameState.Board[pos] == CellsType.portales) position.Add(pos);
            }
        }
        return position;
    }
public static List<Position> CasillasAdyacentesAlcanzables()
    {
        List<Position> casillasparaLuchar = new List<Position>();
        int NumberOfMovesDoingAux = PiecesBasic.NumberOfMovesDoing;
        Direction[] dirs = DirPieza(PlayerPiece(GameState.CurrentPlayer));
        PiecesBasic.NumberOfMovesDoing = NumeroDeMov(PlayerPieceBasic(GameState.CurrentPlayer)) - 1;
        for (int i = 0; i < 4; i++)
        {
            if (Board.IsInside(PosicionPieza(GameState.CurrentPlayer) + dirs[i]))
            {
                Position pos = PosicionPieza(GameState.CurrentPlayer) + dirs[i];
                if (PieceBoard.IsAPiece(pos) && !EstaEnReposo(GameState.PieceBoard[pos].Number) || EsEvento(GameState.Board[pos]))
                {
                    casillasparaLuchar.Add(pos);
                }
            }
        }
        PiecesBasic.NumberOfMovesDoing = NumberOfMovesDoingAux;
        return casillasparaLuchar;
    }
    public static List<Position> CasillasAdyacentesTipo(CellsType tipo , PieceType tipopiece)
    {
        List<Position> adyacentes = new List<Position>() {};
        int NumberOfMovesDoingAux = PiecesBasic.NumberOfMovesDoing;
        Direction[] dirs = DirPieza(PlayerPiece(GameState.CurrentPlayer));
        PiecesBasic.NumberOfMovesDoing = NumeroDeMov(PlayerPieceBasic(GameState.CurrentPlayer)) - 1;
        for (int i = 0; i < 4; i++)
        {
            if (Board.IsInside(PosicionPieza(GameState.CurrentPlayer) + dirs[i]))
            {
                Position pos = PosicionPieza(GameState.CurrentPlayer) + dirs[i];
                if (GameState.Board[pos]==tipo && GameState.PieceBoard[pos].PieceType == tipopiece &&
                pos.Row!=0 && pos.Column!=0 && pos.Column!=GameState.dim -1 && pos.Row!=GameState.dim -1)
                {
                    adyacentes.Add(pos);
                }
            }
        }
        PiecesBasic.NumberOfMovesDoing = NumberOfMovesDoingAux;
        return adyacentes;
    }









}
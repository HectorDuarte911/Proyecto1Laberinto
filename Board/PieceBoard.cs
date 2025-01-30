namespace ProjectLogic;
public class PieceBoard
{
    //Board than contains the pieces of the game
    public static PiecesBasic[,] Laberinth = new PiecesBasic[GameState.dim, GameState.dim];
    //This are links from the position class to th piece board
    public PiecesBasic this[int row, int col]
    {
        get { return Laberinth[row, col]; }
        set { Laberinth[row, col] = value; }
    }
    public PiecesBasic this[Position pos]
    {
        get { return this[pos.Row, pos.Column]; }
        set { this[pos.Row, pos.Column] = value; }
    }
    //Put the pieces in the corners of the maze
    public static void StartPiecePositions(PiecesBasic piece, Player player)
    {
        switch (player)
        {
            case Player.PrimerJugador:
                GameState.PieceBoard[new Position(1, 1)] = piece;
                break;
            case Player.SegundoJugador:
                GameState.PieceBoard[new Position(GameState.dim - 2, GameState.dim - 2)] = piece;
                break;
            case Player.TercerJugador:
                GameState.PieceBoard[new Position(1, GameState.dim - 2)] = piece;
                break;
            case Player.CuartoJugador:
                GameState.PieceBoard[new Position(GameState.dim - 2, 1)] = piece;
                break;
        }
    }
    //Put the others position whith no pieces in none
    public static void CompletePiecePositions()
    {
        for (int i = 0; i < GameState.dim; i++)
        {
            for (int j = 0; j < GameState.dim; j++)
            {
                if (!((i == 1 && j == 1) || (i == GameState.dim - 2 && j == GameState.dim - 2) ||
                  (GameState.NumberPLayer == 3 && i == 1 && j == GameState.dim - 2) ||
                  (GameState.NumberPLayer == 4 && i == GameState.dim - 2 && j == 1))) GameState.PieceBoard[i, j] = new None();
            }
        }
    }
 //Comprobation to know if in the position is a piece
    public static bool IsAPiece(Position pos)
    {
        if (GameState.PieceBoard[pos] != null) return GameState.PieceBoard[pos].PieceType != PieceType.None;
        throw new NullReferenceException();
    }
}



namespace ProjectLogic;
public class PieceBoard
{
    public static PiecesBasic[,] Laberinto = new PiecesBasic[GameState.dim, GameState.dim];

    public PiecesBasic this[int row, int col]
    {
        get { return Laberinto[row, col]; }
        set {Laberinto[row, col] = value; }

    }
    public PiecesBasic this[Position pos]
    {
        get { return this[pos.Row, pos.Column]; }
        set {this[pos.Row, pos.Column] = value;}
    }
    public static void StartPiecePositions(PiecesBasic piece,Player player)
    {
        switch(player)
        {
            case Player.PrimerJugador:
            GameState.PieceBoard[new Position(1,1)]=piece;
            break;
            case Player.SegundoJugador:
            GameState.PieceBoard[new Position(GameState.dim-2,GameState.dim-2)]=piece;
            break;
            case Player.TercerJugador:
            GameState.PieceBoard[new Position(1,GameState.dim-2)]=piece;
            break;
            case Player.CuartoJugador:
            GameState.PieceBoard[new Position(GameState.dim-2,1)]=piece;
            break;
        }
    

        }
        public static void ComplitePiecePositions()
        {
        for(int i=0;i<GameState.dim;i++)
        {
            for(int j=0;j<GameState.dim;j++)
            {
                if(!((i==1 && j==1) ||(i==GameState.dim-2 && j==GameState.dim-2) || 
                  (GameState.CantidadJugadores==3 && i==1 && j==GameState.dim-2 )||
                  (GameState.CantidadJugadores==4 && i==GameState.dim-2 && j==1))  )GameState.PieceBoard[i,j]=new None(Player.None);
            }
        }
        }
        public static bool IsAPiece(Position pos)
        {
         if(GameState.PieceBoard[pos]!=null)return GameState.PieceBoard[pos].PieceType!=PieceType.None;
          else throw new Exception("Referencia de posicion nulllll");
        }
    }



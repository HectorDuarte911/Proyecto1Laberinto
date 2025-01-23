namespace ProjectLogic;
using Spectre.Console;
public class GenerarLabForm:GenerarLabStruct
{
public static List<CellsType> ValoresPosiblesComple = new List<CellsType>()
   {
    CellsType.None,
    CellsType.None,
    CellsType.None,
    CellsType.TrampaMosquitera,
    CellsType.PasilloAgotante,
    CellsType.HoyoProfundo,
    CellsType.RanaSorpresa,
    CellsType.portales,
    CellsType.portales,
    CellsType.portales,
    CellsType.portales,
    CellsType.Cruzado,
    CellsType.CruzadoOscuro,
    CellsType.Caballero,
    CellsType.CaballeroPesado,
    CellsType.Truhan,
    CellsType.Asesino,
    CellsType.Monje,
    CellsType.Escudero,
    CellsType.Ballestero,
    CellsType.ArqueroLargo,
    CellsType.Mercenario,
    CellsType.Mazero,
    CellsType.SeñorOscuro,
   };
    public static List<CellsType> ProbabilidadesObstaculos = new List<CellsType>()
   {
    CellsType.None,
    CellsType.None,
    CellsType.None,
    CellsType.None,
    CellsType.None,
    CellsType.None,
    CellsType.None,
    CellsType.None,
    CellsType.None,
    CellsType.None,
    CellsType.None,
    CellsType.None,
    CellsType.None,
    CellsType.None,
    CellsType.None,
    CellsType.None,
    CellsType.None,
    CellsType.None,
    CellsType.Obstaculos,
   };
public static bool IsCompleteVisited(bool[,] visitadas)
    {
        for (int i = 0; i < visitadas.GetLength(0); i++)
        {
            for (int j = 0; j < visitadas.GetLength(1); j++)
            {
            if (!visitadas[i, j]) return false;
            }
        }
        return true;
    }
    public static void CompleteLab()
    {
       
        int leght = 24;
        int trampcount = 0;
        bool[,] visitadas = new bool[GameState.dim, GameState.dim];
        for (int i = 0; i < GameState.dim; i++)
        {
            for (int j = 0; j < GameState.dim; j++)
            {
                if (GameState.Board[i, j] == CellsType.Wall || GameState.Board[i, j] == CellsType.Obstaculos 
                || PieceBoard.IsAPiece(new Position(i, j)))visitadas[i, j] = true;
                else visitadas[i, j] = false;
            }
        }
        while (!IsCompleteVisited(visitadas))
        {
            Random randomRow = new Random();
            int i = randomRow.Next(1, GameState.dim - 1);
            Random randomColumn = new Random();
            int j = randomColumn.Next(1, GameState.dim - 1);
            if (!visitadas[i, j] && GameState.Board[i, j] == CellsType.None && !PieceBoard.IsAPiece(new Position(i, j)))
            {
                Random random = new Random();
                int r = random.Next(0, leght);
                if (ValoresPosiblesComple[r] == CellsType.portales)
                {
                    for (int k = 1; k < GameState.dim - 1; k++)
                    {
                        for (int l = 1; l < GameState.dim - 1; l++)
                        {
                            if (GameState.Board[k, l] == CellsType.portales && Board.IsVisualNoWall(new Position(i, j), new Position(k, l), 3))
                            {
                                while (ValoresPosiblesComple[r] == CellsType.portales)
                                {
                                 r = random.Next(0, leght);
                                }
                                break;
                            }
                        }
                    }
                }
                GameState.Board[i, j] = ValoresPosiblesComple[r];
                if (IsATrap(ValoresPosiblesComple[r])) trampcount++;
                else if (ValoresPosiblesComple[r] == CellsType.portales)  
                {
                    ValoresPosiblesComple.Remove(CellsType.portales);
                    leght--;
                }
                else if (GameState.EsEvento(ValoresPosiblesComple[r]))
                {
                    ValoresPosiblesComple.Remove(ValoresPosiblesComple[r]);
                    leght--;
                }
                 if (trampcount == 20)
                {
                    ValoresPosiblesComple.Remove(CellsType.HoyoProfundo);
                    ValoresPosiblesComple.Remove(CellsType.PasilloAgotante);
                    ValoresPosiblesComple.Remove(CellsType.RanaSorpresa);
                    ValoresPosiblesComple.Remove(CellsType.TrampaMosquitera);
                    leght-=5;
                    trampcount = 0;
                }
                visitadas[i, j] = true;
            }
        }
        GameState.Board[GameState.dim / 2, GameState.dim / 2 ] = CellsType.Final;
        int wallcount =0;
        List<Position> WallCells = new List<Position>();
        Position finalpos =new Position(GameState.dim / 2, GameState.dim / 2 );
        foreach (Direction dir in Artillero.dirs)
        {
            if(GameState.Board[finalpos + dir] == CellsType.Wall)
            {
            WallCells.Add(finalpos + dir);
            wallcount++;
            }
        }
        if(wallcount == 4)
        {
            Random random =new Random();
            int r = random.Next(0,4);
           GameState.Board[WallCells[r]] = CellsType.None;
        }
    }
    public static void ColocandoObstaculos()
    {
        for (int i = 1; i < GameState.dim-1; i++)
        {
            for (int j = 1; j < GameState.dim-1; j++)
            {
                if (GameState.Board[i, j] == CellsType.None && !PieceBoard.IsAPiece(new Position(i, j)))
                {
                    Random random = new Random();
                    int r = random.Next(0, 19);
                    GameState.Board[i, j] = ProbabilidadesObstaculos[r];
                }
            }
        }
    }
}
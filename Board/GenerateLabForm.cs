namespace ProjectLogic;
using Spectre.Console;
public class GenerateLabForm : GenerateLabStruct
{
    public static List<CellsType> RamdomCellsBuilding = new List<CellsType>()
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
    CellsType.Cofre
   };
    public static List<CellsType> ObstacleChance = new List<CellsType>()
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
    public static bool IsCompleteVisited(bool[,] visited)
    {
        for (int i = 0; i < visited.GetLength(0); i++)
        {
            for (int j = 0; j < visited.GetLength(1); j++)
            {
                if (!visited[i, j]) return false;
            }
        }
        return true;
    }
    public static void CompleteLab()
    {
        int leght = 25;
        int trampcount = 0;
        bool[,] visited = new bool[GameState.dim, GameState.dim];
        for (int i = 0; i < GameState.dim; i++)
        {
            for (int j = 0; j < GameState.dim; j++)
            {
                if (GameState.Board[i, j] == CellsType.Wall || GameState.Board[i, j] == CellsType.Obstaculos
                || PieceBoard.IsAPiece(new Position(i, j))) visited[i, j] = true;
                else visited[i, j] = false;
            }
        }
        while (!IsCompleteVisited(visited))
        {
            Random randomRow = new Random();
            int i = randomRow.Next(1, GameState.dim - 1);
            Random randomColumn = new Random();
            int j = randomColumn.Next(1, GameState.dim - 1);
            if (!visited[i, j] && GameState.Board[i, j] == CellsType.None && !PieceBoard.IsAPiece(new Position(i, j)))
            {
                Random random = new Random();
                int r = random.Next(0, leght);
                if (RamdomCellsBuilding[r] == CellsType.portales)
                {
                    for (int k = 1; k < GameState.dim - 1; k++)
                    {
                        for (int l = 1; l < GameState.dim - 1; l++)
                        {
                            if (GameState.Board[k, l] == CellsType.portales && Board.IsVisualNoWall(new Position(i, j), new Position(k, l), 3))
                            {
                                while (RamdomCellsBuilding[r] == CellsType.portales)
                                {
                                    r = random.Next(0, leght);
                                }
                                break;
                            }
                        }
                    }
                }
                GameState.Board[i, j] = RamdomCellsBuilding[r];
                if (IsATrap(RamdomCellsBuilding[r])) trampcount++;
                else if (RamdomCellsBuilding[r] == CellsType.portales)
                {
                    RamdomCellsBuilding.Remove(CellsType.portales);
                    leght--;
                }
                else if (GameState.IsEvent(RamdomCellsBuilding[r]))
                {
                    RamdomCellsBuilding.Remove(RamdomCellsBuilding[r]);
                    leght--;
                }
                if (trampcount == 20)
                {
                    RamdomCellsBuilding.Remove(CellsType.HoyoProfundo);
                    RamdomCellsBuilding.Remove(CellsType.PasilloAgotante);
                    RamdomCellsBuilding.Remove(CellsType.RanaSorpresa);
                    RamdomCellsBuilding.Remove(CellsType.TrampaMosquitera);
                    leght -= 5;
                    trampcount = 0;
                }
                visited[i, j] = true;
            }
        }
        GameState.Board[GameState.dim / 2, GameState.dim / 2] = CellsType.Final;
        int wallcount = 0;
        List<Position> WallCells = new List<Position>();
        Position finalpos = new Position(GameState.dim / 2, GameState.dim / 2);
        foreach (Direction dir in Move.dirs)
        {
            if (GameState.Board[finalpos + dir] == CellsType.Wall)
            {
                WallCells.Add(finalpos + dir);
                wallcount++;
            }
        }
        if (wallcount == 4)
        {
            Random random = new Random();
            int r = random.Next(0, 4);
            GameState.Board[WallCells[r]] = CellsType.None;
        }
    }
    public static void ObstacleGenerating()
    {
        for (int i = 1; i < GameState.dim - 1; i++)
        {
            for (int j = 1; j < GameState.dim - 1; j++)
            {
                if (GameState.Board[i, j] == CellsType.None && !PieceBoard.IsAPiece(new Position(i, j)))
                {
                    Random random = new Random();
                    int r = random.Next(0, 19);
                    GameState.Board[i, j] = ObstacleChance[r];
                }
            }
        }
    }
}
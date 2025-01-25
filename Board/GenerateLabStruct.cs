namespace ProjectLogic;
using Spectre.Console;
public class GenerateLabStruct : Board
{
    public static void StartLaberinth(int density)
    {
        int Walls = density * 8;
        density = GameState.dim * GameState.dim * density / 4;
        for (int i = 0; i < GameState.dim; i++)
        {
            for (int j = 0; j < GameState.dim; j++)
            {
                if (j == 0 || i == 0 || i == GameState.dim - 1 || j == GameState.dim - 1) GameState.Board[i, j] = CellsType.Wall;
                else GameState.Board[i, j] = CellsType.None;
            }
        }
        for (int i = 0; i < density; i++)
        {
            Random randomX = new Random();
            int x = randomX.Next(2, GameState.dim - 2);
            x = (x / 2) * 2;
            Random randomY = new Random();
            int y = randomY.Next(2, GameState.dim - 2);
            y = (y / 2) * 2;
            GameState.Board[x, y] = CellsType.Wall;
            for (int j = 0; j < Walls; j++)
            {
                int[] ArrayX = { x, x, x + 2, x - 2 };
                int[] ArrayY = { y + 2, y - 2, y, y };
                Random randomIndex = new Random();
                int r = randomIndex.Next(0, 4);
                if (GameState.Board[ArrayX[r], ArrayY[r]] == CellsType.None)
                {
                    GameState.Board[ArrayX[r], ArrayY[r]] = CellsType.Wall;
                    GameState.Board[ArrayX[r] + (x - ArrayX[r]) / 2, ArrayY[r] + (y - ArrayY[r]) / 2] = CellsType.Wall;
                }
            }
        }
        int[] rowX = { 2, 2, GameState.dim - 3, GameState.dim - 3 };
        int[] rowY = { 2, GameState.dim - 3, 2, GameState.dim - 3 };
        Direction[] dirs = Move.dirs;
        int k = 0;
        while (k < 4)
        {
            int i = rowX[k];
            int j = rowY[k];
            for (int l = 2; l <= GameState.dim - 3; l++)
            {
                if (k == 0 || k == 3) i = l;
                else j = l;
                if (GameState.Board[i, j] == CellsType.None)
                {
                    int count = 0;
                    foreach (Position pos in AdyacentCells(new Position(i, j)))
                    {
                        if (GameState.Board[pos.Row, pos.Column] == CellsType.Wall) count++;
                    }
                    if (count == 3 || (count == 2 && (GameState.Board[i, j + 1] == GameState.Board[i + 1, j] && GameState.Board[i + 1, j] == CellsType.Wall ||
                    GameState.Board[i, j - 1] == GameState.Board[i + 1, j] && GameState.Board[i + 1, j] == CellsType.Wall ||
                    GameState.Board[i, j + 1] == GameState.Board[i + 1, j] && GameState.Board[i - 1, j] == CellsType.Wall ||
                    GameState.Board[i, j - 1] == GameState.Board[i + 1, j] && GameState.Board[i - 1, j] == CellsType.Wall)))
                    {
                        while (true)
                        {
                            Random random = new Random();
                            int r = random.Next(0, dirs.Length);
                            Position position = new Position(i, j) + dirs[r];
                            if (GameState.Board[position.Row, position.Column] == CellsType.Wall)
                            {
                                GameState.Board[position.Row, position.Column] = CellsType.None;
                                break;
                            }
                        }
                    }
                }
            }
            k++;
        }
    }
    public static IEnumerable<Position> AdyacentCells(Position pos)
    {
        Direction[] dirs = Move.dirs;
        for (int i = 0; i < 4; i++)
        {
            yield return pos + dirs[i];
        }
    }
    public static void PrintLab(CellsType[,] Laberinto, Position pos)
    {
        var canvas = new Canvas(GameState.dim, GameState.dim);
        for (var i = 0; i < canvas.Width; i++)
        {
            for (var j = 0; j < canvas.Width; j++)
            {
                if(GameState.PieceBoard[i,j].PieceType != PieceType.None && Laberinto[i,j] != CellsType.NoVisible)
                {
                    switch (GameState.PieceBoard[i,j].PieceType)
                    {
                    case PieceType.Artillero:
                    canvas.SetPixel(i, j, Color.NavyBlue);
                    break;
                    case PieceType.Explorador:
                    canvas.SetPixel(i, j, Color.DarkGreen);
                    break;
                    case PieceType.EsclavoLibre:
                    canvas.SetPixel(i, j, Color.Orange4_1);
                    break;
                    case PieceType.General:
                    canvas.SetPixel(i, j, Color.DeepSkyBlue3_1);
                    break;
                    case PieceType.Holguinero:
                    canvas.SetPixel(i, j, Color.DarkCyan);
                    break;
                    case PieceType.Intelectual:
                    canvas.SetPixel(i, j, Color.PaleTurquoise1);
                    break;
                    case PieceType.Internacionalista:
                    canvas.SetPixel(i, j, Color.Red3_1);
                    break;
                    case PieceType.Jinete:
                    canvas.SetPixel(i, j, Color.SpringGreen4);
                    break;
                    case PieceType.Soldado:
                    canvas.SetPixel(i, j, Color.Blue1);
                    break;
                    case PieceType.Titan:
                    canvas.SetPixel(i, j, Color.Grey58);
                    break;
                    case PieceType.Hitman:
                    canvas.SetPixel(i, j, Color.LightSeaGreen);
                    break;
                    case PieceType.Veterano:
                    canvas.SetPixel(i, j, Color.DeepPink4);
                    break;
                    }
                }
                else if (i == pos.Row && j == pos.Column)
                {
                    canvas.SetPixel(i, j, Color.Green);
                }
                else if (Laberinto[i, j] == CellsType.Wall)
                {
                    canvas.SetPixel(i, j, Color.DarkRed_1);
                }
                else if (Laberinto[i, j] == CellsType.portales)
                {
                    canvas.SetPixel(i, j, Color.Blue3_1);
                }
                else if (Laberinto[i, j] == CellsType.NoVisible)
                {
                    canvas.SetPixel(i, j, Color.Black);
                }
                else if (Laberinto[i, j] == CellsType.Obstaculos)
                {
                    canvas.SetPixel(i, j, Color.Orange4);
                }
                else if (GameState.IsEvent(Laberinto[i, j]))
                {
                    switch(Laberinto[i,j])
                    {
                        case CellsType.Final:
                        canvas.SetPixel(i, j, Color.Purple4);
                        break;
                         case CellsType.Cruzado:
                        canvas.SetPixel(i, j, Color.Gold3);
                        break;
                         case CellsType.CruzadoOscuro:
                        canvas.SetPixel(i, j, Color.DarkKhaki);
                        break;
                         case CellsType.Mazero:
                        canvas.SetPixel(i, j, Color.GreenYellow);
                        break;
                         case CellsType.Monje:
                        canvas.SetPixel(i, j, Color.DarkOrange3_1);
                        break;
                         case CellsType.Mercenario:
                        canvas.SetPixel(i, j, Color.Plum2);
                        break;
                         case CellsType.Caballero:
                        canvas.SetPixel(i, j, Color.Yellow);
                        break;
                         case CellsType.CaballeroPesado:
                        canvas.SetPixel(i, j, Color.LightSteelBlue1);
                        break; 
                        case CellsType.Ballestero:
                        canvas.SetPixel(i, j, Color.MistyRose1);
                        break;
                         case CellsType.ArqueroLargo:
                        canvas.SetPixel(i, j, Color.Grey30);
                        break;
                         case CellsType.Asesino:
                        canvas.SetPixel(i, j, Color.Olive);
                        break;
                         case CellsType.Escudero:
                        canvas.SetPixel(i, j, Color.SandyBrown);
                        break;
                         case CellsType.SeñorOscuro:
                        canvas.SetPixel(i, j, Color.SandyBrown);
                        break;
                         case CellsType.Truhan:
                        canvas.SetPixel(i, j, Color.SandyBrown);
                        break;
                    }
                }
                else
                {
                    canvas.SetPixel(i, j, Color.White);
                }
                
            }
        }
        AnsiConsole.Write(canvas);
        Console.WriteLine("\n");
    }
}

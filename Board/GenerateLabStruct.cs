namespace ProjectLogic;
using Spectre.Console;
public class GenerateLabStruct : Board
{
    //This methond is the one who create the walls of the maze ,resive a density (always one because if better whith that number) and create wall
    // whith an algorithm than from a initial position see 2 cells of distanse ,if is empty put a wall in that position and the position between 
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
    }
    //Return the positions on the principal directions adyacents from a position
    public static IEnumerable<Position> AdyacentCells(Position pos)
    {
        Direction[] dirs = Move.dirs;
        for (int i = 0; i < 4; i++)
        {
            yield return pos + dirs[i];
        }
    }
    //Print the Maze
    public static void PrintLab(CellsType[,] Laberinth, Position pos)
    {
        var canvas = new Canvas(GameState.dim, GameState.dim);
        for (var i = 0; i < canvas.Width; i++)
        {
            for (var j = 0; j < canvas.Width; j++)
            {
                if(GameState.PieceBoard[i,j].PieceType != PieceType.None && Laberinth[i,j] != CellsType.NoVisible)
                {
                    switch (GameState.PieceBoard[i,j].PieceType)
                    {
                    case PieceType.Artillero:
                    canvas.SetPixel(i, j, Color.Red3);
                    break;
                    case PieceType.Explorador:
                    canvas.SetPixel(i, j, Color.DarkGreen);
                    break;
                    case PieceType.EsclavoLibre:
                    canvas.SetPixel(i, j, Color.DarkOrange3);
                    break;
                    case PieceType.General:
                    canvas.SetPixel(i, j, Color.LightSkyBlue3);
                    break;
                    case PieceType.Holguinero:
                    canvas.SetPixel(i, j, Color.RoyalBlue1);
                    break;
                    case PieceType.Intelectual:
                    canvas.SetPixel(i, j, Color.OrangeRed1);
                    break;
                    case PieceType.Bolchevique:
                    canvas.SetPixel(i, j, Color.Green3);
                    break;
                    case PieceType.Jinete:
                    canvas.SetPixel(i, j, Color.Teal);
                    break;
                    case PieceType.Soldado:
                    canvas.SetPixel(i, j, Color.Navy);
                    break;
                    case PieceType.Titan:
                    canvas.SetPixel(i, j, Color.Olive);
                    break;
                    case PieceType.Hitman:
                    canvas.SetPixel(i, j, Color.Purple4);
                    break;
                    case PieceType.Veterano:
                    canvas.SetPixel(i, j, Color.LightCyan1);
                    break;
                    }
                }
                else if (i == pos.Row && j == pos.Column        )canvas.SetPixel(i, j, Color.Green);
                else if (Laberinth[i, j] == CellsType.Wall      )canvas.SetPixel(i, j, Color.DarkRed_1);
                else if (Laberinth[i, j] == CellsType.portales  )canvas.SetPixel(i, j, Color.Aqua);
                else if (Laberinth[i, j] == CellsType.NoVisible )canvas.SetPixel(i, j, Color.Black);
                else if (Laberinth[i, j] == CellsType.Obstaculos)canvas.SetPixel(i, j, Color.Grey39);
                else if (Laberinth[i,j] == CellsType.Cofre      )canvas.SetPixel(i, j,Color.Orange4);
                else if (GameState.IsEvent(Laberinth[i, j])     )
                {
                    switch(Laberinth[i,j])
                    {
                        case CellsType.Final:
                        canvas.SetPixel(i, j, Color.Cornsilk1);
                        break;
                         case CellsType.Cruzado:
                        canvas.SetPixel(i, j, Color.LightCoral);
                        break;
                         case CellsType.CruzadoOscuro:
                        canvas.SetPixel(i, j, Color.RosyBrown);
                        break;
                         case CellsType.Mazero:
                        canvas.SetPixel(i, j, Color.Yellow2);
                        break;
                         case CellsType.Monje:
                        canvas.SetPixel(i, j, Color.Blue);
                        break;
                         case CellsType.Mercenario:
                        canvas.SetPixel(i, j, Color.Plum1);
                        break;
                         case CellsType.Caballero:
                        canvas.SetPixel(i, j, Color.Maroon);
                        break;
                         case CellsType.CaballeroPesado:
                        canvas.SetPixel(i, j, Color.Lime);
                        break; 
                        case CellsType.Ballestero:
                        canvas.SetPixel(i, j, Color.Yellow3_1);
                        break;
                         case CellsType.ArqueroLargo:
                        canvas.SetPixel(i, j, Color.DeepPink2);
                        break;
                         case CellsType.Asesino:
                        canvas.SetPixel(i, j, Color.BlueViolet);
                        break;
                         case CellsType.Escudero:
                        canvas.SetPixel(i, j, Color.HotPink);
                        break;
                         case CellsType.SeñorOscuro:
                        canvas.SetPixel(i, j, Color.Orange4_1);
                        break;
                         case CellsType.Truhan:
                        canvas.SetPixel(i, j, Color.SandyBrown);
                        break;
                    }
                }
                else canvas.SetPixel(i, j, Color.White);
            }
        }
        AnsiConsole.Write(canvas);
        Console.WriteLine("\n");
    }
}

namespace ProjectLogic;
using Spectre.Console;
using NAudio.Wave;
public class Program//This is the main class than resive reference of all other class , specially the GamaState class
{
    public static void Main(string[] args)
    {
        while (true)
        { 
            Console.Clear();
            var panelmusic = new Panel($"[yellow]Antes de empezar elije cual de las pistas sonará durante la partidada[/]");
            panelmusic.Border = BoxBorder.Double;
            AnsiConsole.Write(panelmusic);
             string electionmusic = AnsiConsole.Prompt(new SelectionPrompt<string>()
            .PageSize(13)
            .HighlightStyle(new Style(foreground: Spectre.Console.Color.Red))
            .AddChoices(
            "Artillero",
            "EsclavoLibre",
            "Explorador",
            "General",
            "Hitman",
            "Holguinero",
            "Intelectual",
            "Bolchevique",
            "Soldado",
            "Jinete",
            "Titan",
            "Veterano",
            "Inicio"
            ));
            GameState.ChangeMusicIndex(electionmusic);
            Thread music = new Thread(GameState.PlayAudio);
            music.Start();
            bool flag = true, Activation = false;
            bool end = false;
            while (flag)
            {
                Console.Clear();
                int leftspace = (Console.WindowWidth / 2) - 20;
                AnsiConsole.Markup(@"[DarkGoldenrod]
                                             ▄████  ▒█████  ▓█████▄   ██████     ██▓ ██▀███   ▒█████   ███▄    █    ▄▄▄█████▓▓█████   ██████ ▄▄▄█████▓
                                             ██▒ ▀█▒▒██▒  ██▒▒██▀ ██▌▒██    ▒    ▓██▒▓██ ▒ ██▒▒██▒  ██▒ ██ ▀█   █    ▓  ██▒ ▓▒▓█   ▀ ▒██    ▒ ▓  ██▒ ▓▒
                                            ▒██░▄▄▄░▒██░  ██▒░██   █▌░ ▓██▄      ▒██▒▓██ ░▄█ ▒▒██░  ██▒▓██  ▀█ ██▒   ▒ ▓██░ ▒░▒███   ░ ▓██▄   ▒ ▓██░ ▒░
                                            ░▓█  ██▓▒██   ██░░▓█▄   ▌  ▒   ██▒   ░██░▒██▀▀█▄  ▒██   ██░▓██▒  ▐▌██▒   ░ ▓██▓ ░ ▒▓█  ▄   ▒   ██▒░ ▓██▓ ░ 
                                            ░▒▓███▀▒░ ████▓▒░░▒████▓ ▒██████▒▒   ░██░░██▓ ▒██▒░ ████▓▒░▒██░   ▓██░     ▒██▒ ░ ░▒████▒▒██████▒▒  ▒██▒ ░ [/]
                                        [DarkRed_1]    ░▒   ▒ ░ ▒░▒░▒░  ▒▒▓  ▒ ▒ ▒▓▒ ▒ ░   ░▓  ░ ▒▓ ░▒▓░░ ▒░▒░▒░ ░ ▒░   ▒ ▒      ▒ ░░   ░░ ▒░ ░▒ ▒▓▒ ▒ ░  ▒ ░░   
                                            ░   ░   ░ ▒ ▒░  ░ ▒  ▒ ░ ░▒  ░ ░    ▒ ░  ░▒ ░ ▒░  ░ ▒ ▒░ ░ ░░   ░ ▒░       ░     ░ ░  ░░ ░▒  ░ ░    ░    
                                            ░ ░   ░ ░ ░ ░ ▒   ░ ░  ░ ░  ░  ░      ▒ ░  ░░   ░ ░ ░ ░ ▒     ░   ░ ░      ░         ░   ░  ░  ░    ░      
                                            ░     ░ ░     ░          ░      ░     ░         ░ ░           ░                ░  ░      ░           [/]");
                Console.WriteLine("\n");//Obtions of the principal menu
                var obtions = new[] {
                new string (' ',leftspace ) + "[DarkGoldenrod]           CARGAR PARTIDA       [/]" + '\n',
                new string (' ',leftspace ) + "[DarkGoldenrod]           OBCIÓN PARTIDA       [/]" + '\n',
                new string (' ',leftspace ) + "[DarkGoldenrod]           INFORM JUGADOR       [/]" + '\n',
                new string (' ',leftspace ) + "[DarkGoldenrod]               SALIR            [/]" + '\n'};
                var MenuElection = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title(new string(' ', leftspace) + "[yellow]                 MENUS            [/]")
                .PageSize(4)
                .HighlightStyle(new Style(foreground: Color.Red))
                .AddChoices(obtions));
                if (MenuElection == obtions[3])
                {
                    if (NoDoingActions.Confirm("Estás seguro que quieres salir del juego ?") == 'y')
                    {
                        Console.Clear(); end = true; break;
                    }
                }
                if (MenuElection == obtions[2]) GameState.InfoGame();
                if (MenuElection == obtions[1])
                {
                    if (NoDoingActions.Confirm("Estás seguro que quieres seleccionar las Obciones de Partida ?") == 'y') GameState.GameObcions();
                }
                if (MenuElection == obtions[0])
                {
                    if (NoDoingActions.Confirm("Estás seguro de empezar la partida con estos datos de generación ?") == 'y')
                    {
                        Console.Clear(); flag = false;
                    }
                }
            }
            if (end)
            {
                GameState.StopAudio();
                break;
            }
            flag = true;
            GenerateLabStruct.StartLaberinth(1);//Generate the walls of the maze
            GameState.CurrentPlayer = Player.PrimerJugador;
            do
            {
                GameState.SelectPiece();
            } while (!(GameState.CurrentPlayer == Player.PrimerJugador));
            Console.Clear();//Generate the rest of the maze
            PieceBoard.CompletePiecePositions();
            GenerateLabForm.ObstacleGenerating();
            GenerateLabForm.CompleteLab();
            HabilitysMethods.SetHabilityTurn(Player.PrimerJugador, 1);
            HabilitysMethods.SetHabilityTurn(Player.SegundoJugador, 1);
            if (GameState.IsInGame(Player.TercerJugador)) HabilitysMethods.SetHabilityTurn(Player.TercerJugador, 1);
            if (GameState.IsInGame(Player.CuartoJugador)) HabilitysMethods.SetHabilityTurn(Player.CuartoJugador, 1);
            while (GameState.Winner == Player.None)//This while is in action while there is not any winner
            {
                if (GameState.IsInGame(Player.PrimerJugador))
                {
                    if (GameState.CurrentPlayer == Player.PrimerJugador) GameState.Turn++;
                }
                else if (GameState.IsInGame(Player.SegundoJugador))
                {
                    if (GameState.CurrentPlayer == Player.SegundoJugador) GameState.Turn++;
                }
                else if (GameState.CurrentPlayer == Player.TercerJugador) GameState.Turn++;//See if the turns increses
                //Check the actions than the piece can do and the rest state
                NoDoingActions.UndoingActions.Remove(TurnActions.ActivarHabilidad);
                if (GameState.ComprobationActivationTurn())
                {
                    NoDoingActions.AjustAction(TurnActions.ActivarHabilidad);
                    if (!flag) HabilitysMethods.ActivationTurnPlus();
                }
                if (GameState.ComprobationRestTurn()) GameState.SetRestState(GameState.CurrentPlayer, false);
                if (GameState.IsInRest(GameState.CurrentPlayer))
                {
                    var panel1 = new Panel($"[yellow]{GameState.PlayerNameShow(GameState.CurrentPlayer)} esta en reposo[/]");
                    panel1.Border = BoxBorder.Double;
                    AnsiConsole.Write(panel1);
                    flag = false;
                }
                PiecesBasic.NumberOfMovesDoing = 0;
                bool surrender = false;
                bool fight = false;
                NoDoingActions.AjustAction(TurnActions.Caminar);
                if (GameState.PlayerPieceBasic(GameState.CurrentPlayer).PieceType == PieceType.Intelectual && Intelectual.HabilityName != "Trivia" && GameState.ComprobationActivationTurn() && GameState.Trivial)
                {
                    if (NoDoingActions.Confirm("Quieres realizar una trivia") == 'y') Intelectual.HabilityName = "Trivia";
                }
                while (flag)//This continue while the player end his turn or surrender
                {
                    GameState.Continue();
                    //Modificate the actions of the turn corresponding to the piece and turn
                    if (GameState.VariantActivation && (GameState.PlayerPieceBasic(GameState.CurrentPlayer).PieceType == PieceType.Artillero ||
                     (GameState.PlayerPieceBasic(GameState.CurrentPlayer).PieceType == PieceType.Intelectual && Intelectual.HabilityName == Explorador.HabilityName)) &&
                     GameState.CanBreakType(CellsType.Wall)) NoDoingActions.UndoingActions.Add(TurnActions.RomperMuro);
                    if (GameState.PlayerPieceBasic(GameState.CurrentPlayer).PieceType == PieceType.Explorador ||
                    (GameState.PlayerPieceBasic(GameState.CurrentPlayer).PieceType == PieceType.Intelectual && Intelectual.HabilityName == Explorador.HabilityName))
                    {
                        NoDoingActions.UndoingActions.Remove(TurnActions.ActivarHabilidad);
                    }
                    GenerateLabStruct.PrintLab(Board.VisualPiece(GameState.PositionPiece(GameState.CurrentPlayer), Board.Laberinth), GameState.PositionPiece(GameState.CurrentPlayer));
                    if (GameState.Board[GameState.PositionPiece(GameState.CurrentPlayer)] == CellsType.portales) NoDoingActions.UndoingActions.Add(TurnActions.ActivarPortal);
                    if (PiecesBasic.NumberOfMovesDoing != 0) NoDoingActions.UndoingActions.Remove(TurnActions.ActivarPortal);
                    if (GameState.CanBreakType(CellsType.Obstaculos) && PiecesBasic.NumberOfMovesDoing == 0) NoDoingActions.UndoingActions.Add(TurnActions.DerribarObstaculos);
                    if (!GameState.IsEmpty(GameState.FightCells()) && !fight && PiecesBasic.NumberOfMovesDoing != StatsMethods.GetNumberOfMove(GameState.PlayerPieceBasic(GameState.CurrentPlayer))) NoDoingActions.UndoingActions.Add(TurnActions.Luchar);
                    var panelposition = new Panel($"[DarkGoldenrod]Estás en la posición [[{GameState.PositionPiece(GameState.CurrentPlayer).Row},{GameState.PositionPiece(GameState.CurrentPlayer).Column}]][/]");
                    panelposition.Border = BoxBorder.Double;
                    panelposition.BorderColor(Color.Red);
                    AnsiConsole.Write(panelposition);
                    TurnActions election = AnsiConsole.Prompt(new SelectionPrompt<TurnActions>()//Select the action than you will do
                    .Title("Escoja que acción realizar:")
                    .PageSize(12)
                    .HighlightStyle(new Style(foreground: Color.Red))
                    .AddChoices(NoDoingActions.UndoingActions));
                    AnsiConsole.MarkupLineInterpolated($"A seleccionado [red]{election}[/]");
                    switch (election)
                    {
                        case TurnActions.Caminar:
                            if (NoDoingActions.Confirm("Estás seguro que desea selecionar la acción ¨caminar¨") == 'y') flag = GameState.Walk(flag);
                            break;
                        case TurnActions.Luchar:
                            if (NoDoingActions.Confirm("Estás seguro que desea selecionar la acción ¨luchar¨") == 'y')
                            {
                                bool[] shange = GameState.Fight(flag, fight);
                                flag = shange[0]; fight = shange[1];
                            }
                            break;
                        case TurnActions.RomperMuro:
                            if (NoDoingActions.Confirm("Estás seguro que desea selecionar la acción ¨romper muro¨") == 'y')
                            {
                                List<string> BreakPositions = Move.PositionsListString(GameState.GetAdyacetsCells(CellsType.Wall, PieceType.None));
                                string wallposition = AnsiConsole.Prompt(new SelectionPrompt<string>()
                                .Title("[red]Elija que muro derrumbar:[/]")
                                .PageSize(12)
                                .HighlightStyle(new Style(foreground: Spectre.Console.Color.Red))
                                .AddChoices(BreakPositions));
                                AnsiConsole.MarkupLineInterpolated($"[DarkGoldenrod]A seleccionado[/] [yellow]{wallposition} [/]");
                                Position wallpos = Position.ToPosition(wallposition);
                                GameState.Board[wallpos] = CellsType.None;
                                var portalpanel = new Panel($"[green]Se destruyó el muro en la posición {wallposition}[/]");
                                portalpanel.Border = BoxBorder.Ascii;
                                AnsiConsole.Write(portalpanel);
                                NoDoingActions.UndoingActions.Remove(TurnActions.RomperMuro);
                                GameState.VariantActivation = false;
                            }
                            break;
                        case TurnActions.DerribarObstaculos:
                            if (NoDoingActions.Confirm("Estás seguro que desea selecionar la acción ¨derribar obstáculos¨") == 'y')
                            {
                                List<string> BreakPositions = Move.PositionsListString(GameState.GetAdyacetsCells(CellsType.Obstaculos, PieceType.None));
                                string obstacleposition = AnsiConsole.Prompt(new SelectionPrompt<string>()
                                .Title("[red]Elija que obstaculo derribar:[/]")
                                .PageSize(12)
                                .HighlightStyle(new Style(foreground: Spectre.Console.Color.Red))
                                .AddChoices(BreakPositions));
                                AnsiConsole.MarkupLineInterpolated($"[DarkGoldenrod]A seleccionado[/] [yellow]{obstacleposition} [/]");
                                Position wallpos = Position.ToPosition(obstacleposition);
                                GameState.Board[wallpos] = CellsType.None;
                                var portalpanel = new Panel($"[green]Se derribo el obstaculo en la posicion {obstacleposition}[/]");
                                portalpanel.Border = BoxBorder.Ascii;
                                AnsiConsole.Write(portalpanel);
                                PiecesBasic.NumberOfMovesDoing = StatsMethods.GetNumberOfMove(GameState.PlayerPieceBasic(GameState.CurrentPlayer));
                                NoDoingActions.UndoingActions.Remove(TurnActions.DerribarObstaculos);
                            }
                            break;
                        case TurnActions.ObcionesEquipo:
                            if (NoDoingActions.Confirm("Estás seguro que desea selecionar la acción ¨obciones de equipo¨") == 'y')
                            {
                                ObjectMethods.EquipOptions(flag);
                                flag = true;
                            }
                            break;
                        case TurnActions.TerminarTurno:
                            if (NoDoingActions.Confirm("Estás seguro que desea selecionar la acción ¨TerminarGameState.Turno¨") == 'y') flag = false;
                            break;
                        case TurnActions.Rendirse:
                            if (NoDoingActions.Confirm("Estás seguro que desea selecionar la acción ¨rendirse¨ si lo hace abandonará la partida") == 'y')
                            {
                                GameState.NumberPLayer--;
                                if (GameState.NumberPLayer == 1) GameState.Winner = GameState.NextPlayer(GameState.CurrentPlayer);
                                Player AuxiPlayer = GameState.NextPlayer(GameState.CurrentPlayer);
                                GameState.PlayersInGame.Remove(GameState.CurrentPlayer);
                                flag = false;
                                surrender = true;
                            }
                            break;
                        case TurnActions.ActivarHabilidad:
                            if (NoDoingActions.Confirm("Estás seguro que desea selecionar la acción ¨Activar Habilidad¨") == 'y')
                            {
                                Activation = true;
                                HabilitysMethods.AsingHability(GameState.PieceBoard[GameState.PositionPiece(GameState.CurrentPlayer)].PieceType);
                                NoDoingActions.UndoingActions.Remove(TurnActions.ActivarHabilidad);
                                Console.WriteLine();
                            }
                            break;
                        case TurnActions.ActivarPortal:
                            if (NoDoingActions.Confirm("Estás seguro que desea selecionar la acción ¨Activar Portal¨") == 'y') flag = GameState.PortalActivation(flag);
                            break;
                        case TurnActions.InfoJuego:
                            GameState.InfoGame();
                            break;
                        case TurnActions.PlayerPieceView:
                            GameState.PlayerPieceView();
                            break;
                    }
                    if (GameState.PlayerPieceBasic(GameState.CurrentPlayer).Inventary != null)//This comprove if the player have the key of victory in his inventary to win the game
                    {
                        foreach (Object Object in GameState.PlayerPieceBasic(GameState.CurrentPlayer).Inventary)
                        {
                            if (Object == Object.LlaveLaberinto)
                            {
                                GameState.Winner = GameState.CurrentPlayer;
                                flag = false;
                                break;
                            }
                        }
                    }
                    //Adjust the actions
                    NoDoingActions.UndoingActions.Remove(TurnActions.Luchar);
                    NoDoingActions.UndoingActions.Remove(TurnActions.ActivarHabilidad);
                    if (PiecesBasic.NumberOfMovesDoing == StatsMethods.GetNumberOfMove(GameState.PlayerPieceBasic(GameState.CurrentPlayer))) NoDoingActions.UndoingActions.Remove(TurnActions.Caminar);
                    NoDoingActions.UndoingActions.Remove(TurnActions.ActivarPortal);
                    NoDoingActions.UndoingActions.Remove(TurnActions.DerribarObstaculos);
                    NoDoingActions.UndoingActions.Remove(TurnActions.RomperMuro);
                    if (GameState.ComprobationActivationTurn())
                    {
                        NoDoingActions.AjustAction(TurnActions.ActivarHabilidad);
                        if (!flag) HabilitysMethods.ActivationTurnPlus();
                    }
                }
                //Ajust the parameters in the end of the turn
                NoDoingActions.UndoingActions.Remove(TurnActions.RomperMuro);
                if (Activation)
                {
                    HabilitysMethods.NegateHability(GameState.PlayerPieceBasic(GameState.CurrentPlayer).PieceType);
                    Activation = false;
                }
                GameState.VariantActivation = false;
                GameState.ActivationAux = 0;
                if (GameState.Winner != Player.None)
                {
                    int leftspace = (Console.WindowWidth / 2) - 20;
                    AnsiConsole.Write(new FigletText($" EL GANADOR ES {GameState.PlayerNameShow(GameState.Winner)} ")
                    .LeftJustified()
                    .Color(Spectre.Console.Color.Red));
                }
                if (surrender) surrender = false;
                else GameState.CurrentPlayer = GameState.NextPlayer(GameState.CurrentPlayer);
                flag = true;
            }
            if (GameState.Winner != Player.None)//Final Message if any player win
            {
                Console.Clear();
                AnsiConsole.Markup(@"[DarkGoldenrod]
                                              ██░ ██  ▄▄▄        ██████      ▄████  ▄▄▄      ███▄    █  ▄▄▄      ▓█████▄  ▒█████  
                                                ▓██░ ██▒▒████▄    ▒██    ▒     ██▒ ▀█▒▒████▄    ██ ▀█   █ ▒████▄    ▒██▀ ██▌▒██▒  ██▒
                                                ▒██▀▀██░▒██  ▀█▄  ░ ▓██▄      ▒██░▄▄▄░▒██  ▀█▄ ▓██  ▀█ ██▒▒██  ▀█▄  ░██   █▌▒██░  ██▒
                                                ░▓█ ░██ ░██▄▄▄▄██   ▒   ██▒   ░▓█  ██▓░██▄▄▄▄██▓██▒  ▐▌██▒░██▄▄▄▄██ ░▓█▄   ▌▒██   ██░
                                               ░▓█▒░██▓ ▓█   ▓██▒▒██████▒▒   ░▒▓███▀▒ ▓█   ▓██▒██░   ▓██░ ▓█   ▓██▒░▒████▓ ░ ████▓▒░[/][DarkRed_1]
                                                 ▒ ░░▒░▒ ▒▒   ▓▒█░▒ ▒▓▒ ▒ ░    ░▒   ▒  ▒▒   ▓▒█░ ▒░   ▒ ▒  ▒▒   ▓▒█░ ▒▒▓  ▒ ░ ▒░▒░▒░ 
                                                 ▒ ░▒░ ░  ▒   ▒▒ ░░ ░▒  ░ ░     ░   ░   ▒   ▒▒ ░ ░░   ░ ▒░  ▒   ▒▒ ░ ░ ▒  ▒   ░ ▒ ▒░ 
                                                 ░  ░░ ░  ░   ▒   ░  ░  ░     ░ ░   ░   ░   ▒     ░   ░ ░   ░   ▒    ░ ░  ░ ░ ░ ░ ▒  
                                                 ░  ░  ░      ░  ░      ░           ░       ░  ░        ░       ░  ░   ░        ░ ░  
                                                                                                            ░    [/]           
                    ");
            }
            GameState.StopAudio();
        }
    }
}
namespace ProjectLogic;
using Spectre.Console;
using NAudio.Wave;
public class GameState :PlayerMethods
{
    public static Board Board { get; set; } = new Board();
    public static PieceBoard PieceBoard { get; set; } = new PieceBoard();
    public static Player CurrentPlayer { get; set; }
    public static Player Winner = Player.None;
    public static int NumberPLayer = 2, dim = 33, Turn = 0, ActivationAux = 0;
    public static bool VariantActivation = false;
    static WaveOutEvent outputDevice;
    static AudioFileReader audioFile;
    public static bool isPlaying = true, Trivial = true;
    public static List<PieceType> PiecesInGame = new List<PieceType>();
    public static List<Player> PlayersInGame = new List<Player>()
    {
    Player.PrimerJugador,
    Player.SegundoJugador,
    };
    public GameState(Player player, Board board, PieceBoard pieceboard)
    {
        Board = board;
        PieceBoard = pieceboard;
        CurrentPlayer = player;
    }
    public static System.Timers.Timer timer = new System.Timers.Timer(15000);
    public static void PlayAudio()
    {
        while (isPlaying)
        {
            string projectDir = Directory.GetCurrentDirectory();
            string rute = Path.Combine(projectDir,"audio/pista 1.mp3");
            audioFile = new AudioFileReader(rute);  
            outputDevice = new WaveOutEvent();
            outputDevice.Init(audioFile);
            outputDevice.Play();
            while (outputDevice.PlaybackState == PlaybackState.Playing)
            {
                Thread.Sleep(100);
            }
            audioFile.Dispose();
            outputDevice.Dispose();
        }
    }
    public static void StopAudio()
    {
        isPlaying = false;
        if (outputDevice != null)
        {
            outputDevice.Stop();
            outputDevice.Dispose();
        }
    }
    public static void InfoJuego()
    {
        string[] obtions = {
            "                   [DarkGoldenrod]       LORE              [/]",
            "                   [DarkGoldenrod]      LEYENDA            [/]",
            "                   [DarkGoldenrod]  PIEZAS DEL JUEGO       [/]",
            "                   [DarkGoldenrod]SALIR A MENÚ PRINCIPAL   [/]"
        };
        while (true)
        {
            string election = AnsiConsole.Prompt(new SelectionPrompt<string>()
            .Title("[yelllow]  Información DE Jugador   [/]")
            .PageSize(5)
            .HighlightStyle(new Style(foreground: Spectre.Console.Color.Red))
            .AddChoices(obtions));
            AnsiConsole.MarkupLineInterpolated($"[red]Has seleccionado la obción {election}[/]");
            if (election == obtions[3]) break;
            if (election == obtions[2]) SeeLore();
            if (election == obtions[1]) SeeLeyend();
            if (election == obtions[0]) SeePieceOfGame();
        }
    }
    public static void SeeLore()
    {
        string Lore = @"[DarkGoldenrod][/]";
        var panel = new Panel(Lore);
        panel.Border = BoxBorder.Heavy;
        panel.BorderColor(Spectre.Console.Color.Red);
        AnsiConsole.Write(panel);
    }
    public static void SeeLeyend()
    {
        var table = new Table();
        table.AddColumn("[red]Color[/]");
        table.AddColumn(new TableColumn("[red]Nombre[/]").Centered());
        table.AddColumn(new TableColumn("[red]Tipo[/]").Centered());
        table.AddRow($"[red]Rojo[/]", "Arquero Largo", "Evento");
        table.AddRow($"[red]Rojo[/]", "Artillero", "Pieza");
        table.AddRow($"[red]Rojo[/]", "Asesino", "Evento");
        table.AddRow($"[red]Rojo[/]", "Ballestero", "Evento");
        table.AddRow($"[red]Rojo[/]", "Caballero", "Evento");
        table.AddRow($"[red]Rojo[/]", "Caballero Pesado", "Evento");
        table.AddRow($"[red]Rojo[/]", "Cofre", "Celda");
        table.AddRow($"[red]Rojo[/]", "Cruzado", "Evento");
        table.AddRow($"[red]Rojo[/]", "Cruzado Oscuro", "Evento");
        table.AddRow($"[red]Rojo[/]", "Esclavo Libre", "Pieza");
        table.AddRow($"[red]Rojo[/]", "Escudero", "Evento");
        table.AddRow($"[red]Rojo[/]", "Explorador", "Pieza");
        table.AddRow($"[red]Rojo[/]", "Final de Laberinto", "Evento");
        table.AddRow($"[red]Rojo[/]", "General", "Pieza");
        table.AddRow($"[red]Rojo[/]", "Hitman", "Pieza");
        table.AddRow($"[red]Rojo[/]", "Holguinero", "Pieza");
        table.AddRow($"[red]Rojo[/]", "Intelectual", "Pieza");
        table.AddRow($"[red]Rojo[/]", "Internacionalista", "Pieza");
        table.AddRow($"[red]Rojo[/]", "Jinete", "Pieza");
        table.AddRow($"[red]Rojo[/]", "Mazero", "Evento");
        table.AddRow($"[red]Rojo[/]", "Mercenario", "Evento");
        table.AddRow($"[red]Rojo[/]", "Monje", "Evento");
        table.AddRow($"[red]Rojo[/]", "Nada", "Celda");
        table.AddRow($"[red]Rojo[/]", "Obstáculo", "Celda");
        table.AddRow($"[Darkred]Rojo Oscuro[/]", "Pared", "Celda");
        table.AddRow($"[]Rojo[/]", "Portal", "Celda");
        table.AddRow($"[red]Rojo[/]", "Señor Oscuro", "Evento");
        table.AddRow($"[red]Rojo[/]", "Soldado", "Pieza");
        table.AddRow($"[red]Rojo[/]", "Titán", "Pieza");
        table.AddRow($"[red]Rojo[/]", "Truhán", "Evento");
        table.AddRow($"[red]Rojo[/]", "Veterano", "Pieza");
        table.BorderColor(Spectre.Console.Color.DarkGoldenrod);
        AnsiConsole.Write(table);
    }
    public static void SeePieceOfGame()
    {
        bool flag = true;
        while (flag)
        {
            string election = AnsiConsole.Prompt(new SelectionPrompt<string>()
            .Title("[yellow]  Escoja que pieza quiere ver   [/]")
            .PageSize(5)
            .HighlightStyle(new Style(foreground: Spectre.Console.Color.Red))
            .AddChoices(
            "Artillero",
            "EsclavoLibre",
            "Explorador",
            "General",
            "Hitman",
            "Holguinero",
            "Intelectual",
            "Internacionalista",
            "Soldado",
            "Jinete",
            "Titan",
            "Veterano",
            "Salir"
            ));
            AnsiConsole.MarkupLineInterpolated($"[red]Has seleccionado {election}[/]");
            var table = new Table();
            table.AddColumn("[red]Fuerza[/]");
            table.AddColumn(new TableColumn("[red]Armadura[/]").Centered());
            table.AddColumn(new TableColumn("[red]Casillas visibles[/]").Centered());
            table.AddColumn(new TableColumn("[red]Cantida de Movimientos[/]").Centered());
            table.AddColumn(new TableColumn("[red]Arma Equipada[/]").Centered());
            table.AddColumn(new TableColumn("[red]Armadura Equipadada[/]").Centered());
            table.AddColumn(new TableColumn("[red]Nombre Habilidad[/]").Centered());
            table.AddColumn(new TableColumn("[red]Efecto Habilidad[/]").Centered());
            table.AddColumn(new TableColumn("[red]Turnos de Enfriamiento[/]").Centered());
            switch (election)
            {
                case "Artillero":
                    table.AddRow("[DarkGoldenrod]5[/]", "[DarkGoldenrod]4[/]", "[DarkGoldenrod]4[/]", "[DarkGoldenrod]4[/]", "[DarkGoldenrod]Granadas(4)[/]", "[DarkGoldenrod]CasacaAzul(4)[/]", "[DarkGoldenrod]Rompe Muro[/]", "[DarkGoldenrod]Te permite activar la accion RomperMuro que te permite destruir una pared no extrema del laberinto tranformarla en una casilla vacia[/]", "[DarkGoldenrod]2[/]").Centered();
                    break;
                case "EsclavoLibre":
                    table.AddRow("[DarkGoldenrod]5[/]", "[DarkGoldenrod]5[/]", "[DarkGoldenrod]4[/]", "[DarkGoldenrod]4[/]", "[DarkGoldenrod]Machete sin filo(2)[/]", "[DarkGoldenrod]Ninguna[/]", "[DarkGoldenrod]A afilar Machete[/]", "[DarkGoldenrod]Te permite subirle un punto a la fuerza de tu arma equipada permanentemente o dos si posee más de 10 de fuerza[/]", "[DarkGoldenrod]2[/]").Centered();
                    break;
                case "Explorador":
                    table.AddRow("[DarkGoldenrod]3[/]", "[DarkGoldenrod]3[/]", "[DarkGoldenrod]6[/]", "[DarkGoldenrod]5[/]", "[DarkGoldenrod]Machete Corto(3)[/]", "[DarkGoldenrod]Ropa Gastada(1)[/]", "[DarkGoldenrod]Chisme[/]", "[DarkGoldenrod]Te prmite ver las estadisticas de tu adversario en una batalla[/]", "[DarkGoldenrod]4[/]").Centered();
                    break;
                case "General":
                    table.AddRow("[DarkGoldenrod]3[/]", "[DarkGoldenrod]4[/]", "[DarkGoldenrod]4[/]", "[DarkGoldenrod]4[/]", "[DarkGoldenrod]Revolver(3)[/]", "[DarkGoldenrod]Cazaca Azul Condecorada(5)[/]", "[DarkGoldenrod]Predicción de jefes[/]", "[DarkGoldenrod]Te permite observar un mapa con las posiciones de los eventos[/]", "[DarkGoldenrod]2[/]").Centered();
                    break;
                case "Hitman":
                    table.AddRow("[DarkGoldenrod]4[/]", "[DarkGoldenrod]3[/]", "[DarkGoldenrod]4[/]", "[DarkGoldenrod]4[/]", "[DarkGoldenrod]Colt 1911(5)[/]", "[DarkGoldenrod]Gabardina Negra(6)[/]", "[DarkGoldenrod]Silenciar[/]", "[DarkGoldenrod]Te permite poner en reposo a un jugador durante un turno[/]", "[DarkGoldenrod]4[/]").Centered();
                    break;
                case "Holguinero":
                    table.AddRow("[DarkGoldenrod]4[/]", "[DarkGoldenrod]3[/]", "[DarkGoldenrod]4[/]", "[DarkGoldenrod]4[/]", "[DarkGoldenrod]Machete Corto(3)[/]", "[DarkGoldenrod]Ropa Gastada(1)[/]", "[DarkGoldenrod]Juego Sucio[/]", "[DarkGoldenrod]Te permite añadir un obstáculo al tablero en una posición vacía[/]", "[DarkGoldenrod]2[/]").Centered();
                    break;
                case "Intelectual":
                    table.AddRow("[DarkGoldenrod]2[/]", "[DarkGoldenrod]2[/]", "[DarkGoldenrod]4[/]", "[DarkGoldenrod]4[/]", "[DarkGoldenrod]Revolver(3)[/]", "[DarkGoldenrod]Traje Negro(3)[/]", "[DarkGoldenrod]Trivia[/]", "[DarkGoldenrod]Te permite contestar una prgunta y si lo haces correctamente puedes elegir cambiar tu habilidad a cualquier otra[/]", "[DarkGoldenrod]2[/]").Centered();
                    break;
                case "Titan":
                    table.AddRow("[DarkGoldenrod]5[/]", "[DarkGoldenrod]6[/]", "[DarkGoldenrod]4[/]", "[DarkGoldenrod]4[/]", "[DarkGoldenrod]Machete Curvo(4)[/]", "[DarkGoldenrod]Camisa Blanca(2)[/]", "[DarkGoldenrod]27 o 28[/]", "[DarkGoldenrod]Te permite ganar 4 de fuerza durante tu turno[/]", "[DarkGoldenrod]2[/]").Centered();
                    break;
                case "Internacionalista":
                    table.AddRow("[DarkGoldenrod]4[/]", "[DarkGoldenrod]4[/]", "[DarkGoldenrod]4[/]", "[DarkGoldenrod]4[/]", "[DarkGoldenrod]Fusil(3)[/]", "[DarkGoldenrod]Camisa Blanca(2)[/]", "[DarkGoldenrod]Soliridad[/]", "[DarkGoldenrod]Te permite ganar uno extra de movimiento ese turno por cada jugador en juego[/]", "[DarkGoldenrod]2[/]").Centered();
                    break;
                case "Jinete":
                    table.AddRow("[DarkGoldenrod]2[/]", "[DarkGoldenrod]4[/]", "[DarkGoldenrod]5[/]", "[DarkGoldenrod]5[/]", "[DarkGoldenrod]Machete Largo(4)[/]", "[DarkGoldenrod]Ropa Gastada(1)[/]", "[DarkGoldenrod]Cargar[/]", "[DarkGoldenrod]Te permite ganar uno de fuerza este turno por cada movimiento hecho en el turno[/]", "[DarkGoldenrod]2[/]").Centered();
                    break;
                case "Soldado":
                    table.AddRow("[DarkGoldenrod]4[/]", "[DarkGoldenrod]4[/]", "[DarkGoldenrod]4[/]", "[DarkGoldenrod]4[/]", "[DarkGoldenrod]Fusil(3)[/]", "[DarkGoldenrod]Casaca Azul(4)[/]", "[DarkGoldenrod]Inmortal[/]", "[DarkGoldenrod]Te permite no entrar en reposo al perder una batalla en tu turno[/]", "[DarkGoldenrod][DarkGoldenrod]2[/]").Centered();
                    break;
                case "Veterano":
                    table.AddRow("[DarkGoldenrod]4[/]", "[DarkGoldenrod]3[/]", "[DarkGoldenrod]4[/]", "[DarkGoldenrod]4[/]", "[DarkGoldenrod]Machete Corto(3)[/]", "[DarkGoldenrod]Camisa Blanca(2)[/]", "[DarkGoldenrod]Juego Limpio[/]", "[DarkGoldenrod]Te permite ver la ubicación de todas  los trampas[/]", "[DarkGoldenrod]2[/]").Centered();
                    break;
                case "[DarkGoldenrod]Salir[/]":
                    flag = false;
                    break;
            }
            if (flag)
            {
                table.BorderColor(Spectre.Console.Color.Red);
                AnsiConsole.Write(table.Centered());
            }
            else break;
        }
    }
    public static void GameObcions()
    {
        Console.Clear();
        NumberPLayer = AnsiConsole.Prompt(new SelectionPrompt<int>()
        .Title("Elija la cantidad de jugadores:")
        .PageSize(3)
        .HighlightStyle(new Style(foreground: Spectre.Console.Color.Red))
        .AddChoices(2, 3, 4));
        AnsiConsole.MarkupLineInterpolated($"A seleccionado [red]{NumberPLayer} jugadores [/]");
        Console.Clear();
        if (NumberPLayer == 3) PlayersInGame.Add(Player.TercerJugador);
        if (NumberPLayer == 4)
        {
            PlayersInGame.Add(Player.TercerJugador);
            PlayersInGame.Add(Player.CuartoJugador);
        }
        foreach (Player player in PlayersInGame)
        {
            string PlayersNames = AnsiConsole.Prompt(new TextPrompt<string>($"[yellow]Nombre de {player}[/]:")
               .Validate(PlayersNames =>
               {
                   return ValidationResult.Success();
               }));
            PlayerName(player, PlayersNames);
        }
        Console.Clear();
        var obtionsDim = new[] { "33x33", "65x65", "81x81" };
        string LabDim = AnsiConsole.Prompt(new SelectionPrompt<string>()
        .Title("[red]Elija la dimensión del Laberinth[/]:")
        .PageSize(3)
        .HighlightStyle(new Style(foreground: Spectre.Console.Color.Red))
        .AddChoices(obtionsDim));
        AnsiConsole.MarkupLineInterpolated($"[red]A seleccionado {LabDim}  [/]");
        if (LabDim == obtionsDim[0]) { dim = 33; }
        if (LabDim == obtionsDim[1]) { dim = 65; }
        if (LabDim == obtionsDim[2]) { dim = 81; }
        Console.Clear();
    }
    public static void SelectPiece()
    {
        PieceType piece = AnsiConsole.Prompt(new SelectionPrompt<PieceType>()
        .Title($"[yellow]Elija su pieza {PlayerNameShow(CurrentPlayer)}[/]:")
        .PageSize(12)
        .HighlightStyle(new Style(foreground: Spectre.Console.Color.Red))
        .AddChoices(PiecesBasic.Pieces));
        AnsiConsole.MarkupLineInterpolated($"{PlayerNameShow(CurrentPlayer)} a seleccionado el tipo de pieza [red]{piece}[/]");
        PieceType piecelection = PieceType.None;
        foreach (PieceType pieces in PiecesBasic.Pieces)
        {
            if (pieces == piece)
            {
                piecelection = pieces; break;
            }
        }
        PickPiece(piecelection);
    }
    public static bool Walk(bool flag)
    {
        IEnumerable<string> PosString = Move.PositionsMoves(Move.LegalMoveForPieces(PositionPiece(CurrentPlayer)));
        string movposition = AnsiConsole.Prompt(new SelectionPrompt<string>()
        .Title("Elija a que casilla moverse:")
        .PageSize(12)
        .HighlightStyle(new Style(foreground: Spectre.Console.Color.Red))
        .AddChoices(PosString));
        AnsiConsole.MarkupLineInterpolated($"A seleccionado [red]{movposition}[/]");
        flag = true;
        Move moveAux = new Move(new Position(0, 0), new Position(0, 1));
        Move Doing = new Move(PositionPiece(CurrentPlayer), Position.ToPosition(movposition));
        GenerateLabStruct.PrintLab(Board.VisualPiece(PositionPiece(CurrentPlayer), Board.Laberinth), Position.ToPosition(movposition));
        if (NoDoingActions.Confirm($"[DarkGOldenrod]Tiene seguridad de que se quiere mover a la posición [[{movposition}]] marcada en el mapa con[/][green] verde [/]:") == 'y')
        {
            int count = Move.CountPosition(Move.LegalMoveForPieces(PositionPiece(CurrentPlayer)));
            foreach (Position pos in GetInterPos(Doing))
            {
                if (Board.IsATrap(Board[pos]))
                {
                    PieceBoard[pos] = PieceBoard[Doing.FromPos];
                    PieceBoard[Doing.FromPos] = new None();
                    flag = false;
                    moveAux = new Move(Doing.FromPos, pos);
                    break;
                }
                else
                {
                    count--;
                    if (count == 0) break;
                    continue;
                }
            }
            if (flag)
            {
                PieceBoard[Doing.ToPos] = PieceBoard[Doing.FromPos];
                PieceBoard[Doing.FromPos] = new None();
                moveAux = Doing;
            }
            else flag = true;
            int pasosrow = Math.Abs(moveAux.FromPos.Row - moveAux.ToPos.Row);
            int pasoscolumn = Math.Abs(moveAux.FromPos.Column - moveAux.ToPos.Column);
            PiecesBasic.NumberOfMovesDoing += pasoscolumn + pasosrow;
            if (Board.IsATrap(Board[moveAux.ToPos]))
            {
                var movtramp = new Panel($"[red]Ha caido en una {Board[moveAux.ToPos]} en la casilla[/] [yellow]{moveAux.ToPos.Row},{moveAux.ToPos.Column}[/]");
                movtramp.Border = BoxBorder.Square;
                AnsiConsole.Write(movtramp);
                TrampsMethods.SetTrampPenalty(Board[moveAux.ToPos]);
            }
            else
            {
                if (Board[Doing.ToPos] == CellsType.Cofre) Chest.RamdomActivation();
                var mov = new Panel($"[green]Se movió con éxito a la casilla[/][yellow] {movposition}[/]");
                mov.Border = BoxBorder.Ascii;
                AnsiConsole.Write(mov);
            }
            if (PiecesBasic.NumberOfMovesDoing == StatsMethods.GetNumberOfMove(PlayerPieceBasic(CurrentPlayer))) NoDoingActions.UndoingActions.Remove(TurnActions.Caminar);
        }
        return flag;
    }
    public static bool[] Fight(bool flag, bool fight)
    {
        List<string> PosLuchaString = Move.PositionsListString(FightCells());
        string positionlucha = AnsiConsole.Prompt(new SelectionPrompt<string>()
        .Title("[red]Elija con que casilla luchar:[/]")
        .PageSize(12)
        .HighlightStyle(new Style(foreground: Spectre.Console.Color.Red))
        .AddChoices(PosLuchaString));
        AnsiConsole.MarkupLineInterpolated($"[red]A seleccionado [/][DarkGoldenrod]{positionlucha}[/]");
        Position aux = PositionPiece(CurrentPlayer);
        Position fightposition = Position.ToPosition(positionlucha);
        bool fightflag = false;
        if (PlayerPieceBasic(CurrentPlayer).PieceType == PieceType.Explorador || (PlayerPieceBasic(CurrentPlayer).PieceType == PieceType.Intelectual && Intelectual.HabilityName == Explorador.HabilityName))
        {
            NoDoingActions.FightActions.Add(TurnActions.ActivarHabilidad);
        }
        if (PieceBoard.IsAPiece(fightposition)) fightflag = true;
        else
        {
            var DescriptionPanel = new Panel($"[red]{ObjectMethods.AsingDescription(Board[fightposition])}[/]");
            DescriptionPanel.Border = BoxBorder.Double;
            DescriptionPanel.BorderColor(Spectre.Console.Color.White);
            AnsiConsole.Write(DescriptionPanel);
        }
        fight = FightMethods.FightAction(flag, fightposition, aux, fightflag);
        NoDoingActions.FightActions.Remove(TurnActions.ActivarHabilidad);
        bool[] shange = { flag, fight };
        return shange;
    }
    public static bool PortalActivation(bool flag)
    {
        List<Position> portalspos = CompatiblePortal();
        portalspos.Remove(PositionPiece(CurrentPlayer));
        Position posAux = PositionPiece(CurrentPlayer);
        int aux = 0;
        MixPositions(portalspos);
        for (int i = 0; i < 3; i++)
        {
            if (!PieceBoard.IsAPiece(portalspos[i]))
            {
                PieceBoard[portalspos[i]] = PlayerPieceBasic(CurrentPlayer);
                PieceBoard[posAux] = new None();
                aux = i;
                flag = false;
                break;
            }
        }
        if (!flag)
        {
            var portalpanel = new Panel($"[blue]Se teletransportó a la posición {portalspos[aux].Row},{portalspos[aux].Column}[/]");
            portalpanel.Border = BoxBorder.Ascii;
            AnsiConsole.Write(portalpanel);
            flag = true;
            PiecesBasic.NumberOfMovesDoing = StatsMethods.GetNumberOfMove(PlayerPieceBasic(CurrentPlayer));
        }
        else
        {
            var portalpanelno = new Panel($"[red]No se pudo teletransportar a ninguna posición debe estar ocupada[/]");
            portalpanelno.Border = BoxBorder.Ascii;
            AnsiConsole.Write(portalpanelno);
        }
        return flag;
    }
    public static void Continue()
    {
        AnsiConsole.MarkupLine("[blue]Toque cualquier tecla para continuar[/]");
        Console.ReadKey();
        Console.Clear();
        Console.Clear();
        var panel = new Panel($"[blue]{CurrentPlayer}:{PlayerNameShow(CurrentPlayer)}     Turno:{Turn}[/]");
        panel.Border = BoxBorder.Rounded;
        panel.BorderColor(Color.Blue);
        AnsiConsole.Write(panel);
    }
}

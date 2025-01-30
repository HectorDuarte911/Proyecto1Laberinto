namespace ProjectLogic;
using Spectre.Console;
using NAudio.Wave;
public class GameState : PlayerMethods//This class represent the state of the game and all the class whith method in its names response to this class
{
    public static Board Board { get; set; } = new Board();//Current board
    public static PieceBoard PieceBoard { get; set; } = new PieceBoard();//Current piece board
    public static Player CurrentPlayer { get; set; }//Current player
    public static Player Winner = Player.None;//Actual winner
    public static int NumberPLayer = 2, dim = 33, Turn = 0, ActivationAux = 0;//Number of player , dimension , actual turn and auxiliar
    public static bool VariantActivation = false;//Variant of activation  to see if the player have the extra action
    //This filds are the ones who play the music   
    public static WaveOutEvent outputDevice;
    public static AudioFileReader audioFile;
    public static bool isPlaying = true, Trivial = true;
    public static string audio = "audio/pista inicio.mp3";//Current audio playing
    public static List<PieceType> PiecesInGame = new List<PieceType>();//Actual piece in game
    public static List<Player> PlayersInGame = new List<Player>()//Actual list of players in game
    {
    Player.PrimerJugador,
    Player.SegundoJugador,
    };
    public GameState(Player player, Board board, PieceBoard pieceboard)//Constructor
    {
        Board = board;
        PieceBoard = pieceboard;
        CurrentPlayer = player;
    }
    public static System.Timers.Timer timer = new System.Timers.Timer(15000);//Global timer
    public static void PlayAudio()//Method to play the audio
    {
        while (isPlaying)
        {
            string projectDir = Directory.GetCurrentDirectory();
            string rute = Path.Combine(projectDir, audio);
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
    public static void StopAudio()//Method to stop the audio
    {
        isPlaying = false;
        if (outputDevice != null)
        {
            outputDevice.Stop();
            outputDevice.Dispose();
        }
    }
    public static void MusicChange()//Method to change the audio
    {
        switch (PlayerPieceBasic(CurrentPlayer).PieceType)
        {
            case PieceType.Artillero:
                audio = "audio/pista artillero.mp3";
                break;
            case PieceType.EsclavoLibre:
                audio = "audio/pista esclavo libre.mp3";
                break;
            case PieceType.Explorador:
                audio = "audio/pista explorador.mp3";
                break;
            case PieceType.General:
                audio = "audio/pista general.mp3";
                break;
            case PieceType.Intelectual:
                audio = "audio/pista intelectual.mp3";
                break;
            case PieceType.Hitman:
                audio = "audio/pista hitman.mp3";
                break;
            case PieceType.Jinete:
                audio = "audio/pista jinete.mp3";
                break;
            case PieceType.Soldado:
                audio = "audio/pista soldado.mp3";
                break;
            case PieceType.Titan:
                audio = "audio/pista titan.mp3";
                break;
            case PieceType.Veterano:
                audio = "audio/pista veterano.mp3";
                break;
            case PieceType.Holguinero:
                audio = "audio/pista holguinero.mp3";
                break;
            case PieceType.Bolchevique:
                audio = "audio/pista bolchevique.mp3";
                break;
        }
        isPlaying = true;
    }
    public static void InfoGame()//Method to elect the obtion of the info of the game
    {
        int leftspace = (Console.WindowWidth / 2) - 20;
        string[] obtions = {
            new string (' ',leftspace ) +"                  LORE",
            new string (' ',leftspace ) +"                 LEGEND",
            new string (' ',leftspace ) +"            PIEZAS DEL JUEGO",
            new string (' ',leftspace ) +"      SALIR DE IFORMACIÓN DE JUEGO"
        };
        while (true)
        {

            string election = AnsiConsole.Prompt(new SelectionPrompt<string>()
            .PageSize(5)
            .HighlightStyle(new Style(foreground: Color.Red))
            .AddChoices(obtions));
            AnsiConsole.MarkupLineInterpolated($"[red]Has seleccionado la obción {election}[/]");
            if (election == obtions[3]) break;
            if (election == obtions[0]) SeeLore();
            if (election == obtions[1]) SeeLeyend();
            if (election == obtions[2]) SeePieceOfGame();
            Console.ReadKey();
            Console.Clear();
        }
    }
    public static void SeeLore()//Obtion to see the lore
    {
        string Lore = @"[DarkGoldenrod]
        En un tiempo y espacio desconocido varios portales se habrieron hacia un laberinto,los portales salieron grandes representaciones de         
        la historia desde los tiempos medievales hasta el siglo XX. Tú eres una de estas  peculiares  personas quese  encuentran confundidas         
        y en cuanto despertaste de tú inconsiencia quisiste saber la situación. Un mensaje está  grabado en un  cartel  que te informa de la         
        razón por la cual has sido traido al laberinto . Esta es una prueba de Dios para ver que  combatiente  es más habilidosa en salir de         
        este laberinto .Solo se salvará uno por lo que debes apresurarte y tomar todo lo que tengas en el camino para ganar fuerza  y  salir         
        de este inmundo lugar .Debes tener cuidado con las trampas , pensar en si es viable  quitar un  obstáculo del camino,arriesgarte con         
        los cofres , probar suerte con los portales,vencer a enemigos poderosos y si deseas acabar con otros jugadores de este juego divino.         
        BUENA SUERTE :D
                 [/]";
        var panel = new Panel(Lore);
        panel.Border = BoxBorder.Heavy;
        panel.BorderColor(Color.Red);
        AnsiConsole.Write(panel);
    }
    public static void SeeLeyend()//Obtion to see the legend in a table
    {
        var table = new Table();
        table.AddColumn("[red]Color[/]");
        table.AddColumn(new TableColumn("[red]Nombre[/]").Centered());
        table.AddColumn(new TableColumn("[red]Tipo[/]").Centered());
        table.AddRow($"[deeppink2]Rosado Oscuro[/]", "Arquero Largo", "Evento");
        table.AddRow($"[red3]Rojo[/]", "Artillero", "Pieza");
        table.AddRow($"[blueviolet]Morado Azulado[/]", "Asesino", "Evento");
        table.AddRow($"[yellow3_1]Amarillo Oscuro[/]", "Ballestero", "Evento");
        table.AddRow($"[maroon]Marrón[/]", "Caballero", "Evento");
        table.AddRow($"[lime]Lima[/]", "Caballero Pesado", "Evento");
        table.AddRow($"[orange4]Bosque[/]", "Cofre", "Celda");
        table.AddRow($"[lightcoral]Salmóm[/]", "Cruzado", "Evento");
        table.AddRow($"[rosybrown]Carmelita Pieloso[/]", "Cruzado Oscuro", "Evento");
        table.AddRow($"[darkorange3]Naranja Oscuro[/]", "Esclavo Libre", "Pieza");
        table.AddRow($"[hotpink]Rosado[/]", "Escudero", "Evento");
        table.AddRow($"[darkgreen]Verde Oscuro[/]", "Explorador", "Pieza");
        table.AddRow($"[cornsilk1]Maíz[/]", "Final de Laberinto", "Evento");
        table.AddRow($"[lightskyblue3]Azul Cielo[/]", "General", "Pieza");
        table.AddRow($"[purple4]Morado[/]", "Hitman", "Pieza");
        table.AddRow($"[royalblue1]Azul Real[/]", "Holguinero", "Pieza");
        table.AddRow($"[orangered1]Naranja[/]", "Intelectual", "Pieza");
        table.AddRow($"[green3]Verde[/]", "Bolchevique", "Pieza");
        table.AddRow($"[teal]Teal[/]", "Jinete", "Pieza");
        table.AddRow($"[yellow2]Amarillo[/]", "Mazero", "Evento");
        table.AddRow($"[plum1]Algodón Azucar[/]", "Mercenario", "Evento");
        table.AddRow($"[blue]Azul Medio[/]", "Monje", "Evento");
        table.AddRow($"[white]Blanco[/]", "Nada", "Celda");
        table.AddRow($"[grey39]Gris[/]", "Obstáculo", "Celda");
        table.AddRow($"[Darkred]Rojo Oscuro[/]", "Pared", "Celda");
        table.AddRow($"[aqua]Aqua[/]", "Portal", "Celda");
        table.AddRow($"[orange4_1]Carmelita[/]", "Señor Oscuro", "Evento");
        table.AddRow($"[navy]Azul Marina[/]", "Soldado", "Pieza");
        table.AddRow($"[olive]Olivo[/]", "Titán", "Pieza");
        table.AddRow($"[sandybrown]Arena[/]", "Truhán", "Evento");
        table.AddRow($"[lightcyan1]Cyan[/]", "Veterano", "Pieza");
        table.BorderColor(Color.DarkGoldenrod);
        AnsiConsole.Write(table);
    }
    public static void SeePieceOfGame()//Obtion to see the pieces stats in a table
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
            "Bolchevique",
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
                case "Bolchevique":
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
                case "Salir":
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
    public static void GameObcions()//Obtion to choose the configuration of the game
    {
        Console.Clear();
        NumberPLayer = AnsiConsole.Prompt(new SelectionPrompt<int>()
        .Title("Elija la cantidad de jugadores:")
        .PageSize(3)
        .HighlightStyle(new Style(foreground: Color.Red))
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
    public static void SelectPiece()//Method to select the piece of each player
    {
        PieceType piece = AnsiConsole.Prompt(new SelectionPrompt<PieceType>()
        .Title($"[yellow]Elija su pieza {PlayerNameShow(CurrentPlayer)}[/]:")
        .PageSize(12)
        .HighlightStyle(new Style(foreground: Color.Red))
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
    public static bool Walk(bool flag)//Method to walk 
    {
        IEnumerable<string> PosString = Move.PositionsMoves(Move.LegalMoveForPieces(PositionPiece(CurrentPlayer)));
        string movposition = AnsiConsole.Prompt(new SelectionPrompt<string>()
        .Title("Elija a que casilla moverse:")
        .PageSize(12)
        .HighlightStyle(new Style(foreground: Color.Red))
        .AddChoices(PosString));
        AnsiConsole.MarkupLineInterpolated($"A seleccionado [red]{movposition}[/]");
        flag = true;
        Move moveAux = new Move(new Position(0, 0), new Position(0, 1));
        Move Doing = new Move(PositionPiece(CurrentPlayer), Position.ToPosition(movposition));
        //Print the visuals positions
        GenerateLabStruct.PrintLab(Board.VisualPiece(PositionPiece(CurrentPlayer), Board.Laberinth), Position.ToPosition(movposition));
        if (NoDoingActions.Confirm($"[DarkGOldenrod]Tiene seguridad de que se quiere mover a la posición [[{movposition}]] marcada en el mapa con[/][green] verde [/]:") == 'y')
        {
            int count = Move.CountPosition(Move.LegalMoveForPieces(PositionPiece(CurrentPlayer)));
            foreach (Position pos in GetInterPos(Doing))
            {
                if (Board.IsATrap(Board[pos]))//See if there are no tramps
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
    public static bool[] Fight(bool flag, bool fight)//Method to fight , reference the FighMethod class
    {
        List<string> PosLuchaString = Move.PositionsListString(FightCells());
        string positionlucha = AnsiConsole.Prompt(new SelectionPrompt<string>()
        .Title("[red]Elija con que casilla luchar:[/]")
        .PageSize(12)
        .HighlightStyle(new Style(foreground : Color.Red))
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
    public static bool PortalActivation(bool flag)//Activate the teleportation whith other ramdom portal(if there are not any valid then the piece can not teleport)
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
    public static void Continue()//Method auxiliar to stop the console and clean it
    {
        AnsiConsole.MarkupLine("[blue]Toque cualquier tecla para continuar[/]");
        Console.ReadKey();
        Console.Clear();
        var panel = new Panel($"[blue]{CurrentPlayer}:{PlayerNameShow(CurrentPlayer)}     Turno:{Turn}[/]");
        panel.Border = BoxBorder.Rounded;
        panel.BorderColor(Color.Blue);
        AnsiConsole.Write(panel);
    }
    public static void PlayerPieceView()//Obtion to se a table of the stats of your piece
    {
        Table table = new Table();
        table.AddColumn("[yellow]Infirmación del Jugador[/]");
        table.AddRow($"[red]Fuerza : {GetForce(PlayerPieceBasic(CurrentPlayer), CellsType.None)}[/]");
        table.AddRow($"[red]Armadura : {GetArmor(PlayerPieceBasic(CurrentPlayer), CellsType.None)}[/]");
        table.AddRow($"[red]Cantidad de movimientos por turno : {GetNumberOfMove(PlayerPieceBasic(CurrentPlayer))}[/]");
        table.AddRow($"[red]Movimientos sin hacer : {GetNumberOfMove(PlayerPieceBasic(CurrentPlayer)) - PiecesBasic.NumberOfMovesDoing}[/]");
        table.AddRow($"[red]Arma Equipada: {GetEquipItem(PlayerPieceBasic(CurrentPlayer))}[/]");
        table.AddRow($"[red]Armadura Equipada: {GetEquipArmor(PlayerPieceBasic(CurrentPlayer))}[/]");
        table.BorderColor(Color.DarkGoldenrod);
        AnsiConsole.Write(table);
    }
}

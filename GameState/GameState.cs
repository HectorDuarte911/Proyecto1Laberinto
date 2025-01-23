using SixLabors.ImageSharp;
using Spectre.Console;
using Spectre.Console.Extensions;
namespace ProjectLogic;
public class GameState : GSMPlayer
{
    public static Board Board { get; set; } = new Board();
    public static PieceBoard PieceBoard { get; set; } = new PieceBoard();
    public static Player CurrentPlayer { get; set; }//Jugador que esta jugando en el momento
    public static Player Winner = Player.None;
    public static int Turno = 0;
    public static int CantidadJugadores = 2;
    public static int dim =33;
    public static bool VarianteActivacion = false;
    public static int AuxiliarActivacion = 0;
    public static List<PieceType> PiezasEnJuego = new List<PieceType>();
    public static List<Player> PlayersInGame = new List<Player>()
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
    public static void Main(string[] args)//Funcion Principal del juego
    { 

        while (true)
        {
            bool flag = true;
            bool Activacion = false;
            bool Trivial = false;
            while(flag)
            {
        Console.Clear();
        int espacioizquierda=(Console.WindowWidth / 2)-20;
        AnsiConsole.Write(new FigletText("  Welcome to the laberinth")
        .LeftJustified()
        .Color(Spectre.Console.Color.Red));
        Console.WriteLine('\n');
        var obciones=new[] {
        new string (' ',espacioizquierda ) + "[DarkGoldenrod] EMPEZAR  PARTIDA  [/]" + '\n',
        new string (' ',espacioizquierda ) + "[DarkGoldenrod] OBCIONES PARTIDA  [/]" + '\n',
        new string (' ',espacioizquierda ) + "[DarkGoldenrod]     CONTROLES     [/]" + '\n',
        new string (' ',espacioizquierda ) + "[DarkGoldenrod]       SALIR       [/]" + '\n'

        };
        var EleccionMenu = AnsiConsole.Prompt(new SelectionPrompt<string>()
        .Title( new string (' ',espacioizquierda )+"[yellow]   MENU   PRINCIPAL  [/]")
        .PageSize(4)
        .HighlightStyle(new Style(foreground:Spectre.Console.Color.Red))
        .AddChoices(obciones));
        if(EleccionMenu == obciones[3])
        {
         if(AccinesSinRealizarse.Confirm(AccinesDeTurno.SALIR)=='y'){     
         Console.Clear();
         break;
        }
        }
        if(EleccionMenu == obciones[2])
        {
        }
        if(EleccionMenu == obciones[1])
        {
         if(AccinesSinRealizarse.Confirm(AccinesDeTurno.OBCCIONESPARTIDA)=='y'){     
        Console.Clear();
        CantidadJugadores = AnsiConsole.Prompt(new SelectionPrompt<int>()
        .Title("Elija la cantidad de jugadores:")
        .PageSize(3)
        .HighlightStyle(new Style(foreground:Spectre.Console.Color.Red))
        .AddChoices(2, 3, 4));
        AnsiConsole.MarkupLineInterpolated($"A seleccionado [red]{CantidadJugadores} jugadores [/]");
        Console.Clear();
        if (CantidadJugadores == 3) PlayersInGame.Add(Player.TercerJugador);
        if (CantidadJugadores == 4)
        {
            PlayersInGame.Add(Player.TercerJugador);
            PlayersInGame.Add(Player.CuartoJugador);
        }
        foreach (Player player in PlayersInGame)
        {
            string NombreJugador = AnsiConsole.Prompt(new TextPrompt<string>($"[yellow]Nombre de {player}[/]:")
               .Validate(NombreJugador =>
               {
                   return ValidationResult.Success();
               }));
            PlayerName(player, NombreJugador);
        }
        Console.Clear();
        var ObcionesDim=new [] {   
        "33x33",
        "65x65",
        "81x81",
        } ;
        string LabDim = AnsiConsole.Prompt(new SelectionPrompt<string>()
        .Title("[red]Elija la dimension del laberinto[/]:")
        .PageSize(3)
        .HighlightStyle(new Style(foreground:Spectre.Console.Color.Red))
        .AddChoices(ObcionesDim ));
        AnsiConsole.MarkupLineInterpolated($"[red]A seleccionado {LabDim}  [/]");
        if(LabDim==ObcionesDim[0]){dim=33;}
        if(LabDim==ObcionesDim[1]){dim=65;}
        if(LabDim==ObcionesDim[2]){dim=81;}
        Console.Clear();
        }
        }
        if(EleccionMenu == obciones[0])
        {
            if(AccinesSinRealizarse.Confirm(AccinesDeTurno.EMPEZARPARTIDA)=='y'){   
            Console.Clear();
            flag=false;
        }
        }
        }
        flag=true;
        GenerarLabStruct.StartLaberinth(1);
        CurrentPlayer = Player.PrimerJugador;
        do
        {
            PieceType pieza = AnsiConsole.Prompt(new SelectionPrompt<PieceType>()
            .Title($"[yellow]Elija su pieza {PlayerNameShow(CurrentPlayer)}[/]:")
            .PageSize(12)
            .HighlightStyle(new Style(foreground:Spectre.Console.Color.Red))
            .AddChoices(PieceList.Pieces));
            AnsiConsole.MarkupLineInterpolated($"{PlayerNameShow(CurrentPlayer)} a seleccionado el tipo de pieza [red]{pieza}[/]");
            PieceType pieceleccion = PieceType.None;
            foreach (PieceType pieces in PieceList.Pieces)
            {
                if (pieces == pieza)
                {
                    pieceleccion = pieces; break;
                }
            }
            PickPiece(pieceleccion);
        } while (!(CurrentPlayer == Player.PrimerJugador));
        Console.Clear();
        PieceBoard.ComplitePiecePositions();
        GenerarLabForm.ColocandoObstaculos();
        GenerarLabForm.CompleteLab();
        Board.Laberinto[1,2] = CellsType.Cruzado;
        PlayerBasicTurnoHabidad(Player.PrimerJugador, 1);
        PlayerBasicTurnoHabidad(Player.SegundoJugador, 1);
        if (EstaEnJuego(Player.TercerJugador))PlayerBasicTurnoHabidad(Player.TercerJugador, 1);
        if (EstaEnJuego(Player.CuartoJugador))PlayerBasicTurnoHabidad(Player.CuartoJugador, 1);
        while (Winner == Player.None)
        {
        if (EstaEnJuego(Player.PrimerJugador))
        {
            if (CurrentPlayer == Player.PrimerJugador) Turno++;
        }
        else if (EstaEnJuego(Player.SegundoJugador))
        {
            if (CurrentPlayer == Player.SegundoJugador) Turno++;
        }
        else if (CurrentPlayer == Player.TercerJugador) Turno++;
         if (PlayerbasicCompTurnActivacion() )
        {
            AccinesSinRealizarse.AjustAccion(AccinesDeTurno.ActivarHabilidad);
            if(!flag) PLayerBasicTurnActivacionPlus();
        }
        var panel = new Panel($"[red]Turno {Turno}[/]");
        panel.Border = BoxBorder.Rounded;
        panel.BorderColor(Spectre.Console.Color.Red);
        AnsiConsole.Write(panel);
        var jugadorpanel = new Panel($"[DarkGoldenrod]Turno de {CurrentPlayer}[/]");
        panel.Border = BoxBorder.Ascii;
        panel.BorderColor(Spectre.Console.Color.DarkGoldenrod);
        AnsiConsole.Write(jugadorpanel);
        if (PlayerbasicCompTurnReposo())PLayerBasicReposoAsingn(CurrentPlayer, false);
        if (EstaEnReposo(CurrentPlayer))
        {
            var panel1 = new Panel($"[yellow]{PlayerNameShow(CurrentPlayer)} esta en reposo[/]");
            panel1.Border = BoxBorder.Double;
            Console.Write(panel1);
            flag = false;
        }
        PiecesBasic.NumberOfMovesDoing = 0;
        bool rendirse = false;
        bool luchar = false;
        AccinesSinRealizarse.AjustAccion(AccinesDeTurno.Caminar);
          if(PlayerPiece(CurrentPlayer) == PieceType.Intelectual && Intelectual.NombreHabilidad != "Trivia" && PlayerbasicCompTurnActivacion())
            {
            char HacerTrivia = AnsiConsole.Prompt(new SelectionPrompt<char>()
            .Title("Quiere realizar la trivia:")
            .PageSize(3)
            .HighlightStyle(new Style(foreground:Spectre.Console.Color.Red))
            .AddChoices('y','n'));
            string color = string.Empty;
            if(HacerTrivia == 'y')
            {
            color = "green";
            Intelectual.NombreHabilidad = "Trivia";
            }
            else color = "red";
            AnsiConsole.MarkupLineInterpolated($"A seleccionado [{color}]{HacerTrivia}[/]");
            }
        while (flag)
        {    
            if(VarianteActivacion && (PlayerPiece(CurrentPlayer) == PieceType.Artillero || 
             (PlayerPiece(CurrentPlayer) == PieceType.Intelectual && Intelectual.NombreHabilidad == Explorador.NombreHabilidad)) && 
             SepuedeRomperTipo(CellsType.Wall))AccinesSinRealizarse.AccionesSinRealizar.Add(AccinesDeTurno.RomperMuro);
            
            if(PlayerPiece(CurrentPlayer) == PieceType.Explorador ||
            (PlayerPiece(CurrentPlayer) == PieceType.Intelectual && Intelectual.NombreHabilidad == Explorador.NombreHabilidad)){
            AccinesSinRealizarse.AccionesSinRealizar.Remove(AccinesDeTurno.ActivarHabilidad);}
            GenerarLabStruct.PrintLab(Board.Laberinto,PosicionPieza(CurrentPlayer)); 
            GenerarLabStruct.PrintLab(Board.VisualPieza(PosicionPieza(CurrentPlayer),Board.Laberinto),PosicionPieza(CurrentPlayer));  
            if (Board[PosicionPieza(CurrentPlayer)] == CellsType.portales) AccinesSinRealizarse.AccionesSinRealizar.Add(AccinesDeTurno.ActivarPortal);
            if (PiecesBasic.NumberOfMovesDoing != 0) AccinesSinRealizarse.AccionesSinRealizar.Remove(AccinesDeTurno.ActivarPortal);
            if (SepuedeRomperTipo(CellsType.Obstaculos) && PiecesBasic.NumberOfMovesDoing==0) AccinesSinRealizarse.AccionesSinRealizar.Add(AccinesDeTurno.DerribarObstaculos);
            if (!IsEmpty(CasillasAdyacentesAlcanzables()) && !luchar && PiecesBasic.NumberOfMovesDoing!=NumeroDeMov(PlayerPieceBasic(CurrentPlayer))) AccinesSinRealizarse.AccionesSinRealizar.Add(AccinesDeTurno.Luchar);
            var panelposition = new Panel($"[DarkGoldenrod]Estas en la posicions [[{PosicionPieza(CurrentPlayer).Row},{PosicionPieza(CurrentPlayer).Column}]][/]");
            panelposition.Border=BoxBorder.Double;
            panelposition.BorderColor(Spectre.Console.Color.Red);
            AnsiConsole.Write(panelposition);
            AccinesDeTurno eleccion = AnsiConsole.Prompt(new SelectionPrompt<AccinesDeTurno>()
            .Title("Escoja que accion realizar:")
            .PageSize(12)
            .HighlightStyle(new Style(foreground:Spectre.Console.Color.Red))
            .AddChoices(AccinesSinRealizarse.AccionesSinRealizar));
            AnsiConsole.MarkupLineInterpolated($"A seleccionado [red]{eleccion}[/]");
            switch (eleccion)
            {
                case AccinesDeTurno.Caminar:
                if(AccinesSinRealizarse.Confirm(eleccion)=='y')
                {
                    IEnumerable<string> PosString = PositionsMoves(LegalMoveForPieces(PosicionPieza(CurrentPlayer)));
                    string movposition = AnsiConsole.Prompt(new SelectionPrompt<string>()
                    .Title("Elija a que casilla moverse:")
                    .PageSize(12)
                    .HighlightStyle(new Style(foreground:Spectre.Console.Color.Red))
                    .AddChoices(PosString));
                    AnsiConsole.MarkupLineInterpolated($"A seleccionado [red]{movposition}[/]"); 
                    flag = true;
                    Move moveAux = new Move(new Position(0, 0), new Position(0, 1));
                    Move hecho = new Move(PosicionPieza(CurrentPlayer), Position.ToPosition(movposition));
                    GenerarLabStruct.PrintLab(Board.VisualPieza(PosicionPieza(CurrentPlayer),Board.Laberinto),Position.ToPosition(movposition));
                   string color = string.Empty;
                    char  seguro = AnsiConsole.Prompt(new SelectionPrompt<char>()
                    .Title($"[DarkGOldenrod]Tiene seguridad de que se quiere mover a la posicion [[{movposition}]] marcada en ele mapa con[/][green] verde [/]:")
                    .PageSize(3)
                    .HighlightStyle(new Style(foreground:Spectre.Console.Color.White))
                    .AddChoices('y','n'));
                    if(seguro =='y')color="green";
                    else color="red";
                    AnsiConsole.MarkupLine($"A seleccionado [{color}]{seguro}[/]");
                    if(seguro == 'y')
                    {
                    int count = CountPosition(LegalMoveForPieces(PosicionPieza(CurrentPlayer)));
                    foreach (Position pos in GetInterPos(hecho))
                    {        
                        if (Board.IsATrap(Board[pos]))
                        {
                            PieceBoard[pos] = PieceBoard[hecho.FromPos];
                            PieceBoard[hecho.FromPos] = new None(Player.None) ;
                            flag = false;
                            moveAux = new Move(hecho.FromPos, pos);
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
                        Console .WriteLine($"{hecho.ToPos.Row},{hecho.ToPos.Column}");
                        PieceBoard[hecho.ToPos] = PieceBoard[hecho.FromPos];
                        PieceBoard[hecho.FromPos] = new None(Player.None);
                        moveAux = hecho;
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
                        ActivarPenalisacionTrampa(Board[moveAux.ToPos]);
                    }
                    else
                    {
                        var movimiento = new Panel($"[green]Se movio con exito a la casilla[/][yellow] {movposition}[/]");
                        movimiento.Border = BoxBorder.Ascii;
                        AnsiConsole.Write(movimiento);
                    }
                    if (PiecesBasic.NumberOfMovesDoing == NumeroDeMov(PlayerPieceBasic(CurrentPlayer)))
                    {
                        AccinesSinRealizarse.AccionesSinRealizar.Remove(AccinesDeTurno.Caminar);
                    }
                  }
                }
                    break;
                case AccinesDeTurno.Luchar:
                if(AccinesSinRealizarse.Confirm(eleccion)=='y')
                {
                    List<string> PosLuchaString = PositionsListString(CasillasAdyacentesAlcanzables());
                    string positionlucha = AnsiConsole.Prompt(new SelectionPrompt<string>()
                    .Title("[red]Elija con que casilla luchar:[/]")
                    .PageSize(12)
                    .HighlightStyle(new Style(foreground:Spectre.Console.Color.Red))
                    .AddChoices(PosLuchaString));
                    AnsiConsole.MarkupLineInterpolated($"[red]A seleccionado [/][DarkGoldenrod]{positionlucha}[/]");
                    Position aux = PosicionPieza(CurrentPlayer);
                    Position posicionLucha = Position.ToPosition(positionlucha);
                    bool bandera = false;
                    if(PlayerPiece(CurrentPlayer) == PieceType.Explorador || (PlayerPiece(CurrentPlayer) == PieceType.Intelectual && Intelectual.NombreHabilidad == Explorador.NombreHabilidad))
                    {
                    AccinesSinRealizarse.AccionesDeLucha.Add(AccinesDeTurno.ActivarHabilidad);
                    }
                    if (PieceBoard.IsAPiece(posicionLucha)) bandera = true;
                    else
                    {
                     var DescriptionPanel= new Panel($"[red]{AsingDescription(Board[posicionLucha])}[/]");
                     DescriptionPanel.Border = BoxBorder.Double;
                     DescriptionPanel.BorderColor(Spectre.Console.Color.White); 
                     AnsiConsole.Write(DescriptionPanel);
                    }
                    luchar = LuchaAction(flag, posicionLucha, aux, bandera);
                    AccinesSinRealizarse.AccionesDeLucha.Remove(AccinesDeTurno.ActivarHabilidad);
                }
                    break;
                case AccinesDeTurno.RomperMuro:
                if(AccinesSinRealizarse.Confirm(eleccion)=='y')
                {
                    List<string> PosDerribar = PositionsListString(CasillasAdyacentesTipo(CellsType.Wall,PieceType.None));
                    string posmuralla = AnsiConsole.Prompt(new SelectionPrompt<string>()
                    .Title("[red]Elija que mura derrumbar:[/]")
                    .PageSize(12)
                    .HighlightStyle(new Style(foreground:Spectre.Console.Color.Red))
                    .AddChoices(PosDerribar));
                    AnsiConsole.MarkupLineInterpolated($"[DarkGoldenrod]A seleccionado[/] [yellow]{posmuralla} [/]");
                    Position posicionmuralla = Position.ToPosition(posmuralla);
                    Board[posicionmuralla] = CellsType.None;
                    var portalpanel = new Panel($"[green]Se destruyo el muro en la posicion {posmuralla}[/]");
                    portalpanel.Border=BoxBorder.Ascii;
                    AnsiConsole.Write(portalpanel);
                    AccinesSinRealizarse.AccionesSinRealizar.Remove(AccinesDeTurno.RomperMuro);
                }
                    break;
                  case AccinesDeTurno.DerribarObstaculos:
                if(AccinesSinRealizarse.Confirm(eleccion)=='y')
                {
                    List<string> PosDerribar = PositionsListString(CasillasAdyacentesTipo(CellsType.Obstaculos,PieceType.None));/////////
                    string posmuralla = AnsiConsole.Prompt(new SelectionPrompt<string>()
                    .Title("[red]Elija que obstaculo derribar:[/]")
                    .PageSize(12)
                    .HighlightStyle(new Style(foreground:Spectre.Console.Color.Red))
                    .AddChoices(PosDerribar));
                    AnsiConsole.MarkupLineInterpolated($"[DarkGoldenrod]A seleccionado[/] [yellow]{posmuralla} [/]");
                    Position posicionmuralla = Position.ToPosition(posmuralla);
                    Board[posicionmuralla] = CellsType.None;
                    var portalpanel = new Panel($"[green]Se derribo el obstaculo en la posicion {posmuralla}[/]");
                    portalpanel.Border=BoxBorder.Ascii;
                    AnsiConsole.Write(portalpanel);
                    PiecesBasic.NumberOfMovesDoing = NumeroDeMov(PlayerPieceBasic(CurrentPlayer));
                    AccinesSinRealizarse.AccionesSinRealizar.Remove(AccinesDeTurno.DerribarObstaculos);
                }
                    break;
                
                case AccinesDeTurno.ObcionesEquipo:
                if(AccinesSinRealizarse.Confirm(eleccion)=='y')
                {
                    ObcionesEquipo(flag);
                    flag = true;
                }
                    break;
              
                case AccinesDeTurno.TerminarTurno:
                if(AccinesSinRealizarse.Confirm(eleccion)=='y')
                {
                    flag = false;
                }
                    break;
                case AccinesDeTurno.ActivarHabilidad:
                if(AccinesSinRealizarse.Confirm(eleccion)=='y')
                {
                    if(PlayerPiece(CurrentPlayer) == PieceType.Intelectual && Intelectual.NombreHabilidad == "Trivia")Trivial = true;
                    else Trivial =false;
                    Activacion = true;
                   PlayerBasicAsignarHabilidad(PieceBoard[PosicionPieza(CurrentPlayer)].PieceType);
                   
                    AccinesSinRealizarse.AccionesSinRealizar.Remove(AccinesDeTurno.ActivarHabilidad);
                }
                    break;
                case AccinesDeTurno.ActivarPortal:
                if(AccinesSinRealizarse.Confirm(eleccion)=='y')
                {
                    List<Position> portalespos = PortalCompatible();
                    portalespos.Remove(PosicionPieza(CurrentPlayer));
                    Position posAux = PosicionPieza(CurrentPlayer);
                    int auxiliar=0;
                    MezclarPosiciones(portalespos);
                    for(int i=0;i<3;i++)
                    {
                    if(!PieceBoard.IsAPiece(portalespos[i]) && !EsEvento(Board[portalespos[i]]))
                    {
                    PieceBoard[portalespos[i]] = PlayerPieceBasic(CurrentPlayer);
                    PieceBoard[posAux] = new None(Player.None);
                    auxiliar=i;
                    flag=false;
                    break;
                    }                    
                    }
                    if(!flag)
                    {
                    var portapanel = new Panel($"[blue]Se teletransporto a la posicion {portalespos[auxiliar].Row},{portalespos[auxiliar].Column}[/]");
                    portapanel.Border=BoxBorder.Ascii;
                    AnsiConsole.Write(portapanel);
                    flag=true;
                    PiecesBasic.NumberOfMovesDoing = NumeroDeMov(PlayerPieceBasic(CurrentPlayer));
                    }
                    else
                    {
                    var portalpanelno = new Panel($"[red]No se pudo teletransportar a ninguna posicion debe estar ocupada[/]");
                    portalpanelno.Border=BoxBorder.Ascii;
                    AnsiConsole.Write(portalpanelno); 
                    }
                }
                    break;
            }
            AccinesSinRealizarse.AccionesSinRealizar.Remove(AccinesDeTurno.Luchar);
            AccinesSinRealizarse.AccionesSinRealizar.Remove(AccinesDeTurno.ActivarHabilidad);
            if (PiecesBasic.NumberOfMovesDoing == NumeroDeMov(PlayerPieceBasic(CurrentPlayer)))AccinesSinRealizarse.AccionesSinRealizar.Remove(AccinesDeTurno.Caminar);
            AccinesSinRealizarse.AccionesSinRealizar.Remove(AccinesDeTurno.ActivarPortal);
            AccinesSinRealizarse.AccionesSinRealizar.Remove(AccinesDeTurno.DerribarObstaculos);
            if(Trivial )
            {
            AccinesSinRealizarse.AjustAccion(AccinesDeTurno.ActivarHabilidad);
            }        
            if (PlayerbasicCompTurnActivacion() )
        {
            AccinesSinRealizarse.AjustAccion(AccinesDeTurno.ActivarHabilidad);
            if(!flag) PLayerBasicTurnActivacionPlus();
        }    
        }
        AccinesSinRealizarse.AccionesSinRealizar.Remove(AccinesDeTurno.RomperMuro);
        if(Activacion)
        {
            PlayerBasicDesactivarHabilidad(PlayerPiece(CurrentPlayer));
            Activacion = false;
        }
       
        VarianteActivacion = false;
        AuxiliarActivacion = 0;
        if (Winner != Player.None) 
        {
        int espacioizquierda=(Console.WindowWidth / 2) - 20;
        AnsiConsole.Write(new FigletText($" EL GANADOR ES {PlayerNameShow(Winner)} ")
        .LeftJustified()
        .Color(Spectre.Console.Color.Red));
        }
        if (rendirse)rendirse = false;
        else CurrentPlayer = NextPlayer(CurrentPlayer);
      
        flag = true;
        
        }
    
      
            }

    }  
}
 






// case AccinesDeTurno.MirarMapa:
//                 if(AccinesSinRealizarse.Confirm(eleccion)=='y')
//                 {
//                     
//                     
//                 }
//                     break;
//   case AccinesDeTurno.Rendirse:
//                 if(AccinesSinRealizarse.Confirm(eleccion)=='y')
//                 {
//                     CantidadJugadores--;
//                     if (CantidadJugadores == 1) Winner = NextPlayer(CurrentPlayer);
//                     Player AuxiPlayer = NextPlayer(CurrentPlayer);
//                     PlayersInGame.Remove(CurrentPlayer);
//                     flag = false;
//                     rendirse = true;
//                 }
//                     break;
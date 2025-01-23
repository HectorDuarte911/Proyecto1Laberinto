using System.Reflection.Metadata;
using Spectre.Console;
namespace ProjectLogic;
public class GSMLucha:GSMEventos
{
    public static bool LuchaAction(bool flag, Position posicionLucha, Position aux,bool bandera)
    {
        Player enemyplayer=Player.None;
       if(bandera) enemyplayer=GameState.PieceBoard[posicionLucha].Number;
        bool abandonar = false;
        bool luchar = false;
        string ganador = "ninguno";
        while (!abandonar && ganador == "ninguno")
        {
            AccinesDeTurno eleccion = AnsiConsole.Prompt(new SelectionPrompt<AccinesDeTurno>()
            .Title("[red]Escoja que accion realizar:[/]")
            .PageSize(12)
            .HighlightStyle(new Style(foreground:Color.Red))
            .AddChoices(AccinesSinRealizarse.AccionesDeLucha));
            AnsiConsole.MarkupLineInterpolated($"[DarkGoldenrod]A seleccionado[/] {eleccion}");
            int atacanteforce=GSMStats.GetForce(GameState.PieceBoard[GSMPosition.PosicionPieza(GameState.CurrentPlayer)],GameState.Board[GSMPosition.PosicionPieza(GameState.CurrentPlayer)])-2;
            int defArmorPlayer=0; 
            int defArmorEvent= 0;
            if(bandera)defArmorPlayer=GSMStats.GetArmor(GameState.PieceBoard[GSMPosition.PosicionPieza(enemyplayer)],GameState.Board[GSMPosition.PosicionPieza(enemyplayer)]);
            else defArmorEvent=GSMStats.GetArmor(new None(enemyplayer),GameState.Board[posicionLucha]);
            switch (eleccion)
            {
                case AccinesDeTurno.atacar:
                    if (atacanteforce==defArmorPlayer+defArmorEvent )
                    {
                        ganador = "Empate";
                    }
                    else if (atacanteforce<defArmorPlayer+defArmorEvent)
                    {
                        ganador = $"{enemyplayer}";
                    }
                    else
                    {
                        ganador = $"{GameState.CurrentPlayer}";
                    }
                    break;
                case AccinesDeTurno.ObcionesEquipo:
                    GSMObjetos.ObcionesEquipo(flag);
                    flag = true;
                    break;
                    case AccinesDeTurno.ActivarHabilidad:
                    Explorador.Habilidad(GameState.PieceBoard[GameState.PosicionPieza(enemyplayer)]);
                    int ActivacionTurnExplorador = GameState.Turno + Explorador.TurnosEnfriamiento;
                    GameState.PlayerBasicTurnoHabidad(GameState.CurrentPlayer, ActivacionTurnExplorador);
                    break;
                case AccinesDeTurno.abandonar:
                    abandonar = true;
                    break;
          }
        }
        if (!abandonar)
        {
            var panel = new Panel("");
            if(ganador == Player.None.ToString())panel =new Panel($"[red]El ganador de la batalla es[/][yellow] {GameState.Board[posicionLucha]}[/]");
            else panel=new Panel($"[red]El ganador de la batalla es[/][yellow] {ganador}[/]");
            panel.Border=BoxBorder.Ascii;
            AnsiConsole.Write(panel);
            Player JugadorReposo = Player.None;
            Player JugadorGanador = Player.None;
            if (ganador == $"{enemyplayer}")
            {
                JugadorReposo = GameState.CurrentPlayer;
                JugadorGanador = enemyplayer;
            }
            if (ganador == $"{GameState.CurrentPlayer}" && bandera)
            {
                JugadorGanador = GameState.CurrentPlayer;
                JugadorReposo = enemyplayer;
            }
            if (ganador == $"{GameState.CurrentPlayer}" && !bandera)
            {
            JugadorGanador = GameState.CurrentPlayer;
            while(true)
            {
            if(ObjetosStats.StatsPeso[DarRecompenseEvento(GameState.Board[posicionLucha])] + GameState.PlayerPieceBasic(JugadorGanador).WeightInventary <= 200 )
            {
              GameState.PlayerPieceBasic(JugadorGanador).Inventario.Add(DarRecompenseEvento(GameState.Board[posicionLucha]));
              break;
            }
            else
            {
            int NecesaryWeight = 200 - ObjetosStats.StatsPeso[DarRecompenseEvento(GameState.Board[posicionLucha])] - GameState.PlayerPieceBasic(JugadorGanador).WeightInventary;
            Console.WriteLine($"[red] no hay espaco suficiente por favor si quiere obtener su recompensa debe liberar {NecesaryWeight} unidades de su inventario[/] ");
            if(AccinesSinRealizarse.Confirm(AccinesDeTurno.DescartarObjeto) == 'y')
            {
            GameState.VerInventario();
            GameState.DiscartObject();
            }
            else break;
            }
            }
            GameState.PlayerPieceBasic(JugadorGanador).WeightInventary += ObjetosStats.StatsPeso[DarRecompenseEvento(GameState.Board[posicionLucha])];
            GameState.Board[posicionLucha]=CellsType.None;
            }
            if (ganador == "Empate")
            {
                JugadorReposo = GameState.CurrentPlayer;
                JugadorGanador = enemyplayer;
            }
            PiecesBasic JugadorReposoAux = GSMPiece.PlayerPieceBasic(JugadorReposo);
            PiecesBasic JugadorGanadorAux = GSMPiece.PlayerPieceBasic(JugadorGanador);
            GameState.PieceBoard[GSMPosition.PosicionPieza(enemyplayer)] = JugadorGanadorAux;
            GameState.PieceBoard[aux] = JugadorReposoAux;
            luchar = true;
            if(GameState.PlayerPiece(GameState.CurrentPlayer) != PieceType.Soldado ||  GameState.PlayerPiece(JugadorReposo) != PieceType.Soldado 
            || !GameState.VarianteActivacion || !(GameState.PlayerPiece(GameState.CurrentPlayer) == PieceType.Intelectual &&
            Intelectual.NombreHabilidad == Soldado.NombreHabilidad))
            {
            GSMPlayer.PLayerBasicReposoAsingn(JugadorReposo, true);
            GSMPlayer.PlayerBasicTurnoReposo(JugadorReposo);
            }
            AccinesSinRealizarse.AccionesSinRealizar.Remove(AccinesDeTurno.Caminar);
            AccinesSinRealizarse.AccionesSinRealizar.Remove(AccinesDeTurno.RomperMuro);
            AccinesSinRealizarse.AccionesSinRealizar.Remove(AccinesDeTurno.DerribarObstaculos);
        }
        AccinesSinRealizarse.AccionesSinRealizar.Remove(AccinesDeTurno.Luchar);
        PiecesBasic.NumberOfMovesDoing = GSMPosition.NumeroDeMov(GSMPiece.PlayerPieceBasic(GameState.CurrentPlayer));
        ;
        return luchar;
    }
    

}

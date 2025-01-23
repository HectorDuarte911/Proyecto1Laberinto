namespace ProjectLogic;
using Spectre.Console;
public class GSMHabilidades:GSMLucha
{
    public static void PlayerBasicTurnoHabidad(Player player, int ActivacionTurn)
    {
        switch (player)
        {
            case Player.PrimerJugador:
                PrimerJugador.TurnoActivacion = ActivacionTurn;
                break;
            case Player.SegundoJugador:
                SegundoJugador.TurnoActivacion = ActivacionTurn;
                break;
            case Player.TercerJugador:
                TercerJugador.TurnoActivacion = ActivacionTurn;
                break;
            case Player.CuartoJugador:
                CuartoJugador.TurnoActivacion = ActivacionTurn;
                break;
        }
    }
    public static void PlayerBasicAsignarHabilidad(PieceType pieceType)
    {
        string nombreHabilidad = string.Empty;
        switch(pieceType)
        {
            case PieceType.Artillero:
            nombreHabilidad = Artillero.NombreHabilidad;
            break;
            case PieceType.EsclavoLibre:
            nombreHabilidad = EsclavoLibre.NombreHabilidad;
            break;
            case PieceType.Explorador:
            nombreHabilidad = Explorador.NombreHabilidad;
            break;
            case PieceType.General:
            nombreHabilidad = General.NombreHabilidad;
            break;
            case PieceType.Holguinero:
            nombreHabilidad = Holguinero.NombreHabilidad;
            break;
            case PieceType.Internacionalista:
            nombreHabilidad = Internacionalista.NombreHabilidad;
            break;
            case PieceType.Intelectual:
            nombreHabilidad = Intelectual.NombreHabilidad;
            break;
            case PieceType.Jinete:
            nombreHabilidad = Jinete.NombreHabilidad;
            break;
            case PieceType.Soldado:
            nombreHabilidad = Soldado.NombreHabilidad;
            break;
            case PieceType.Titan:
            nombreHabilidad = Titan.NombreHabilidad;
            break;
            case PieceType.Terrateniente:
            nombreHabilidad = Terrateniente.NombreHabilidad;
            break;
             case PieceType.Veterano:
            nombreHabilidad = Veterano.NombreHabilidad;
            break;
        }
        switch (nombreHabilidad)
        {
            case "Rompe Muro":
                int ActivacionTurnArtillero = GameState.Turno + Artillero.TurnosEnfriamiento;
                PlayerBasicTurnoHabidad(GameState.CurrentPlayer, ActivacionTurnArtillero);
                Artillero.Habilidad();
                break;
            case "A afilar el machete":
                int ActivacionTurnEsclavoLibre = GameState.Turno + EsclavoLibre.TurnosEnfriamiento;
                PlayerBasicTurnoHabidad(GameState.CurrentPlayer, ActivacionTurnEsclavoLibre);
                EsclavoLibre.Habilidad();
                break;  
            case "Prediccion de jefes":
                int ActivacionTurnGeneral = GameState.Turno + General.TurnosEnfriamiento;
                PlayerBasicTurnoHabidad(GameState.CurrentPlayer, ActivacionTurnGeneral);
                General.Habilidad();
                break;
            case "Juego Sucio":
                int ActivacionTurnHolguinero = GameState.Turno + Holguinero.TurnosEnfriamiento;
                PlayerBasicTurnoHabidad(GameState.CurrentPlayer, ActivacionTurnHolguinero);
                Holguinero.Habilidad();
                break;
            case "Trivia" :
                Intelectual.Habilidad();
                break;
            case"Solidaridad":
                int ActivacionTurnInInternacionalista = GameState.Turno + Internacionalista.TurnosEnfriamiento;
                PlayerBasicTurnoHabidad(GameState.CurrentPlayer, ActivacionTurnInInternacionalista);
                Internacionalista.Habilidad();
                break;
            case "Cargar":
                int ActivacionTurnJinete = GameState.Turno + Jinete.TurnosEnfriamiento;
                PlayerBasicTurnoHabidad(GameState.CurrentPlayer, ActivacionTurnJinete); Jinete.Habilidad();
                Jinete.Habilidad();
                break;
            case "Inmmortal":
                int ActivacionTurnSoldado = GameState.Turno + Soldado.TurnosEnfriamiento;
                PlayerBasicTurnoHabidad(GameState.CurrentPlayer, ActivacionTurnSoldado);
                Soldado.Habilidad();
                break;
            case "27 o 28":
                int ActivacionTurnTitan = GameState.Turno + Titan.TurnosEnfriamiento;
                PlayerBasicTurnoHabidad(GameState.CurrentPlayer, ActivacionTurnTitan);
                Titan.Habilidad();
                break;
            case "Vender":
                int ActivacionTurnTerrateniente = GameState.Turno + Terrateniente.TurnosEnfriamiento;
                PlayerBasicTurnoHabidad(GameState.CurrentPlayer, ActivacionTurnTerrateniente);
                Terrateniente.Habilidad();
                break;
            case "Juego Limpio":
                int ActivacionTurnVeterano = GameState.Turno + Veterano.TurnosEnfriamiento;
                PlayerBasicTurnoHabidad(GameState.CurrentPlayer, ActivacionTurnVeterano);
                Veterano.Habilidad();
                break;
        }
        var panelAnuncio = new Panel($"[green]Se activo la habilidad {nombreHabilidad}[/]");
        panelAnuncio.Border = BoxBorder.Ascii;
        panelAnuncio.BorderColor(Color.Green);
        AnsiConsole.Write(panelAnuncio); 
    }
    public static void PlayerBasicDesactivarHabilidad(PieceType pieceType)
    {
        switch (pieceType)
        {
            case PieceType.Intelectual:
                Intelectual.DesactivarHabilidad();
                break;
            case PieceType.Internacionalista:
                Internacionalista.DesactivarHabilidad();
                break;
            case PieceType.Jinete:
                Jinete.DesactivarHabilidad();
                break;
            case PieceType.Titan:
                Titan.DesactivarHabilidad();
                break;
            case PieceType.Terrateniente:
                Terrateniente.DesactivarHabilidad();
                break;
        }
    }
    public static void PLayerBasicTurnActivacionPlus()
    {
        switch (GameState.CurrentPlayer)
        {
            case Player.PrimerJugador:
                PrimerJugador.TurnoActivacion++;
                break;
            case Player.SegundoJugador:
                SegundoJugador.TurnoActivacion++;
                break;
            case Player.TercerJugador:
                TercerJugador.TurnoActivacion++;
                break;
            case Player.CuartoJugador:
                CuartoJugador.TurnoActivacion++;
                break;
        }
    }
}
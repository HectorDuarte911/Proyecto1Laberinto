namespace ProjectLogic;
using Spectre.Console;
public class HabilitysMethods :TrampsMethods
{
    public static void SetHabilityTurn(Player player, int activationTurn)
    {
        switch (player)
        {
            case Player.PrimerJugador:
                PrimerJugador.ActivationTurn = activationTurn;
                break;
            case Player.SegundoJugador:
                SegundoJugador.ActivationTurn = activationTurn;
                break;
            case Player.TercerJugador:
                TercerJugador.ActivationTurn = activationTurn;
                break;
            case Player.CuartoJugador:
                CuartoJugador.ActivationTurn = activationTurn;
                break;
        }
    }
    public static void AsingHability(PieceType pieceType)
    {
        string HabilityName = string.Empty;
        switch (pieceType)
        {
            case PieceType.Artillero:
                HabilityName = Artillero.HabilityName;
                break;
            case PieceType.EsclavoLibre:
                HabilityName = EsclavoLibre.HabilityName;
                break;
            case PieceType.Explorador:
                HabilityName = Explorador.HabilityName;
                break;
            case PieceType.General:
                HabilityName = General.HabilityName;
                break;
            case PieceType.Holguinero:
                HabilityName = Holguinero.HabilityName;
                break;
            case PieceType.Internacionalista:
                HabilityName = Internacionalista.HabilityName;
                break;
            case PieceType.Intelectual:
                HabilityName = Intelectual.HabilityName;
                break;
            case PieceType.Jinete:
                HabilityName = Jinete.HabilityName;
                break;
            case PieceType.Soldado:
                HabilityName = Soldado.HabilityName;
                break;
            case PieceType.Titan:
                HabilityName = Titan.HabilityName;
                break;
            case PieceType.Hitman:
                HabilityName = Hitman.HabilityName;
                break;
            case PieceType.Veterano:
                HabilityName = Veterano.HabilityName;
                break;
        }
        switch (HabilityName)
        {
            case "Rompe Muro":
                int ActivationTurnArtillero = GameState.Turn + Artillero.Coldturns;
                SetHabilityTurn(GameState.CurrentPlayer, ActivationTurnArtillero);
                Artillero.Hability();
                break;
            case "A afilar el machete":
                int ActivationTurnEsclavoLibre = GameState.Turn + EsclavoLibre.Coldturns;
                SetHabilityTurn(GameState.CurrentPlayer, ActivationTurnEsclavoLibre);
                EsclavoLibre.Hability();
                break;
            case "Predicción de jefes":
                int ActivationTurnGeneral = GameState.Turn + General.Coldturns;
                SetHabilityTurn(GameState.CurrentPlayer, ActivationTurnGeneral);
                General.Hability();
                break;
            case "Juego Sucio":
                int ActivationTurnHolguinero = GameState.Turn + Holguinero.Coldturns;
                SetHabilityTurn(GameState.CurrentPlayer, ActivationTurnHolguinero);
                Holguinero.Hability();
                break;
            case "Trivia":
                Intelectual.Hability();
                break;
            case "Solidaridad":
                int ActivationTurnInInternacionalista = GameState.Turn + Internacionalista.Coldturns;
                SetHabilityTurn(GameState.CurrentPlayer, ActivationTurnInInternacionalista);
                Internacionalista.Hability();
                break;
            case "Cargar":
                int ActivationTurnJinete = GameState.Turn + Jinete.Coldturns;
                SetHabilityTurn(GameState.CurrentPlayer, ActivationTurnJinete); Jinete.Hability();
                Jinete.Hability();
                break;
            case "Inmmortal":
                int ActivationTurnSoldado = GameState.Turn + Soldado.Coldturns;
                SetHabilityTurn(GameState.CurrentPlayer, ActivationTurnSoldado);
                Soldado.Hability();
                break;
            case "27 o 28":
                int ActivationTurnTitan = GameState.Turn + Titan.Coldturns;
                SetHabilityTurn(GameState.CurrentPlayer, ActivationTurnTitan);
                Titan.Hability();
                break;
            case "Silenciar":
                int ActivationTurnHitman = GameState.Turn + Hitman.Coldturns;
                SetHabilityTurn(GameState.CurrentPlayer, ActivationTurnHitman);
                Hitman.Hability();
                break;
            case "Juego Limpio":
                int ActivationTurnVeterano = GameState.Turn + Veterano.Coldturns;
                SetHabilityTurn(GameState.CurrentPlayer, ActivationTurnVeterano);
                Veterano.Hability();
                break;
        }
        var Panel = new Panel($"[green]Se activó la habilidad {HabilityName}[/]");
        Panel.Border = BoxBorder.Ascii;
        Panel.BorderColor(Color.Green);
        AnsiConsole.Write(Panel);
    }
    public static void NegateHability(PieceType pieceType)
    {
        switch (pieceType)
        {
            case PieceType.Intelectual:
                Intelectual.EnableHability();
                break;
            case PieceType.Internacionalista:
                Internacionalista.EnableHability();
                break;
            case PieceType.Jinete:
                Jinete.EnableHability();
                break;
            case PieceType.Titan:
                Titan.EnableHability();
                break;
        }
    }
    public static void ActivationTurnPlus()
    {
        switch (GameState.CurrentPlayer)
        {
            case Player.PrimerJugador:
                PrimerJugador.ActivationTurn++;
                break;
            case Player.SegundoJugador:
                SegundoJugador.ActivationTurn++;
                break;
            case Player.TercerJugador:
                TercerJugador.ActivationTurn++;
                break;
            case Player.CuartoJugador:
                CuartoJugador.ActivationTurn++;
                break;
        }
    }
}
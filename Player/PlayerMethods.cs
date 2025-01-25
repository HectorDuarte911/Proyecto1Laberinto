namespace ProjectLogic;
public class PlayerMethods : PieceMethods
{
    public static Player NextPlayer(Player CurrentPlayer)
    {
        switch (CurrentPlayer)
        {
            case Player.PrimerJugador:
                if (IsInGame(Player.SegundoJugador)) return Player.SegundoJugador;
                else if (IsInGame(Player.TercerJugador)) return Player.TercerJugador;
                else if (IsInGame(Player.CuartoJugador)) return Player.CuartoJugador;
                else return Player.PrimerJugador;
            case Player.SegundoJugador:
                if (IsInGame(Player.TercerJugador)) return Player.TercerJugador;
                else if (IsInGame(Player.CuartoJugador)) return Player.CuartoJugador;
                else if (IsInGame(Player.PrimerJugador)) return Player.PrimerJugador;
                else return Player.SegundoJugador;
            case Player.TercerJugador:
                if (IsInGame(Player.CuartoJugador)) return Player.CuartoJugador;
                else if (IsInGame(Player.PrimerJugador)) return Player.PrimerJugador;
                else if (IsInGame(Player.SegundoJugador)) return Player.SegundoJugador;
                else return Player.TercerJugador;
            case Player.CuartoJugador:
                if (IsInGame(Player.PrimerJugador)) return Player.PrimerJugador;
                else if (IsInGame(Player.SegundoJugador)) return Player.SegundoJugador;
                else if (IsInGame(Player.TercerJugador)) return Player.TercerJugador;
                else return Player.CuartoJugador;
        }
        return Player.None;
    }
    public static void PlayerName(Player player, string name)
    {
        switch (player)
        {
            case Player.PrimerJugador:
                PrimerJugador.name = name;
                break;
            case Player.SegundoJugador:
                SegundoJugador.name = name;
                break;
            case Player.TercerJugador:
                TercerJugador.name = name;
                break;
            case Player.CuartoJugador:
                CuartoJugador.name = name;
                break;
        }
    }
    public static string PlayerNameShow(Player player)
    {
        switch (player)
        {
            case Player.PrimerJugador:
                return PrimerJugador.name;
            case Player.SegundoJugador:
                return SegundoJugador.name;
            case Player.TercerJugador:
                return TercerJugador.name;
            case Player.CuartoJugador:
                return CuartoJugador.name;
            default: return string.Empty;
        }
    }
    public static void SetRestState(Player player, bool asign)
    {
        switch (player)
        {
            case Player.PrimerJugador:
                PrimerJugador.RestState = asign;
                break;
            case Player.TercerJugador:
                TercerJugador.RestState = asign;
                break;
            case Player.CuartoJugador:
                CuartoJugador.RestState = asign;
                break;
            case Player.SegundoJugador:
                SegundoJugador.RestState = asign;
                break;
        }
    }
    public static void SetRestTurn(Player player, int turns)
    {
        switch (player)
        {
            case Player.PrimerJugador:
                PrimerJugador.RestTurn = GameState.Turn + turns;
                break;
            case Player.TercerJugador:
                TercerJugador.RestTurn = GameState.Turn + turns;
                break;
            case Player.CuartoJugador:
                CuartoJugador.RestTurn = GameState.Turn + turns;
                break;
            case Player.SegundoJugador:
                SegundoJugador.RestTurn = GameState.Turn + turns;
                break;
        }
    }
}
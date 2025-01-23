namespace ProjectLogic;
public class GSMPlayer:GSMPosition
{
    public static Player NextPlayer(Player CurrentPlayer)
    {
        switch (CurrentPlayer)
        {
            case Player.PrimerJugador:
                if (EstaEnJuego(Player.SegundoJugador)) return Player.SegundoJugador;
                else if (EstaEnJuego(Player.TercerJugador)) return Player.TercerJugador;
                else if (EstaEnJuego(Player.CuartoJugador)) return Player.CuartoJugador;
                else return Player.PrimerJugador;
            case Player.SegundoJugador:
                if (EstaEnJuego(Player.TercerJugador)) return Player.TercerJugador;
                else if (EstaEnJuego(Player.CuartoJugador)) return Player.CuartoJugador;
                else if (EstaEnJuego(Player.PrimerJugador)) return Player.PrimerJugador;
                else return Player.SegundoJugador;
            case Player.TercerJugador:
                if (EstaEnJuego(Player.CuartoJugador)) return Player.CuartoJugador;
                else if (EstaEnJuego(Player.PrimerJugador)) return Player.PrimerJugador;
                else if (EstaEnJuego(Player.SegundoJugador)) return Player.SegundoJugador;
                else return Player.TercerJugador;
            case Player.CuartoJugador:
                if (EstaEnJuego(Player.PrimerJugador)) return Player.PrimerJugador;
                else if (EstaEnJuego(Player.SegundoJugador)) return Player.SegundoJugador;
                else if (EstaEnJuego(Player.TercerJugador)) return Player.TercerJugador;
                else return Player.CuartoJugador;
        }
        return Player.None;
    }
    public static Player LastPlayer(Player CurrentPlayer)
    {
        switch (CurrentPlayer)
        {
            case Player.PrimerJugador:
                if      (EstaEnJuego(Player.CuartoJugador))  return Player.CuartoJugador;
                else if (EstaEnJuego(Player.TercerJugador))  return Player.TercerJugador;
                else if (EstaEnJuego(Player.SegundoJugador)) return Player.SegundoJugador;
                else return Player.PrimerJugador;
            case Player.SegundoJugador:
                if      (EstaEnJuego(Player.PrimerJugador)) return Player.PrimerJugador;
                else if (EstaEnJuego(Player.CuartoJugador)) return Player.CuartoJugador;
                else if (EstaEnJuego(Player.TercerJugador)) return Player.TercerJugador;
                else return Player.SegundoJugador;
            case Player.TercerJugador:
                if      (EstaEnJuego(Player.SegundoJugador)) return Player.SegundoJugador;
                else if (EstaEnJuego(Player.PrimerJugador)) return Player.PrimerJugador;
                else if (EstaEnJuego(Player.CuartoJugador)) return Player.CuartoJugador;
                else return Player.TercerJugador;
            case Player.CuartoJugador:
                if      (EstaEnJuego(Player.TercerJugador)) return Player.TercerJugador;
                else if (EstaEnJuego(Player.SegundoJugador)) return Player.SegundoJugador;
                else if (EstaEnJuego(Player.PrimerJugador)) return Player.PrimerJugador;
                else return Player.CuartoJugador;
        }
        return Player.None;
    }
    public static void PlayerName(Player player, string name)
    {
        switch (player)
        {
            case Player.PrimerJugador:
                PrimerJugador.nombre = name;
                break;
            case Player.SegundoJugador:
                SegundoJugador.nombre = name;
                break;
            case Player.TercerJugador:
                TercerJugador.nombre = name;
                break;
            case Player.CuartoJugador:
                CuartoJugador.nombre = name;
                break;
        }
    }
     public static string PlayerNameShow(Player player)
    {
        switch (player)
        {
            case Player.PrimerJugador:
               return PrimerJugador.nombre;
            case Player.SegundoJugador:
                return SegundoJugador.nombre;     
            case Player.TercerJugador:
               return TercerJugador.nombre;
            case Player.CuartoJugador:
                 return CuartoJugador.nombre;
            default:return string.Empty;
        }
    }
    
    public static void PLayerBasicReposoAsingn(Player player, bool asign)
    {
        switch (player)
        {
            case Player.PrimerJugador:
                PrimerJugador.EstadoReposo = asign;
                break;
            case Player.TercerJugador:
                TercerJugador.EstadoReposo = asign;
                break;
            case Player.CuartoJugador:
                CuartoJugador.EstadoReposo = asign;
                break;
            case Player.SegundoJugador:
                SegundoJugador.EstadoReposo = asign;
                break;
        }
    }
    public static void PlayerBasicTurnoReposo(Player player)
    {
        switch (player)
        {
            case Player.PrimerJugador:
                PrimerJugador.TurnoReposo = GameState.Turno + 3;
                break;
            case Player.TercerJugador:
                TercerJugador.TurnoReposo = GameState.Turno + 3;
                break;
            case Player.CuartoJugador:
                CuartoJugador.TurnoReposo = GameState.Turno + 3;
                break;
            case Player.SegundoJugador:
                SegundoJugador.TurnoReposo = GameState.Turno + 3;
                break;
        }
    }
    
}
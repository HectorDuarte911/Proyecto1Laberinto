namespace ProjectLogic;
public class GSMBool:GSMMove
{
    public static bool EstaEnJuego(Player player)
    {
        foreach (Player player1 in GameState.PlayersInGame)
        {
            if (player1 == player) return true;
        }
        return false;
    }
    public static bool MovPertenece(List<Position> positions, Position position)
    {
        List<Position> Aux = positions;
        Aux.Remove(position);
        if (Aux == positions) return true;
        return false;
    }
    public static bool IsEmpty(List<Position> positions)
    {
        foreach (Position poss in positions)
        {
            return false;
        }
        return true;
    }
    public static bool PlayerbasicCompTurnActivacion()
    {
        switch (GameState.CurrentPlayer)
        {
            case Player.PrimerJugador:
                return PrimerJugador.TurnoActivacion == GameState.Turno;
            case Player.SegundoJugador:
                return SegundoJugador.TurnoActivacion == GameState.Turno;
            case Player.TercerJugador:
                return TercerJugador.TurnoActivacion == GameState.Turno;
            case Player.CuartoJugador:
                return CuartoJugador.TurnoActivacion == GameState.Turno;
            default: return false;
        }
    }
    public static bool EstaEnReposo(Player player)
    {
        switch (player)
        {
            case Player.PrimerJugador:
                return PrimerJugador.EstadoReposo;
            case Player.TercerJugador:
                return TercerJugador.EstadoReposo;
            case Player.CuartoJugador:
                return CuartoJugador.EstadoReposo;
            case Player.SegundoJugador:
                return SegundoJugador.EstadoReposo;
            default: return false;
        }
    }
    public static bool PlayerbasicCompTurnReposo()
    {
        switch (GameState.CurrentPlayer)
        {
            case Player.PrimerJugador:
                return PrimerJugador.TurnoReposo == GameState.Turno;
            case Player.SegundoJugador:
                return SegundoJugador.TurnoReposo == GameState.Turno;
            case Player.TercerJugador:
                return TercerJugador.TurnoReposo == GameState.Turno;
            case Player.CuartoJugador:
                return CuartoJugador.TurnoReposo == GameState.Turno;
            default: return false;
        }
    }
    public static bool EsArma(Objetos objetos)
    {
        if (ObjetosStats.StatsFuerza[objetos] > ObjetosStats.StatsArmadura[objetos])return true;
        return false;
    }
    public static bool EsArmadura(Objetos objetos)
    {
        if (ObjetosStats.StatsFuerza[objetos] < ObjetosStats.StatsArmadura[objetos])return true;
        return false;
    }
    // public static bool EsItemRamdon(Objetos objetos)
    // {
    //     return !EsArma(objetos) && !EsArmadura(objetos);
    // }
    public static bool SepuedeRomperTipo(CellsType type)
   {
    foreach (Position pos in GSMPosition.CasillasAdyacentesTipo(type,PieceType.None))
    {
        return true;
    }
    return false;
   } 
   public static void MezclarPosiciones(List< Position> array)
   {
    Random random= new Random();
    int n = array.Count;
    for (int i =n-1 ;i >= 0 ;i--)
    {
     int j =random.Next(0,i+1);
     Position aux = array[i];
     array[i] = array [j];
     array[j] = aux;
    }
   }
}
namespace ProjectLogic;
public class BoolMethods : FightMethods
{
    //Comprove if the parameter no violate the conditions in the names ofthe methonds
    public static bool IsInGame(Player player)
    {
        foreach (Player player1 in GameState.PlayersInGame)
        {
            if (player1 == player) return true;
        }
        return false;
    }
    public static bool IsEmpty(List<Position> positions)
    {
        foreach (Position pos in positions)
        {
            return false;
        }
        return true;
    }
    public static bool ComprobationActivationTurn()
    {
        switch (GameState.CurrentPlayer)
        {
            case Player.PrimerJugador:
                return PrimerJugador.ActivationTurn == GameState.Turn;
            case Player.SegundoJugador:
                return SegundoJugador.ActivationTurn == GameState.Turn;
            case Player.TercerJugador:
                return TercerJugador.ActivationTurn == GameState.Turn;
            case Player.CuartoJugador:
                return CuartoJugador.ActivationTurn == GameState.Turn;
            default: return false;
        }
    }
    public static bool IsInRest(Player player)
    {
        switch (player)
        {
            case Player.PrimerJugador:
                return PrimerJugador.RestState;
            case Player.TercerJugador:
                return TercerJugador.RestState;
            case Player.CuartoJugador:
                return CuartoJugador.RestState;
            case Player.SegundoJugador:
                return SegundoJugador.RestState;
            default: return false;
        }
    }
    public static bool ComprobationRestTurn()
    {
        switch (GameState.CurrentPlayer)
        {
            case Player.PrimerJugador:
                return PrimerJugador.RestTurn == GameState.Turn;
            case Player.SegundoJugador:
                return SegundoJugador.RestTurn == GameState.Turn;
            case Player.TercerJugador:
                return TercerJugador.RestTurn == GameState.Turn;
            case Player.CuartoJugador:
                return CuartoJugador.RestTurn == GameState.Turn;
            default: return false;
        }
    }
    public static bool IsItem(Object Object)
    {
        if (ObjectsStats.StatsForce[Object] > ObjectsStats.StatsArmor[Object]) return true;
        return false;
    }
    public static bool IsArmor(Object Object)
    {
        if (ObjectsStats.StatsForce[Object] < ObjectsStats.StatsArmor[Object]) return true;
        return false;
    }
    public static bool CanBreakType(CellsType type)
    {
        foreach (Position pos in GameState.GetAdyacetsCells(type, PieceType.None))
        {
            return true;
        }
        return false;
    }
}
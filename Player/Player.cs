namespace ProjectLogic;
public enum Player
{
    None,
    PrimerJugador,
    SegundoJugador,
    TercerJugador,
    CuartoJugador,
}
public abstract class PlayerBasic
{
    public abstract Player player { get;}
    public static int ActivationTurn { get; set; }
    public static bool RestState { get; set; }
    public static int RestTurn { get; set; }
}



namespace ProjectLogic;

public abstract class PlayerBasic
{
    public abstract Player player { get;}
    public static PieceType Piece { get;set;}
    public abstract bool IsInGame { get; }
    public static string nombre { get; set;}
    public static int TurnoActivacion { get; set; }
    public static bool EstadoReposo { get; set; }
    public static int TurnoReposo { get; set; }

}
public enum Player//Posibles jugadores del juego
{
    None,
    PrimerJugador,
    SegundoJugador,
    TercerJugador,
    CuartoJugador,
}



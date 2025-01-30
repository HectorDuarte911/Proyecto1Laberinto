namespace ProjectLogic;
public enum Player//All the posible players
{
    None,
    PrimerJugador,
    SegundoJugador,
    TercerJugador,
    CuartoJugador,
}
public abstract class PlayerBasic
{
    public abstract Player player { get;}//Number of player
    public static int ActivationTurn { get; set; }//Turn of activation of the obtion of the activation of the hability
    public static bool RestState { get; set; }//State of the player than determinate if the player can play or not
    public static int RestTurn { get; set; }//Turn than the player stop the rest state
}



namespace ProjectLogic;
//Class of each player representing the player basic methond
public class NonePlayer : PlayerBasic
{
    public override Player player => Player.None;
}
public class PrimerJugador : PlayerBasic
{
    public override Player player => Player.PrimerJugador;
    private static string aux = "Primer Jugador";
    public static new string name
    {
        get { return aux; }
        set { aux = value; }
    }
    public static new int ActivationTurn { get; set; }
    public static new bool RestState { get; set; }
    public static new int RestTurn { get; set; }

}
public class SegundoJugador : PlayerBasic
{
    public override Player player => Player.SegundoJugador;
    private static string aux = "Segundo Jugador";
    public static new string name
    {
        get { return aux; }
        set { aux = value; }
    }
    public static new int ActivationTurn { get; set; }
    public static new bool RestState { get; set; }
    public static new int RestTurn { get; set; }
}
public class TercerJugador : PlayerBasic
{
    public override Player player => Player.TercerJugador;
    private static string aux = "Tercer Jugador";
    public static new string name
    {
        get { return aux; }
        set { aux = value; }
    }
    public static new int ActivationTurn { get; set; }
    public static new bool RestState { get; set; }
    public static new int RestTurn { get; set; }
}
public class CuartoJugador : PlayerBasic
{
    public override Player player => Player.CuartoJugador;
    private static string aux = "Cuarto Jugador";
    public static new string name
    {
        get { return aux; }
        set { aux = value; }
    }
    public static new int ActivationTurn { get; set; }
    public static new bool RestState { get; set; }
    public static new int RestTurn { get; set; }
}
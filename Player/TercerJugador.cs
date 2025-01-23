namespace ProjectLogic;
public class TercerJugador:PlayerBasic
{
public override  Player player=>Player.TercerJugador;
public static new PieceType Piece { get;set;}
public override bool IsInGame{get;}
private static string aux="Tercer Jugador";
public static new  string nombre
{
    get{return aux;}
    set{aux=value;}
}
public static new  int TurnoActivacion{get;set;}
public static new bool EstadoReposo{get;set;}
public static new  int TurnoReposo{get;set;}
}
namespace ProjectLogic;
public enum PieceType
{
None,
Artillero,
EsclavoLibre,
Explorador,
General,
Holguinero,
Intelectual,
Internacionalista,
Soldado,
Jinete,
Terrateniente,
Titan,
Veterano,
}
public class PieceList
{
public static List<PieceType> Pieces = new List<PieceType>()
{
PieceType.Artillero,
PieceType.EsclavoLibre,
PieceType.Explorador,
PieceType.General,
PieceType.Holguinero,
PieceType.Intelectual,
PieceType.Internacionalista,
PieceType.Soldado,
PieceType.Jinete,
PieceType.Terrateniente,
PieceType.Titan,
PieceType.Veterano,
};
}
public abstract class PiecesBasic
{
public  abstract  PieceType  PieceType { get;}//Tipo de elemento en la celda
public  abstract Player Number { get; }//Jugador propietario del elemento de la celda
public abstract IEnumerable<Move> GetMoves(Position from, Board board); 
public abstract IEnumerable<Position> MovePosicionInDirs(Position from, Board board);
public List<Objetos>Inventario{get;set;}
public int TurnosEnfriamiento{get;set;}
public int Armadura{get;set;}
public int Fuerza{get;set;}
public int WeightInventary{get;set;}
public int Visibilidad{get;set;}
public static string NombreHabilidad{get;set;}
public static int NumberOfMoves{get;set;}//Indicador de la cantidad de moovimientos de un espacio de la pieza
public static int NumberOfMovesDoing {get;set;}//Indicador de cantidad de movimientos hehos por la pieza en el turno
public static  Objetos ArmaEquipada{get;set;}
public static  Objetos ArmaduraEquipada{get;set;}
public static List<PieceType> PiecesWhithHabil = new List<PieceType>()
{
PieceType.Artillero,
PieceType.EsclavoLibre,
PieceType.Explorador,
PieceType.General,
PieceType.Holguinero,
PieceType.Internacionalista,
PieceType.Soldado,
PieceType.Jinete,
PieceType.Terrateniente,
PieceType.Titan,
PieceType.Veterano,
};
public static PiecesBasic PieceReference(PieceType piece)
{
    switch (piece)
    {
        case PieceType.Artillero:
        return new Artillero(Player.None);
        case PieceType.EsclavoLibre:
        return new EsclavoLibre(Player.None);
        case PieceType.Explorador:
        return new Explorador(Player.None);
        case PieceType.General:
        return new General(Player.None);
        case PieceType.Holguinero:
        return new Holguinero(Player.None);
        case PieceType.Internacionalista:
        return new Internacionalista(Player.None);
        case PieceType.Jinete:
        return new Jinete(Player.None);
        case PieceType.Soldado:
        return new Soldado(Player.None);
        case PieceType.Titan:
        return new Titan(Player.None);
        case PieceType.Terrateniente:
        return new Terrateniente(Player.None);
        case PieceType.Veterano:
        return new Veterano(Player.None);
        default: return new None(Player.None);
    }
}
}
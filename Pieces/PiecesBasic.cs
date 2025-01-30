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
    Bolchevique,
    Soldado,
    Jinete,
    Hitman,
    Titan,
    Veterano,
}
public abstract class PiecesBasic//Abstract methond than envolve all the pieces
{
    public abstract PieceType PieceType { get; }//Type of piece
    public abstract Player Number { get; }//Player propietary
    public List<Object> Inventary = new List<Object>();//Inventary
    public int Coldturns { get; set; }//Turn to wait util activate the hability
    public int Armor { get; set; }//Armor of the piece
    public int Force { get; set; }//Force of the piece
    public int WeightInventary { get; set; }//Actual weight of the inventary
    public int Visibility { get; set; }//how many cells the piece can see
    public static string HabilityName { get; set; }//Name of the hability of the piece
    public static int NumberOfMoves { get; set; }//Number of move than the piece can do all the turns
    public static int NumberOfMovesDoing { get; set; }//Number of move doing in the turn (this is general to all the pieces)
    public static Object EquipItem { get; set; }//Actual equip item of the piece
    public static Object EquipArmor { get; set; }//Actual equip armotr of the piece
    //List of piece than have a hability(this is general to all the pieces)
    public static List<PieceType> PiecesWhithHability = new List<PieceType>()
{
PieceType.Artillero,
PieceType.EsclavoLibre,
PieceType.Explorador,
PieceType.General,
PieceType.Holguinero,
PieceType.Bolchevique,
PieceType.Soldado,
PieceType.Jinete,
PieceType.Hitman,
PieceType.Titan,
PieceType.Veterano,
};
    //List of piece than can be choose(this is general to all the pieces)
    public static List<PieceType> Pieces = new List<PieceType>()
{
PieceType.Artillero,
PieceType.EsclavoLibre,
PieceType.Explorador,
PieceType.General,
PieceType.Holguinero,
PieceType.Intelectual,
PieceType.Bolchevique,
PieceType.Soldado,
PieceType.Jinete,
PieceType.Hitman,
PieceType.Titan,
PieceType.Veterano,
};
}

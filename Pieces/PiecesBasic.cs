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
public abstract class PiecesBasic
{
    public abstract PieceType PieceType { get; }
    public abstract Player Number { get; }
    public List<Object> Inventary = new List<Object>();
    public int Coldturns { get; set; }
    public int Armor { get; set; }
    public int Force { get; set; }
    public int WeightInventary { get; set; }
    public int Visibility { get; set; }
    public static string HabilityName { get; set; }
    public static int NumberOfMoves { get; set; }
    public static int NumberOfMovesDoing { get; set; }
    public static Object EquipItem { get; set; }
    public static Object EquipArmor { get; set; }
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

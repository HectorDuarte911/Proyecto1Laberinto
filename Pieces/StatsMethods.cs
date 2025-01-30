namespace ProjectLogic;
public class StatsMethods :EventsMethods
{
    //Methonds to get the diferent stats of the pieces whith references
    public static int GetNumberOfMove(PiecesBasic piece)
    {
        switch (piece.PieceType)
        {
            case PieceType.Artillero:
                return Artillero.NumberOfMoves;
            case PieceType.EsclavoLibre:
                return EsclavoLibre.NumberOfMoves;
            case PieceType.Explorador:
                return Explorador.NumberOfMoves;
            case PieceType.Holguinero:
                return Holguinero.NumberOfMoves;
            case PieceType.General:
                return General.NumberOfMoves;
            case PieceType.Intelectual:
                return Intelectual.NumberOfMoves;
            case PieceType.Bolchevique:
                return Bolchevique.NumberOfMoves;
            case PieceType.Jinete:
                return Jinete.NumberOfMoves;
            case PieceType.Soldado:
                return Soldado.NumberOfMoves;
            case PieceType.Titan:
                return Titan.NumberOfMoves;
            case PieceType.Hitman:
                return Hitman.NumberOfMoves;
            case PieceType.Veterano:
                return Veterano.NumberOfMoves;
        }
        throw new ArgumentException("");
    }
    public static int GetArmor(PiecesBasic piecesBasic, CellsType cellsType)
    {
        switch (piecesBasic.PieceType)
        {
            case PieceType.Artillero:
                return Artillero.Armor;
            case PieceType.EsclavoLibre:
                return EsclavoLibre.Armor;
            case PieceType.Explorador:
                return Explorador.Armor;
            case PieceType.Holguinero:
                return Holguinero.Armor;
            case PieceType.General:
                return General.Armor;
            case PieceType.Intelectual:
                return Intelectual.Armor;
            case PieceType.Bolchevique:
                return Bolchevique.Armor;
            case PieceType.Jinete:
                return Jinete.Armor;
            case PieceType.Soldado:
                return Soldado.Armor;
            case PieceType.Titan:
                return Titan.Armor;
            case PieceType.Hitman:
                return Hitman.Armor;
            case PieceType.Veterano:
                return Veterano.Armor;
            default:
                switch (cellsType)
                {
                    case CellsType.Cruzado:
                        return Cruzado.Armor;
                    case CellsType.CruzadoOscuro:
                        return CruzadoOscuro.Armor;
                    case CellsType.Caballero:
                        return Caballero.Armor;
                    case CellsType.CaballeroPesado:
                        return CaballeroPesado.Armor;
                    case CellsType.Escudero:
                        return Escudero.Armor;
                    case CellsType.Ballestero:
                        return Ballestero.Armor;
                    case CellsType.Asesino:
                        return Asesino.Armor;
                    case CellsType.ArqueroLargo:
                        return ArqueroLargo.Armor;
                    case CellsType.Truhan:
                        return Truhan.Armor;
                    case CellsType.SeñorOscuro:
                        return SeñorOscuro.Armor;
                    case CellsType.Monje:
                        return Monje.Armor;
                    case CellsType.Mazero:
                        return Mazero.Armor;
                    case CellsType.Mercenario:
                        return Mercenario.Armor;
                    case CellsType.Final:
                        return Final.Armor;
                }
                break;
        }
        throw new ArgumentException("");
    }
    public static int GetForce(PiecesBasic piecesBasic, CellsType cellsType)
    {
        switch (piecesBasic.PieceType)
        {
            case PieceType.Artillero:
                return Artillero.Force;
            case PieceType.EsclavoLibre:
                return EsclavoLibre.Force;
            case PieceType.Explorador:
                return Explorador.Force;
            case PieceType.Holguinero:
                return Holguinero.Force;
            case PieceType.General:
                return General.Force;
            case PieceType.Intelectual:
                return Intelectual.Force;
            case PieceType.Bolchevique:
                return Bolchevique.Force;
            case PieceType.Jinete:
                return Jinete.Force;
            case PieceType.Soldado:
                return Soldado.Force;
            case PieceType.Titan:
                return Titan.Force;
            case PieceType.Hitman:
                return Hitman.Force;
            case PieceType.Veterano:
                return Veterano.Force;
        }
        throw new ArgumentException("");
    }
    public static int GetVisibility(PiecesBasic piecesBasic)
    {
        switch (piecesBasic.PieceType)
        {
            case PieceType.Artillero:
                return Artillero.Visibility;
            case PieceType.EsclavoLibre:
                return EsclavoLibre.Visibility;
            case PieceType.Explorador:
                return Explorador.Visibility;
            case PieceType.Holguinero:
                return Holguinero.Visibility;
            case PieceType.General:
                return General.Visibility;
            case PieceType.Intelectual:
                return Intelectual.Visibility;
            case PieceType.Bolchevique:
                return Bolchevique.Visibility;
            case PieceType.Jinete:
                return Jinete.Visibility;
            case PieceType.Soldado:
                return Soldado.Visibility;
            case PieceType.Titan:
                return Titan.Visibility;
            case PieceType.Hitman:
                return Hitman.Visibility;
            case PieceType.Veterano:
                return Veterano.Visibility;
        }
        throw new ArgumentException("");
    }
    public static Object GetEquipItem(PiecesBasic piecesBasic)
    {
        switch (piecesBasic.PieceType)
        {
            case PieceType.Artillero:
                return Artillero.EquipItem;
            case PieceType.EsclavoLibre:
                return EsclavoLibre.EquipItem;
            case PieceType.Explorador:
                return Explorador.EquipItem;
            case PieceType.General:
                return General.EquipItem;
            case PieceType.Holguinero:
                return Holguinero.EquipItem;
            case PieceType.Intelectual:
                return Intelectual.EquipItem;
            case PieceType.Bolchevique:
                return Bolchevique.EquipItem;
            case PieceType.Jinete:
                return Jinete.EquipItem;
            case PieceType.Soldado:
                return Soldado.EquipItem;
            case PieceType.Hitman:
                return Hitman.EquipItem;
            case PieceType.Titan:
                return Titan.EquipItem;
            case PieceType.Veterano:
                return Veterano.EquipItem;
        }
        throw new ArgumentException("");
    }
    public static Object GetEquipArmor(PiecesBasic piecesBasic)
    {
        switch (piecesBasic.PieceType)
        {
            case PieceType.Artillero:
                return Artillero.EquipArmor;
            case PieceType.EsclavoLibre:
                return EsclavoLibre.EquipArmor;
            case PieceType.Explorador:
                return Explorador.EquipArmor;
            case PieceType.General:
                return General.EquipArmor;
            case PieceType.Holguinero:
                return Holguinero.EquipArmor;
            case PieceType.Intelectual:
                return Intelectual.EquipArmor;
            case PieceType.Bolchevique:
                return Bolchevique.EquipArmor;
            case PieceType.Jinete:
                return Jinete.EquipArmor;
            case PieceType.Soldado:
                return Soldado.EquipArmor;
            case PieceType.Hitman:
                return Hitman.EquipArmor;
            case PieceType.Titan:
                return Titan.EquipArmor;
            case PieceType.Veterano:
                return Veterano.EquipArmor;
        }
        throw new ArgumentException("");
    }
    //Methond to no have negative stats 
    public static void NoNegativeStats(PieceType piece)
    {
        switch (piece)
        {
            case PieceType.Artillero:
                if (Artillero.Force < 0) Artillero.Force = 0;
                if (Artillero.Armor < 0) Artillero.Armor = 0;
                break;
            case PieceType.EsclavoLibre:
                if (EsclavoLibre.Force < 0) EsclavoLibre.Force = 0;
                if (EsclavoLibre.Armor < 0) EsclavoLibre.Armor = 0;
                break;
            case PieceType.Explorador:
                if (Explorador.Force < 0) Explorador.Force = 0;
                if (Explorador.Armor < 0) Explorador.Armor = 0;
                break;
            case PieceType.General:
                if (General.Force < 0) General.Force = 0;
                if (General.Armor < 0) General.Armor = 0;
                break;
            case PieceType.Holguinero:
                if (Holguinero.Force < 0) Holguinero.Force = 0;
                if (Holguinero.Armor < 0) Holguinero.Armor = 0;
                break;
            case PieceType.Intelectual:
                if (Intelectual.Force < 0) Intelectual.Force = 0;
                if (Intelectual.Armor < 0) Intelectual.Armor = 0;
                break;
            case PieceType.Bolchevique:
                if (Bolchevique.Force < 0) Bolchevique.Force = 0;
                if (Bolchevique.Armor < 0) Bolchevique.Armor = 0;
                break;
            case PieceType.Jinete:
                if (Jinete.Force < 0) Jinete.Force = 0;
                if (Jinete.Armor < 0) Jinete.Armor = 0;
                break;
            case PieceType.Soldado:
                if (Soldado.Force < 0) Soldado.Force = 0;
                if (Soldado.Armor < 0) Soldado.Armor = 0;
                break;
            case PieceType.Hitman:
                if (Hitman.Force < 0) Hitman.Force = 0;
                if (Hitman.Armor < 0) Hitman.Armor = 0;
                break;
            case PieceType.Titan:
                if (Titan.Force < 0) Titan.Force = 0;
                if (Titan.Armor < 0) Titan.Armor = 0;
                break;
            case PieceType.Veterano:
                if (Veterano.Force < 0) Veterano.Force = 0;
                if (Veterano.Armor < 0) Veterano.Armor = 0;
                break;
        }
    }
}
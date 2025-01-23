namespace ProjectLogic;
public class GSMStats:GSMObjetos
{
    public static int NumeroDeMov(PiecesBasic piece)
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
            case PieceType.Internacionalista:
                return Internacionalista.NumberOfMoves;
            case PieceType.Jinete:
                return Jinete.NumberOfMoves;
            case PieceType.Soldado:
                return Soldado.NumberOfMoves;
            case PieceType.Titan:
                return Titan.NumberOfMoves;
            case PieceType.Terrateniente:
                return Terrateniente.NumberOfMoves;
            case PieceType.Veterano:
                return Veterano.NumberOfMoves;
            default:
                return 0;
        }
    }
    public static int GetArmor(PiecesBasic piecesBasic,CellsType cellsType)
    {
        switch (piecesBasic.PieceType)
        {
            case PieceType.Artillero:
                return Artillero.Armadura;
            case PieceType.EsclavoLibre:
                return EsclavoLibre.Armadura;
            case PieceType.Explorador:
                return Explorador.Armadura;
            case PieceType.Holguinero:
                return Holguinero.Armadura;
            case PieceType.General:
                return General.Armadura;
            case PieceType.Intelectual:
                return Intelectual.Armadura;
            case PieceType.Internacionalista:
                return Internacionalista.Armadura;
            case PieceType.Jinete:
                return Jinete.Armadura;
            case PieceType.Soldado:
                return Soldado.Armadura;
            case PieceType.Titan:
                return Titan.Armadura;
            case PieceType.Terrateniente:
                return Terrateniente.Armadura;
            case PieceType.Veterano:
                return Veterano.Armadura;
            default:
           switch(cellsType)
           {
            case CellsType.Cruzado:
            return Cruzado.Armor;
           }break;
        }
        return 0;
    }
    public static int GetForce(PiecesBasic piecesBasic,CellsType cellsType)
    {
        switch (piecesBasic.PieceType)
        {
            case PieceType.Artillero:
                return Artillero.Fuerza;
            case PieceType.EsclavoLibre:
                return EsclavoLibre.Fuerza;
            case PieceType.Explorador:
                return Explorador.Fuerza;
            case PieceType.Holguinero:
                return Holguinero.Fuerza;
            case PieceType.General:
                return General.Fuerza;
            case PieceType.Intelectual:
                return Intelectual.Fuerza;
            case PieceType.Internacionalista:
                return Internacionalista.Fuerza;
            case PieceType.Jinete:
                return Jinete.Fuerza;
            case PieceType.Soldado:
                return Soldado.Fuerza;
            case PieceType.Titan:
                return Titan.Fuerza;
            case PieceType.Terrateniente:
                return Terrateniente.Fuerza;
            case PieceType.Veterano:
                return Veterano.Fuerza;    
        }
          switch(cellsType)
           {
            case CellsType.Cruzado:
            return Cruzado.Fuerza;
           }
        return 0;
    }
    public static int GetVisibility(PiecesBasic piecesBasic)
    {
        switch (piecesBasic.PieceType)
        {
            case PieceType.Artillero:
                return Artillero.Visibilidad;
            case PieceType.EsclavoLibre:
                return EsclavoLibre.Visibilidad;
            case PieceType.Explorador:
                return Explorador.Visibilidad;
            case PieceType.Holguinero:
                return Holguinero.Visibilidad;
            case PieceType.General:
                return General.Visibilidad;
            case PieceType.Intelectual:
                return Intelectual.Visibilidad;
            case PieceType.Internacionalista:
                return Internacionalista.Visibilidad;
            case PieceType.Jinete:
                return Jinete.Visibilidad;
            case PieceType.Soldado:
                return Soldado.Visibilidad;
            case PieceType.Titan:
                return Titan.Visibilidad;
            case PieceType.Terrateniente:
                return Terrateniente.Visibilidad;
            case PieceType.Veterano:
                return Veterano.Visibilidad;    
        }
        return 0;
    }
}
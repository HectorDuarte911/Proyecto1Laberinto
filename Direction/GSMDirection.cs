namespace ProjectLogic;
public class GSMDirection: GSMStats
{
    public static Direction[] DirPieza(PieceType piece)
    {
        foreach (PieceType piece1 in GameState.PiezasEnJuego)
        {
            if (piece == piece1)
            {
                switch (piece1)
                {
                    case PieceType.Artillero:
                        return Artillero.dirs;
                    case PieceType.EsclavoLibre:
                        return EsclavoLibre.dirs;
                    case PieceType.Explorador:
                        return Explorador.dirs;
                    case PieceType.General:
                        return General.dirs;
                    case PieceType.Internacionalista:
                        return Internacionalista.dirs;
                    case PieceType.Intelectual:
                        return Intelectual.dirs;
                    case PieceType.Holguinero:
                        return Holguinero.dirs;
                    case PieceType.Jinete:
                        return Jinete.dirs;
                    case PieceType.Soldado:
                        return Soldado.dirs;
                    case PieceType.Titan:
                        return Titan.dirs;
                    case PieceType.Terrateniente:
                        return Terrateniente.dirs;
                    case PieceType.Veterano:
                        return Veterano.dirs;
                }
            }
        }
        return Artillero.dirs;
    }
    public static Direction GetMoveDirection(Move move)
    {
        Direction dir=new Direction (0,0);
        if (move.ToPos.Row > move.FromPos.Row) dir +=new Direction(1, 0);
        if (move.ToPos.Row < move.FromPos.Row) dir += new Direction(-1, 0);
        if (move.ToPos.Column > move.FromPos.Column) dir +=  new Direction(0, 1);
        if (move.ToPos.Column < move.FromPos.Column) dir +=  new Direction(0, -1);
        return dir;
    }
}
namespace ProjectLogic;
public class Artillero : PiecesBasic//Metodo para tipi de  pieza Artillero
{
public override PieceType PieceType => PieceType.Artillero; //Sobrescritura del tipo de celda a Artillero
public override  Player Number{get;}//Sobrescritura  de Jugador propietario
public static readonly Direction[] dirs = new Direction[]//Direcciones en las que se puede mover la pieza
{
      Direction.Arriba,
      Direction.Abajo,
      Direction.Derecha,
      Direction.Izquierda,
};
public Artillero(Player number)
{
Number = number;
}
  public override IEnumerable<Move> GetMoves(Position from, Board board)//Movimiento de la pieza
  {
    return MovePosicionInDirs(from, board).Select(to => new Move(from, to));
  }
    public override IEnumerable<Position> MovePosicionInDirs(Position from, Board board)
  {

    foreach (Direction dir in dirs)
    {
      for(int i=1;i<=NumberOfMoves-NumberOfMovesDoing;i++)
      {
      Position to = from + i*dir;
      if (!Board.IsInside(to))break;
      if (board[to]!=CellsType.Wall || board[to]!=CellsType.Obstaculos)
      {
        yield return to;
      }
      else if (PieceBoard.IsAPiece(to)||GameState.EsEvento(GameState.Board[to]))
      {
        continue;
      }
      else break; 
    }
    } 
     }

  public static new List<Objetos> Inventario =new List<Objetos>()
  {
   Objetos.Granadas,
   Objetos.CasacaAzul,
  };
  public  static void Habilidad()
  {
    GameState.VarianteActivacion = true;
  }
   public static new string NombreHabilidad=>"Rompe Muro";
    public static new int TurnosEnfriamiento=2;
    public static new int Armadura=4;
    public static new int Fuerza=5;
    public static new int NumberOfMoves = 4;
    public static new  int Visibilidad = 4;
    public static new Objetos ArmaEquipada{get;set;}
    public static new  Objetos ArmaduraEquipada{get;set;}
}

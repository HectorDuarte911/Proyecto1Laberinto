namespace ProjectLogic;

public class Move
{
    
    public  Position FromPos { get;}//Posicion inicial de la pieza a mover
    public  Position ToPos { get;}//Posicion a donde se quiere mover la pieza  
  
    public Move(Position from, Position to)//Constructor
    {
    FromPos = from;
    ToPos = to;
    }
   public  bool Caminable(Board board)//Comprobacion de si una pieza se puede mover en cierto turno hacia cierta posicion
    {
    return board[ToPos]!=CellsType.Obstaculos && board[ToPos]!=CellsType.Wall;
    }
 

}
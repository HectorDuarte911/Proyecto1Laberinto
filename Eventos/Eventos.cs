namespace ProjectLogic;
public abstract class Eventos
{
    public abstract CellsType Type {get;}
    public static string Descripcion{get;}
    public abstract Player Player{get;}
    public static int Armor{get;set;}
    public static void Recompensa(){}
}
public class GSMEventos
{
    public static bool EsEvento(CellsType cellsType)
    {
        return cellsType==CellsType.Cruzado||cellsType==CellsType.CruzadoOscuro||cellsType==CellsType.Escudero||cellsType==CellsType.SeñorOscuro||
               cellsType==CellsType.Truhan||cellsType==CellsType.Caballero||cellsType==CellsType.CaballeroPesado||cellsType==CellsType.Mazero||
               cellsType==CellsType.Mercenario||cellsType==CellsType.Monje||cellsType==CellsType.Asesino|| cellsType==CellsType.Ballestero|| 
               cellsType==CellsType.ArqueroLargo|| cellsType==CellsType.Final;
    }
    public static Objetos DarRecompenseEvento(CellsType cellsType)
    {
       switch(cellsType)
       {
        case CellsType.Cruzado:
        return Cruzado.Recompensa();
      
       }
       throw new Exception("");
    }
    public static string AsingDescription(CellsType cellsType)
    {
      switch(cellsType)
      {
        case CellsType.Cruzado:
        return Cruzado.Descripcion;
         case CellsType.CruzadoOscuro:
        return CruzadoOscuro.Descripcion;
         case CellsType.Monje:
        return Monje.Descripcion;
         case CellsType.Mazero:
        return Mazero.Descripcion;
         case CellsType.Mercenario:
        return Mercenario.Descripcion;
         case CellsType.Caballero:
        return Caballero.Descripcion;
         case CellsType.CaballeroPesado:
        return CaballeroPesado.Descripcion;
         case CellsType.SeñorOscuro:
        return SeñorOscuro.Descripcion;
         case CellsType.Truhan:
        return Truhan.Descripcion;
         case CellsType.Asesino:
        return Asesino.Descripcion;
         case CellsType.ArqueroLargo:
        return ArqueroLargo.Descripcion;
         case CellsType.Ballestero:
        return Ballestero.Descripcion;
         case CellsType.Escudero:
        return Escudero.Descripcion; 
        case CellsType.Final:
        return Final.Descripcion;

      }
      throw new Exception("No es un evento valido");
    }
}
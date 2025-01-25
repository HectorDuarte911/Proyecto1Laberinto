namespace ProjectLogic;
public abstract class Events:Program
{
  public abstract CellsType Type { get; }
  public static string Description { get; }
  public abstract Player Player { get; }
  public static int Armor { get; set; }
  public static void Reward(){}
}
public class EventsMethods
{
  public static bool IsEvent(CellsType cellsType)
  {
    return cellsType == CellsType.Cruzado || cellsType == CellsType.CruzadoOscuro || cellsType == CellsType.Escudero || cellsType == CellsType.SeñorOscuro ||
           cellsType == CellsType.Truhan || cellsType == CellsType.Caballero || cellsType == CellsType.CaballeroPesado || cellsType == CellsType.Mazero ||
           cellsType == CellsType.Mercenario || cellsType == CellsType.Monje || cellsType == CellsType.Asesino || cellsType == CellsType.Ballestero ||
           cellsType == CellsType.ArqueroLargo || cellsType == CellsType.Final;
  }
  public static Object GetEventReward(CellsType cellsType)
  {
    
    switch (cellsType)
    {
      case CellsType.Cruzado:
        return Cruzado.Reward();
        case CellsType.CruzadoOscuro:
        return CruzadoOscuro.Reward();
        case CellsType.Caballero:
        return Caballero.Reward();
        case CellsType.CaballeroPesado:
        return CaballeroPesado.Reward();
        case CellsType.Mazero:
        return Mazero.Reward();
        case CellsType.Monje:
        return Monje.Reward();
        case CellsType.Mercenario:
        return Mercenario.Reward();
        case CellsType.ArqueroLargo:
        return ArqueroLargo.Reward();
        case CellsType.Asesino:
        return Asesino.Reward();
        case CellsType.Ballestero:
        return Ballestero.Reward();
        case CellsType.Escudero:
        return Escudero.Reward();
        case CellsType.Final:
        return Final.Reward();
        case CellsType.SeñorOscuro:
        return SeñorOscuro.Reward();
        case CellsType.Truhan:
        return Truhan.Reward();
    }
    throw new ArgumentException("");
  }
  public static string AsingDescription(CellsType cellsType)
  {
    switch (cellsType)
    {
      case CellsType.Cruzado:
        return Cruzado.Description;
      case CellsType.CruzadoOscuro:
        return CruzadoOscuro.Description;
      case CellsType.Monje:
        return Monje.Description;
      case CellsType.Mazero:
        return Mazero.Description;
      case CellsType.Mercenario:
        return Mercenario.Description;
      case CellsType.Caballero:
        return Caballero.Description;
      case CellsType.CaballeroPesado:
        return CaballeroPesado.Description;
      case CellsType.SeñorOscuro:
        return SeñorOscuro.Description;
      case CellsType.Truhan:
        return Truhan.Description;
      case CellsType.Asesino:
        return Asesino.Description;
      case CellsType.ArqueroLargo:
        return ArqueroLargo.Description;
      case CellsType.Ballestero:
        return Ballestero.Description;
      case CellsType.Escudero:
        return Escudero.Description;
      case CellsType.Final:
        return Final.Description;

    }
    throw new Exception("No es un evento valido");
  }
}
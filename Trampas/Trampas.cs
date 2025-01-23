namespace ProjectLogic;

using SixLabors.ImageSharp;
using Spectre.Console;
public class TrampaMosquitera
{
    public CellsType Tipo=CellsType.TrampaMosquitera;
    public static void Penalisacion()
    {
    PiecesBasic.NumberOfMovesDoing = GameState.NumeroDeMov(GameState.PlayerPieceBasic(GameState.CurrentPlayer));
    var AlertPanel = new Panel("[red] Un campo lleno de mosquitos lo dejan el resto del turno en recuperacion en la casilla [/]");
    AlertPanel.Border = BoxBorder.Double;
    AlertPanel.BorderColor(Spectre.Console.Color.Yellow);
    AnsiConsole.Write(AlertPanel);
    }
}
public class HoyoProfundo
{
    public CellsType Tipo=CellsType.HoyoProfundo;
    public static void Penalisacion()
    {
    if(PiecesBasic.NumberOfMovesDoing != GameState.NumeroDeMov(GameState.PlayerPieceBasic(GameState.CurrentPlayer)))PiecesBasic.NumberOfMovesDoing += 1;
    if(GameState.PlayerPieceBasic(GameState.CurrentPlayer).Armadura != 0)GameState.PlayerPieceBasic(GameState.CurrentPlayer).Armadura -= 1;
    var AlertPanel = new Panel("[red] Un sorpresido agujero en el suelo lo hace caer por un momento y pierde un poco se su movimiento y su armadura por el golpe[/]");
    AlertPanel.Border = BoxBorder.Double;
    AlertPanel.BorderColor(Spectre.Console.Color.Yellow);
    AnsiConsole.Write(AlertPanel);
    }
}
public class PasilloAgotante
{
    public CellsType Tipo=CellsType.PasilloAgotante;
    public static void Penalisacion()
    {
    if(PiecesBasic.NumberOfMovesDoing != GameState.NumeroDeMov(GameState.PlayerPieceBasic(GameState.CurrentPlayer)))PiecesBasic.NumberOfMovesDoing += 1;
    if(GameState.PlayerPieceBasic(GameState.CurrentPlayer).Fuerza != 0)GameState.PlayerPieceBasic(GameState.CurrentPlayer).Fuerza-= 1;
    var AlertPanel = new Panel("[red] Un enigmatico pasillo con patrones de movimiento hace que sus neuronas y su pasiencia casi estallen por lo que pierde movimiento y fuerzas para el camino[/]");
    AlertPanel.Border = BoxBorder.Double;
    AlertPanel.BorderColor(Spectre.Console.Color.Yellow);
    AnsiConsole.Write(AlertPanel);
    }
}
public class RanaSorpresa
{
    public CellsType Tipo=CellsType.RanaSorpresa;
    public static void Penalisacion()
    {
    int count = 0;
    List<Objetos> Inventary = GameState.PlayerPieceBasic(GameState.CurrentPlayer).Inventario; 
    foreach (Objetos objects in Inventary)
    {
        count++;
    } 
    int rand =0;
    if(count<=2)
    {
    var AlertPanel = new Panel("[red]Una rana a aparecido e intento robarte los items pero no posees ningun item suelto por lo que no hubo ningun cambio en tu inventario[/]");
    AlertPanel.Border = BoxBorder.Double;
    AlertPanel.BorderColor(Spectre.Console.Color.Yellow);
    AnsiConsole.Write(AlertPanel);
    }
    else
    {
    do{
    Random random = new Random();
    rand = random.Next(0,count);
    }while(Inventary[rand] == GetEquipItem(GameState.PlayerPieceBasic(GameState.CurrentPlayer)) || Inventary[rand] == GetEquipItem(GameState.PlayerPieceBasic(GameState.CurrentPlayer)));
    GameState.PlayerPieceBasic(GameState.CurrentPlayer).Inventario.Remove(Inventary[rand]);
    var AlertPanel = new Panel("[red]Una rana a aparecido y no parece normal se ha llevado uno de tus items guardados[/]");
    AlertPanel.Border = BoxBorder.Double;
    AlertPanel.BorderColor(Spectre.Console.Color.Yellow);
    AnsiConsole.Write(AlertPanel);
    }
    }
public static Objetos GetEquipItem(PiecesBasic piecesBasic)
{
    switch(piecesBasic.PieceType)
    {
        case PieceType.Artillero:
        return Artillero.ArmaEquipada;
        case PieceType.EsclavoLibre:
        return EsclavoLibre.ArmaEquipada;
        case PieceType.Explorador:
        return Explorador.ArmaEquipada;
        case PieceType.General:
        return General.ArmaEquipada;
        case PieceType.Holguinero:
        return Holguinero.ArmaEquipada;
        case PieceType.Intelectual:
        return Intelectual.ArmaEquipada;
        case PieceType.Internacionalista:
        return Internacionalista.ArmaEquipada;
        case PieceType.Jinete:
        return Jinete.ArmaEquipada;
        case PieceType.Soldado:
        return Soldado.ArmaEquipada;
        case PieceType.Terrateniente:
        return Terrateniente.ArmaEquipada;
        case PieceType.Titan:
        return Titan.ArmaEquipada;
        case PieceType.Veterano:
        return Veterano.ArmaEquipada;
        default:throw new Exception("No se asigno una pieza disponible");
    }
}
public static Objetos GetEquipArmor(PiecesBasic piecesBasic)
{
    switch(piecesBasic.PieceType)
    {
        case PieceType.Artillero:
        return Artillero.ArmaduraEquipada;
        case PieceType.EsclavoLibre:
        return EsclavoLibre.ArmaduraEquipada;
        case PieceType.Explorador:
        return Explorador.ArmaduraEquipada;
        case PieceType.General:
        return General.ArmaduraEquipada;
        case PieceType.Holguinero:
        return Holguinero.ArmaduraEquipada;
        case PieceType.Intelectual:
        return Intelectual.ArmaduraEquipada;
        case PieceType.Internacionalista:
        return Internacionalista.ArmaduraEquipada;
        case PieceType.Jinete:
        return Jinete.ArmaduraEquipada;
        case PieceType.Soldado:
        return Soldado.ArmaduraEquipada;
        case PieceType.Terrateniente:
        return Terrateniente.ArmaduraEquipada;
        case PieceType.Titan:
        return Titan.ArmaduraEquipada;
        case PieceType.Veterano:
        return Veterano.ArmaduraEquipada;
        default:throw new Exception("No se asigno una pieza disponible");
    }
}
}
public class GSMTrampas:GSMHabilidades
{
     public static void ActivarPenalisacionTrampa(CellsType tipo)
    {
        switch (tipo)
        {
            case CellsType.TrampaMosquitera:
                TrampaMosquitera.Penalisacion();
                break;
            case CellsType.HoyoProfundo:
                HoyoProfundo.Penalisacion();
                break;
            case CellsType.PasilloAgotante:
                PasilloAgotante.Penalisacion();
                break;
            case CellsType.RanaSorpresa:
                RanaSorpresa.Penalisacion();
                break;
        }
    }
}




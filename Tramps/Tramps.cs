namespace ProjectLogic;
using Spectre.Console;
public class TrampaMosquitera
{
    public CellsType Type = CellsType.TrampaMosquitera;
    public static void Penalty()
    {
        PiecesBasic.NumberOfMovesDoing = GameState.GetNumberOfMove(GameState.PlayerPieceBasic(GameState.CurrentPlayer));
        var AlertPanel = new Panel("[red] Un campo lleno de mosquitos lo dejan el resto del turno en recuperación en la casilla [/]");
        AlertPanel.Border = BoxBorder.Double;
        AlertPanel.BorderColor(Color.Yellow);
        AnsiConsole.Write(AlertPanel);
    }
}
public class HoyoProfundo
{
    public CellsType Type = CellsType.HoyoProfundo;
    public static void Penalty()
    {
        if (PiecesBasic.NumberOfMovesDoing != GameState.GetNumberOfMove(GameState.PlayerPieceBasic(GameState.CurrentPlayer))) PiecesBasic.NumberOfMovesDoing += 1;
        GameState.PlayerPieceBasic(GameState.CurrentPlayer).Armor -= 1;
        GameState.NoNegativeStats(GameState.PlayerPieceBasic(GameState.CurrentPlayer).PieceType);
        var AlertPanel = new Panel("[red] Un agujero en el suelo lo hace caer por un momento y pierde un poco de se su movimiento y de su armadura  por el golpe[/]");
        AlertPanel.Border = BoxBorder.Double;
        AlertPanel.BorderColor(Color.Yellow);
        AnsiConsole.Write(AlertPanel);
    }
}
public class PasilloAgotante
{
    public CellsType Type = CellsType.PasilloAgotante;
    public static void Penalty()
    {
        if (PiecesBasic.NumberOfMovesDoing != GameState.GetNumberOfMove(GameState.PlayerPieceBasic(GameState.CurrentPlayer))) PiecesBasic.NumberOfMovesDoing += 1;
        GameState.PlayerPieceBasic(GameState.CurrentPlayer).Force -= 1;
        GameState.NoNegativeStats(GameState.PlayerPieceBasic(GameState.CurrentPlayer).PieceType);
        var AlertPanel = new Panel("[red] Un enigmático pasillo con patrones de movimiento hace que sus neuronas y su paciencia casi estallen por lo que pierde movimiento y fuerza para el camino[/]");
        AlertPanel.Border = BoxBorder.Double;
        AlertPanel.BorderColor(Color.Yellow);
        AnsiConsole.Write(AlertPanel);
    }
}
public class RanaSorpresa
{
    public CellsType Type = CellsType.RanaSorpresa;
    public static void Penalty()
    {
        List<Object> inventary = GameState.PlayerPieceBasic(GameState.CurrentPlayer).Inventary;
        int count = inventary.Count;
        int rand = 0;
        if (count <= 2)
        {
            var AlertPanel = new Panel("[red]Una rana a aparecido e intenta robarte los items pero no posees ningún item suelto por lo que no hubo cambio en tu inventario[/]");
            AlertPanel.Border = BoxBorder.Double;
            AlertPanel.BorderColor(Color.Yellow);
            AnsiConsole.Write(AlertPanel);
        }
        else
        {
            do
            {
                Random random = new Random();
                rand = random.Next(0, count);
            } while (inventary[rand] == GameState.GetEquipItem(GameState.PlayerPieceBasic(GameState.CurrentPlayer)) || inventary[rand] == GameState.GetEquipItem(GameState.PlayerPieceBasic(GameState.CurrentPlayer)));
            GameState.PlayerPieceBasic(GameState.CurrentPlayer).Inventary.Remove(inventary[rand]);
            var AlertPanel = new Panel("[red]Una rana a aparecido y no parece normal ,se ha llevado uno de tus items guardados[/]");
            AlertPanel.Border = BoxBorder.Double;
            AlertPanel.BorderColor(Color.Yellow);
            AnsiConsole.Write(AlertPanel);
        }
    }
}
public class TrampsMethods :StatsMethods
{
    public static void SetTrampPenalty(CellsType Type)
    {
        switch (Type)
        {
            case CellsType.TrampaMosquitera:
                TrampaMosquitera.Penalty();
                break;
            case CellsType.HoyoProfundo:
                HoyoProfundo.Penalty();
                break;
            case CellsType.PasilloAgotante:
                PasilloAgotante.Penalty();
                break;
            case CellsType.RanaSorpresa:
                RanaSorpresa.Penalty();
                break;
        }
    }
}




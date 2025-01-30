namespace ProjectLogic;
using Spectre.Console;
public class Escudero : Events//Espesifications in Event class
{
    public override CellsType Type => CellsType.Escudero;
    public override Player Player => Player.None;
    public static new string Description => "Un escudero que parece haber perdido a su caballero pero que carga consigo un traje muy resistente";
    public static new int Armor = 12;
    public static new Object Reward()
    {
        var InformativePanel = new Panel("[green]La ha vencido ,ahora puede tener la oportunidad de tomar su armadura[/]");
        InformativePanel.BorderColor(Color.Green);
        AnsiConsole.Write(InformativePanel);
        return Object.CotaDeMallas;
    }
}
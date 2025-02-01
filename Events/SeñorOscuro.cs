namespace ProjectLogic;
using Spectre.Console;
public class SeñorOscuro : Events//Espesifications in Event class
{
    public override CellsType Type => CellsType.SeñorOscuro;
    public override Player Player => Player.None;
    public static new string Description => "Parece un miembro de la realeza pero emana sierta oscuridad a su alrededor";
    public static new int Armor = 16;
    public static new Object Reward()
    {
        var InformativePanel = new Panel(@"[green]Lo has derrotado pero aún el panico afecta tus sentidos ,la capa negra que llevaba tu 
        enemigo puede convertirse en tu salvaguarda en este laberinto[/]");
        InformativePanel.BorderColor(Color.Green);
        AnsiConsole.Write(InformativePanel);
        return Object.CapaSombria;
    }
}
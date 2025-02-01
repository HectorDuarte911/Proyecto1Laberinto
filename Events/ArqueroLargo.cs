namespace ProjectLogic;
using Spectre.Console;
public class ArqueroLargo : Events//Espesifications in Event class
{
    public override CellsType Type => CellsType.ArqueroLargo;
    public override Player Player => Player.None;
    public static new string Description => @"Ve a un arquero con un arco extremadamente largo para sus costumbres así que se le ocurre la idea 
    de que tal vez pueda apropiarse de él";
    public static new int Armor = 18;
    public static new Object Reward()
    {
        var InformativePanel = new Panel("[green]Probó el arco de su víctima y es extremadamente incómodo de usar ,pero aun así puede ser de gran ayuda[/]");
        InformativePanel.BorderColor(Color.Green);
        AnsiConsole.Write(InformativePanel);
        return Object.ArcoLargo;
    }
}
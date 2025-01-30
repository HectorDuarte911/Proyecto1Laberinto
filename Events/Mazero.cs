namespace ProjectLogic;
using Spectre.Console;
public class Mazero : Events//Espesifications in Event class
{
    public override CellsType Type => CellsType.Mazero;
    public override Player Player => Player.None;
    public static new string Description => "Un hombre con maza y armadura te ve repentinamente , puedes uir o confrontarlo";
    public static new int Armor = 13;
    public static new Object Reward()
    {
        var InformativePanel = new Panel("[green]La victoria es tuya, el arma del hombre era una maza muy poderosa ,es tu desición tomarla o no[/]");
        InformativePanel.BorderColor(Color.Green);
        AnsiConsole.Write(InformativePanel);
        return Object.Maza;
    }
}
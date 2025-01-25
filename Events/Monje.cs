namespace ProjectLogic;
using Spectre.Console;
public class Monje : Events
{
    public override CellsType Type => CellsType.Monje;
    public override Player Player => Player.None;
    public static new string Description => "Un monje está tomando poder de la fe para sus beneficios lo mejor podría ser acabar con él";
    public static new int Armor = 15;
    public static new Object Reward()
    {
        var InformativePanel = new Panel("[green]Ha consegido las cruz del monje parece que albergaba poderes ocultos[/]");
        InformativePanel.BorderColor(Color.Green);
        AnsiConsole.Write(InformativePanel);
        return Object.CruzSagrada;
    }
}
namespace ProjectLogic;
using Spectre.Console;
public class Mercenario : Events//Espesifications in Event class
{
    public override CellsType Type => CellsType.Mercenario;
    public override Player Player => Player.None;
    public static new string Description => "Un hombre sin estandarte que parece estar bien pagado se encuentra frente a ti";
    public static new int Armor = 14;
    public static new Object Reward()
    {
        var InformativePanel = new Panel("[green]Pudiste someterlo ,ahora puedes tomar sus cosas[/]");
        InformativePanel.BorderColor(Color.Green);
        AnsiConsole.Write(InformativePanel);
        return Object.ArmaduraCuero;
    }
}
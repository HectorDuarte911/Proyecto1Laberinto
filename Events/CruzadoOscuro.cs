namespace ProjectLogic;
using Spectre.Console;
public class CruzadoOscuro : Events
{
    public override CellsType Type => CellsType.CruzadoOscuro;
    public override Player Player => Player.None;
    public static new string Description => "Un cruzado está frente a tus ojos pero este parece como poseido";
    public static new int Armor = 19;
    public static new Object Reward()
    {
        var InformativePanel = new Panel(@"[green]Lograte vencer al cruzado que emanaba oscuridad puedes tomar su armadura y luego será tu 
                                                  desición heredar su voluntad oscura o no[/]");
        InformativePanel.BorderColor(Color.Green);
        AnsiConsole.Write(InformativePanel);
        return Object.ArmaduraOscura;
    }
}
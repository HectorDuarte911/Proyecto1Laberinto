namespace ProjectLogic;
using Spectre.Console;
public class Truhan : Events
{
    public override CellsType Type => CellsType.Truhan;
    public override Player Player => Player.None;
    public static new string Description => @"Vez como el truhan engaña a las personas y tu desides hacer algo por ellas : vencer al truhan o 
                                              tambien puedes irte y pensar que no viste nada ,pero más importante que las personas vez la daga que
                                              lleva en su mano y te lo piensas mejor al ver su calidad artesanal";
    public static new int Armor = 9;
    public static new Object Reward()
    {
        var InformativePanel = new Panel(@"[green]El truhan no pudo escapar a tiempo y te habla de forma indesente y entonses tomas su linda 
                                                  daga y el truhan susurra ¨fue un regalo de mi abuela Tomasita¨ y cae muerto en el suelo[/]");
        InformativePanel.BorderColor(Color.Green);
        AnsiConsole.Write(InformativePanel);
        return Object.Daga;
    }
}
namespace ProjectLogic;
using Spectre.Console;
public class Caballero:Events//Espesifications in Event class
{
public override CellsType Type =>CellsType.Caballero;
public override Player Player => Player.None; 
public static new string Description=>@"Usted ve un caballero que parese agradable y buena persona, pero más importante es el equipo que
lleva .Parece un oponenete poderoso pero el miedo no deberia ser una obcion para usted";
public static new int Armor=15;
public static new Object Reward()
{
var InformativePanel = new Panel(@"[green]El caballero con su último respiro te cuenta que él no era malvado (lo que te da igual tu solo querías
su equipo) y te revela que su verdadera armadura no la tenía puesta ya que lo interrumpió en su descanso[/]");
InformativePanel.BorderColor(Color.Green);
AnsiConsole.Write(InformativePanel);
return Object.ArmaduraVerdadera;
}
}
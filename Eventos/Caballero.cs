namespace ProjectLogic;
using Spectre.Console;
public class Caballero:Eventos
{
public override CellsType Type =>CellsType.Caballero;
public override Player Player => Player.None; 
public static new string Descripcion=>"Usted ve un caballero que parece agradable y buena persona, pero mas importante que eso es el equipo que lleva .Parrece un oponenete poderoso pero el miedo no deberia ser una obcion para usted";
public static new int Armor=10;
public static new Objetos Recompensa()
{
var InformativePanel = new Panel("[green]El caballero con su ultimo respiro te cuenta que el no era malvado (lo que te da igual tu solo querias su equipo) y te revela que su verdadera armadura no la tenia puesta ya que lo interrumpio en su descanaso[/]");
InformativePanel.BorderColor(Color.Green);
AnsiConsole.Write(InformativePanel);
return Objetos.ArmaduraVerdadera;
}
}
namespace ProjectLogic;
using Spectre.Console;
public class CaballeroPesado:Events
{
public override CellsType Type =>CellsType.CaballeroPesado;
public override Player Player => Player.None; 
public static new string Description=>"Este caballero lleva una armadura negra muy pesada pero muy poderosa";
public static new int Armor=18;
public static new Object Reward()
{
var InformativePanel = new Panel("[green]Has conseguido la victoria ,la armadura puede ser tuya[/]");
InformativePanel.BorderColor(Color.Green);
AnsiConsole.Write(InformativePanel);
return Object.ArmaduraPesada;
}
}
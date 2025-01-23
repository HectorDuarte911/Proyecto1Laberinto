namespace ProjectLogic;
using Spectre.Console;
public class CaballeroPesado:Eventos
{
public override CellsType Type =>CellsType.CaballeroPesado;
public override Player Player => Player.None; 
public static new string Descripcion=>"Este caballero lleva una armadura negra muy pesada pero muy poderosa";
public static new int Armor=10;
public static new Objetos Recompensa()
{
var InformativePanel = new Panel("[green]Has conseguido la victoria la armadura puede ser tuya[/]");
InformativePanel.BorderColor(Color.Green);
AnsiConsole.Write(InformativePanel);
return Objetos.ArmaduraPesada;
}
}
namespace ProjectLogic;
using Spectre.Console;
public class ArqueroLargo:Eventos
{
public override CellsType Type =>CellsType.ArqueroLargo;
public override Player Player => Player.None; 
public static new string Descripcion=>"Ve a un arquero con un arco extremadamente largo para sus costumbres asi que se le ocurre la idea de que tal vez pueda apropiarse de el";
public static new int Fuerza=10;
public static new int Armor=10;
public static new Objetos Recompensa()
{
var InformativePanel = new Panel("[green]Probo el arco de su victima y es extremadamente incomodo de usar ,pero aun asi puede ser de gran ayuda[/]");
InformativePanel.BorderColor(Color.Green);
AnsiConsole.Write(InformativePanel);
return Objetos.ArcoLargo;
}
}
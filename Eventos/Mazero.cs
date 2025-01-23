namespace ProjectLogic;
using Spectre.Console;
public class Mazero:Eventos
{
public override CellsType Type =>CellsType.Mazero;
public override Player Player => Player.None; 
public static new string Descripcion=>"Un hombre con maza y armadura te ve repentinamente , puedes uir o confrontarlo";
public static new int Armor=10;
public static new Objetos Recompensa()
{
var InformativePanel = new Panel("[green]La victoria es tuya, el arma del hombre era una maza muy poderosa ,es tu desicion tomarla o no[/]");
InformativePanel.BorderColor(Color.Green);
AnsiConsole.Write(InformativePanel);
return Objetos.Maza;
}
}
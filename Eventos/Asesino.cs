namespace ProjectLogic;
using Spectre.Console;
public class Asesino:Eventos
{
public override CellsType Type =>CellsType.Asesino;
public override Player Player => Player.None; 
public static new string Descripcion=>"Encuentras a un asesino masacrando a otra de las personas que son de tu epoca (pero claro esta persona no era protagonista y solo es una justificacion para matar al asesino y tomar sus cosas)";
public static new int Armor=10;
public static new Objetos Recompensa()
{
var InformativePanel = new Panel("[green]No tenia mucho de valor exepto un cuchillo envenenado y resulta que estaba protegiendo a su mujer por lo que no era un asesino despiadado como se pensaba peo bueno ya esta muero asi que no importa[/]");
InformativePanel.BorderColor(Color.Green);
AnsiConsole.Write(InformativePanel);
return Objetos.CuchilloEnvenenado;
}
}
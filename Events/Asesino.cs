namespace ProjectLogic;
using Spectre.Console;
public class Asesino:Events//Espesifications in Event class
{
public override CellsType Type =>CellsType.Asesino;
public override Player Player => Player.None; 
public static new string Description=>@"Encuentras a un asesino masacrando a otra de las personas que son de tu epoca (pero claro esta persona no
                                        era protagonista y solo es una justificación para matar al asesino y tomar sus cosas)";
public static new int Armor=20;
public static new Object Reward()
{
var InformativePanel = new Panel(@"[green]No tenía mucho de valor exepto un cuchillo envenenado y resulta que estaba protegiendo a su mujer por lo
                                         que no era un asesino despiadado como se pensaba ,pero bueno ,ya está muerto así que no importa[/]");
InformativePanel.BorderColor(Color.Green);
AnsiConsole.Write(InformativePanel);
return Object.CuchilloEnvenenado;
}
}
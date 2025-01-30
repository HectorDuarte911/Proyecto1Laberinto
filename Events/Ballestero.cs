namespace ProjectLogic;
using Spectre.Console;
public class Ballestero:Events//Espesifications in Event class
{
public override CellsType Type =>CellsType.Ballestero;
public override Player Player => Player.None; 
public static new string Description=>@"Un hombre con una ballesta descansa en una hoguera ,puede ser tú oportunid para atacarle y tomar su 
                                        linda arma";
public static new int Armor=17;
public static new Object Reward()
{
var InformativePanel = new Panel("[green]Lo has logrado la ballesta puede ser tuya espero que tengas espacio para guardarla[/]");
InformativePanel.BorderColor(Color.Green);
AnsiConsole.Write(InformativePanel);
return Object.Ballesta;
}
}
namespace ProjectLogic;
using Spectre.Console;
public class Ballestero:Eventos
{
public override CellsType Type =>CellsType.Ballestero;
public override Player Player => Player.None; 
public static new string Descripcion=>"Un hombre con una ballesta descanza en una hoguera puede ser yu oportunida para atacarle y tomar su linda arma";
public static new int Armor=10;
public static new Objetos Recompensa()
{
var InformativePanel = new Panel("[green]Lo has logrado la ballesta puede ser tuya espero que tengas espacio para guardarla[/]");
InformativePanel.BorderColor(Color.Green);
AnsiConsole.Write(InformativePanel);
return Objetos.Ballesta;
}
}
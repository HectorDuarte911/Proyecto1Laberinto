namespace ProjectLogic;
using Spectre.Console;
public class Escudero:Eventos
{
public override CellsType Type =>CellsType.Escudero;
public override Player Player => Player.None; 
public static new string Descripcion=>"Un escudero que parece haber perdido a su caballero pero que carga consigo un traje muy resistente";
public static new int Armor=10;
public static new Objetos Recompensa()
{
var InformativePanel = new Panel("[green]La ha vencido ahora puede tener la oportunidad de tomar su armadura[/]");
InformativePanel.BorderColor(Color.Green);
AnsiConsole.Write(InformativePanel);
return Objetos.CotaDeMallas;
}
}
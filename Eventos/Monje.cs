namespace ProjectLogic;
using Spectre.Console;
public class Monje:Eventos
{
public override CellsType Type =>CellsType.Monje;
public override Player Player => Player.None; 
public static new string Descripcion=>"Un monje esta tomando poder de la fe para sus beneficios lo mejor podria ser acabar con el";
public static new int Armor=10;
public static new Objetos Recompensa()
{
var InformativePanel = new Panel("[green]Ha conseghido las cruz del monje parece que albergaba poderes ocultos[/]");
InformativePanel.BorderColor(Color.Green);
AnsiConsole.Write(InformativePanel);
return Objetos.CruzSagrada;
}
}
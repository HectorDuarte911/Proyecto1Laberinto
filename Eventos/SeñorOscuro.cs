namespace ProjectLogic;
using Spectre.Console;
public class SeñorOscuro:Eventos
{
public override CellsType Type =>CellsType.SeñorOscuro;
public override Player Player => Player.None; 
public static new string Descripcion=>"Parece un miembro de la realez pero emana sierta oscuridad a su alrededor";
public static new int Armor=10;
public static new Objetos Recompensa()
{
var InformativePanel = new Panel("[green]Lo has derrotado pero aun el panico afeta tus sentidos pero la capa negra que llevaba tu enemigo puede convertirse en tu salvaguarda em este laberinto[/]");
InformativePanel.BorderColor(Color.Green);
AnsiConsole.Write(InformativePanel);
return Objetos.CapaSombria;
}
}
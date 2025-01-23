namespace ProjectLogic;
using Spectre.Console;
public class Mercenario:Eventos
{
public override CellsType Type =>CellsType.Mercenario;
public override Player Player => Player.None; 
public static new string Descripcion=>"Un hombre sin estandarte que parece estar bien pagado se encuentra frente a ti";
public static new int Armor=10;
public static new Objetos Recompensa()
{
var InformativePanel = new Panel("[green]Pudiste someterlo ,ahora puedes tomar sus cosas[/]");
InformativePanel.BorderColor(Color.Green);
AnsiConsole.Write(InformativePanel);
return Objetos.ArmaduraCuero;
}
}
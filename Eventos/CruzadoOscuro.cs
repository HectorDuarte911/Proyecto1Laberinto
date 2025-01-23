namespace ProjectLogic;
using Spectre.Console;
public class CruzadoOscuro:Eventos
{
public override CellsType Type =>CellsType.CruzadoOscuro;
public override Player Player => Player.None; 
public static new string Descripcion=>"Un cruzado est frente a tus ojos pero este parece como poseido";
public static new int Armor=10;
public static new Objetos Recompensa()
{
var InformativePanel = new Panel("[green]Lograte vencer al cruzado que emanaba oscuridad puedes tomar su armadura y luego sera tu desicion heredar su voluntad oscura o no[/]");
InformativePanel.BorderColor(Color.Green);
AnsiConsole.Write(InformativePanel);
return Objetos.ArmaduraOscura;
}
}
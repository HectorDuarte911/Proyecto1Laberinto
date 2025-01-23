namespace ProjectLogic;
using Spectre.Console;
public class Truhan:Eventos
{
public override CellsType Type =>CellsType.Truhan;
public override Player Player => Player.None; 
public static new string Descripcion=>"Vez como el truhan engaña a las personas y tu desides hacer algo por ellas : vencer al truhan o tambien puedes irte y pensar que no viste nada pero mas importante que las personas vez la daga que llleva en su mano y te lo piensas mejor al ver su calidad artesanal";
public static new int Armor=10;
public static new Objetos Recompensa()
{
var InformativePanel = new Panel("[green]El truhan no pudo escapar a tiempo y te habla de forma indesente y entonses tomas su linda daga y el truhan susurra 'fue un regalo de mi abuela' y cae muerto en el suelo[/]");
InformativePanel.BorderColor(Color.Green);
AnsiConsole.Write(InformativePanel);
return Objetos.Daga;
}
}
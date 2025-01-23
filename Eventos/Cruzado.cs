using System.Dynamic;
using Spectre.Console;

namespace ProjectLogic;
public class Cruzado:Eventos
{
public override CellsType Type =>CellsType.Cruzado;
public override Player Player => Player.None; 
public static new string Descripcion=>"Un cruzado legendario custodia algo de muy buena calidad debe vencerlo en un duelo uno contra uno para quedarte con la espada";
public static new int Armor=10;
public static new Objetos Recompensa()
{
var InformativePanel = new Panel("[green]A conseguido acabar con el infame cruzado y ahora se puede disponer a despojar su cuerpo de su armadura o de su espadada [/],[red] o era asi hasta que destruiste su armadura con tu poder descontrolado [/],[green] pero no te procupes la espada aun se conserva [/]");
InformativePanel.Border = BoxBorder.Double;
InformativePanel.BorderColor(Color.Green);
AnsiConsole.Write(InformativePanel);
return Objetos.EspadadaCruzado;
}
}
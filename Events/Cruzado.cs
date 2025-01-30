using Spectre.Console;
namespace ProjectLogic;
public class Cruzado : Events//Espesifications in Event class
{
    public override CellsType Type => CellsType.Cruzado;
    public override Player Player => Player.None;
    public static new string Description => @"Un cruzado legendario custodia algo de muy buena calidad debe vencerlo en un duelo uno contra uno 
                                              para quedarte con la espada";
    public static new int Armor = 16;
    public static new Object Reward()
    {
        var InformativePanel = new Panel(@"[green]A conseguido acabar con el infame cruzado y ahora se puede disponer a despojar el cuerpo de su 
                                                  armadura o de su espadada [/],[red] o era así hasta que destruiste su armadura con tú poder descontrolado
                                                  [/],[green] pero no te procupes la espada aún se conserva [/]");
        InformativePanel.Border = BoxBorder.Double;
        InformativePanel.BorderColor(Color.Green);
        AnsiConsole.Write(InformativePanel);
        return Object.EspadadaCruzado;
    }
}
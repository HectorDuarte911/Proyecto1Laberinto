namespace ProjectLogic;
using Spectre.Console;
public class Final:Eventos
{
public override CellsType Type =>CellsType.Final;
public override Player Player => Player.None; 
public static new string Descripcion=>"Por fin has llegado al final del laberinto pero no esperabas encontrate con una criatura inponente como el Behemonth tendras que derrotarlo para conseguir salir del laberinto";
public static new int Armor=10;
public static new Objetos Recompensa()
{
var InformativePanel = new Panel("[green]Por fin lograste la victoria ,la sangre de la criatura se filtra por las grietas del suelo ,ahora sal del laberinto antes que alguien te alcance con la llave que encontraste[/]");
InformativePanel.BorderColor(Color.Green);
AnsiConsole.Write(InformativePanel);
GameState.Winner = GameState.CurrentPlayer;
return Objetos.LlaveLaberinto;
}
}
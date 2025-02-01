namespace ProjectLogic;
using Spectre.Console;
public class Final : Events//Espesifications in Event class
{
    public override CellsType Type => CellsType.Final;
    public override Player Player => Player.None;
    public static new string Description => @"Por fin has llegado al final del laberinto pero no esperabas encontrate con una criatura inponente
    como el Behemonth tendrás que derrotarlo para conseguir salir del laberinto";
    public static new int Armor =40-GameState.GetArmor(GameState.PlayerPieceBasic(GameState.CurrentPlayer),CellsType.None);
    public static new Object Reward()
    {
        var InformativePanel = new Panel(@"[green]Por fin lograste la victoria ,la sangre de la criatura se filtra por las grietas del suelo ,
        ahora sal del laberinto antes de que alguien te alcance con la llave que encontraste[/]");
        InformativePanel.BorderColor(Color.Green);
        AnsiConsole.Write(InformativePanel);
        GameState.Winner = GameState.CurrentPlayer;
        return Object.LlaveLaberinto;
    }
}
namespace ProjectLogic;
using Spectre.Console;
public enum TurnActions//All the posible actions of a turn
{
    Caminar,
    ActivarHabilidad,
    RomperMuro,
    DerribarObstaculos,
    ActivarPortal,
    Rendirse,
    ObcionesEquipo,
    MirarEquipo,
    TerminarTurno,
    abandonar,
    atacar,
    Luchar,
    EquiparArma,
    EquiparArmadura,
    VerCaracteristicasDeObjetos,
    CerrarEquipo,
    InfoJuego,
    DescartarObjeto,
    PlayerPieceView,
}
public class NoDoingActions
{
    public static List<TurnActions> UndoingActions = new List<TurnActions>()//Actions that the player can do
   {
    TurnActions.PlayerPieceView,
    TurnActions.InfoJuego,
    TurnActions.Caminar,
    TurnActions.ObcionesEquipo,
    TurnActions.TerminarTurno,
   };
    public static List<TurnActions> FightActions = new List<TurnActions>()//Actions that the player can do in figth
   {
    TurnActions.PlayerPieceView,
    TurnActions.atacar,
    TurnActions.InfoJuego,
    TurnActions.ObcionesEquipo,
    TurnActions.abandonar,
   };
    public static List<TurnActions> EquipActions = new List<TurnActions>()//Actions that the player can do in equip obtions
   {
    TurnActions.PlayerPieceView,
    TurnActions.EquiparArma,
    TurnActions.EquiparArmadura,
    TurnActions.VerCaracteristicasDeObjetos,
    TurnActions.CerrarEquipo,
    TurnActions.MirarEquipo,
    TurnActions.DescartarObjeto,
    TurnActions.InfoJuego
   };
    public static void AjustAction(TurnActions TurnActions)//This Methonds if to no have two of the same ations in the list
    {
        NoDoingActions.UndoingActions.Remove(TurnActions);
        NoDoingActions.UndoingActions.Add(TurnActions);
    }
    public static char Confirm(string confimation)//Action to confirm if you are sure of continue with the same desition
    {
        string color = "white";
        char confirm = AnsiConsole.Prompt(new SelectionPrompt<char>()
        .Title(confimation)
        .PageSize(3)
        .AddChoices('y', 'n'));
        if (confirm == 'y') color = "green";
        else color = "red";
        AnsiConsole.MarkupLineInterpolated($"Seleccionó [{color}] {confirm}[/]");
        return confirm;
    }
}

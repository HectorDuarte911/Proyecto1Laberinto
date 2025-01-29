namespace ProjectLogic;
using Spectre.Console;
public enum TurnActions
{
    Caminar,
    ActivarHabilidad,
    RomperMuro,
    DerribarObstaculos,
    ActivarPortal,
    Rendirse,
    MirarMapa,
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
    SALIR,
    EMPEZARPARTIDA,
    OBCCIONESPARTIDA,
    DescartarObjeto,
    PlayerPieceView,
}
public class NoDoingActions
{
    public static List<TurnActions> UndoingActions = new List<TurnActions>()
   {
    TurnActions.PlayerPieceView,
    TurnActions.InfoJuego,
    TurnActions.Caminar,
    TurnActions.ObcionesEquipo,
    TurnActions.TerminarTurno,
   };
    public static List<TurnActions> FightActions = new List<TurnActions>()
   {
    TurnActions.PlayerPieceView,
    TurnActions.atacar,
    TurnActions.InfoJuego,
    TurnActions.ObcionesEquipo,
    TurnActions.abandonar,
   };
    public static List<TurnActions> EquipActions = new List<TurnActions>()
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
    public static void AjustAction(TurnActions TurnActions)
    {
        NoDoingActions.UndoingActions.Remove(TurnActions);
        NoDoingActions.UndoingActions.Add(TurnActions);
    }
    public static char Confirm(string confimation)
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

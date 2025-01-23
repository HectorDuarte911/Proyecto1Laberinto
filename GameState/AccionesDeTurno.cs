namespace ProjectLogic;
using Spectre.Console;
public enum AccinesDeTurno //Posibles Acciones de un jugador
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
    CONTROLES,
    SALIR,
    EMPEZARPARTIDA,
    OBCCIONESPARTIDA,
    DescartarObjeto,
}
public class AccinesSinRealizarse
{
    public static List<AccinesDeTurno> AccionesSinRealizar = new List<AccinesDeTurno>()//Lista de Acciones predeterminadas del Turno Para Cada Jugador
   {
    AccinesDeTurno.Caminar,
    AccinesDeTurno.ObcionesEquipo,
    AccinesDeTurno.TerminarTurno,
   };
    public static List<AccinesDeTurno> AccionesDeLucha = new List<AccinesDeTurno>()
   {
    AccinesDeTurno.atacar,
    AccinesDeTurno.ObcionesEquipo,
    AccinesDeTurno.abandonar,
   };
    public static List<AccinesDeTurno> AccinesDeEquipo = new List<AccinesDeTurno>()
   {
    AccinesDeTurno.EquiparArma,
    AccinesDeTurno.EquiparArmadura,
    AccinesDeTurno.VerCaracteristicasDeObjetos,
    AccinesDeTurno.CerrarEquipo,
    AccinesDeTurno.MirarEquipo,
   };
   public static void AjustAccion(AccinesDeTurno accinesDeTurno)
   {
    AccinesSinRealizarse.AccionesSinRealizar.Remove(accinesDeTurno);
    AccinesSinRealizarse.AccionesSinRealizar.Add(accinesDeTurno);
   }
   public static char Confirm(AccinesDeTurno eleccion)
   {
    string color="white";
    char confirm = AnsiConsole.Prompt(new SelectionPrompt<char>()
    .Title($"Estas seguro que quieres seleccionar {eleccion}")
    .PageSize(3)
    .AddChoices('y','n'));
    if(confirm=='y')color="green";
    else color="red";
    AnsiConsole.MarkupLineInterpolated($"Selecciono [{color}] {confirm}[/]");
    return confirm;
   }
}

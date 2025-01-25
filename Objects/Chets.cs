namespace ProjectLogic;
using Spectre.Console;
public class Chest
{
    public static void RamdomActivation()
    {
        int k =0;
        if(PosibleObjects.Count == 0)k = 1;
        Random random =new Random();
        int r = random.Next(k,5);
        switch(r)
        {
            case 0:
            Random random1 = new Random();
            int objectrand = random1.Next(0,PosibleObjects.Count);
            AnsiConsole.WriteLine($"[green]Ha encontrado {PosibleObjects[objectrand]} en el cofre[/]");
            GameState.AddObject(PosibleObjects[objectrand]);
            PosibleObjects.Remove(PosibleObjects[objectrand]);
            break;
            case 1:ForceUp();
            AnsiConsole.WriteLine($"[green]Ha encontrado una bebida muy poderosa su fuerza ha subido en uno [/]");
            break;
            case 2:ForceDown();
            AnsiConsole.WriteLine($"[red]]Ha encontrado una bebida pestilenta su fuerza ha bajado en uno [/]");
            break;
            case 3:ArmorUp();
            AnsiConsole.WriteLine($"[green]Ha encontrado una pai muy poderosa su armadura ha subido en uno [/]");
            break;
            case 4:ArmorDown();
            AnsiConsole.WriteLine($"[red]Ha encontrado una pai hechado a perder armadura ha bajado en uno [/]");
            break;
        }
    }
    public static List<Object> PosibleObjects = new List<Object>()
    {
    Object.Magnum,
    Object.Thopsom,
    Object.Escopeta,
    Object.Lupara,
    Object.Bate,
    Object.Martillo,
    Object.Paraguas,
    Object.Vara,
    Object.Palo,
    Object.Manopla,
    Object.Chaleco,
    Object.CamisaDeLaSuerte,
    Object.TrajeElegante,
    Object.ArmaduraPuntiaguda,
    Object.Capucha,
    Object.ArmaduraOro,
    Object.ArmaduraOro,
    Object.RopaCampaña,
    Object.CascoCruzado,
    Object.ArmaduraDeFlores,
    Object.TrajePielDeIndio,
    Object.Lanza,
    Object.MangoPodrido,
    Object.ArmaduraPuntiaguda,
    };
    public static void ForceUp()
    {
        GameState.PlayerPieceBasic(GameState.CurrentPlayer).Force++;
    }
    public static void ForceDown()
    {
        GameState.PlayerPieceBasic(GameState.CurrentPlayer).Force--;
        GameState.NoNegativeStats(GameState.PlayerPieceBasic(GameState.CurrentPlayer).PieceType);
    }
    public static void ArmorUp()
    {
        GameState.PlayerPieceBasic(GameState.CurrentPlayer).Armor++;
    }
    public static void ArmorDown()
    {
        GameState.PlayerPieceBasic(GameState.CurrentPlayer).Armor--;
        GameState.NoNegativeStats(GameState.PlayerPieceBasic(GameState.CurrentPlayer).PieceType);
    }
}
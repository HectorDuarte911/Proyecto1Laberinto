namespace ProjectLogic;
using Spectre.Console;
public class ObjectMethods :HabilitysMethods
{
    public static void SeeInventary()
    {
        var table = new Table();
        List<string> StatsObjets = new List<string>();
        List<string> StatsForce = new List<string>();
        List<string> StatsArmor = new List<string>();
        List<string> StatsWeight = new List<string>();
        switch (GameState.PlayerPieceBasic(GameState.CurrentPlayer).PieceType)
        {
            case PieceType.Artillero:
                foreach (Object Artillero in Artillero.Inventary)
                {
                    StatsObjets.Add($"{Artillero}");
                    StatsForce.Add($"{ObjectsStats.StatsForce[Artillero]}");
                    StatsArmor.Add($"{ObjectsStats.StatsArmor[Artillero]}");
                    StatsWeight.Add($"{ObjectsStats.StatsWeight[Artillero]}");
                }
                break;
            case PieceType.EsclavoLibre:
                foreach (Object EsclavoLibre in EsclavoLibre.Inventary)
                {
                    StatsObjets.Add($"{EsclavoLibre}");
                    StatsForce.Add($"{ObjectsStats.StatsForce[EsclavoLibre]}");
                    StatsArmor.Add($"{ObjectsStats.StatsArmor[EsclavoLibre]}");
                    StatsWeight.Add($"{ObjectsStats.StatsWeight[EsclavoLibre]}");
                }
                break;
            case PieceType.Explorador:
                foreach (Object Explorador in Explorador.Inventary)
                {
                    StatsObjets.Add($"{Explorador}");
                    StatsForce.Add($"{ObjectsStats.StatsForce[Explorador]} ");
                    StatsArmor.Add($"{ObjectsStats.StatsArmor[Explorador]}");
                    StatsWeight.Add($"{ObjectsStats.StatsWeight[Explorador]}");
                }
                break;
            case PieceType.General:
                foreach (Object General in General.Inventary)
                {
                    StatsObjets.Add($"{General}");
                    StatsForce.Add($"{ObjectsStats.StatsForce[General]} ");
                    StatsArmor.Add($"{ObjectsStats.StatsArmor[General]}");
                    StatsWeight.Add($"{ObjectsStats.StatsWeight[General]}");
                }
                break;
            case PieceType.Holguinero:
                foreach (Object Holguinero in Holguinero.Inventary)
                {
                    StatsObjets.Add($"{Holguinero}");
                    StatsForce.Add($"{ObjectsStats.StatsForce[Holguinero]} ");
                    StatsArmor.Add($"{ObjectsStats.StatsArmor[Holguinero]}");
                    StatsWeight.Add($"{ObjectsStats.StatsWeight[Holguinero]}");
                }
                break;
            case PieceType.Intelectual:
                foreach (Object Intelectual in Intelectual.Inventary)
                {
                    StatsObjets.Add($"{Intelectual}");
                    StatsForce.Add($"{ObjectsStats.StatsForce[Intelectual]} ");
                    StatsArmor.Add($"{ObjectsStats.StatsArmor[Intelectual]}");
                    StatsWeight.Add($"{ObjectsStats.StatsWeight[Intelectual]}");
                }
                break;
            case PieceType.Internacionalista:
                foreach (Object Internacionalista in Internacionalista.Inventary)
                {
                    StatsObjets.Add($"{Internacionalista}");
                    StatsForce.Add($"{ObjectsStats.StatsForce[Internacionalista]} ");
                    StatsArmor.Add($"{ObjectsStats.StatsArmor[Internacionalista]}");
                    StatsWeight.Add($"{ObjectsStats.StatsWeight[Internacionalista]}");
                }
                break;
            case PieceType.Jinete:
                foreach (Object Jinete in Jinete.Inventary)
                {
                    StatsObjets.Add($"{Jinete}");
                    StatsForce.Add($"{ObjectsStats.StatsForce[Jinete]} ");
                    StatsArmor.Add($"{ObjectsStats.StatsArmor[Jinete]}");
                    StatsWeight.Add($"{ObjectsStats.StatsWeight[Jinete]}");
                }
                break;
            case PieceType.Soldado:
                foreach (Object Soldado in Soldado.Inventary)
                {
                    StatsObjets.Add($"{Soldado}");
                    StatsForce.Add($"{ObjectsStats.StatsForce[Soldado]} ");
                    StatsArmor.Add($"{ObjectsStats.StatsArmor[Soldado]}");
                    StatsWeight.Add($"{ObjectsStats.StatsWeight[Soldado]}");
                }
                break;
            case PieceType.Titan:
                foreach (Object Titan in Titan.Inventary)
                {
                    StatsObjets.Add($"{Titan}");
                    StatsForce.Add($"{ObjectsStats.StatsForce[Titan]} ");
                    StatsArmor.Add($"{ObjectsStats.StatsArmor[Titan]}");
                    StatsWeight.Add($"{ObjectsStats.StatsWeight[Titan]}");
                }
                break;
            case PieceType.Hitman:
                foreach (Object Hitman in Hitman.Inventary)
                {
                    StatsObjets.Add($"{Hitman}");
                    StatsForce.Add($"{ObjectsStats.StatsForce[Hitman]} ");
                    StatsArmor.Add($"{ObjectsStats.StatsArmor[Hitman]}");
                    StatsWeight.Add($"{ObjectsStats.StatsWeight[Hitman]}");
                }
                break;
            case PieceType.Veterano:
                foreach (Object Veterano in Veterano.Inventary)
                {
                    StatsObjets.Add($"{Veterano}");
                    StatsForce.Add($"{ObjectsStats.StatsForce[Veterano]} ");
                    StatsArmor.Add($"{ObjectsStats.StatsArmor[Veterano]}");
                    StatsWeight.Add($"{ObjectsStats.StatsWeight[Veterano]}");
                }
                break;
        }
        table.AddColumn("[red]Objeto[/]");
        table.AddColumn(new TableColumn("[red]Force[/]").Centered());
        table.AddColumn(new TableColumn("[red]Armor[/]").Centered());
        table.AddColumn(new TableColumn("[red]Weight[/]").Centered());
        int i = 0;
        foreach (string Object in StatsObjets)
        {
            table.AddRow($"[DarkGoldenrod]{StatsObjets[i]}[/]", $"[orange1]{StatsForce[i]}[/]", $"[orange1]{StatsArmor[i]}[/]", $"[orange1]{StatsWeight[i]}[/]");
            i++;
        }
        AnsiConsole.Write(table);
    }
    public static void EquipOptions(bool flag)
    {
        while (flag)
        {
            TurnActions election = AnsiConsole.Prompt(new SelectionPrompt<TurnActions>()
            .Title("[DarkGoldenrod]Escoja que acción realizar[/]:")
            .PageSize(12)
            .HighlightStyle(new Style(foreground: Color.Red))
            .AddChoices(NoDoingActions.EquipActions));
            AnsiConsole.MarkupLineInterpolated($"[red]A seleccionado {election}[/]");
            switch (election)
            {
                case TurnActions.MirarEquipo:
                    if (NoDoingActions.Confirm("Estas seguro que quieres mirar tú equipo disponible ?") == 'y') SeeInventary();
                    break;
                case TurnActions.CerrarEquipo:
                    if (NoDoingActions.Confirm("Estas seguro que deseas salir de las obciones de equipo ?") == 'y') flag = false;
                    Console.Clear();
                    break;
                case TurnActions.EquiparArma:
                    if (NoDoingActions.Confirm("Estas seguro que quieres equiparte un arma ?") == 'y')
                    {
                        List<Object> Items = new List<Object>();
                        foreach (Object Object in GetInventary(GameState.CurrentPlayer))
                        {
                            if (GameState.IsItem(Object))Items.Add(Object);
                        }
                        if (!ISEmpty(Items))AddItem(Items);
                        else
                        {
                            var panel = new Panel($"[red]No posees armas disponibles para equipar[/]");
                            panel.Border = BoxBorder.Ascii;
                            panel.BorderColor(Color.Red);
                            AnsiConsole.Write(panel);
                        }
                    }
                    break;
                case TurnActions.EquiparArmadura:
                    if (NoDoingActions.Confirm("Estas seguro que quieres equiparte una aramaduar ?") == 'y')
                    {
                        List<Object> Armors = new List<Object>();
                        foreach (Object Object in GameState.PlayerPieceBasic(GameState.CurrentPlayer).Inventary)
                        {
                            if (GameState.IsArmor(Object)) Armors.Add(Object);
                        }
                        if (!ISEmpty(Armors))AddArmor(Armors);
                        else
                        {
                            var panel = new Panel($"[red]No posees armaduras disponibles para equipar[/]");
                            panel.Border = BoxBorder.Ascii;
                            panel.BorderColor(Color.Red);
                            AnsiConsole.Write(panel);
                        }
                    }
                    break;
                case TurnActions.VerCaracteristicasDeObjetos:
                    if (NoDoingActions.Confirm("Estas seguro que deseas ver las características de algún objeto ?") == 'y')
                    {
                        Object Object = AnsiConsole.Prompt(new SelectionPrompt<Object>()
                        .Title("[DarkGoldenrod]Escoja un objeto que analizar[/] :")
                        .PageSize(12)
                        .HighlightStyle(new Style(foreground: Color.Red))
                        .AddChoices(GetInventary(GameState.CurrentPlayer)));
                        AnsiConsole.MarkupLineInterpolated($"[red]A seleccionado {Object}[/]");
                        var panel = new Panel($"[orange1]{ObjectsStats.DescriptionObject[Object]}[/]");
                        panel.Border = BoxBorder.None;
                        panel.BorderColor(Color.DarkGoldenrod);
                        AnsiConsole.Write(panel);
                    }
                    break;
                case TurnActions.DescartarObjeto:
                    if (NoDoingActions.Confirm("Estas seguro que quieres descartar algún objeto ?") == 'y') DiscartObject();
                    break;
            }
        }
    }
    public static List<Object> GetInventary(Player player)
    {
        switch (GameState.PlayerPieceBasic(player).PieceType)
        {
            case PieceType.Artillero:
                return Artillero.Inventary;
            case PieceType.EsclavoLibre:
                return EsclavoLibre.Inventary;
            case PieceType.Explorador:
                return Explorador.Inventary;
            case PieceType.General:
                return General.Inventary;
            case PieceType.Holguinero:
                return Holguinero.Inventary;
            case PieceType.Intelectual:
                return Intelectual.Inventary;
            case PieceType.Internacionalista:
                return Internacionalista.Inventary;
            case PieceType.Jinete:
                return Jinete.Inventary;
            case PieceType.Soldado:
                return Artillero.Inventary;
            case PieceType.Titan:
                return Titan.Inventary;
            case PieceType.Hitman:
                return Hitman.Inventary;
            case PieceType.Veterano:
                return Veterano.Inventary;
        }
        throw new ArgumentException("");
    }
    public static void DiscartObject()
    {
        var DiscartElection = AnsiConsole.Prompt(new SelectionPrompt<Object>()
        .Title("[yellow]   Inventario  [/]")
        .PageSize(12)
        .HighlightStyle(new Style(foreground: Color.Red))
        .AddChoices(GetInventary(GameState.CurrentPlayer)));
        AnsiConsole.MarkupLineInterpolated($"[red]Ha selecionado descartar {DiscartElection} [/]");
        GameState.PlayerPieceBasic(GameState.CurrentPlayer).WeightInventary -= ObjectsStats.StatsWeight[DiscartElection];
        if (GameState.GetEquipItem(GameState.PlayerPieceBasic(GameState.CurrentPlayer)) == DiscartElection)
        {
            AjustObject(GameState.PlayerPieceBasic(GameState.CurrentPlayer).PieceType, GameState.GetEquipItem(GameState.PlayerPieceBasic(GameState.CurrentPlayer)));
        }
        else if (GameState.GetEquipArmor(GameState.PlayerPieceBasic(GameState.CurrentPlayer)) == DiscartElection) AjustObject(GameState.PlayerPieceBasic(GameState.CurrentPlayer).PieceType, GameState.GetEquipArmor(GameState.PlayerPieceBasic(GameState.CurrentPlayer)));
        RemoveObject(GameState.PlayerPieceBasic(GameState.CurrentPlayer).PieceType, DiscartElection);
    }
    public static void AddObject(Object Object)
    {
        while (true)
        {
            if (ObjectsStats.StatsWeight[Object] + GameState.PlayerPieceBasic(GameState.CurrentPlayer).WeightInventary <= 200)
            {
                switch (GameState.PlayerPieceBasic(GameState.CurrentPlayer).PieceType)
                {
                    case PieceType.Artillero:
                        Artillero.Inventary.Add(Object);
                        break;
                    case PieceType.EsclavoLibre:
                        EsclavoLibre.Inventary.Add(Object);
                        break;
                    case PieceType.Explorador:
                        Explorador.Inventary.Add(Object);
                        break;
                    case PieceType.General:
                        General.Inventary.Add(Object);
                        break;
                    case PieceType.Hitman:
                        Hitman.Inventary.Add(Object);
                        break;
                    case PieceType.Holguinero:
                        Holguinero.Inventary.Add(Object);
                        break;
                    case PieceType.Intelectual:
                        Intelectual.Inventary.Add(Object);
                        break;
                    case PieceType.Internacionalista:
                        Internacionalista.Inventary.Add(Object);
                        break;
                    case PieceType.Jinete:
                        Jinete.Inventary.Add(Object);
                        break;
                    case PieceType.Soldado:
                        Soldado.Inventary.Remove(Object);
                        break;
                    case PieceType.Titan:
                        Titan.Inventary.Add(Object);
                        break;
                    case PieceType.Veterano:
                        Veterano.Inventary.Add(Object);
                        break;
                }
                break;
            }
            else
            {
                int NecesaryWeight = 200 - ObjectsStats.StatsWeight[Object] - GameState.PlayerPieceBasic(GameState.CurrentPlayer).WeightInventary;
                Console.WriteLine(@$"[red] No hay espacio suficiente por favor si quiere obtener su objeto debe liberar {NecesaryWeight} unidades 
                                           de su inventario[/] ");
                GameState.SeeInventary();
                if (NoDoingActions.Confirm("Estas seguro que quieres descartar un objeto") == 'y')
                {
                    GameState.DiscartObject();
                }
                else break;
            }
        }
        GameState.PlayerPieceBasic(GameState.CurrentPlayer).WeightInventary += ObjectsStats.StatsWeight[Object];
    }
    public static void RemoveObject(PieceType type, Object Object)
    {
        switch (type)
        {
            case PieceType.Artillero:
                Artillero.Inventary.Remove(Object);
                break;
            case PieceType.EsclavoLibre:
                EsclavoLibre.Inventary.Remove(Object);
                break;
            case PieceType.Explorador:
                Explorador.Inventary.Remove(Object);
                break;
            case PieceType.General:
                General.Inventary.Remove(Object);
                break;
            case PieceType.Hitman:
                Hitman.Inventary.Remove(Object);
                break;
            case PieceType.Holguinero:
                Holguinero.Inventary.Remove(Object);
                break;
            case PieceType.Intelectual:
                Intelectual.Inventary.Remove(Object);
                break;
            case PieceType.Internacionalista:
                Internacionalista.Inventary.Remove(Object);
                break;
            case PieceType.Jinete:
                Jinete.Inventary.Remove(Object);
                break;
            case PieceType.Soldado:
                Soldado.Inventary.Remove(Object);
                break;
            case PieceType.Titan:
                Titan.Inventary.Remove(Object);
                break;
            case PieceType.Veterano:
                Veterano.Inventary.Remove(Object);
                break;
        }
    }
    public static void AjustObject(PieceType type, Object Object)
    {
        if (GameState.IsItem(Object))
        {
            switch (type)
            {
                case PieceType.Artillero:
                    Artillero.Force -= ObjectsStats.StatsForce[Artillero.EquipItem];
                    Artillero.Armor -= ObjectsStats.StatsArmor[Artillero.EquipItem];
                    Artillero.EquipItem = Object.none;
                    break;
                case PieceType.EsclavoLibre:
                    EsclavoLibre.Force -= ObjectsStats.StatsForce[EsclavoLibre.EquipItem];
                    EsclavoLibre.Armor -= ObjectsStats.StatsArmor[EsclavoLibre.EquipItem];
                    EsclavoLibre.EquipItem = Object.none;
                    break;
                case PieceType.Explorador:
                    Explorador.Force -= ObjectsStats.StatsForce[Explorador.EquipItem];
                    Explorador.Armor -= ObjectsStats.StatsArmor[Explorador.EquipItem];
                    Explorador.EquipItem = Object.none;
                    break;
                case PieceType.General:
                    General.Force -= ObjectsStats.StatsForce[General.EquipItem];
                    General.Armor -= ObjectsStats.StatsArmor[General.EquipItem];
                    General.EquipItem = Object.none;
                    break;
                case PieceType.Holguinero:
                    Holguinero.Force -= ObjectsStats.StatsForce[Holguinero.EquipItem];
                    Holguinero.Armor -= ObjectsStats.StatsArmor[Holguinero.EquipItem];
                    Holguinero.EquipItem = Object.none;
                    break;
                case PieceType.Intelectual:
                    Intelectual.Force -= ObjectsStats.StatsForce[Intelectual.EquipItem];
                    Intelectual.Armor -= ObjectsStats.StatsArmor[Intelectual.EquipItem];
                    Intelectual.EquipItem = Object.none;
                    break;
                case PieceType.Internacionalista:
                    Internacionalista.Force -= ObjectsStats.StatsForce[Internacionalista.EquipItem];
                    Internacionalista.Armor -= ObjectsStats.StatsArmor[Internacionalista.EquipItem];
                    Internacionalista.EquipItem = Object.none;
                    break;
                case PieceType.Jinete:
                    Jinete.Force -= ObjectsStats.StatsForce[Jinete.EquipItem];
                    Jinete.Armor -= ObjectsStats.StatsArmor[Jinete.EquipItem];
                    Jinete.EquipItem = Object.none;
                    break;
                case PieceType.Soldado:
                    Soldado.Force -= ObjectsStats.StatsForce[Soldado.EquipItem];
                    Soldado.Armor -= ObjectsStats.StatsArmor[Soldado.EquipItem];
                    Soldado.EquipItem = Object.none;
                    break;
                case PieceType.Hitman:
                    Hitman.Force -= ObjectsStats.StatsForce[Hitman.EquipItem];
                    Hitman.Armor -= ObjectsStats.StatsArmor[Hitman.EquipItem];
                    Hitman.EquipItem = Object.none;
                    break;
                case PieceType.Titan:
                    Titan.Force -= ObjectsStats.StatsForce[Titan.EquipItem];
                    Titan.Armor -= ObjectsStats.StatsArmor[Titan.EquipItem];
                    Titan.EquipItem = Object.none;
                    break;
                case PieceType.Veterano:
                    Veterano.Force -= ObjectsStats.StatsForce[Veterano.EquipItem];
                    Veterano.Armor -= ObjectsStats.StatsArmor[Veterano.EquipItem];
                    Veterano.EquipItem = Object.none;
                    break;
            }
        }
        else
        {
            switch (GameState.PlayerPieceBasic(GameState.CurrentPlayer).PieceType)
            {
                case PieceType.Artillero:
                    Artillero.Force -= ObjectsStats.StatsForce[Artillero.EquipArmor];
                    Artillero.Armor -= ObjectsStats.StatsForce[Artillero.EquipArmor];
                    Artillero.EquipArmor = Object.none;
                    break;
                case PieceType.EsclavoLibre:
                    EsclavoLibre.Force -= ObjectsStats.StatsForce[EsclavoLibre.EquipArmor];
                    EsclavoLibre.Armor -= ObjectsStats.StatsForce[EsclavoLibre.EquipArmor];
                    EsclavoLibre.EquipArmor = Object.none;
                    break;
                case PieceType.Explorador:
                    Explorador.Force -= ObjectsStats.StatsForce[Explorador.EquipArmor];
                    Explorador.Armor -= ObjectsStats.StatsForce[Explorador.EquipArmor];
                    Explorador.EquipArmor = Object.none;
                    break;
                case PieceType.General:
                    General.Force -= ObjectsStats.StatsForce[General.EquipArmor];
                    General.Armor -= ObjectsStats.StatsForce[General.EquipArmor];
                    General.EquipArmor = Object.none;
                    break;
                case PieceType.Holguinero:
                    Holguinero.Force -= ObjectsStats.StatsForce[Holguinero.EquipArmor];
                    Holguinero.Armor -= ObjectsStats.StatsForce[Holguinero.EquipArmor];
                    Holguinero.EquipArmor = Object.none;
                    break;
                case PieceType.Intelectual:
                    Intelectual.Force -= ObjectsStats.StatsForce[Intelectual.EquipArmor];
                    Intelectual.Armor -= ObjectsStats.StatsForce[Intelectual.EquipArmor];
                    Intelectual.EquipArmor = Object.none;
                    break;
                case PieceType.Internacionalista:
                    Internacionalista.Force -= ObjectsStats.StatsForce[Internacionalista.EquipArmor];
                    Internacionalista.Armor -= ObjectsStats.StatsForce[Internacionalista.EquipArmor];
                    Internacionalista.EquipArmor = Object.none;
                    break;
                case PieceType.Jinete:
                    Jinete.Force -= ObjectsStats.StatsForce[Jinete.EquipArmor];
                    Jinete.Armor -= ObjectsStats.StatsForce[Jinete.EquipArmor];
                    Jinete.EquipArmor = Object.none;
                    break;
                case PieceType.Soldado:
                    Soldado.Force -= ObjectsStats.StatsForce[Soldado.EquipArmor];
                    Soldado.Armor -= ObjectsStats.StatsForce[Soldado.EquipArmor];
                    Soldado.EquipArmor = Object.none;
                    break;
                case PieceType.Hitman:
                    Hitman.Force -= ObjectsStats.StatsForce[Hitman.EquipArmor];
                    Hitman.Armor -= ObjectsStats.StatsForce[Hitman.EquipArmor];
                    Hitman.EquipArmor = Object.none;
                    break;
                case PieceType.Titan:
                    Titan.Force -= ObjectsStats.StatsForce[Titan.EquipArmor];
                    Titan.Armor -= ObjectsStats.StatsForce[Titan.EquipArmor];
                    Titan.EquipArmor = Object.none;
                    break;
                case PieceType.Veterano:
                    Veterano.Force -= ObjectsStats.StatsForce[Veterano.EquipArmor];
                    Veterano.Armor -= ObjectsStats.StatsForce[Veterano.EquipArmor];
                    Veterano.EquipArmor = Object.none;
                    break;
            }
        }
        GameState.NoNegativeStats(type);
    }
   
    public static bool ISEmpty(List<Object> Inventary)
    {
        foreach (Object Object in Inventary)
        {
            return false;
        }
        return true;
    }
    public static void AddItem(List<Object> Items)
    {
        Object elec = AnsiConsole.Prompt(new SelectionPrompt<Object>()
        .Title("[DarkGoldenrod]Escoja que arma equiparse[/] :")
        .PageSize(12)
        .HighlightStyle(new Style(foreground: Color.Red))
        .AddChoices(Items));
        AnsiConsole.MarkupLineInterpolated($"[red]A seleccionado {elec}[/]");
        switch (GameState.PlayerPieceBasic(GameState.CurrentPlayer).PieceType)
        {
            case PieceType.Artillero:
                int ArtilleroAux = ObjectsStats.StatsForce[Artillero.EquipItem];
                Artillero.Force += ObjectsStats.StatsForce[elec] - ArtilleroAux;
                Artillero.EquipItem = elec;
                break;
            case PieceType.EsclavoLibre:
                int EsclavoLibreAux = ObjectsStats.StatsForce[EsclavoLibre.EquipItem];
                EsclavoLibre.Force += ObjectsStats.StatsForce[elec] - EsclavoLibreAux;
                EsclavoLibre.EquipItem = elec;
                break;
            case PieceType.Explorador:
                int ExploradorAux = ObjectsStats.StatsForce[Explorador.EquipItem];
                Explorador.Force += ObjectsStats.StatsForce[elec] - ExploradorAux;
                Explorador.EquipItem = elec;
                break;
            case PieceType.General:
                int GeneralAux = ObjectsStats.StatsForce[General.EquipItem];
                General.Force += ObjectsStats.StatsForce[elec] - GeneralAux;
                General.EquipItem = elec;
                break;
            case PieceType.Holguinero:
                int HolguineroAux = ObjectsStats.StatsForce[Holguinero.EquipItem];
                Holguinero.Force += ObjectsStats.StatsForce[elec] - HolguineroAux;
                Holguinero.EquipItem = elec;
                break;
            case PieceType.Intelectual:
                int IntelectualAux = ObjectsStats.StatsForce[Intelectual.EquipItem];
                Intelectual.Force += ObjectsStats.StatsForce[elec] - IntelectualAux;
                Intelectual.EquipItem = elec;
                break;
            case PieceType.Internacionalista:
                int InternacionalistaAux = ObjectsStats.StatsForce[Internacionalista.EquipItem];
                Internacionalista.Force += ObjectsStats.StatsForce[elec] - InternacionalistaAux;
                Internacionalista.EquipItem = elec;
                break;
            case PieceType.Jinete:
                int JineteAux = ObjectsStats.StatsForce[Jinete.EquipItem];
                Jinete.Force += ObjectsStats.StatsForce[elec] - JineteAux;
                Jinete.EquipItem = elec;
                break;
            case PieceType.Soldado:
                int SoldadoAux = ObjectsStats.StatsForce[Soldado.EquipItem];
                Soldado.Force += ObjectsStats.StatsForce[elec] - SoldadoAux;
                Soldado.EquipItem = elec;
                break;
            case PieceType.Titan:
                int TitanAux = ObjectsStats.StatsForce[Titan.EquipItem];
                Titan.Force += ObjectsStats.StatsForce[elec] - TitanAux;
                Titan.EquipItem = elec;
                break;
            case PieceType.Hitman:
                int HitmanAux = ObjectsStats.StatsForce[Hitman.EquipItem];
                Hitman.Force += ObjectsStats.StatsForce[elec] - HitmanAux;
                Hitman.EquipItem = elec;
                break;
            case PieceType.Veterano:
                int VeteranoAux = ObjectsStats.StatsForce[Veterano.EquipItem];
                Veterano.Force += ObjectsStats.StatsForce[elec] - VeteranoAux;
                Veterano.EquipItem = elec;
                break;
        }
    }
    public static void AddArmor(List<Object> Armors)
    {
        Object elec = AnsiConsole.Prompt(new SelectionPrompt<Object>()
        .Title("[DarkGoldenrod]Escoja que armadura equiparse[/] :")
        .PageSize(12)
        .HighlightStyle(new Style(foreground: Color.Red))
        .AddChoices(Armors));
        AnsiConsole.MarkupLineInterpolated($"[red]A seleccionado {elec}[/]");
        switch (GameState.PlayerPieceBasic(GameState.CurrentPlayer).PieceType)
        {
            case PieceType.Artillero:
                int ArtilleroAux = ObjectsStats.StatsArmor[Artillero.EquipArmor];
                Artillero.Armor += ObjectsStats.StatsArmor[elec] - ArtilleroAux;
                Artillero.EquipArmor = elec;
                break;
            case PieceType.EsclavoLibre:
                int EsclavoLibreAux = ObjectsStats.StatsArmor[EsclavoLibre.EquipArmor];
                EsclavoLibre.Armor += ObjectsStats.StatsArmor[elec] - EsclavoLibreAux;
                EsclavoLibre.EquipArmor = elec;
                break;
            case PieceType.Explorador:
                int ExploradorAux = ObjectsStats.StatsArmor[Explorador.EquipArmor];
                Explorador.Armor += ObjectsStats.StatsArmor[elec] - ExploradorAux;
                Explorador.EquipArmor = elec;
                break;
            case PieceType.General:
                int GeneralAux = ObjectsStats.StatsArmor[General.EquipArmor];
                General.Armor += ObjectsStats.StatsArmor[elec] - GeneralAux;
                General.EquipArmor = elec;
                break;
            case PieceType.Holguinero:
                int HolguineroAux = ObjectsStats.StatsArmor[Holguinero.EquipArmor];
                Holguinero.Armor += ObjectsStats.StatsArmor[elec] - HolguineroAux;
                Holguinero.EquipArmor = elec;
                break;
            case PieceType.Intelectual:
                int IntelectualAux = ObjectsStats.StatsArmor[Intelectual.EquipArmor];
                Intelectual.Armor += ObjectsStats.StatsArmor[elec] - IntelectualAux;
                Intelectual.EquipArmor = elec;
                break;
            case PieceType.Internacionalista:
                int InternacionalistaAux = ObjectsStats.StatsArmor[Internacionalista.EquipArmor];
                Internacionalista.Armor += ObjectsStats.StatsArmor[elec] - InternacionalistaAux;
                Internacionalista.EquipArmor = elec;
                break;
            case PieceType.Jinete:
                int JineteAux = ObjectsStats.StatsArmor[Jinete.EquipArmor];
                Jinete.Armor += ObjectsStats.StatsArmor[elec] - JineteAux;
                Jinete.EquipArmor = elec;
                break;
            case PieceType.Soldado:
                int SoldadoAux = ObjectsStats.StatsArmor[Soldado.EquipArmor];
                Soldado.Armor += ObjectsStats.StatsArmor[elec] - SoldadoAux;
                Soldado.EquipArmor = elec;
                break;
            case PieceType.Titan:
                int TitanAux = ObjectsStats.StatsArmor[Titan.EquipArmor];
                Titan.Armor += ObjectsStats.StatsArmor[elec] - TitanAux;
                Titan.EquipArmor = elec;
                break;
            case PieceType.Hitman:
                int HitmanAux = ObjectsStats.StatsArmor[Hitman.EquipArmor];
                Hitman.Armor += ObjectsStats.StatsArmor[elec] - HitmanAux;
                Hitman.EquipArmor = elec;
                break;
            case PieceType.Veterano:
                int VeteranoAux = ObjectsStats.StatsArmor[Veterano.EquipArmor];
                Veterano.Armor += ObjectsStats.StatsArmor[elec] - VeteranoAux;
                Veterano.EquipArmor = elec;
                break;
        }
    }
}

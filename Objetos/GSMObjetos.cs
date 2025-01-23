namespace ProjectLogic;

using System.Text;
using Spectre.Console;
public class GSMObjetos : GSMTrampas//Pendiente a mejorar lejibilidad
{
    public static void VerInventario()
    {
        var table = new Table();
        List<string> StatsObjets = new List<string>();
        List<string> StatsFuerza = new List<string>();
        List<string> StatsArmor = new List<string>();
        List<string> StatsPeso = new List<string>();
        switch (GSMPiece.PlayerPiece(GameState.CurrentPlayer))
        {
            case PieceType.Artillero:
                foreach (Objetos Artillero in Artillero.Inventario)
                {
                    StatsObjets.Add($"{Artillero}");
                    StatsFuerza.Add($"{ObjetosStats.StatsFuerza[Artillero]} ");
                    StatsArmor.Add($"{ObjetosStats.StatsArmadura[Artillero]}");
                    StatsPeso.Add($"{ObjetosStats.StatsPeso[Artillero]}");
                }
                break;
            case PieceType.EsclavoLibre:
                foreach (Objetos EsclavoLibre in EsclavoLibre.Inventario)
                {
                    StatsObjets.Add($"{EsclavoLibre}");
                    StatsFuerza.Add($"{ObjetosStats.StatsFuerza[EsclavoLibre]} ");
                    StatsArmor.Add($"{ObjetosStats.StatsArmadura[EsclavoLibre]}");
                    StatsPeso.Add($"{ObjetosStats.StatsPeso[EsclavoLibre]}");
                    }
                break;
            case PieceType.Explorador:
                foreach (Objetos Explorador in Explorador.Inventario)
                {
                    StatsObjets.Add($"{Explorador}");
                    StatsFuerza.Add($"{ObjetosStats.StatsFuerza[Explorador]} ");
                    StatsArmor.Add($"{ObjetosStats.StatsArmadura[Explorador]}");
                    StatsPeso.Add($"{ObjetosStats.StatsPeso[Explorador]}");
                    }
                break;
            case PieceType.General:
                foreach (Objetos General in General.Inventario)
                {
                    StatsObjets.Add($"{General}");
                    StatsFuerza.Add($"{ObjetosStats.StatsFuerza[General]} ");
                    StatsArmor.Add($"{ObjetosStats.StatsArmadura[General]}");
                    StatsPeso.Add($"{ObjetosStats.StatsPeso[General]}"); 
                }
                break;
            case PieceType.Holguinero:
                foreach (Objetos Holguinero in Holguinero.Inventario)
                {
                    StatsObjets.Add($"{Holguinero}");
                    StatsFuerza.Add($"{ObjetosStats.StatsFuerza[Holguinero]} ");
                    StatsArmor.Add($"{ObjetosStats.StatsArmadura[Holguinero]}");
                    StatsPeso.Add($"{ObjetosStats.StatsPeso[Holguinero]}"); 
                }
                break;
            case PieceType.Intelectual:
                foreach (Objetos Intelectual in Intelectual.Inventario)
                {
                    StatsObjets.Add($"{Intelectual}");
                    StatsFuerza.Add($"{ObjetosStats.StatsFuerza[Intelectual]} ");
                    StatsArmor.Add($"{ObjetosStats.StatsArmadura[Intelectual]}");
                    StatsPeso.Add($"{ObjetosStats.StatsPeso[Intelectual]}");
                }
                break;
            case PieceType.Internacionalista:
                foreach (Objetos Internacionalista in Internacionalista.Inventario)
                {
                    StatsObjets.Add($"{Internacionalista}");
                    StatsFuerza.Add($"{ObjetosStats.StatsFuerza[Internacionalista]} ");
                    StatsArmor.Add($"{ObjetosStats.StatsArmadura[Internacionalista]}");
                    StatsPeso.Add($"{ObjetosStats.StatsPeso[Internacionalista]}");
                }
                break;
            case PieceType.Jinete:
                foreach (Objetos Jinete in Jinete.Inventario)
                {
                    StatsObjets.Add($"{Jinete}");
                    StatsFuerza.Add($"{ObjetosStats.StatsFuerza[Jinete]} ");
                    StatsArmor.Add($"{ObjetosStats.StatsArmadura[Jinete]}");
                    StatsPeso.Add($"{ObjetosStats.StatsPeso[Jinete]}"); 
                }
                break;
            case PieceType.Soldado:
                foreach (Objetos Soldado in Soldado.Inventario)
                {
                    StatsObjets.Add($"{Soldado}");
                    StatsFuerza.Add($"{ObjetosStats.StatsFuerza[Soldado]} ");
                    StatsArmor.Add($"{ObjetosStats.StatsArmadura[Soldado]}");
                    StatsPeso.Add($"{ObjetosStats.StatsPeso[Soldado]}");
                }
                break;
            case PieceType.Titan:
                foreach (Objetos Titan in Titan.Inventario)
                {
                    StatsObjets.Add($"{Titan}");
                    StatsFuerza.Add($"{ObjetosStats.StatsFuerza[Titan]} ");
                    StatsArmor.Add($"{ObjetosStats.StatsArmadura[Titan]}");
                    StatsPeso.Add($"{ObjetosStats.StatsPeso[Titan]}");
                }
                break;
            case PieceType.Terrateniente:
                foreach (Objetos Terrateniente in Terrateniente.Inventario)
                {
                    StatsObjets.Add($"{Terrateniente}");
                    StatsFuerza.Add($"{ObjetosStats.StatsFuerza[Terrateniente]} ");
                    StatsArmor.Add($"{ObjetosStats.StatsArmadura[Terrateniente]}");
                    StatsPeso.Add($"{ObjetosStats.StatsPeso[Terrateniente]}");
                }
                break;
            case PieceType.Veterano:
                foreach (Objetos Veterano in Veterano.Inventario)
                {
                    StatsObjets.Add($"{Veterano}");
                    StatsFuerza.Add($"{ObjetosStats.StatsFuerza[Veterano]} ");
                    StatsArmor.Add($"{ObjetosStats.StatsArmadura[Veterano]}");
                    StatsPeso.Add($"{ObjetosStats.StatsPeso[Veterano]}");
                }
                break;
        }
        table.AddColumn("[red]Objeto[/]");
        table.AddColumn(new TableColumn("[red]Fuerza[/]").Centered());
        table.AddColumn(new TableColumn("[red]Armadura[/]").Centered());
        table.AddColumn(new TableColumn("[red]Peso[/]").Centered());
        int i=0;
        foreach (string objetos in StatsObjets)
        {
            table.AddRow($"[DarkGoldenrod]{StatsObjets[i]}[/]",$"[orange1]{StatsFuerza[i]}[/]",$"[orange1]{StatsArmor[i]}[/]",$"[orange1]{StatsPeso[i]}[/]");
            i++;
        }
        AnsiConsole.Write(table);
    }
    public static void ObcionesEquipo(bool flag)
    {
        while (flag)
        {
            AccinesDeTurno eleccion = AnsiConsole.Prompt(new SelectionPrompt<AccinesDeTurno>()
            .Title("[DarkGoldenrod]Escoja que accion realizar[/]:")
            .PageSize(12)
            .HighlightStyle(new Style(foreground:Color.Red))
            .AddChoices(AccinesSinRealizarse.AccinesDeEquipo));
            AnsiConsole.MarkupLineInterpolated($"[red]A seleccionado {eleccion}[/]");
            switch (eleccion)
            {
                case AccinesDeTurno.MirarEquipo:
                    if (AccinesSinRealizarse.Confirm(eleccion) == 'y')
                    {
                        VerInventario();
                    }
                    break;
                case AccinesDeTurno.CerrarEquipo:
                    if (AccinesSinRealizarse.Confirm(eleccion) == 'y') flag = false;
                    Console.Clear();
                    break;
                case AccinesDeTurno.EquiparArma:
                    if (AccinesSinRealizarse.Confirm(eleccion) == 'y')
                    {
                        int count = 0;
                        List<Objetos> Armas = new List<Objetos>();
                        if (GSMPiece.PlayerPieceBasic(GameState.CurrentPlayer).Inventario != null)
                        {
                            foreach (Objetos objetos in GSMPiece.PlayerPieceBasic(GameState.CurrentPlayer).Inventario)
                            {
                                if (GSMBool.EsArma(objetos))
                                {
                                    Armas.Add(objetos);
                                    count++;
                                }
                            }
                            if (count != 0)
                            {
                                Objetos elec = AnsiConsole.Prompt(new SelectionPrompt<Objetos>()
                                .Title("[DarkGoldenrod]Escoja que arma equiparse[/] :")
                                .PageSize(12)
                                .HighlightStyle(new Style(foreground:Color.Red))
                                .AddChoices(Armas));
                                AnsiConsole.MarkupLineInterpolated($"[red]A seleccionado {elec}[/]");
                                switch (GSMPiece.PlayerPiece(GameState.CurrentPlayer))
                                {
                                    case PieceType.Artillero:
                                        int ArtilleroAux = ObjetosStats.StatsFuerza[Artillero.ArmaEquipada];
                                        Artillero.Fuerza += ObjetosStats.StatsFuerza[elec] - ArtilleroAux;
                                        Artillero.ArmaEquipada = elec;
                                        break;
                                    case PieceType.EsclavoLibre:
                                        int EsclavoLibreAux = ObjetosStats.StatsFuerza[EsclavoLibre.ArmaEquipada];
                                        EsclavoLibre.Fuerza += ObjetosStats.StatsFuerza[elec] - EsclavoLibreAux;
                                        EsclavoLibre.ArmaEquipada = elec;
                                        break;
                                    case PieceType.Explorador:
                                        int ExploradorAux = ObjetosStats.StatsFuerza[Explorador.ArmaEquipada];
                                        Explorador.Fuerza += ObjetosStats.StatsFuerza[elec] - ExploradorAux;
                                        Explorador.ArmaEquipada = elec;
                                        break;
                                    case PieceType.General:
                                        int GeneralAux = ObjetosStats.StatsFuerza[General.ArmaEquipada];
                                        General.Fuerza += ObjetosStats.StatsFuerza[elec] - GeneralAux;
                                        General.ArmaEquipada = elec;
                                        break;
                                    case PieceType.Holguinero:
                                        int HolguineroAux = ObjetosStats.StatsFuerza[Holguinero.ArmaEquipada];
                                        Holguinero.Fuerza += ObjetosStats.StatsFuerza[elec] - HolguineroAux;
                                        Holguinero.ArmaEquipada = elec;
                                        break;
                                    case PieceType.Intelectual:
                                        int IntelectualAux = ObjetosStats.StatsFuerza[Intelectual.ArmaEquipada];
                                        Intelectual.Fuerza += ObjetosStats.StatsFuerza[elec] - IntelectualAux;
                                        Intelectual.ArmaEquipada = elec;
                                        break;
                                    case PieceType.Internacionalista:
                                        int InternacionalistaAux = ObjetosStats.StatsFuerza[Internacionalista.ArmaEquipada];
                                        Internacionalista.Fuerza += ObjetosStats.StatsFuerza[elec] - InternacionalistaAux;
                                        Internacionalista.ArmaEquipada = elec;
                                        break;
                                    case PieceType.Jinete:
                                        int JineteAux = ObjetosStats.StatsFuerza[Jinete.ArmaEquipada];
                                        Jinete.Fuerza += ObjetosStats.StatsFuerza[elec] - JineteAux;
                                        Jinete.ArmaEquipada = elec;
                                        break;
                                    case PieceType.Soldado:
                                        int SoldadoAux = ObjetosStats.StatsFuerza[Soldado.ArmaEquipada];
                                        Soldado.Fuerza += ObjetosStats.StatsFuerza[elec] - SoldadoAux;
                                        Soldado.ArmaEquipada = elec;
                                        break;
                                    case PieceType.Titan:
                                        int TitanAux = ObjetosStats.StatsFuerza[Titan.ArmaEquipada];
                                        Titan.Fuerza += ObjetosStats.StatsFuerza[elec] - TitanAux;
                                        Titan.ArmaEquipada = elec;
                                        break;
                                    case PieceType.Terrateniente:
                                        int TerratenienteAux = ObjetosStats.StatsFuerza[Terrateniente.ArmaEquipada];
                                        Terrateniente.Fuerza += ObjetosStats.StatsFuerza[elec] - TerratenienteAux;
                                        Terrateniente.ArmaEquipada = elec;
                                        break;
                                    case PieceType.Veterano:
                                        int VeteranoAux = ObjetosStats.StatsFuerza[Veterano.ArmaEquipada];
                                        Veterano.Fuerza += ObjetosStats.StatsFuerza[elec] - VeteranoAux;
                                        Veterano.ArmaEquipada = elec;
                                        break;
                                }
                            }
                        }
                        else
                        {
                            var panel = new Panel($"[red]No posees armas disponibles para equipar[/]");
                            panel.Border = BoxBorder.Ascii;
                            panel.BorderColor(Color.Red);
                            AnsiConsole.Write(panel);
                        }
                    }
                    break;
                case AccinesDeTurno.EquiparArmadura:
                    if (AccinesSinRealizarse.Confirm(eleccion) == 'y')
                    {

                        List<Objetos> Armaduras = new List<Objetos>();
                        int count = 0;
                        if (GSMPiece.PlayerPieceBasic(GameState.CurrentPlayer).Inventario != null)
                        {
                            foreach (Objetos objetos in GSMPiece.PlayerPieceBasic(GameState.CurrentPlayer).Inventario)
                            {
                                if (GSMBool.EsArmadura(objetos))
                                {
                                    Armaduras.Add(objetos);
                                    count++;
                                }
                            }
                            if (count != 0)
                            {
                                Objetos elec = AnsiConsole.Prompt(new SelectionPrompt<Objetos>()
                                .Title("[DarkGoldenrod]Escoja que armadura equiparse[/] :")
                                .PageSize(12)
                                .HighlightStyle(new Style(foreground:Color.Red))
                                .AddChoices(Armaduras));
                                AnsiConsole.MarkupLineInterpolated($"[red]A seleccionado {elec}[/]");
                                switch (GSMPiece.PlayerPiece(GameState.CurrentPlayer))
                                {
                                    case PieceType.Artillero:
                                        int ArtilleroAux = ObjetosStats.StatsArmadura[Artillero.ArmaduraEquipada];
                                        Artillero.Armadura += ObjetosStats.StatsArmadura[elec] - ArtilleroAux;
                                        Artillero.ArmaduraEquipada = elec;
                                        break;
                                    case PieceType.EsclavoLibre:
                                        int EsclavoLibreAux = ObjetosStats.StatsArmadura[EsclavoLibre.ArmaduraEquipada];
                                        EsclavoLibre.Armadura += ObjetosStats.StatsArmadura[elec] - EsclavoLibreAux;
                                        EsclavoLibre.ArmaduraEquipada = elec;
                                        break;
                                    case PieceType.Explorador:
                                        int ExploradorAux = ObjetosStats.StatsArmadura[Explorador.ArmaduraEquipada];
                                        Explorador.Armadura += ObjetosStats.StatsArmadura[elec] - ExploradorAux;
                                        Explorador.ArmaduraEquipada = elec;
                                        break;
                                    case PieceType.General:
                                        int GeneralAux = ObjetosStats.StatsArmadura[General.ArmaduraEquipada];
                                        General.Armadura += ObjetosStats.StatsArmadura[elec] - GeneralAux;
                                        General.ArmaduraEquipada = elec;
                                        break;
                                    case PieceType.Holguinero:
                                        int HolguineroAux = ObjetosStats.StatsArmadura[Holguinero.ArmaduraEquipada];
                                        Holguinero.Armadura += ObjetosStats.StatsArmadura[elec] - HolguineroAux;
                                        Holguinero.ArmaduraEquipada = elec;
                                        break;
                                    case PieceType.Intelectual:
                                        int IntelectualAux = ObjetosStats.StatsArmadura[Intelectual.ArmaduraEquipada];
                                        Intelectual.Armadura += ObjetosStats.StatsArmadura[elec] - IntelectualAux;
                                        Intelectual.ArmaduraEquipada = elec;
                                        break;
                                    case PieceType.Internacionalista:
                                        int InternacionalistaAux = ObjetosStats.StatsArmadura[Internacionalista.ArmaduraEquipada];
                                        Internacionalista.Armadura += ObjetosStats.StatsArmadura[elec] - InternacionalistaAux;
                                        Internacionalista.ArmaduraEquipada = elec;
                                        break;
                                    case PieceType.Jinete:
                                        int JineteAux = ObjetosStats.StatsArmadura[Jinete.ArmaduraEquipada];
                                        Jinete.Armadura += ObjetosStats.StatsArmadura[elec] - JineteAux;
                                        Jinete.ArmaduraEquipada = elec;
                                        break;
                                    case PieceType.Soldado:
                                        int SoldadoAux = ObjetosStats.StatsArmadura[Soldado.ArmaduraEquipada];
                                        Soldado.Armadura += ObjetosStats.StatsArmadura[elec] - SoldadoAux;
                                        Soldado.ArmaduraEquipada = elec;
                                        break;
                                    case PieceType.Titan:
                                        int TitanAux = ObjetosStats.StatsArmadura[Titan.ArmaduraEquipada];
                                        Titan.Armadura += ObjetosStats.StatsArmadura[elec] - TitanAux;
                                        Titan.ArmaduraEquipada = elec;
                                        break;
                                    case PieceType.Terrateniente:
                                        int TerratenienteAux = ObjetosStats.StatsArmadura[Terrateniente.ArmaduraEquipada];
                                        Terrateniente.Armadura += ObjetosStats.StatsArmadura[elec] - TerratenienteAux;
                                        Terrateniente.ArmaduraEquipada = elec;
                                        break;
                                    case PieceType.Veterano:
                                        int VeteranoAux = ObjetosStats.StatsArmadura[Veterano.ArmaduraEquipada];
                                        Veterano.Armadura += ObjetosStats.StatsArmadura[elec] - VeteranoAux;
                                        Veterano.ArmaduraEquipada = elec;
                                        break;
                                }
                            }
                        }
                        else
                        {
                            var panel = new Panel($"[red]No posees armaduras disponibles para equipar[/]");
                            panel.Border = BoxBorder.Ascii;
                            panel.BorderColor(Color.Red);
                            AnsiConsole.Write(panel);
                        }
                    }
                    break;
                case AccinesDeTurno.VerCaracteristicasDeObjetos:
                    if (AccinesSinRealizarse.Confirm(eleccion) == 'y')
                    {
                        Objetos objeto = AnsiConsole.Prompt(new SelectionPrompt<Objetos>()
                        .Title("[DarkGoldenrod]Escoja un objeto que analizar[/] :")
                        .PageSize(12)
                        .HighlightStyle(new Style(foreground:Color.Red))
                        .AddChoices(GetInventario(GameState.CurrentPlayer)));
                        AnsiConsole.MarkupLineInterpolated($"[red]A seleccionado {objeto}[/]");
                        var panel = new Panel($"[orange1]{ObjetosStats.DescripcionObjetos[objeto]}[/]");
                        panel.Border = BoxBorder.None;
                        panel.BorderColor(Color.DarkGoldenrod);
                        AnsiConsole.Write(panel);
                    }
                    break;
            }
        }
    }


    public static List<Objetos> GetInventario(Player player)
    {
        switch (GSMPiece.PlayerPiece(player))
        {
            case PieceType.Artillero:
                return Artillero.Inventario;
            case PieceType.EsclavoLibre:
                return EsclavoLibre.Inventario;
            case PieceType.Explorador:
                return Explorador.Inventario;
            case PieceType.General:
                return General.Inventario;
            case PieceType.Holguinero:
                return Holguinero.Inventario;
            case PieceType.Intelectual:
                return Intelectual.Inventario;
            case PieceType.Internacionalista:
                return Internacionalista.Inventario;
            case PieceType.Jinete:
                return Jinete.Inventario;
            case PieceType.Soldado:
                return Artillero.Inventario;
            case PieceType.Titan:
                return Titan.Inventario;
            case PieceType.Terrateniente:
                return Terrateniente.Inventario;
            case PieceType.Veterano:
                return Veterano.Inventario;
            default:
                return Artillero.Inventario;
        }
    }
    public static void DiscartObject ()
    {
       if(AccinesSinRealizarse.Confirm(AccinesDeTurno.DescartarObjeto) == 'y')
       {
        var DiscartElection = AnsiConsole.Prompt(new SelectionPrompt<Objetos>()
        .Title("[yellow]   Inventario  [/]")
        .PageSize(12)
        .HighlightStyle(new Style(foreground:Spectre.Console.Color.Red))
        .AddChoices(GameState.PlayerPieceBasic(GameState.CurrentPlayer).Inventario));
        AnsiConsole.Write($"[red]Ha selecionado descartar {DiscartElection} [/]");
        GameState.PlayerPieceBasic(GameState.CurrentPlayer).WeightInventary -= ObjetosStats.StatsPeso[DiscartElection];
       } 
    }
}
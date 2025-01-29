namespace ProjectLogic;
using Spectre.Console;
using System.Timers;
public class Intelectual : PiecesBasic
{
  public override PieceType PieceType => PieceType.Intelectual;
  public override Player Number { get; }
  public Intelectual(Player number)
  {
    Number = number;
  }
  public static bool Correcto = false;
  public static void OnTimedEvent(object source, ElapsedEventArgs e)
  {
    Console.Clear();
    var panel = new Panel("[red]No ha respondido a tiempo[/]");
    panel.Border = BoxBorder.Ascii;
    panel.BorderColor(Color.Red);
    AnsiConsole.Write(panel);
    Console.ReadKey();
  }
  public static void StopTimer()
  {
    Correcto = true;
    GameState.timer.Enabled = false;
  }
  public static new List<Object> Inventary = new List<Object>();
  public static void Hability()
  {
    int countQuestion = 0;
    foreach (QuestionsName question in Question.QuestionsInGame)
    {
      countQuestion++;
    }
    Random random = new Random();
    int r = random.Next(0, countQuestion);
    GameState.timer.Elapsed += OnTimedEvent;
    GameState.timer.AutoReset = false;
    GameState.timer.Enabled = true;
    string selection = AnsiConsole.Prompt(new SelectionPrompt<string>()
    .Title($"[DarkGoldenrod]{Question.QuesionsTexts[Question.QuestionsInGame[r]]}[/]")
    .PageSize(6)
    .HighlightStyle(new Style(foreground: Spectre.Console.Color.Green))
    .AddChoices(Question.Elections[Question.QuestionsInGame[r]]));
    AnsiConsole.MarkupLineInterpolated($"A seleccionado [DarkGoldenrod]{selection}[/]");
    StopTimer();
    if (selection == Question.QuestionAnswer[Question.QuestionsInGame[r]] && Correcto)
      Correcto = true;
    else Correcto = false;
    var CorrectPanel = new Panel($"[green]Su respuesta es correcta elija que habilidad obtener[/]");
    var IncorrectPanel = new Panel($"[red]Su respuesta es incorrecta, la verdadera respuesta es[/][green] {Question.QuestionAnswer[Question.QuestionsInGame[r]]}[/]");
    CorrectPanel.Border = BoxBorder.Ascii;
    IncorrectPanel.Border = BoxBorder.Ascii;
    CorrectPanel.BorderColor(Color.Green);
    IncorrectPanel.BorderColor(Color.Red);
    if (Correcto) AnsiConsole.Write(CorrectPanel);
    else
    {
      int ActivationTurnIntelectual = GameState.Turn + Coldturns;
      GameState.SetHabilityTurn(GameState.CurrentPlayer, ActivationTurnIntelectual);
      AnsiConsole.Write(IncorrectPanel);
    }
    if (Correcto)
    {
      string HabilitySelection = AnsiConsole.Prompt(new SelectionPrompt<string>()
     .Title($"[DarkGoldenrod]Selecciona que habilidad desea poseer[/]")
     .PageSize(11)
     .HighlightStyle(new Style(foreground: Color.Green))
     .AddChoices(
       Artillero.HabilityName,
       EsclavoLibre.HabilityName,
       Explorador.HabilityName,
       General.HabilityName,
       Holguinero.HabilityName,
       Bolchevique.HabilityName,
       Jinete.HabilityName,
       Soldado.HabilityName,
       Titan.HabilityName,
       Hitman.HabilityName,
       Veterano.HabilityName
       ));
      AnsiConsole.MarkupLineInterpolated($"A seleccionado [DarkGoldenrod]{HabilitySelection}[/]");
      HabilityName = HabilitySelection;
      Question.QuestionsInGame.Remove(Question.QuestionsInGame[r]);
      countQuestion--;
    }
    if (countQuestion == 0)
    {
      var panel = new Panel("[red]No hay más prguntas disponibles se quedará con la última habilidad seleccionada[/]");
      panel.Border = BoxBorder.Ascii;
      panel.BorderColor(Color.Red);
      AnsiConsole.Write(panel);
      GameState.Trivial = false;
    }
  }
  public static void EnableHability()
  {
    foreach (PieceType piece in PiecesWhithHability)
    {
      switch (piece)
      {
        case PieceType.Bolchevique:
          if (Bolchevique.HabilityName == HabilityName) Bolchevique.EnableHability();
          break;
        case PieceType.Jinete:
          if (Jinete.HabilityName == HabilityName) Jinete.EnableHability();
          break;
        case PieceType.Titan:
          if (Titan.HabilityName == HabilityName) Titan.EnableHability();
          break;
      }

    }
  }
  public static new string HabilityName { get; set; }
  public static new int Coldturns = 2;
  public static new int Armor = 2;
  public static new int Force = 2;
  public static new int NumberOfMoves = 4;
  public static new int Visibility = 4;
  public static new Object EquipItem { get; set; }
  public static new Object EquipArmor { get; set; }

}

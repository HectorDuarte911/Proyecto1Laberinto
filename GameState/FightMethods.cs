using Spectre.Console;
namespace ProjectLogic;
public class FightMethods : ObjectMethods
{
    public static bool FightAction(bool flag, Position fightpostion, Position aux, bool fightflag)
    {
        Player enemyplayer = Player.None;
        if (fightflag) enemyplayer = GameState.PieceBoard[fightpostion].Number;
        bool flee = false;
        bool fight = false;
        string winner = "ninguno";
        while (!flee && winner == "ninguno")
        {
            TurnActions election = AnsiConsole.Prompt(new SelectionPrompt<TurnActions>()
            .Title("[red]Escoja que acción realizar:[/]")
            .PageSize(12)
            .HighlightStyle(new Style(foreground: Color.Red))
            .AddChoices(NoDoingActions.FightActions));
            AnsiConsole.MarkupLineInterpolated($"[DarkGoldenrod]A selectionado[/] {election}");
            int atacforce = GameState.GetForce(GameState.PieceBoard[GameState.PositionPiece(GameState.CurrentPlayer)], GameState.Board[GameState.PositionPiece(GameState.CurrentPlayer)]) - 2;
            int defArmorPlayer = 0;
            int defArmorEvent = 0;
            if (fightflag) defArmorPlayer = GameState.GetArmor(GameState.PieceBoard[GameState.PositionPiece(enemyplayer)], GameState.Board[GameState.PositionPiece(enemyplayer)]);
            else defArmorEvent = GameState.GetArmor(new None(), GameState.Board[fightpostion]);
            switch (election)
            {
                case TurnActions.atacar:
                    if (atacforce == defArmorPlayer + defArmorEvent) winner = "Empate";
                    else if (atacforce < defArmorPlayer + defArmorEvent) winner = $"{enemyplayer}";
                    else winner = $"{GameState.CurrentPlayer}";
                    break;
                case TurnActions.ObcionesEquipo:
                    GameState.EquipOptions(flag);
                    flag = true;
                    break;
                case TurnActions.ActivarHabilidad:
                    Explorador.Hability(GameState.PieceBoard[GameState.PositionPiece(enemyplayer)]);
                    int ActivationTurnExploeador = GameState.Turn + Explorador.Coldturns;
                    GameState.SetHabilityTurn(GameState.CurrentPlayer, ActivationTurnExploeador);
                    break;
                case TurnActions.abandonar:
                    flee = true;
                    break;
                case TurnActions.InfoJuego:
                    GameState.InfoGame();
                    break;
                case TurnActions.PlayerPieceView:
                    GameState.PlayerPieceView();
                    break;
            }
        }
        if (!flee)
        {
            var panel = new Panel("");
            if (winner == Player.None.ToString()) panel = new Panel($"[red]El ganador de la batalla es[/][yellow] {GameState.Board[fightpostion]}[/]");
            else panel = new Panel($"[red]El ganador de la batalla es[/][yellow] {winner}[/]");
            panel.Border = BoxBorder.Ascii;
            AnsiConsole.Write(panel);
            Player RestPlayer = Player.None;
            Player WinnerPlayer = Player.None;
            if (winner == $"{enemyplayer}")
            {
                RestPlayer = GameState.CurrentPlayer;
                WinnerPlayer = enemyplayer;
            }
            if (winner == $"{GameState.CurrentPlayer}" && fightflag)
            {
                WinnerPlayer = GameState.CurrentPlayer;
                RestPlayer = enemyplayer;
            }
            if (winner == $"{GameState.CurrentPlayer}" && !fightflag)
            {
                WinnerPlayer = GameState.CurrentPlayer;
                GameState.AjustObject(GameState.PlayerPieceBasic(WinnerPlayer).PieceType, GetEventReward(GameState.Board[fightpostion]));
                GameState.Board[fightpostion] = CellsType.None;
            }
            if (winner == "Empate")
            {
                RestPlayer = GameState.CurrentPlayer;
                WinnerPlayer = enemyplayer;
            }
            PiecesBasic RestPlayerAux = GameState.PlayerPieceBasic(RestPlayer);
            PiecesBasic WinnerPlayerAux = GameState.PlayerPieceBasic(WinnerPlayer);
            GameState.PieceBoard[GameState.PositionPiece(enemyplayer)] = WinnerPlayerAux;
            GameState.PieceBoard[aux] = RestPlayerAux;
            fight = true;
            if (GameState.PlayerPieceBasic(GameState.CurrentPlayer).PieceType != PieceType.Soldado || GameState.PlayerPieceBasic(RestPlayer).PieceType != PieceType.Soldado
            || !GameState.VariantActivation || !(GameState.PlayerPieceBasic(GameState.CurrentPlayer).PieceType == PieceType.Intelectual &&
            Intelectual.HabilityName == Soldado.HabilityName))
            {
                GameState.SetRestState(RestPlayer, true);
                GameState.SetRestTurn(RestPlayer, 3);
            }
            NoDoingActions.UndoingActions.Remove(TurnActions.Caminar);
            NoDoingActions.UndoingActions.Remove(TurnActions.RomperMuro);
            NoDoingActions.UndoingActions.Remove(TurnActions.DerribarObstaculos);
        }
        NoDoingActions.UndoingActions.Remove(TurnActions.Luchar);
        PiecesBasic.NumberOfMovesDoing = GameState.GetNumberOfMove(GameState.PlayerPieceBasic(GameState.CurrentPlayer));
        return fight;
    }
}

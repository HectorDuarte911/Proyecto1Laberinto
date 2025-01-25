namespace ProjectLogic;
public class PieceMethods:PositionMethods
{
    public static bool IsValidPick(PieceType Piece)
    {
        foreach (PieceType piece in PiecesBasic.Pieces)
        {
            if (Piece == piece) return true;
        }
        return false;
    }
    public static PiecesBasic PlayerPieceBasic(Player player)
    {
        return GameState.PieceBoard[GameState.PositionPiece(player)];
    }
    public static void PickPiece(PieceType election)
    {
        switch (election)
        {
            case PieceType.Artillero:
                PieceBoard.StartPiecePositions(new Artillero(GameState.CurrentPlayer), GameState.CurrentPlayer);
                Artillero.EquipItem = Object.Granadas;
                Artillero.EquipArmor = Object.CasacaAzul;
                Artillero.Inventary.Add(Object.Granadas);
                Artillero.Inventary.Add(Object.CasacaAzul);
                Artillero.Force += ObjectsStats.StatsForce[Object.Granadas];
                Artillero.Armor += ObjectsStats.StatsArmor[Object.CasacaAzul];
                GameState.PiecesInGame.Add(PieceType.Artillero);
                PiecesBasic.Pieces.Remove(PieceType.Artillero);
                break;
            case PieceType.EsclavoLibre:
                PieceBoard.StartPiecePositions(new EsclavoLibre(GameState.CurrentPlayer), GameState.CurrentPlayer);
                EsclavoLibre.EquipItem = Object.MacheteSinFilo;                
                EsclavoLibre.EquipArmor = Object.none;
                EsclavoLibre.Inventary.Add(Object.MacheteSinFilo);
                EsclavoLibre.Force += ObjectsStats.StatsForce[Object.MacheteSinFilo];
                GameState.PiecesInGame.Add(PieceType.EsclavoLibre);
                PiecesBasic.Pieces.Remove(PieceType.EsclavoLibre);
                break;
            case PieceType.Explorador:
                PieceBoard.StartPiecePositions(new Explorador(GameState.CurrentPlayer), GameState.CurrentPlayer);
                Explorador.EquipItem = Object.MacheteCorto;
                Explorador.EquipArmor = Object.RopaGastada;
                Explorador.Inventary.Add(Object.MacheteCorto);
                Explorador.Inventary.Add(Object.RopaGastada);
                Explorador.Force += ObjectsStats.StatsForce[Object.MacheteCorto];
                Explorador.Armor += ObjectsStats.StatsArmor[Object.RopaGastada];
                GameState.PiecesInGame.Add(PieceType.Explorador);
                PiecesBasic.Pieces.Remove(PieceType.Explorador);
                break;
            case PieceType.General:
                PieceBoard.StartPiecePositions(new General(GameState.CurrentPlayer), GameState.CurrentPlayer);
                General.EquipItem = Object.Revolver;
                General.EquipArmor = Object.CasacaAzulCondecorada;
                General.Inventary.Add(Object.Revolver);
                General.Inventary.Add(Object.CasacaAzulCondecorada);
                General.Force += ObjectsStats.StatsForce[Object.Revolver];
                General.Armor += ObjectsStats.StatsArmor[Object.CasacaAzulCondecorada];
                GameState.PiecesInGame.Add(PieceType.General);
                PiecesBasic.Pieces.Remove(PieceType.General);
                break;
            case PieceType.Hitman:
                PieceBoard.StartPiecePositions(new Hitman(GameState.CurrentPlayer), GameState.CurrentPlayer);
                Hitman.EquipItem = Object.Colt1911;
                Hitman.EquipArmor = Object.GabardinaNegra;
                Hitman.Inventary.Add(Object.Colt1911);
                Hitman.Inventary.Add(Object.GabardinaNegra);
                Hitman.Force += ObjectsStats.StatsForce[Object.Colt1911];
                Hitman.Armor += ObjectsStats.StatsArmor[Object.GabardinaNegra];
                GameState.PiecesInGame.Add(PieceType.Hitman);
                PiecesBasic.Pieces.Remove(PieceType.Hitman);
                break;
            case PieceType.Holguinero:
                PieceBoard.StartPiecePositions(new Holguinero(GameState.CurrentPlayer), GameState.CurrentPlayer);
                Holguinero.EquipItem = Object.MacheteCorto;
                Holguinero.EquipArmor = Object.RopaGastada;
                Holguinero.Inventary.Add(Object.MacheteCorto);
                Holguinero.Inventary.Add(Object.RopaGastada);
                Holguinero.Force += ObjectsStats.StatsForce[Object.MacheteCorto];
                Holguinero.Armor += ObjectsStats.StatsArmor[Object.RopaGastada];
                GameState.PiecesInGame.Add(PieceType.Holguinero);
                PiecesBasic.Pieces.Remove(PieceType.Holguinero);
                break;
            case PieceType.Intelectual:
                PieceBoard.StartPiecePositions(new Intelectual(GameState.CurrentPlayer), GameState.CurrentPlayer);
                Intelectual.EquipItem = Object.Revolver;
                Intelectual.EquipArmor = Object.TrajeNegro;
                Intelectual.Inventary.Add(Object.Revolver);
                Intelectual.Inventary.Add(Object.TrajeNegro);
                Intelectual.HabilityName = "Trivia";
                Artillero.Force += ObjectsStats.StatsForce[Object.Revolver];
                Artillero.Armor += ObjectsStats.StatsArmor[Object.TrajeNegro];
                GameState.PiecesInGame.Add(PieceType.Intelectual);
                PiecesBasic.Pieces.Remove(PieceType.Intelectual);
                break;
            case PieceType.Internacionalista:
                PieceBoard.StartPiecePositions(new Internacionalista(GameState.CurrentPlayer), GameState.CurrentPlayer);
                Internacionalista.EquipItem = Object.Fusiles;
                Internacionalista.EquipArmor = Object.CamisaBlanca;
                Internacionalista.Inventary.Add(Object.Fusiles);
                Internacionalista.Inventary.Add(Object.CamisaBlanca);
                Internacionalista.Force += ObjectsStats.StatsForce[Object.Fusiles];
                Internacionalista.Armor += ObjectsStats.StatsArmor[Object.CamisaBlanca];
                GameState.PiecesInGame.Add(PieceType.Internacionalista);
                PiecesBasic.Pieces.Remove(PieceType.Internacionalista);
                break;
            case PieceType.Jinete:
                PieceBoard.StartPiecePositions(new Jinete(GameState.CurrentPlayer), GameState.CurrentPlayer);
                Jinete.EquipItem = Object.MacheteLargo;
                Jinete.EquipArmor = Object.RopaGastada;
                Jinete.Inventary.Add(Object.MacheteLargo);
                Jinete.Inventary.Add(Object.RopaGastada);
                Jinete.Force += ObjectsStats.StatsForce[Object.MacheteLargo];
                Jinete.Armor += ObjectsStats.StatsArmor[Object.RopaGastada];
                GameState.PiecesInGame.Add(PieceType.Jinete);
                PiecesBasic.Pieces.Remove(PieceType.Jinete);
                break;
            case PieceType.Soldado:
                PieceBoard.StartPiecePositions(new Soldado(GameState.CurrentPlayer), GameState.CurrentPlayer);
                Soldado.EquipItem = Object.Fusiles;
                Soldado.EquipArmor = Object.CasacaAzul;
                Soldado.Inventary.Add(Object.Fusiles);
                Soldado.Inventary.Add(Object.CasacaAzul);
                Soldado.Force += ObjectsStats.StatsForce[Object.Fusiles];
                Soldado.Armor += ObjectsStats.StatsArmor[Object.CasacaAzul];
                GameState.PiecesInGame.Add(PieceType.Soldado);
                PiecesBasic.Pieces.Remove(PieceType.Soldado);
                break;
            case PieceType.Titan:
                PieceBoard.StartPiecePositions(new Titan(GameState.CurrentPlayer), GameState.CurrentPlayer);
                Titan.EquipItem = Object.MacheteCurvo;
                Titan.EquipArmor = Object.CamisaBlanca;
                Titan.Inventary.Add(Object.MacheteCurvo);
                Titan.Inventary.Add(Object.CamisaBlanca);
                Titan.Force += ObjectsStats.StatsForce[Object.MacheteCurvo];
                Titan.Armor += ObjectsStats.StatsArmor[Object.CamisaBlanca];
                GameState.PiecesInGame.Add(PieceType.Titan);
                PiecesBasic.Pieces.Remove(PieceType.Titan);
                break;
            case PieceType.Veterano:
                PieceBoard.StartPiecePositions(new Veterano(GameState.CurrentPlayer), GameState.CurrentPlayer);
                Veterano.EquipItem = Object.MacheteCorto;
                Veterano.EquipArmor = Object.CamisaBlanca;
                Veterano.Inventary.Add(Object.MacheteCorto);
                Veterano.Inventary.Add(Object.CamisaBlanca);
                Veterano.Force += ObjectsStats.StatsForce[Object.MacheteCorto];
                Veterano.Armor += ObjectsStats.StatsArmor[Object.CamisaBlanca];
                GameState.PiecesInGame.Add(PieceType.Veterano);
                PiecesBasic.Pieces.Remove(PieceType.Veterano);
                break;
        }
        GameState.CurrentPlayer = GameState.NextPlayer(GameState.CurrentPlayer);
    }
}

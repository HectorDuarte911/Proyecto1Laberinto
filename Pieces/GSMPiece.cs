namespace ProjectLogic;
public class GSMPiece : GSMBool
{
    public static bool IsValidPick(PieceType Piece)
    {
        foreach (PieceType piece in PieceList.Pieces)
        {
            if (Piece == piece) return true;
        }
        return false;
    }
    public static PieceType PlayerPiece(Player player)
    {
        return GameState.PieceBoard[GSMPosition.PosicionPieza(player)].PieceType;
    }
    public static PiecesBasic PlayerPieceBasic(Player player)
    {
        return GameState.PieceBoard[GSMPosition.PosicionPieza(player)];
    }
    public static void PonerTipoJugador(Player player, PieceType pieceType)
    {
        switch(player)
        {
            case Player.PrimerJugador:
            PrimerJugador.Piece=pieceType;
            break;
            case Player.SegundoJugador:
            SegundoJugador.Piece=pieceType;
            break;
            case Player.TercerJugador:
            TercerJugador.Piece=pieceType;
            break;
            case Player.CuartoJugador:
            CuartoJugador.Piece=pieceType;
            break;
        }
    }
    public static void PickPiece(PieceType eleccion)
    {
             switch (eleccion)
                {
                    case PieceType.Artillero:
                        PieceBoard.StartPiecePositions(new Artillero(GameState.CurrentPlayer),GameState.CurrentPlayer);
                        Artillero.ArmaEquipada = Objetos.Granadas;
                        Artillero.ArmaduraEquipada = Objetos.CasacaAzul;
                        Artillero.Fuerza += ObjetosStats.StatsFuerza[Objetos.Granadas];
                        Artillero.Armadura += ObjetosStats.StatsArmadura[Objetos.CasacaAzul];
                        GameState.PiezasEnJuego.Add(PieceType.Artillero);
                        PieceList.Pieces.Remove(PieceType.Artillero);
                        break;
                    case PieceType.EsclavoLibre:
                        PieceBoard.StartPiecePositions(new EsclavoLibre(GameState.CurrentPlayer),GameState.CurrentPlayer);
                        EsclavoLibre.ArmaEquipada = Objetos.MacheteSinFilo;
                        EsclavoLibre.ArmaduraEquipada = Objetos.none;
                        EsclavoLibre.Fuerza += ObjetosStats.StatsFuerza[Objetos.MacheteSinFilo];
                        GameState.PiezasEnJuego.Add(PieceType.EsclavoLibre);
                        PieceList.Pieces.Remove(PieceType.EsclavoLibre);
                        break;
                    case PieceType.Explorador:
                        PieceBoard.StartPiecePositions(new Explorador(GameState.CurrentPlayer),GameState.CurrentPlayer);
                        Explorador.ArmaEquipada = Objetos.MacheteCorto;
                        Explorador.ArmaduraEquipada = Objetos.RopaGastada;
                        Explorador.Fuerza += ObjetosStats.StatsFuerza[Objetos.MacheteCorto];
                        Explorador.Armadura += ObjetosStats.StatsArmadura[Objetos.RopaGastada];
                        GameState.PiezasEnJuego.Add(PieceType.Explorador);
                        PieceList.Pieces.Remove(PieceType.Explorador);
                        break;
                    case PieceType.General:
                        PieceBoard.StartPiecePositions(new General(GameState.CurrentPlayer),GameState.CurrentPlayer);
                        General.ArmaEquipada = Objetos.Revolver;
                        General.ArmaduraEquipada = Objetos.CasacaAzulCondecorada;
                        General.Fuerza += ObjetosStats.StatsFuerza[Objetos.Revolver];
                        General.Armadura += ObjetosStats.StatsArmadura[Objetos.CasacaAzulCondecorada];
                        GameState.PiezasEnJuego.Add(PieceType.General);
                        PieceList.Pieces.Remove(PieceType.General);
                        break;
                    case PieceType.Holguinero:
                        PieceBoard.StartPiecePositions(new Holguinero(GameState.CurrentPlayer),GameState.CurrentPlayer);
                        Holguinero.ArmaEquipada = Objetos.MacheteCorto;
                        Holguinero.ArmaduraEquipada = Objetos.RopaGastada;
                        Holguinero.Fuerza += ObjetosStats.StatsFuerza[Objetos.MacheteCorto];
                        Holguinero.Armadura += ObjetosStats.StatsArmadura[Objetos.RopaGastada];
                        GameState.PiezasEnJuego.Add(PieceType.Holguinero);
                        PieceList.Pieces.Remove(PieceType.Holguinero);
                        break;
                    case PieceType.Intelectual:
                        PieceBoard.StartPiecePositions(new Intelectual(GameState.CurrentPlayer),GameState.CurrentPlayer);
                        Intelectual.ArmaEquipada = Objetos.Revolver;
                        Intelectual.ArmaduraEquipada = Objetos.TrajeNegro;
                        Intelectual.NombreHabilidad = "Trivia";
                        Artillero.Fuerza += ObjetosStats.StatsFuerza[Objetos.Revolver];
                        Artillero.Armadura += ObjetosStats.StatsArmadura[Objetos.TrajeNegro];
                        GameState.PiezasEnJuego.Add(PieceType.Intelectual);
                        PieceList.Pieces.Remove(PieceType.Intelectual);
                        break;
                    case PieceType.Internacionalista:
                        PieceBoard.StartPiecePositions(new Internacionalista(GameState.CurrentPlayer),GameState.CurrentPlayer);
                        Internacionalista.ArmaEquipada = Objetos.Fusiles;
                        Internacionalista.ArmaduraEquipada = Objetos.CamisaBlanca;
                        Internacionalista.Fuerza += ObjetosStats.StatsFuerza[Objetos.Fusiles];
                        Internacionalista.Armadura += ObjetosStats.StatsArmadura[Objetos.CamisaBlanca];
                        GameState.PiezasEnJuego.Add(PieceType.Internacionalista);
                        PieceList.Pieces.Remove(PieceType.Internacionalista);
                        break;
                    case PieceType.Jinete:
                        PieceBoard.StartPiecePositions(new Jinete(GameState.CurrentPlayer),GameState.CurrentPlayer);
                        Jinete.ArmaEquipada = Objetos.MacheteLargo;
                        Jinete.ArmaduraEquipada = Objetos.RopaGastada;
                        Jinete.Fuerza += ObjetosStats.StatsFuerza[Objetos.MacheteLargo];
                        Jinete.Armadura += ObjetosStats.StatsArmadura[Objetos.RopaGastada];
                        GameState.PiezasEnJuego.Add(PieceType.Jinete);
                        PieceList.Pieces.Remove(PieceType.Jinete);
                        break;
                    case PieceType.Soldado:
                        PieceBoard.StartPiecePositions(new Soldado(GameState.CurrentPlayer),GameState.CurrentPlayer);
                        Soldado.ArmaEquipada = Objetos.Fusiles;
                        Soldado.ArmaduraEquipada = Objetos.CasacaAzul;
                        Soldado.Fuerza += ObjetosStats.StatsFuerza[Objetos.Fusiles];
                        Soldado.Armadura += ObjetosStats.StatsArmadura[Objetos.CasacaAzul];
                        GameState.PiezasEnJuego.Add(PieceType.Soldado);
                        PieceList.Pieces.Remove(PieceType.Soldado);
                        break;
                    case PieceType.Terrateniente:
                        PieceBoard.StartPiecePositions(new Terrateniente(GameState.CurrentPlayer),GameState.CurrentPlayer);
                        Terrateniente.ArmaEquipada = Objetos.Revolver;
                        Terrateniente.ArmaduraEquipada = Objetos.CamisaBlanca;
                        Terrateniente.Fuerza += ObjetosStats.StatsFuerza[Objetos.Revolver];
                        Terrateniente.Armadura += ObjetosStats.StatsArmadura[Objetos.CamisaBlanca];
                        GameState.PiezasEnJuego.Add(PieceType.Terrateniente);
                        PieceList.Pieces.Remove(PieceType.Terrateniente);
                        break;
                    case PieceType.Titan:
                        PieceBoard.StartPiecePositions(new Titan(GameState.CurrentPlayer),GameState.CurrentPlayer);
                        Titan.ArmaEquipada = Objetos.MacheteCurvo;
                        Titan.ArmaduraEquipada = Objetos.CamisaBlanca;
                        Titan.Fuerza += ObjetosStats.StatsFuerza[Objetos.MacheteCurvo];
                        Titan.Armadura += ObjetosStats.StatsArmadura[Objetos.CamisaBlanca];
                        GameState.PiezasEnJuego.Add(PieceType.Titan);
                        PieceList.Pieces.Remove(PieceType.Titan);
                        break;
                    case PieceType.Veterano:
                        PieceBoard.StartPiecePositions(new Veterano(GameState.CurrentPlayer),GameState.CurrentPlayer);
                        Veterano.ArmaEquipada = Objetos.MacheteCorto;
                        Veterano.ArmaduraEquipada = Objetos.CamisaBlanca;
                        Veterano.Fuerza += ObjetosStats.StatsFuerza[Objetos.MacheteCorto];
                        Veterano.Armadura += ObjetosStats.StatsArmadura[Objetos.CamisaBlanca];
                        GameState.PiezasEnJuego.Add(PieceType.Veterano);
                        PieceList.Pieces.Remove(PieceType.Veterano);
                        break;
                }
                PonerTipoJugador(GameState.CurrentPlayer,eleccion);
                GameState.CurrentPlayer = GSMPlayer.NextPlayer(GameState.CurrentPlayer);
            }
        }

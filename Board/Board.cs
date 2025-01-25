﻿using SixLabors.ImageSharp;

namespace ProjectLogic;
public class Board
{
    public static CellsType[,] Laberinth = new CellsType[GameState.dim, GameState.dim];
    public CellsType this[int row, int col]
    {
        get { return Laberinth[row, col]; }
        set { Laberinth[row, col] = value; }
    }
    public CellsType this[Position pos]
    {
        get { return this[pos.Row, pos.Column]; }
        set { this[pos.Row, pos.Column] = value; }
    }
    public static bool IsInside(Position pos)
    {
        return pos.Row >= 0 && pos.Row < GameState.dim && pos.Column >= 0 && pos.Column < GameState.dim;
    }
    public static bool IsATrap(CellsType Cells)
    {
        return Cells == CellsType.TrampaMosquitera || Cells == CellsType.HoyoProfundo || Cells == CellsType.PasilloAgotante
             || Cells == CellsType.RanaSorpresa;
    }
    public static CellsType[,] VisualPiece(Position pos, CellsType[,] Board)
    {
        CellsType[,] VisualLab = new CellsType[GameState.dim, GameState.dim];
        for (int i = 0; i < GameState.dim; i++)
        {
            for (int j = 0; j < GameState.dim; j++)
            {
                if (ISVisible(pos, new Position(i, j), Board, GameState.GetVisibility(GameState.PlayerPieceBasic(GameState.CurrentPlayer)) - 1))
                {
                    VisualLab[i, j] = Board[i, j];
                }
                else VisualLab[i, j] = CellsType.NoVisible;
            }
        }
        return VisualLab;
    }
    public static bool ISVisible(Position pos, Position to, CellsType[,] Board, int numberVis)
    {
        return IsVisualNoWall(pos, to, numberVis) || IsVisualWall(pos, to, numberVis);
    }
    public static bool IsVisualNoWall(Position piecepos, Position Topos, int numberVis)
    {
        if (GameState.Board[Topos] != CellsType.Wall)
        {
            bool[,] visitated = new bool[GameState.dim, GameState.dim];
            return IsReachable(GameState.Board, piecepos, Topos, numberVis, visitated);
        }
        return false;
    }
    public static bool IsVisualWall(Position piecepos, Position Topos, int numberVis)
    {
        List<Direction> dirs = new List<Direction>()
    {
    Direction.Up,
    Direction.Down,
    Direction.Right,
    Direction.Left,
    Direction.UpRight,
    Direction.DownLeft,
    Direction.DownRight,
    Direction.UpLeft,
    };
        foreach (Direction dir in dirs)
        {
            Position adyancent = Topos + dir;
            if (IsInside(adyancent))
            {
                if (IsVisualNoWall(piecepos, adyancent, numberVis)) return true;
            }
        }
        return false;
    }
    public static bool IsReachable(Board board, Position from, Position to, int remeingmove, bool[,] visitated)
    {
        if (from.Row == to.Row && from.Column == to.Column) return true;
        if (remeingmove == 0) return false;
        visitated[from.Row, from.Column] = true;
        foreach (Direction dir in Move.dirs)
        {
            Position newPos = from + dir;
            if (IsInside(newPos) && board[newPos] != CellsType.Wall && !visitated[newPos.Row, newPos.Column])
            {
                if (IsReachable(GameState.Board, newPos, to, remeingmove - 1, visitated)) return true;
            }
        }
        visitated[from.Row, from.Column] = false;
        return false;
    }
}







using System;
using System.Collections.Generic;

namespace Miltochess
{

    public class ChessBoard : ChessUnitListener
    {
        public Matrix boardMatrix;
        public List<ChessUnit> units = new List<ChessUnit>();

        public static ChessBoard InitBoard(int x, int y)
        {
            var board = new ChessBoard();
            board.boardMatrix = Matrix.ZeroMatrix(x, y);

            return board;
        }

        public void PutUnit(ChessUnit unit, int x, int y)
        {
            units.Add(unit);
            unit.addListener(this);

            boardMatrix[x, y] = unit.id;
        }

        public ChessUnit GetUnitOn(int x, int y)
        {
            foreach (var unit in units)
            {
                if (unit.x == x && unit.y == y)
                {
                    return unit;
                }
            }

            return null;
        }

        public Matrix GetCurrentMatrix()
        {
            return this.boardMatrix;
        }

        public void IssueMoveUnit(ChessUnit unit, int x, int y)
        {
            unit.StartMove(x,y);
        }

        public void OnUnitRemove(ChessUnit unit)
        {
            boardMatrix[unit.x, unit.y] = 0;
            units.Remove(unit);
        }

        public void OnUnitMoveStart(ChessUnit unit)
        {
            boardMatrix[unit.x, unit.y] = 0;
        }

        public void OnUnitMoveEnd(ChessUnit unit)
        {
            boardMatrix[unit.x, unit.y] = unit.id;
        }

        public void WillAttachModifier(ChessUnit unit, Modifier modifier)
        {
        }

        public void DidAttachModifier(ChessUnit unit, Modifier modifier)
        {
        }
    }
}
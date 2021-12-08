using System;
using System.Collections.Generic;

namespace Miltochess {

    public class ChessBoard
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
            boardMatrix[x,y] = unit.id;
        }

        public ChessUnit GetUnitOn(int x, int y)
        {
            foreach(var unit in units) {
                if (unit.x == x && unit.y == y) {
                    return unit;
                }
            }

            return null;
        }

        public Matrix GetCurrentMatrix()
        {
            return this.boardMatrix;
        }
    }
}
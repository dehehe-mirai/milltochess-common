using System;

namespace Miltochess {

    public class ChessBoard
    {
        public Matrix boardMatrix;

        public static ChessBoard InitBoard(int x, int y)
        {
            var board = new ChessBoard();
            board.boardMatrix = Matrix.ZeroMatrix(x, y);
            
            return board;
        }

        public Matrix GetCurrentMatrix()
        {
            return this.boardMatrix;
        }
    }
}
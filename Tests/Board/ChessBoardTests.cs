using Miltochess;
using NUnit.Framework;

namespace Tests
{
    public class ChessBoardTests
    {
        [Test]
        public void PutUnitOnBoard()
        {
            ChessBoard board = ChessBoard.InitBoard(10, 10);
            ChessUnit unit = new ChessUnit();

            board.PutUnit(unit, 0, 0);

            Assert.AreEqual(unit, board.GetUnitOn(0, 0));
        }
        
    }
}
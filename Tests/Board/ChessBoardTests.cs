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
            unit.id = 1;

            board.PutUnit(unit, 0, 0);

            Assert.AreEqual(unit, board.GetUnitOn(0, 0));
            Assert.AreEqual(1, board.GetCurrentMatrix()[0,0]);

            unit.Remove();

            Assert.AreEqual(null, board.GetUnitOn(0, 0));
            Assert.AreEqual(0, board.GetCurrentMatrix()[0,0]);
        }
        
    }
}
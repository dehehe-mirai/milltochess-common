using Miltochess;
using Moq;
using NUnit.Framework;

namespace Tests
{
    public class ChessBoardTests
    {
        [Test]
        public void PutUnitOnBoardAndRemove()
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
        
        [Test]
        public void MoveUnitOnBoard()
        {
            ChessBoard board = ChessBoard.InitBoard(10, 10);
            ChessUnit unit = new ChessUnit();
            var listener = new Mock<ChessUnitListener>();
            unit.addListener(listener.Object);

            unit.id = 1;

            board.PutUnit(unit, 0, 0);

            board.IssueMoveUnit(unit, 0, 1);
            listener.Verify(x=>x.OnUnitMoveStart(unit), Times.Once());
            listener.Verify(x=>x.OnUnitMoveEnd(unit), Times.Once());

            Assert.AreEqual(0, unit.x);
            Assert.AreEqual(1, unit.y);
            
            Assert.AreEqual(0, board.GetCurrentMatrix()[0,0]);
            Assert.AreEqual(1, board.GetCurrentMatrix()[0,1]);
        }
    }
}
using Miltochess;
using Moq;
using NUnit.Framework;

namespace Tests
{
    public class ChessUnitTests
    {
        [Test]
        public void OnUnitRemove()
        {
            ChessUnit unit = new ChessUnit();
            var chessUnitListener = new Mock<ChessUnitListener>();
            unit.addListener(chessUnitListener.Object);

            unit.Remove();
            chessUnitListener.Verify(x=>x.OnUnitRemove(unit), Times.Once);
        }
        [Test]
        public void UnitHaveBaseStatAndCurrentStat()
        {
            ChessUnit unit = ChessUnit.BaseUnit();
            Assert.NotNull(unit.GetBaseStat());
            Assert.NotNull(unit.GetCurrentStat());
        }
    }
}
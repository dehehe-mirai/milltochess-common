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
        
        [Test]
        public void CanAddModifier(){
            ChessUnit unit = ChessUnit.BaseUnit();
            var listener = new Mock<ChessUnitListener>();
            unit.addListener(listener.Object);
            var modifier = Modifiers.StatModifier("atk", "*1.1");

            unit.AddModifier(modifier);
            listener.Verify(x=>x.WillAttachModifier(unit, modifier), Times.Once);
            listener.Verify(x=>x.DidAttachModifier(unit, modifier), Times.Once);
            //Assert.AreEqual(11, unit.ATK);
        }
    }
}
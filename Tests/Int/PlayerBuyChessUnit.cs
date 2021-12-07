using Miltochess;
using Moq;
using NUnit.Framework;

namespace Tests
{
    public class PlayerBuyChessUnit
    {
        [Test]
        public void PlayerTryToBuyUnitButLessMoney()
        {
            ChessPlayer player = new ChessPlayer();
            player.Money = 0;

            ChessShop shop = new ChessShop();
            var shopListener = new Mock<ChessShopListener>();
            //mockCarService.Setup(x => x.Get(It.IsAny<int>())).Returns(car);
            shop.AddShopListener(shopListener.Object);

            bool isBought = shop.Buy(player, 0);
            
            shopListener.Verify(x=>x.OnBuyUnit(It.IsAny<ChessPlayer>(), It.IsAny<ChessUnit>()), Times.Never);
            Assert.False(isBought);
            Assert.Zero(player.CountInventoryUnits());
        }
        
        [Test]
        public void PlayerTryToBuyUnitWithEnoughMoney()
        {
            ChessPlayer player = new ChessPlayer();
            player.Money = 1;

            ChessShop shop = new ChessShop();
            var shopListener = new Mock<ChessShopListener>();
            //mockCarService.Setup(x => x.Get(It.IsAny<int>())).Returns(car);
            shop.AddShopListener(shopListener.Object);

            ChessUnit unit = new ChessUnit();
            unit.SetPrice(1);

            shop.AddSellingUnit(unit);
            Assert.AreEqual(1, shop.GetSellingUnitCount());

            bool isBought = shop.Buy(player, 0);
            
            shopListener.Verify(x=>x.OnBuyUnit(It.IsAny<ChessPlayer>(), It.IsAny<ChessUnit>()), Times.Once);
            Assert.True(isBought);
            Assert.True(player.HaveUnitInInventory(unit));
            Assert.AreEqual(0, shop.GetSellingUnitCount());
        }
    }
}
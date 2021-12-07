using System.Collections.Generic;
using Miltochess;
using Moq;
using NUnit.Framework;

namespace Tests
{
    public class ShopTests
    {
        [Test]
        public void SetShopByPlayerLevelAndChessUnits()
        {
            ChessShop shop = new ChessShop();
            int playerLevel = 1;
            // Owned by GameManager
            Dictionary<string, ChessUnit> unitPool = new Dictionary<string, ChessUnit>();
            shop.SetSellingUnit(playerLevel, unitPool);
        }
    }
}
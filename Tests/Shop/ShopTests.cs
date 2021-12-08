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
            var unitPool = new Dictionary<string, List<ChessUnit>>();
            unitPool["common"] = new List<ChessUnit>();
            
            var unit1 = new ChessUnit();
            var unit2 = new ChessUnit();
            var unit3 = new ChessUnit();
            var unit4 = new ChessUnit();
            var unit5 = new ChessUnit();
            unitPool["common"].Add(unit1);
            unitPool["common"].Add(unit2);
            unitPool["common"].Add(unit3);
            unitPool["common"].Add(unit4);
            unitPool["common"].Add(unit5);

            var levelPool = new Dictionary<int, Dictionary<string, double>>();
            levelPool[1] = new Dictionary<string, double>();
            levelPool[1]["common"] = 1.0;

            shop.SetLevelPool(levelPool);
            shop.SetSellingUnit(playerLevel, unitPool);

            Assert.AreEqual(5, shop.GetSellingUnitCount());
            Assert.AreEqual(0, unitPool["common"].Count);
        }
    }
}
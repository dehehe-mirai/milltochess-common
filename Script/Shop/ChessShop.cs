using System;
using System.Collections.Generic;

namespace Miltochess
{
    public class ChessShop
    {
        List<ChessShopListener> listeners = new List<ChessShopListener>();
        List<ChessUnit> sellingUnits = new List<ChessUnit>();
        private Dictionary<int, Dictionary<string, double>> levelPool;

        public bool Buy(ChessPlayer player, int i)
        {
            if (sellingUnits.Count == 0) return false;
            if (player.Money < sellingUnits[i].price)
            {
                return false;
            }
            else
            {
                player.Money -= sellingUnits[i].price;
                player.SuccessBuyUnit(sellingUnits[i]);

                foreach (var listener in listeners)
                {
                    listener.OnBuyUnit(player, sellingUnits[i]);
                }

                sellingUnits.RemoveAt(i);
                return true;
            }
        }

        public void SetLevelPool(Dictionary<int, Dictionary<string, double>> levelPool)
        {
            this.levelPool = levelPool;
        }

        public void SetSellingUnit(int playerLevel, Dictionary<string, List<ChessUnit>> unitPool)
        {
            var probForRarity = this.levelPool[playerLevel];
            double random = 0;

            for (int i = 0; i < 5; i++) {
                var choosenRarity = "";
                double offset = 0;
                // Choose Rarity
                // --------------------------(0.8<0.9)
                // |--common(0.7)---(rare)0.2---(sr)0.1---|
                foreach (var rarity in probForRarity.Keys) {
                    if (random + offset <= probForRarity[rarity]) {
                        choosenRarity = rarity;
                        offset = 0;
                        break;
                    } else {
                        offset += probForRarity[rarity];
                    }
                }
                
                // Choose Unit
                var unitList = unitPool[choosenRarity];
                var randomIndex = 0;

                var unit = unitList[randomIndex];

                unitList.Remove(unit);
                sellingUnits.Add(unit);
            }
        }

        public void AddShopListener(ChessShopListener shopListener)
        {
            listeners.Add(shopListener);
        }

        public double GetSellingUnitCount()
        {
            return sellingUnits.Count;
        }

        public void AddSellingUnit(ChessUnit unit)
        {
            sellingUnits.Add(unit);
        }
    }

}
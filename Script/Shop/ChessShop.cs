using System;
using System.Collections.Generic;

namespace Miltochess
{
    public class ChessShop
    {
        List<ChessShopListener> listeners = new List<ChessShopListener>();
        List<ChessUnit> sellingUnits = new List<ChessUnit>();
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

        public void SetSellingUnit(int playerLevel, Dictionary<string, ChessUnit> unitPool)
        {
            throw new NotImplementedException();
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
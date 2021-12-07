using System;
using System.Collections.Generic;

namespace Miltochess{
    public class ChessPlayer
    {
        List<ChessUnit> unitInInventory = new List<ChessUnit>();
        int money = 0;

        public int Money { get => money; set => money = value; }

        public int CountInventoryUnits()
        {
            return unitInInventory.Count;
        }

        public bool HaveUnitInInventory(ChessUnit unit)
        {
            return unitInInventory.Contains(unit);
        }

        public void SuccessBuyUnit(ChessUnit unit)
        {
            unitInInventory.Add(unit);
        }
    }
}
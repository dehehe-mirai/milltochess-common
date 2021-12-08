
using System;
using System.Collections.Generic;

namespace Miltochess
{
    public class ChessUnit
    {
        public int price = 0;
        public int isAnimating;
        internal int x;
        internal int y;
        public double id;

        HashSet<ChessUnitListener> listeners = new HashSet<ChessUnitListener>();

        public void SetPrice(int value) {
            this.price = value;
        }

        public void Remove()
        {
            foreach (ChessUnitListener listener in listeners) {
                listener.OnUnitRemove(this);
            }
        }

        public void addListener(ChessUnitListener chessUnitListener)
        {
            listeners.Add(chessUnitListener);
        }
    }
}
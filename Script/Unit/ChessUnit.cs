
using System;
using System.Collections.Generic;

namespace Miltochess
{
    public class ChessUnit
    {
        public int price = 0;
        public bool isAnimating;

        public int x;
        public int y;
        public double id;

        HashSet<ChessUnitListener> listeners = new HashSet<ChessUnitListener>();
        private ChessUnitStat baseStat;
        private ChessUnitStat currentStat;
        private List<Modifier> modifiers = new List<Modifier>();

        #region Stats
        public int HP
        {
            get
            {
                return currentStat.hp;
            }
        }

        public int ATK
        {
            get
            {
                return currentStat.atk;
            }
        }
        #endregion
        public void SetPrice(int value)
        {
            this.price = value;
        }

        public void Remove()
        {
            foreach (ChessUnitListener listener in listeners)
            {
                listener.OnUnitRemove(this);
            }
        }

        public void addListener(ChessUnitListener chessUnitListener)
        {
            listeners.Add(chessUnitListener);
        }

        public void StartMove(int x, int y)
        {
            foreach (ChessUnitListener listener in listeners)
            {
                listener.OnUnitMoveStart(this);
            }

            this.x = x;
            this.y = y;

            foreach (ChessUnitListener listener in listeners)
            {
                listener.OnUnitMoveEnd(this);
            }
        }

        public void AddModifier(Modifier modifier)
        {
            foreach (ChessUnitListener listener in listeners)
            {
                listener.WillAttachModifier(this, modifier);
            }
            modifiers.Add(modifier);
            foreach (ChessUnitListener listener in listeners)
            {
                listener.DidAttachModifier(this, modifier);
            }
        }

        public static ChessUnit BaseUnit()
        {
            ChessUnit unit = new ChessUnit();
            unit.baseStat = new ChessUnitStat();
            unit.currentStat = new ChessUnitStat();

            return unit;
        }

        public ChessUnitStat GetCurrentStat()
        {
            return this.currentStat;
        }

        public ChessUnitStat GetBaseStat()
        {
            return this.baseStat;
        }
    }
}
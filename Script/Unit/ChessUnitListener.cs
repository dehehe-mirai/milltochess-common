namespace Miltochess
{
    public interface ChessUnitListener
    {
        void OnUnitRemove(ChessUnit unit);
        void OnUnitMoveStart(ChessUnit unit);
        void OnUnitMoveEnd(ChessUnit unit);
        void WillAttachModifier(ChessUnit unit, Modifier modifier);
        void DidAttachModifier(ChessUnit unit, Modifier modifier);
    }
}
namespace Miltochess
{
    public interface ChessUnitListener
    {
        void OnUnitRemove(ChessUnit unit);
        void OnUnitMoveStart(ChessUnit unit);
        void OnUnitMoveEnd(ChessUnit unit);
    }
}
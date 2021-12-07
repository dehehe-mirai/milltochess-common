using System.Collections.Generic;
using Miltochess;
using NUnit.Framework;

namespace Tests
{
    [TestFixtureSource(typeof(GameFixtures), nameof(GameFixtures.EarlyGame))]
    public class GameTests
    {
        private List<ChessPlayer> players;
        private List<ChessBoard> boards;
        private List<ChessShop> shops;

        public GameTests(List<ChessPlayer> players, List<ChessBoard> boards, List<ChessShop> shops)
        {
            this.players = players;
            this.boards = boards;
            this.shops = shops;
        }
    }
}
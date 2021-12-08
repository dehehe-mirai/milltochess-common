using System;
using System.Collections.Generic;
using Miltochess;
using Moq;
using NUnit.Framework;

namespace Tests
{
    public class ChessGameTests_Not_Started
    {
        [Test]
        public void InitChessGame_FailsIfPlayerNotSet()
        {
            var game = new ChessGame();
            Assert.Throws<ArgumentNullException>(() => {
                game.InitChessGame();
            });
        }
        
        [Test]
        public void InitChessGame_SetBoardForPlayers()
        {
            var game = new ChessGame();
            var players = DataFixtures.GetTwoPlayer();
            game.SetPlayers(players);
            game.InitChessGame();

            foreach (var player in players) {
                var board = player.GetBoard();
                Assert.NotNull(board);
                Assert.True(Matrix.Equals(Matrix.ZeroMatrix(10, 10), board.GetCurrentMatrix()));
            }
        }

    }

    public class ChessGameTests_Waiting
    {
        private ChessGame game;

        [SetUp]
        public void SetUp() {
            game = new ChessGame();
            var players = DataFixtures.GetTwoPlayer();

            game.SetPlayers(players);
            game.InitChessGame();
        }

        [Test]
        public void WaitStateStart()
        {
            var gameStateListener = new Mock<GameStateListener>();
            game.AddGameStateListener(gameStateListener.Object);

            game.SetToWaitPhase();
            gameStateListener.Verify(x=>x.OnWaitingPhase(), Times.Once);
            Assert.AreEqual(ChessGameState.WAITING, game.State);
        }
        
    }

}
using System.Collections;
using System.Collections.Generic;
using Miltochess;
using NUnit.Framework;

public class GameFixtures
{
    public static IEnumerable EarlyGame {
        get {
            // EarlyGame
            yield return new TestFixtureData(twoPlayers());
            // MidGame
            // yield return new TestFixtureData();
            // // LateGame
            // yield return new TestFixtureData();
        }

    }   
    private static List<ChessPlayer> twoPlayers() {
        return new List<ChessPlayer>();
    }
}
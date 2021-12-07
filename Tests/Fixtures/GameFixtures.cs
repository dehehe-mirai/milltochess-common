using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

public class GameFixtures
{
    public static IEnumerable EarlyGame {
        get {
            // EarlyGame
            yield return new TestFixtureData();
            // MidGame
            yield return new TestFixtureData();
            // LateGame
            yield return new TestFixtureData();
        }
    }   
}
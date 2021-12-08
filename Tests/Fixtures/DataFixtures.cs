using System.Collections.Generic;
using Miltochess;

public class DataFixtures
{
    public static List<ChessPlayer> GetTwoPlayer() {
        var players = new List<ChessPlayer>();
        var player1 = new ChessPlayer();
        var player2 = new ChessPlayer();

        players.Add(player1);
        players.Add(player2);

        return players;
    }
}
using System;
using System.Collections.Generic;
using Miltochess;

public class ChessGame
{
    public ChessGameState State = ChessGameState.NOT_STARTED;
    private List<GameStateListener> stateListeners = new List<GameStateListener>();
    private List<ChessPlayer> players;
    
    public void SetPlayers(List<ChessPlayer> players)
    {
        this.players = players ?? throw new ArgumentNullException(nameof(players));
    }

    public void InitChessGame()
    {
        if (players == null) throw new ArgumentNullException(nameof(players));
        foreach (var player in players) {
            player.SetBoard(ChessBoard.InitBoard(10, 10));
        }
    }

    public double GetPlayersCount()
    {
        return players.Count;
    }

    public void AddGameStateListener(GameStateListener gameStateListener)
    {
        stateListeners.Add(gameStateListener);
    }

    public void SetToStartPhase()
    {
        this.State = ChessGameState.INITIAL;
    }
    
    public void SetToWaitPhase()
    {
        this.State = ChessGameState.WAITING;
        stateListeners.ForEach(gameStateListener => gameStateListener.OnWaitingPhase());
    }
}
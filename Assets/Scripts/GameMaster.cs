using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster
{
    public static GameMaster Instance { get; private set; }

    public Field GameField { get; private set; }
    public CombinationAnalyzer Analyzer { get; private set; }

    public readonly TeamsManager TeamsManager;

    public GameMaster()
    {
        Instance = this;

        GameField = new Field();
        Analyzer = new CombinationAnalyzer(GameField);
        
        TeamsManager = new TeamsManager();

        InitTeamsSelectors();
    }

    public void InitTeamsSelectors()
    {
        TeamsManager.Crosses.TeamSelector.ChangeTargetField(GameField);
        TeamsManager.Zeroes.TeamSelector.ChangeTargetField(GameField);
    }

    public void TerminateCurrentTurn()
    {
        var winningTeam = Analyzer.AnalyzeWinner();
        if (winningTeam is NullTeam)
        {
            // продолжаем игру
            TeamsManager.StartNextTurn();
        }
        else
        {
            // заканчиваем игру
            Debug.Log("Game ended! The winner is Team " + winningTeam.Name);
        }
    }
}

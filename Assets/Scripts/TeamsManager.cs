using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TeamsManager
{
    public static event Action<Team> TeamTurning;

    public static TeamsManager Instance;

    public readonly TeamCross Crosses;
    public readonly TeamZero Zeroes;

    public Team CurrentTurningTeam { get; private set; }

    public TeamsManager()
    {
        Instance = this;

        Crosses = new TeamCross();
        Zeroes = new TeamZero();
    }

    public void StartFirstTurn()
    {
        CurrentTurningTeam = Crosses;
        TeamTurning?.Invoke(CurrentTurningTeam);
    }

    public void StartNextTurn()
    {
        CurrentTurningTeam = CurrentTurningTeam is TeamCross ? Zeroes : Crosses;
        TeamTurning?.Invoke(CurrentTurningTeam);
    }
}

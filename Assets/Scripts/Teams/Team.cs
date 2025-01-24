using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Team
{
    public readonly string Name;
    public readonly bool IsFirstTurn;
    public readonly Selector TeamSelector;

    private AutoTurnHandler autoTurnHandler;

    public Team(string name, bool firstTurn)
    {
        Name = name;
        IsFirstTurn = firstTurn;
        TeamSelector = new Selector(this);
    }

    public void AddAutoTurnHandler()
    {
        autoTurnHandler = new AutoTurnHandler(this);
    }

    public void RemoveAutoTurnHandler()
    {
        if (autoTurnHandler != null)
        {
            autoTurnHandler.RemoveHandler();
            autoTurnHandler = null;
        }
    }
}

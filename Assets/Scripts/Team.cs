using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Team
{
    public readonly string Name;
    public readonly bool IsFirstTurn;

    public Team(string name, bool firstTurn)
    {
        Name = name;
        IsFirstTurn = firstTurn;
    }
}

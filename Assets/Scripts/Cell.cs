using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Cell
{
    public static event Action<Cell> CellGotOccupied;

    public readonly int X;
    public readonly int Y;

    public Team OccupiedBy { get; private set; }

    public Cell(int x, int y)
    {
        X = x;
        Y = y;

        OccupiedBy = NullTeam.Instance;
    }

    public void Occupy(Team team)
    {
        if (team == NullTeam.Instance)
        {
            throw new SystemException("Trying to occupy cell by NullTeam");
        }

        OccupiedBy = team;
        CellGotOccupied?.Invoke(this);
    }
}

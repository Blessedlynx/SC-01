using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Cell : ISelectable
{
    public static event Action<Cell> CellGotOccupied;

    public readonly Point Position;

    public Team OccupiedBy { get; private set; }

    public Cell(int x, int y)
    {
        Position = new Point(x, y);

        OccupiedBy = NullTeam.Instance;
    }

    public bool TryInteract(Selector sourceSelector)
    {
        if (OccupiedBy is NullTeam && sourceSelector.IsSelectorsTeamTurn())
        {
            Occupy(sourceSelector.TargetTeam);
            return true;
        }

        return false;
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

    public Point GetPoint() => Position;
}

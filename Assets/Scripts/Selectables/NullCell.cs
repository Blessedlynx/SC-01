using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NullCell : Cell
{
    public static NullCell Instance = Instance == null ? new NullCell() : instance;

    private static NullCell instance;

    public NullCell() : base(-1, -1) { }

    public new void Occupy(Team team)
    {
        Debug.Log("Trying to occupy NullCell");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ShiftDirectionExtensions
{
    public static Point AsPoint(this ShiftDirection direction)
    {
        return direction switch
        {
            ShiftDirection.Up    => new Point(0, 1),
            ShiftDirection.Right => new Point(1, 0),
            ShiftDirection.Down  => new Point(0, -1),
            ShiftDirection.Left  => new Point(-1, 0),
            _ => throw new System.Exception("Unsupported shifting direction: " + direction)
        };
    }
}

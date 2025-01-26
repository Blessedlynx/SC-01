using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PathFinder
{
    public static List<ShiftDirection> FindPath(Cell current, Cell target)
    {
        var result = new List<ShiftDirection>();
        var delta = target.Position - current.Position;

        for (int i = 0; i < Mathf.Abs(delta.X); i++)
        {
            if (delta.X > 0)
            {
                result.Add(ShiftDirection.Right);
            }
            else
            {
                result.Add(ShiftDirection.Left);
            }
        }

        for (int i = 0; i < Mathf.Abs(delta.Y); i++)
        {
            if (delta.Y > 0)
            {
                result.Add(ShiftDirection.Up);
            }
            else
            {
                result.Add(ShiftDirection.Down);
            }
        }

        return result.Shuffle();
    }

    private static List<ShiftDirection> Shuffle(this List<ShiftDirection> source)
    {
        var result = new List<ShiftDirection>();

        var count = source.Count;
        for (int i = 0; i < count; i++)
        {
            var currentItem = source[Random.Range(0, source.Count)];
            source.Remove(currentItem);
            result.Add(currentItem);
        }

        return result;
    }
}

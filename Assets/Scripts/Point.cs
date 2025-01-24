using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Point
{
    public readonly int X;
    public readonly int Y;

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    public Point(Point other) : this(other.X, other.Y) { }

    public static Point operator+(Point a, Point b) => new Point(a.X + b.X, a.Y + b.Y);
    public static Point operator-(Point a, Point b) => new Point(a.X - b.X, a.Y - b.Y);

    public Point Shift(ShiftDirection direction) => new Point(this + direction.AsPoint());
}

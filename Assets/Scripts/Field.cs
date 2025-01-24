using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : IOrganizedSelectables
{
    public Cell this[int x, int y] => IsAppropriateCellIndex(x, y) ? cells[x, y] : NullCell.Instance;

    private static int fieldSize = 3;

    private Cell[,] cells;

    public Field()
    {
        cells = new Cell[fieldSize, fieldSize];

        for (int i = 0; i < fieldSize; i++)
        {
            for (int j = 0; j < fieldSize; j++)
            {
                cells[i, j] = new Cell(i, j);
            }
        }
    }

    public int GetFieldSize() => fieldSize;

    public ISelectable GetStandartSelectable() => cells[1, 1];

    public bool TryGetSelectable(Point position, out ISelectable potentialSelectable)
    {
        var result = IsAppropriateSelectablePosition(position);
        potentialSelectable = result ? cells[position.X, position.Y] : null;
        return result;
    }

    public bool TryGetShiftedSelectable(ISelectable currentSelectable, ShiftDirection direction, out ISelectable potentialSelectable)
    {
        var potentialPosition = currentSelectable.GetPoint() + direction.AsPoint();
        return TryGetSelectable(potentialPosition, out potentialSelectable);
    }

    public bool IsAppropriateSelectablePosition(Point position) => IsAppropriateCellIndex(position.X, position.Y);

    private bool IsAppropriateCellIndex(int x, int y)
    {
        return (x >= 0 & x < fieldSize)
            && (y >= 0 & y < fieldSize);
    }
}

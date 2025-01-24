using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupOfUI : IOrganizedSelectables
{
    public ISelectable GetStandartSelectable()
    {
        throw new System.NotImplementedException();
    }

    public bool TryGetSelectable(Point position, out ISelectable potentialSelectable)
    {
        throw new System.NotImplementedException();
    }

    public bool TryGetShiftedSelectable(ISelectable currentSelectable, ShiftDirection direction, out ISelectable potentialSelectable)
    {
        throw new System.NotImplementedException();
    }

    public bool IsAppropriateSelectablePosition(Point position)
    {
        throw new System.NotImplementedException();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IOrganizedSelectables
{
    public ISelectable GetStandartSelectable();

    public bool TryGetSelectable(Point selectablePosition, out ISelectable potentialSelectable);

    public bool TryGetShiftedSelectable(ISelectable currentSelectable, ShiftDirection direction, out ISelectable potentialSelectable);

    public bool IsAppropriateSelectablePosition(Point position);
}

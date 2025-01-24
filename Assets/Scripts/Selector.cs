using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Selector
{
    public static Action<ISelectable> UpdatedPosition;

    public readonly Team TargetTeam;

    public ISelectable CurrentSelectable { get; private set; }

    private IOrganizedSelectables targetField;

    public Selector(Team targetTeam)
    {
        TargetTeam = targetTeam;
    }

    public bool IsSelectorsTeamTurn() => TargetTeam == GameMaster.Instance.TeamsManager.CurrentTurningTeam;

    public bool TryShiftSelector(ShiftDirection direction)
    {
        ISelectable potentialSelectable;
        var isPossible = targetField.TryGetShiftedSelectable(CurrentSelectable, direction, out potentialSelectable);
        if (isPossible)
        {
            UpdateSelectableAndCall(potentialSelectable);
        }
        return isPossible;
    }

    public void ChangeTargetField(IOrganizedSelectables targetField)
    {
        this.targetField = targetField;
        UpdateSelectableAndCall(targetField.GetStandartSelectable());
    }

    private void UpdateSelectableAndCall(ISelectable selectable)
    {
        CurrentSelectable = selectable;
        UpdatedPosition?.Invoke(CurrentSelectable);
    }
}

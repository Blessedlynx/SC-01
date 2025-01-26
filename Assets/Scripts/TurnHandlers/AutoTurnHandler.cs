using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoTurnHandler
{
    public readonly Team TargetTeam;

    public AutoTurnHandler(Team targetTeam)
    {
        TargetTeam = targetTeam;

        TeamsManager.TeamTurning += HandleTurn;
    }

    public void RemoveHandler()
    {
        TeamsManager.TeamTurning -= HandleTurn;
    }

    public void HandleTurn(Team turningTeam)
    {
        if (turningTeam != TargetTeam)
        {
            return;
        }

        // Handle
        var targetCell = CombinationAnalyzer.Instance.GetRandomFreeCell();
        FollowPath(TargetTeam.TeamSelector.CurrentSelectable as Cell, targetCell); // -> need to shift selector
        if (!TargetTeam.TeamSelector.CurrentSelectable.TryInteract(TargetTeam.TeamSelector))
        {
            Debug.LogError("Something went wrong!");
        }
        GameMaster.Instance.TerminateCurrentTurn();
    }

    private void FollowPath(Cell current, Cell target)
    {
        var path = PathFinder.FindPath(current, target);
        for (int i = 0; i < path.Count; i++)
        {
            TargetTeam.TeamSelector.TryShiftSelector(path[i]);
        }
    }
}

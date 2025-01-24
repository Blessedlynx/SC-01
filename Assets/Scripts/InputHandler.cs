using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private Selector playerSelector;

    public void Update()
    {
        if (playerSelector == null)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (playerSelector.TryShiftSelector(ShiftDirection.Up))
            {
                Debug.Log("Shifted!");
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (playerSelector.TryShiftSelector(ShiftDirection.Right))
            {
                Debug.Log("Shifted!");
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (playerSelector.TryShiftSelector(ShiftDirection.Down))
            {
                Debug.Log("Shifted!");
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (playerSelector.TryShiftSelector(ShiftDirection.Left))
            {
                Debug.Log("Shifted!");
            }
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (playerSelector.CurrentSelectable.TryInteract(playerSelector))
            {
                Debug.Log("Player occupied cell");
                GameMaster.Instance.TerminateCurrentTurn();
            }
        }
    }

    public void Init(Selector playerSelector)
    {
        this.playerSelector = playerSelector;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldView : MonoBehaviour
{
    public Field TargetField { get; private set; }

    private Dictionary<Cell, GameObject> viewers;

    public void Init(Field target)
    {
        TargetField = target;

        viewers = new Dictionary<Cell, GameObject>();

        // Creating field view
        var cellViewPrefab = Resources.Load<GameObject>("FieldCell");
        for (int i = 0; i < target.GetFieldSize(); i++)
        {
            for (int j = 0; j < target.GetFieldSize(); j++)
            {
                var cellView = Instantiate(cellViewPrefab);
                cellView.transform.position += new Vector3(cellViewPrefab.transform.localScale.x * (i - 1), cellViewPrefab.transform.localScale.y * (j - 1), 0);

                viewers.Add(target[i, j], cellView);
            }
        }

        Cell.CellGotOccupied += HandleCellOccupation;
    }

    private void HandleCellOccupation(Cell occupiedCell)
    {
        var targetCellView = viewers[occupiedCell];
        Debug.Log(string.Format("Cell ({0}, {1}) got occupied by Team {2}", occupiedCell.Position.X, occupiedCell.Position.Y, occupiedCell.OccupiedBy.Name));
    }
}

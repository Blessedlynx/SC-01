using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldView : MonoBehaviour
{
    public Field TargetField { get; private set; }

    private GameObject fieldBordersView;
    private Dictionary<Cell, GameObject> viewers;

    public void Init(Field target)
    {
        TargetField = target;

        viewers = new Dictionary<Cell, GameObject>();

        // Creating field view
        CreateCellsView();
        CreateFieldBorders();

        Cell.CellGotOccupied += HandleCellOccupation;
    }

    private void CreateCellsView()
    {
        var cellViewPrefab = Resources.Load<GameObject>("FieldCell");
        for (int i = 0; i < TargetField.GetFieldSize(); i++)
        {
            for (int j = 0; j < TargetField.GetFieldSize(); j++)
            {
                var cellView = Instantiate(cellViewPrefab);
                cellView.transform.SetParent(transform);
                var cellRectTransfom = cellView.GetComponent<RectTransform>();
                cellRectTransfom.anchoredPosition = new Vector2(cellRectTransfom.sizeDelta.x * (i - 1), cellRectTransfom.sizeDelta.y * (j - 1));

                viewers.Add(TargetField[i, j], cellView);
            }
        }
    }

    private void CreateFieldBorders()
    {
        var fieldBordersPrefab = Resources.Load<GameObject>("FieldBorders");
        
        fieldBordersView = Instantiate(fieldBordersPrefab);
        fieldBordersView.transform.SetParent(transform);
        fieldBordersView.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
    }

    private void HandleCellOccupation(Cell occupiedCell)
    {
        var targetCellView = viewers[occupiedCell];
        Debug.Log(string.Format("Cell ({0}, {1}) got occupied by Team {2}", occupiedCell.Position.X, occupiedCell.Position.Y, occupiedCell.OccupiedBy.Name));

        var signatureView = TeamSignatureHandler.CreateSignature(occupiedCell.OccupiedBy is TeamCross);
        signatureView.transform.SetParent(transform);
        signatureView.GetComponent<RectTransform>().anchoredPosition = targetCellView.GetComponent<RectTransform>().anchoredPosition;
    }
}

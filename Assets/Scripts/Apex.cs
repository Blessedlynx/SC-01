using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apex : MonoBehaviour
{
    [SerializeField] private InputHandler inputHandler;
    [SerializeField] private FieldView fieldView;

    private GameMaster master;

    // Start is called before the first frame update
    void Start()
    {
        master = new GameMaster();
        master.TeamsManager.Zeroes.AddAutoTurnHandler();
        inputHandler.Init(master.TeamsManager.Crosses.TeamSelector);

        fieldView.Init(master.GameField);

        master.TeamsManager.StartFirstTurn();
    }
}

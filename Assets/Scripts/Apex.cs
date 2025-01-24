using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apex : MonoBehaviour
{
    [SerializeField] private InputHandler inputHandler;

    private GameMaster master;

    // Start is called before the first frame update
    void Start()
    {
        master = new GameMaster();
        master.TeamsManager.Zeroes.AddAutoTurnHandler();
        inputHandler.Init(master.TeamsManager.Crosses.TeamSelector);

        master.TeamsManager.StartFirstTurn();
    }
}

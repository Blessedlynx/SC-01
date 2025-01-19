using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster
{
    public static GameMaster Instance { get; private set; }

    private Field gameField;

    public GameMaster()
    {
        // ?
        Instance = this;

        gameField = new Field();
    }
}

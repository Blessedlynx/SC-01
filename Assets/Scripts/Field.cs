using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field
{
    private static int fieldSize = 3;

    private Cell[,] cells;

    public Field()
    {
        cells = new Cell[fieldSize, fieldSize];

        for (int i = 0; i < fieldSize; i++)
        {
            for (int j = 0; j < fieldSize; j++)
            {
                cells[i, j] = new Cell(i, j);
            }
        }
    }
}

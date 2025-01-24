using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinationAnalyzer
{
    public static CombinationAnalyzer Instance { get; private set; }

    private readonly Field gameField;
    private readonly int fieldSize;

    public CombinationAnalyzer(Field field)
    {
        Instance = this;

        gameField = field;
        fieldSize = gameField.GetFieldSize();
    }

    public Team AnalyzeWinner()
    {
        Team winningTeam = NullTeam.Instance;
        var straightLinesWinner = AnalyzeStraightLines();
        var diagonalLinesWinner = AnalyzeDiagonalLines();

        return ChooseFirstWinner(winningTeam, ChooseFirstWinner(straightLinesWinner, diagonalLinesWinner));
    }

    public Team AnalyzeStraightLines()
    {
        Team winningTeam = NullTeam.Instance;

        for (int i = 0; i < fieldSize; i++)
        {
            winningTeam = ChooseFirstWinner(winningTeam, AnalyzeSingleStraightLine(i, true));
            winningTeam = ChooseFirstWinner(winningTeam, AnalyzeSingleStraightLine(i, false));
        }

        return winningTeam;
    }

    public Team AnalyzeSingleStraightLine(int lineIndex, bool isHorizontal)
    {
        Team winningTeam = null;
        for (int i = 0; i < fieldSize; i++)
        {
            var cellPoint = isHorizontal ? new Point(i, lineIndex) : new Point(lineIndex, i);
            winningTeam = MultipleTeamByCell(winningTeam, gameField[cellPoint.X, cellPoint.Y]);
        }

        return winningTeam;
    }

    public Team AnalyzeDiagonalLines() => ChooseFirstWinner(CheckSingleDiagonalLine(true), CheckSingleDiagonalLine(false));

    public Team CheckSingleDiagonalLine(bool isStraightDiagonal)
    {
        Team winningTeam = null;
        for (int i = 0; i < fieldSize; i++)
        {
            var cellIndexY = isStraightDiagonal ? i : (fieldSize - i - 1);
            winningTeam = MultipleTeamByCell(winningTeam, gameField[i, cellIndexY]);
        }

        return winningTeam;
    }

    private Team ChooseFirstWinner(Team firstTeam, Team secondTeam) => firstTeam is NullTeam ? secondTeam : firstTeam;

    private Team MultipleTeamByCell(Team winningTeam, Cell nextCell) => MultipleTeams(winningTeam, nextCell.OccupiedBy);

    private Team MultipleTeams(Team winningTeam, Team multipleBy)
    {
        if (winningTeam == null)
        {
            return multipleBy;
        }

        if (winningTeam == multipleBy)
        {
            return winningTeam;
        }

        return NullTeam.Instance;
    }

    #region AdditionalMethodsForAI

    public Cell GetRandomFreeCell()
    {
        var freeCells = new List<Cell>();
        for (int i = 0; i < fieldSize; i++)
        {
            for (int j = 0; j < fieldSize; j++)
            {
                if (gameField[i, j].OccupiedBy is NullTeam)
                {
                    freeCells.Add(gameField[i, j]);
                }
            }
        }

        return freeCells[Random.Range(0, freeCells.Count)];
    }

    #endregion
}

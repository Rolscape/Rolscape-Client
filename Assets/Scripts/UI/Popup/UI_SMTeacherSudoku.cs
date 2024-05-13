using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_SMTeacherSudoku : UI_SM
{
    private int[][,] sudokuArray = new int[12][,];
    private int[,] sudoku = new int[4,4];

    public override void Init()
    {
        base.Init();
    }

    void Start()
    {
        Init();
    }

    void SetSudoku()
    {
        int idx = Random.Range(0, 12);
        sudoku = sudokuArray[idx];
    }

    void SetSudokuArray()
    {
        sudokuArray[0] = new int[,] {
            {4, 3, 2, 1},
            {3, 2, 4, 1},
            {1, 4, 2, 3},
            {2, 3, 1, 4}
        };

        sudokuArray[1] = new int[,] {
            {4, 3, 1, 2},
            {2, 1, 3, 4},
            {3, 4, 2, 1},
            {1, 2, 4, 3}
        };

        sudokuArray[2] = new int[,] {
            {2, 4, 1, 3},
            {3, 1, 4, 2},
            {4, 2, 3, 1},
            {1, 3, 2, 4}
        };

        sudokuArray[3] = new int[,] {
            {4, 1, 2, 3},
            {2, 3, 1, 4},
            {3, 2, 4, 1},
            {1, 4, 3, 2}
        };

        sudokuArray[4] = new int[,] {
            {2, 3, 4, 1},
            {1, 4, 3, 2},
            {3, 2, 1, 4},
            {4, 1, 2, 3}
        };

        sudokuArray[5] = new int[,] {
            {4, 3, 2, 1},
            {1, 2, 3, 4},
            {3, 4, 1, 2},
            {2, 1, 4, 3}
        };

        sudokuArray[6] = new int[,] {
            {2, 1, 3, 4},
            {3, 4, 1, 2},
            {4, 3, 2, 1},
            {1, 2, 4, 3}
        };

        sudokuArray[7] = new int[,] {
            {1, 3, 4, 2},
            {4, 2, 3, 1},
            {2, 4, 1, 3},
            {3, 1, 2, 4}
        };

        sudokuArray[8] = new int[,] {
            {3, 1, 2, 4},
            {2, 4, 1, 3},
            {1, 3, 4, 2},
            {4, 2, 3, 1}
        };

        sudokuArray[9] = new int[,] {
            {2, 1, 3, 4},
            {3, 4, 1, 2},
            {4, 3, 2, 1},
            {1, 2, 4, 3}
        };

        sudokuArray[10] = new int[,] {
            {4, 1, 3, 2},
            {2, 3, 4, 1},
            {3, 2, 1, 4},
            {1, 4, 2, 3}
        };

        sudokuArray[11] = new int[,]
        {
            { 3, 4, 1, 2 },
            { 2, 1, 3, 4 },
            { 4, 3, 2, 1 },
            { 1, 2, 4, 3 }
        };
    }

}

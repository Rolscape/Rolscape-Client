using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_SMTeacherSudoku : UI_SM
{
    enum Texts
    {
        Timer,
    }
    
    private int[][,] sudokuArray = new int[12][,];
    private int[,] sudoku = new int[4,4];
    private int[] sudokuSol;
    private Dictionary<int, int[]> sudokuSolArray = new Dictionary<int, int[]>();

    public override void Init()
    {
        base.Init();
    }

    void Start()
    {
        Init();
        BiundUI();
        StartCoroutine(TimerCoroutine());
    }

    void BiundUI()
    {
        countTimer = 16;
        timerText = GetText((int)Texts.Timer);
        timerText.text = countTimer.ToString("D2");
    }

    void SetSudoku()
    {
        int idx = Random.Range(0, 12);
        sudoku = sudokuArray[idx];
        sudokuSol = sudokuSolArray[idx];
    }

    void SetSudokuArray()
    {
        sudokuArray[0] = new int[,] {
            {4, 1, 3, 0},
            {0, 2, 4, 0},
            {1, 0, 0, 3},
            {0, 0, 1, 4},
        };
        sudokuSolArray.Add(0, new int[]{2, 3, 1, 4, 2, 2, 3});

        sudokuArray[1] = new int[,] {
            {4, 0, 1, 2},
            {0, 1, 0, 4},
            {3, 0, 2, 1},
            {0, 0, 0, 3},
        };
        sudokuSolArray.Add(1, new int[]{3, 2, 3, 4, 1, 2, 4});

        sudokuArray[2] = new int[,] {
            {0, 4, 1, 0},
            {3, 0, 0, 2},
            {0, 2, 0, 1},
            {0, 3, 0, 4},
        };
        sudokuSolArray.Add(2, new int[]{2, 3, 1, 4, 4, 3, 1, 2});
        
        sudokuArray[3] = new int[,] {
            {0, 0, 0, 0},
            {2, 3, 0, 4},
            {3, 2, 4, 0},
            {0, 4, 0, 2},
        };
        sudokuSolArray.Add(3, new int[]{4, 1, 2, 3, 1, 1, 1, 3});
        
        sudokuArray[4] = new int[,] {
            {0, 3, 0, 0},
            {0, 0, 3, 2},
            {3, 2, 0, 4},
            {4, 0, 2, 0},
        };
        sudokuSolArray.Add(4, new int[]{2, 4, 1, 1, 4, 1, 1, 3});
        
        sudokuArray[5] = new int[,] {
            {4, 3, 2, 0},
            {0, 0, 3, 4},
            {3, 0, 0, 0},
            {2, 0, 4, 0},
        };
        sudokuSolArray.Add(5, new int[]{1, 1, 2, 4, 1, 2, 1, 3});

        sudokuArray[6] = new int[,] {
            {2, 0, 0, 4},
            {3, 4, 0, 2},
            {0, 0, 2, 0},
            {0, 2, 0, 3},
        };
        sudokuSolArray.Add(6, new int[]{1, 3, 1, 4, 3, 1, 1, 4});

        sudokuArray[7] = new int[,] {
            {0, 3, 0, 2},
            {0, 2, 0, 1},
            {0, 0, 1, 0},
            {0, 1, 2, 4},
        };
        sudokuSolArray.Add(7, new int[]{1, 4, 4, 3, 2, 4, 3, 3});
        
        sudokuArray[8] = new int[,] {
            {3, 0, 0, 0},
            {2, 4, 0, 0},
            {1, 0, 0, 2},
            {0, 2, 3, 1},
        };
        sudokuSolArray.Add(8, new int[]{1, 2, 4, 1, 3, 3, 4, 4});

        sudokuArray[9] = new int[,] {
            {0, 0, 0, 0},
            {3, 4, 1, 0},
            {4, 0, 0, 1},
            {0, 2, 4, 3},
        };
        sudokuSolArray.Add(9, new int[]{2, 1, 3, 4, 2, 3, 2, 1});

        sudokuArray[10] = new int[,] {
            {0, 1, 0, 0},
            {0, 0, 0, 1},
            {3, 0, 1, 0},
            {1, 4, 2, 3},
        };
        sudokuSolArray.Add(10, new int[]{4, 3, 2, 2, 3, 4, 2, 4});

        sudokuArray[11] = new int[,]
        {
            { 0, 0, 1, 0 },
            { 0, 1, 3, 0 },
            { 4, 3, 0, 0 },
            { 1, 2, 0, 3 },
        };
        sudokuSolArray.Add(11, new int[]{3, 4, 2, 2, 4, 2, 1, 4});
    }

}

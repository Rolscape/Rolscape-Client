using System;
using System.Collections;
using System.Collections.Generic;
using Google.Protobuf.WellKnownTypes;
using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Enum = System.Enum;
using Image = UnityEngine.UI.Image;
using Random = UnityEngine.Random;

public class UI_SMTeacherSudoku : UI_SM
{
    enum Texts
    {
        Timer,
    }

    enum Images
    {
        Background,
    }

    enum Buttons
    {
        Submit,
    }

    enum InputFields
    {
        a,
        b,
        c,
        d,
        e,
        f,
        g,
        h,
        i,
        j,
        k,
        l,
        n,
        m,
        o,
        p,
    }
    
    private int[][,] sudokuArray = new int[12][,];
    private Dictionary<int, int[]> sudokuSolArray = new Dictionary<int, int[]>();

    private int[,] sudoku = new int[4,4];
    private int[] sudokuSol;
    
    private int[] answer;
    
    private TMP_InputField[] _inputFields = new TMP_InputField[16];

    public override void Init()
    {
        base.Init();
        BiundUI();
        SetSudoku();
        SetInputField();
        StartCoroutine(TimerCoroutine());
    }

    void Start()
    {
        Init();
    }

    void BiundUI()
    {
        Bind<Image>(typeof(Images));
        Bind<TextMeshProUGUI>(typeof(Texts));
        Bind<TMP_InputField>(typeof(InputFields));
        Bind<Button>(typeof(Buttons));
        GetButton((int)Buttons.Submit).gameObject.BindEvent(OnButtonClicked);
        countTimer = 31;
        timerText = GetText((int)Texts.Timer);
        timerText.text = countTimer.ToString("D2");
    }

    void SetInputField()
    {
        foreach (int idx in Enum.GetValues(typeof(InputFields))) 
            _inputFields[idx]=Get<TMP_InputField>(idx);

        int k = 0;
        for (int i = 0; i < sudoku.GetLength(0); i++)
        {
            for (int j = 0; j < sudoku.GetLength(1); j++)
            {
                if (sudoku[i, j] != 0)
                {
                    _inputFields[k].text = "";
                    _inputFields[k].enabled = false;
                }
                k++;
            }
        }

        k = -1;
        foreach (TMP_InputField inputField in _inputFields)
        {
            if (inputField.enabled)
            {
                int index = ++k;
                inputField.onEndEdit.AddListener(msg => UpdateInputField(msg, index));
            }
        }
    }

    void UpdateInputField(string msg, int idx)
    {
        if (string.IsNullOrEmpty(msg))
            return;
        
        answer[idx] = Convert.ToInt32(msg);
    }

    void OnButtonClicked(PointerEventData data)
    {
        for (int i = 0; i < sudokuSol.Length; i++)
        {
            if(answer[i]!=sudokuSol[i])
                MissionFailed();
        }
        MissionSuccess();
    }

    void SetSudoku()
    {
        SetSudokuArray();
        int idx = Random.Range(0, 12);
        SetBackground(idx);
        sudoku = sudokuArray[idx];
        sudokuSol = new int[sudokuSolArray[idx].Length];
        sudokuSol = sudokuSolArray[idx];
        answer = new int[sudokuSol.Length];
    }

    void SetBackground(int idx)
    {
        Texture2D texture2D = Managers.Resource.Load<Texture2D>($"Arts/Mission/Sudoku/P{idx}");
        Sprite sprite = Sprite.Create(texture2D, new Rect(0, 0, texture2D.width, texture2D.height), Vector2.one * 0.5f);
        GetImage((int)Images.Background).sprite = sprite;
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

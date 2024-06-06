using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class UI_TM2 : UI_TM
{
    public Action<int> putPuzzleAction = null;
    enum Images
    {
        Puzzle0,
        Puzzle1,
        Puzzle2,
        Puzzle3,
        Puzzle4,
        Puzzle5,
        Puzzle6,
        Puzzle7,
        Puzzle8,
        Puzzle9,
        Puzzle10,
        Puzzle11,
        Puzzle12,
        Puzzle13,
        Puzzle14,
        Puzzle15,
        PuzzleResult,
    }

    enum Texts
    {
        Timer,
    }
    
    public override void Init()
    {
        base.Init();
        BIndUI();
        LoadPuzzle();
        StartCoroutine(TimerCoroutine());
    }

    private void Start()
    {
        Init();
    }

    private Image[] puzzles = new Image[16];

    void BIndUI()
    {
        Bind<Image>(typeof(Images));
        Bind<TextMeshProUGUI>(typeof(Texts));
        timerText = GetText((int)Texts.Timer);
        timerText.text = countTimer.ToString("D2");
    }

    void LoadPuzzle()
    {
        int idx = Random.Range(0, 2);
        Sprite[] sprites = Resources.LoadAll<Sprite>($"Arts/Mission/Puzzle/puzzle{idx}");
        Sprite puzzle = Managers.Resource.Load<Sprite>($"Arts/Mission/Puzzle/puzzleResult{idx}");

        foreach (int index in Enum.GetValues(typeof(Images)))
        {
            if(index == (int)Images.PuzzleResult)
                continue;
            puzzles[idx] = Get<Image>(index);
            puzzles[idx].sprite = sprites[index];
        }
        GetImage((int)Images.PuzzleResult).sprite = puzzle;

    }

    public void putPuzzle(int idx)
    {

        
    }

    public void Clear()
    {
        putPuzzleAction = null;
    }

    
}

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class UI_TM2 : UI_Popup
{
    public Action<int> putPuzzleAction = null;
    enum Images
    {
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
    }

    private void Start()
    {
        Init();
    }

    private Image[] puzzle = new Image[16];

    void BIndUI()
    {
        Bind<Image>(typeof(Images));
        Bind<TextMeshProUGUI>(typeof(Texts));
    }

    void LoadPuzzle()
    {
        int idx = Random.Range(0, 2);
        Sprite[] sprites = Resources.LoadAll<Sprite>($"Arts/Mission/Puzzle/puzzle{idx}");
        
    }

    public void putPuzzle(int idx)
    {

        
    }

    public void OnDragEnded(PointerEventData data)
    {
        // TODO Image 판단
        
        int idx = 0;
        
        
        // TODO Send ID to Sever   
    }

    public void Clear()
    {
        putPuzzleAction = null;
    }

    
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_TM2 : UI_Popup
{
    public Action<int> putPuzzleAction = null;
    enum Images
    {
        Background,
        Puzzle,
    }
    
    public override void Init()
    {
        base.Init();
    }

    private void Start()
    {
        Init();
    }

    void BIndUI()
    {
        Bind<Image>(typeof(Images));
        
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

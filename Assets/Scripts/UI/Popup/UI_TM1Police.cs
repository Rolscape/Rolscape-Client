using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Diagnostics;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class UI_TM1Police : UI_TM1
{
    protected enum Images
    {
        Dest1,
        Dest2,
        Player1,
        Player2,
    }
    public int _tCurPos;
    public int _sCurPos;

    public int _teacherDestPos;
    public int _studentDestPos;
    
    public override void Init()
    {
        base.Init();
        
        _tCurPos = 0;
        _sCurPos = 0;
    }

    private void Start()
    {
        Init();
    }

    protected override void SetUI()
    {
        base.SetUI();
        GetImage((int)Images.Dest1).sprite = Managers.Resource.Load<Sprite>("TMMove/bluesqure");
        GetImage((int)Images.Dest2).sprite = Managers.Resource.Load<Sprite>("TMMove/pinksqure");
        GetImage((int)Images.Player1).sprite = Managers.Resource.Load<Sprite>("TMMove/blueeraser");
        GetImage((int)Images.Player2).sprite = Managers.Resource.Load<Sprite>("TMMove/pinkeraser");
    }

    public void SetDestPos(int idx)
    {
        
    }
   
}

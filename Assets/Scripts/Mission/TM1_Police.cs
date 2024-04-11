using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TM1_Police : TM1
{
    private UI_TM1Police _ui;

    protected override void Init()
    {
        base.Init();
        
       
    }

    void Start()
    {
        Init();
    }

    protected override void Mission1Start()
    {
        base.Mission1Start();
        _ui = Managers.UI.ShowPopupUI<UI_TM1Police>();
    }

    protected override void OnKeyboard()
    {
    
    }
    
    public void CheckMoveNextGrid(int nextPos)
    {
        // TODO Add job type

        
    }
}

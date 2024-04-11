using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TM1_Student : TM1
{
    private UI_TM1Student _ui;

    protected override void Init()
    {
        base.Init();
        
    }
    void Start()
    {
        Init();
        Mission1Start();
    }

    protected override void Mission1Start()
    {
        base.Mission1Start();

        _ui = Managers.UI.ShowPopupUI<UI_TM1Student>("UI_TM1");
    }

    protected override void OnKeyboard()
    {
        base.OnKeyboard();

        CheckMoveNextGrid(_dir);
    }

    public bool CheckMoveNextGrid(Vector3 dir)
    {
        
        
        return false;
    }
    
}

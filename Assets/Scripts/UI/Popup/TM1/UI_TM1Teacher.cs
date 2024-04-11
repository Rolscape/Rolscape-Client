using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_TM1Teacher : UI_TM1
{
    public override void Init()
    {
        base.Init();
    }
    
    protected override void SetUI()
    {
        base.SetUI();
        GetImage((int)Images.Dest).sprite = Managers.Resource.Load<Sprite>("TMMove/pinksqure");
        GetImage((int)Images.Player).sprite = Managers.Resource.Load<Sprite>("TMMove/pinkeraser");
    }

    public override void SetDefaultPos(int startPos)
    {
        base.SetDefaultPos(startPos);
        _curPos = startPos;
    }

    protected override void MoveTile(int nextPos)
    {
        
        _curPos = nextPos;
    }
}

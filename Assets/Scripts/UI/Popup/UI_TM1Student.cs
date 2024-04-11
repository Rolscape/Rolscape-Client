using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_TM1Student : UI_TM1
{
    
    public override void Init()
    {
        base.Init();

    }

    protected override void SetUI()
    {
        base.SetUI();
        GetImage((int)Images.Dest).sprite = Managers.Resource.Load<Sprite>("TMMove/bluesqure");
        GetImage((int)Images.Player).sprite = Managers.Resource.Load<Sprite>("TMMove/blueeraser");
    }
    
    protected override void MoveTile(int nextPos)
    {
        
        _curPos = nextPos;
    }

}

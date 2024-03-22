using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Police : Player
{
    protected override void Init()
    {
        base.Init();
        _isLeader = true;
        Job = Protocol.PlayerJob.Police;
    }

    public override void Mission1Start()
    {
        base.Mission1Start();

        Managers.UI.ShowPopupUI<UI_TM1Police>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}

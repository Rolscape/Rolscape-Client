using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Police : Player
{
    private TM1_Police _tm1Police;
    protected override void Init()
    {
        base.Init();
        _isLeader = true;
        Job = Protocol.PlayerJob.Police;

        _tm1Police = gameObject.GetOrAddComponent<TM1_Police>();
    }
    void Start()
    {
        Init();
    }
}

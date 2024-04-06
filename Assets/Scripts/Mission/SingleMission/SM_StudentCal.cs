using Protocol;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SM_StudentCal : SM_Single
{
    private void Start()
    {
        Init();
    }

    public override void MissionStart()
    {
        Managers.UI.ShowPopupUI<UI_SMStudentCal>();
    }

    public override void MissionStop(bool isSuccess)
    {
        Managers.Mission.bStudentCal = isSuccess;
    }
}

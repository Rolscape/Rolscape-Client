using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SM_PoliceCatchTrigger : SM_DefaultTrigger
{
    protected override void Init()
    {
        missionType = Protocol.SingleMissionType.PoliceCatch;
    }

    public override void OnShowUI()
    {
        //Util.GetOrAddComponent<SM_StudentCal>(gameObject);

        Managers.UI.ShowPopupUI<UI_SMStart>();
    }

    protected override bool TriggerEnterEvent(Collider other)
    {
        Police police = other.GetComponent<Police>();
        if (police == null)
            return false;

        return true;
    }

    protected override bool TriggerExitEvent(Collider other)
    {
        return Managers.Mission.bPoliceCatch;
    }


    protected override void MissionStart()
    {
        base.MissionStart();

        Managers.UI.ShowPopupUI<UI_SMPoliceCatch>();
    }

    protected override void MissionStop(bool isSuccess)
    {
        base.MissionStop(isSuccess);

        Managers.Mission.bPoliceCatch = isSuccess;
    }
}
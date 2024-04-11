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

    protected override void TriggerExitEvent(Collider other)
    {
        base.TriggerExitEvent(other);
    }


    protected override void MissionStart()
    {
        Managers.UI.ShowPopupUI<UI_SMPoliceCatch>();
    }

    protected override void MissionStop(bool isSuccess)
    {
        Managers.Mission.bPoliceCatch = isSuccess;
    }
}
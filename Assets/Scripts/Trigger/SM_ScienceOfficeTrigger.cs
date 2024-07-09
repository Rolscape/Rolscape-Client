using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SM_ScienceOfficeTrigger : SM_DefaultTrigger
{
    protected override void Init()
    {
        missionType = Define.SingleMissionType.ScienceOffice;
    }

    public override void OnShowUI()
    {
        Managers.UI.ShowPopupUI<UI_SMStart>();
    }

    protected override bool TriggerEnterEvent(Collider other)
    {
        return true;
    }

    protected override void TriggerExitEvent(Collider other)
    {
        base.TriggerExitEvent(other);
    }


    protected override void MissionStart()
    {
        Managers.UI.ShowPopupUI<UI_SMScience>();
    }

    protected override void MissionStop(bool isSuccess)
    {
        Managers.Mission.bStudentCal = isSuccess;
    }
}

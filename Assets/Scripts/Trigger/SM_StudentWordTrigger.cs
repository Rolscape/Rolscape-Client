using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SM_StudentWordTrigger : SM_DefaultTrigger
{
    protected override void Init()
    {
        missionType = Protocol.SingleMissionType.StudentAlpha;
    }

    public override void OnShowUI()
    {
        //Util.GetOrAddComponent<SM_StudentCal>(gameObject);

        Managers.UI.ShowPopupUI<UI_SMStart>();
    }

    protected override bool TriggerEnterEvent(Collider other)
    {
        Student student = other.GetComponent<Student>();
        if (student == null)
            return false;

        return true;
    }

    protected override void TriggerExitEvent(Collider other)
    {
        base.TriggerExitEvent(other);
    }


    protected override void MissionStart()
    {
        base.MissionStart();
        Managers.UI.ShowPopupUI<UI_SMStudentWord>();
    }

    protected override void MissionStop(bool isSuccess)
    {
        Managers.Mission.bStudentWord = isSuccess;
    }
}

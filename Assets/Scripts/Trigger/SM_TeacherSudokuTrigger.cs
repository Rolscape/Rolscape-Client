using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SM_TeacherSudokuTrigger : SM_DefaultTrigger
{
    protected override void Init()
    {
        missionType = Protocol.SingleMissionType.TeacherSudoku;
    }

    protected override bool TriggerEnterEvent(Collider other)
    {
        Teacher teacher = other.GetComponent<Teacher>();
        if (teacher == null)
            return false;

        return true;
    }

    protected override bool TriggerExitEvent(Collider other)
    {
        return Managers.Mission.bTeacherSudoku;
    }

    public override void OnShowUI()
    {
        //Util.GetOrAddComponent<SM_StudentCal>(gameObject);

        Managers.UI.ShowPopupUI<UI_SMStart>();
    }

    protected override void MissionStart()
    {
        base.MissionStart();

        Managers.UI.ShowPopupUI<UI_SMTeacherSudoku>();
    }

    protected override void MissionStop(bool isSuccess)
    {
        base.MissionStop(isSuccess);

        Managers.Mission.bStudentCal = isSuccess;
    }
}

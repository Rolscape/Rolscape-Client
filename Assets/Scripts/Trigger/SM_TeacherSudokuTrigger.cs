using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SM_TeacherSudokuTrigger : SM_DefaultTrigger
{
    protected override void Init()
    {
        missionType = Define.SingleMissionType.TeacherSudoku;
    }

    public override void OnShowUI()
    {
        //Util.GetOrAddComponent<SM_StudentCal>(gameObject);

        Managers.UI.ShowPopupUI<UI_SMStart>();
    }

    protected override bool TriggerEnterEvent(Collider other)
    {
        Teacher teacher = other.GetComponent<Teacher>();
        if (teacher == null)
            return false;

        return true;
    }

    protected override void TriggerExitEvent(Collider other)
    {
        base.TriggerExitEvent(other);
    }


    protected override void MissionStart()
    {
        Managers.UI.ShowPopupUI<UI_SMTeacherSudoku>();
    }

    protected override void MissionStop(bool isSuccess)
    {
        Managers.Mission.bStudentCal = isSuccess;
    }
}

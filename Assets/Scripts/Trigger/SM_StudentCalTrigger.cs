using Protocol;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Diagnostics;

public class SM_StudentCalTrigger : SM_DefaultTrigger
{
    protected override void Init()
    {
        missionType = SingleMissionType.StudentMath;
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
        Managers.UI.ShowPopupUI<UI_SMStudentCal>();
    }

    protected override void MissionStop(bool isSuccess)
    {
        Managers.Mission.bStudentCal = isSuccess;
    }
}
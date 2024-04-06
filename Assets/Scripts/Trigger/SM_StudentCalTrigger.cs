using Protocol;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class SM_StudentCalTrigger : SM_DefaultTrigger
{
    public override void Init()
    {
        missionType = SingleMissionType.StudentMath;
    }

    protected override bool TriggerEnterEvent(Collider other)
    {
        base.TriggerEnterEvent(other);

        // TODO 미션 했는지 안했는지 여부 및 직업 체크 
        Student student = other.GetComponent<Student>();
        if (student == null)
            return false;

        return true;
    }

    protected override void TriggerExitEvent(Collider other)
    {
        base.TriggerExitEvent(other);
    }

    public override void OnShowUI()
    {
        // TODO 암산 미션 시작하기 창 띄우기
        Managers.UI.ShowPopupUI<UI_SMStart>();

    }

    public void Clear()
    {
        
    }
}

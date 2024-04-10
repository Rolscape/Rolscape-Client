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

    private void OnTriggerExit(Collider other)
    {
        Managers.UI.ClosePopupUI();
    }

    public void Clear()
    {
        
    }
}

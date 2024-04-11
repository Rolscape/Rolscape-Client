using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SM_TeacherEraseTrigger : SM_DefaultTrigger
{
    protected override void Init()
    {
        missionType = Protocol.SingleMissionType.TeacherErase;
    }

    protected override bool TriggerEnterEvent(Collider other)
    {
        Teacher student = other.GetComponent<Teacher>();
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
        //Util.GetOrAddComponent<SM_TeacherErase>(gameObject);

        // TODO 암산 미션 시작하기 창 띄우기
        Managers.UI.ShowPopupUI<UI_SMStart>();
    }

    protected override void MissionStart()
    {
        Texture2D texture2D = Managers.Resource.Load<Texture2D>("Arts/Mission/BlackboardErase/Eraser");
        Cursor.SetCursor(texture2D, Vector2.zero, CursorMode.Auto);

        Managers.UI.ShowPopupUI<UI_SMTeacherErase>();
    }

    protected override void MissionStop(bool isSuccess)
    {
        Managers.Mission.bTeacherErase = isSuccess;
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SM_TeacherErase : SM_Single
{
    public override void MissionStart()
    {
        // Set Cursor Eraser
        Texture2D texture2D = Managers.Resource.Load<Texture2D>("Arts/Mission/BlackboardErase/Eraser");
        Cursor.SetCursor(texture2D, Vector2.zero, CursorMode.Auto);
        
        Managers.UI.ShowPopupUI<UI_SMTeacherErase>();
    }

    public override void MissionStop(bool isSuccess)
    {
        Managers.Mission.bTeacherErase = isSuccess;
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}

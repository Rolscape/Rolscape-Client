using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SM_TeacherErase : MonoBehaviour
{
    public void Init()
    {
        Managers.Mission.SMStart -= MissionStart;
        Managers.Mission.SMStart += MissionStart;
    }

    private void Start()
    {
        Init();
    }

    public void MissionStart()
    {
        // Set Cursor Eraser
        Texture2D texture2D = Managers.Resource.Load<Texture2D>("Arts/Mission/BlackboardErase/Eraser");
        Cursor.SetCursor(texture2D, Vector2.zero, CursorMode.Auto);
        
        Managers.UI.ShowPopupUI<UI_SMTeacherErase>();
    }

    // Mission Finished
    public void Clear()
    {
        Managers.Mission.SMStart -= MissionStart;
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}

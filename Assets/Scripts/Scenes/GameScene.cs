using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{
    protected override void Init()
    {
        base.Init();

        SceneType = Define.Scene.Game;
        Managers.UI.ShowSceneUI<UI_Button>();
        Managers.UI.ShowPopupUI<UI_Start>();
        
        // Temp Code
        GameObject go = Managers.Resource.Instantiate("Player");
        go.name = "Player";
        
        GameObject student = Managers.Resource.Instantiate("StudentRoot");
        student.transform.SetParent(go.transform);

        go.GetOrAddComponent<Student>();

        // TEMP Code
        // Managers.Resource.Instantiate("Player");
        //Managers.UI.ShowPopupUI<UI_TM1Police>();
    }
    
    public override void Clear()
    {
        
    }
}

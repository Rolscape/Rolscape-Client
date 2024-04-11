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
        Managers.Sound.Play("MainBgm", Define.Sound.Bgm);
        
        // Temp Code
        GameObject go = Managers.Resource.Instantiate("Player");
        go.name = "Player";
        
        GameObject student = Managers.Resource.Instantiate("TeacherRoot");
        student.transform.SetParent(go.transform);
        
        go.GetOrAddComponent<Teacher>();
    }
    
    public override void Clear()
    {
        
    }
}

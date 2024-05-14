using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{
    protected override void Init()
    {
        base.Init();

        SceneType = Define.Scene.Game;
        Managers.UI.ShowSceneUI<UI_Main>();
        Managers.Sound.Play("MainBgm", Define.Sound.Bgm);
        
        // Temp Code
        GameObject go = Managers.Resource.Instantiate("Player");
        go.name = "Player";
        
        // GameObject player = Managers.Resource.Instantiate("StudentRoot");
        // go.GetOrAddComponent<Student>();
        GameObject player = Managers.Resource.Instantiate("PoliceRoot");
        go.GetOrAddComponent<Police>();
        // GameObject player = Managers.Resource.Instantiate("TeacherRoot");
        // go.GetOrAddComponent<Student>();
        
        player.transform.SetParent(go.transform);
        
        
        
    }
    
    public override void Clear()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScene : BaseScene
{
    protected override void Init()
    {
        base.Init();

        SceneType = Define.Scene.Game;
        Managers.UI.ShowSceneUI<UI_Button>();
        //Managers.UI.ShowPopupUI<UI_Start>();
        
        // Temp Code
        //GameObject go = Managers.Resource.Instantiate("Player");
        //go.name = "Player";
        
        //GameObject student = Managers.Resource.Instantiate("TeacherRoot");
        //student.transform.SetParent(go.transform);
        
        //go.GetOrAddComponent<Teacher>();
    }

    public void Start()
    {
        Managers.UI.ShowSceneUI<UI_Button>();

        Managers.Player.MovePlayerToScene(gameObject.scene);

        Managers.Scene.UnloadScene(Define.Scene.Login);

        Init();
    }

    public override void Clear()
    {
        
    }
}

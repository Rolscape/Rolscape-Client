using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScene : BaseScene
{
    [SerializeField]
    private Camera MainCamera;
    
    protected override void Init()
    {
        base.Init();

        SceneType = Define.Scene.Game;
        Managers.UI.ShowSceneUI<UI_Button>();
        Managers.Sound.Play("MainBgm", Define.Sound.Bgm);

        // Temp Code
        //GameObject go = Managers.Resource.Instantiate("Player");
        //go.name = "Player";

        //GameObject student = Managers.Resource.Instantiate("TeacherRoot");
        //student.transform.SetParent(go.transform);

        //go.GetOrAddComponent<Teacher>();
        Managers.Player.SettingMainCameraToPlayer(MainCamera);
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

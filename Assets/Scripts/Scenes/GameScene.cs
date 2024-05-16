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
        Managers.UI.ShowSceneUI<UI_Main>();
        Managers.Sound.Play("MainBgm", Define.Sound.Bgm);

        Managers.Player.SettingMainCameraToPlayer(MainCamera);
    }

    public void Start()
    {
        Managers.Player.MovePlayerToScene(gameObject.scene);

        Managers.Scene.UnloadScene(Define.Scene.Login);

        Init();
    }

    public override void Clear()
    {
        
    }
}

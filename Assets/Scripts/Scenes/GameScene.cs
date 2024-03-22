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

        //Managers.Resource.Instantiate("Player");

        // TEMP Code
        Managers.UI.ShowSceneUI<UI_Button>();
        //Managers.UI.ShowPopupUI<UI_TM1Police>();
    }

    public void Start()
    {
        Managers.Player.MovePlayerToScene(gameObject.scene);

        Managers.Scene.UnloadScene(Define.Scene.Login);
    }

    public override void Clear()
    {
        
    }
}

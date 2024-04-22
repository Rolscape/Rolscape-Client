using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginScene : BaseScene
{
    protected override void Init()
    {
        base.Init();

        SceneType = Define.Scene.Login;
        Managers.UI.ShowSceneUI<UI_Login>();
        Managers.Sound.Play("LoadingBgm", Define.Sound.Bgm);
    }

    private void Update()
    {
            
    }

    public override void Clear()
    {
        Debug.Log("Login Scene Clear");
    }
}

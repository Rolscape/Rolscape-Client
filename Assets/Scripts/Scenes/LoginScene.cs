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
        Managers.UI.ShowPopupUI<UI_Login>();
    }

    private void Update()
    {
            
    }

    public override void Clear()
    {
        Debug.Log("Login Scene Clear");
    }
}

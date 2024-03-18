using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{
    protected override void Init()
    {
        base.Init();

        SceneType = Define.Scene.Game;

        Managers.Resource.Instantiate("Player");
        // Managers.UI.ShowPopupUI<UI_Button>();
        Managers.UI.ShowPopupUI<UI_TM1Police>();
    }
    
    public override void Clear()
    {
        
    }
}

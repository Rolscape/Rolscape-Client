using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Popup : UI_Base
{
    protected TMP_FontAsset font;

    public override void Init()
    {
        Managers.UI.SetCanvas(gameObject, true);
        font = Managers.Resource.Load<TMP_FontAsset>("Arts/Fonts/MainFont");
    }

    public virtual void ClosePopupUI()
    {
        Managers.UI.ClosePopupUI(this);
    }

}

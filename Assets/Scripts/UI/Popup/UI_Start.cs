using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Start : UI_Popup
{
    enum Buttons
    {
        PointButton
    }
    
    enum Texts
    {
        PointText
    }
    public override void Init()
    {
        base.Init();
        
        Bind<Button>(typeof(Buttons));
        Bind<TextMeshProUGUI>(typeof(Texts));

        GetText((int)Texts.PointText).text = "Start Game";
        
        GetButton((int)Buttons.PointButton).gameObject.BindEvent(OnButtonClicked);
    }

    void Start()
    {
        Init();
    }

    public void OnButtonClicked(PointerEventData data)
    {
        
    }
}

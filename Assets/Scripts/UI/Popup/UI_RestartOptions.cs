using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_RestartOptions : UI_Popup
{
    enum Buttons
    {
        Button
    }
    public override void Init()
    {
        base.Init();
        BindUI();
    }

    void Start()
    {
        Init();
        
    }

    void BindUI()
    {
        Bind<Button>(typeof(Buttons));
        GameObject go = GetButton((int)Buttons.Button).gameObject;
        BindEvent(go, OnButtonCliced, Define.UIEvent.Click); 
    }

    void OnButtonCliced(PointerEventData data)
    {
        Managers.Scene.LoadScene(Define.Scene.Login);
    }

    
}

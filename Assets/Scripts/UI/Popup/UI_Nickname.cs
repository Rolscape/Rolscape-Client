using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Nickname : UI_Popup
{
    enum Buttons
    {
        NicknameButton,
    }

    enum Texts
    {
        PointText,
        InputText,
        SettingText,
        InputPointText,
    }

    enum InputFields
    {
        InputField,
    }

    private void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();
        
        Bind<Button>(typeof(Buttons));
        Bind<TextMeshProUGUI>(typeof(Texts));
        Bind<GameObject>(typeof(InputFields));

        GetText((int)Texts.PointText).text = "Setting User Nickname";
        GetText((int)Texts.SettingText).text = "Setting";
        GetText((int)Texts.InputPointText).text = "Input User Nickname";
        GetText((int)Texts.InputText).text = "";

        GameObject go = GetButton((int)Buttons.NicknameButton).gameObject;
        BindEvent(go, OnButtonClicked, Define.UIEvent.Click);
    }

    public void OnButtonClicked(PointerEventData data)
    {
        // TODO Null Check And Setting nickname
        String text = GetText((int)Texts.InputText).text;
        
        if(text.Length > 1)
            Managers.Scene.LoadScene(Define.Scene.Game);

        // if (string.IsNullOrEmpty(text) == false)
        // {
        //     Debug.Log($"nickname: {text}, Length: {text.Length}");
        // }
    }
}

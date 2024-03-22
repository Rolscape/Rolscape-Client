using Protocol;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class UI_Login : UI_Popup
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
        Bind<TMP_InputField>(typeof(InputFields));

        GetText((int)Texts.PointText).text = "Setting User Nickname";
        GetText((int)Texts.SettingText).text = "Setting";
        GetText((int)Texts.InputPointText).text = "Input User Nickname";

        TMP_InputField inputField = Get<TMP_InputField>((int)InputFields.InputField);
        inputField.characterLimit = 9;
        
        GameObject go = GetButton((int)Buttons.NicknameButton).gameObject;
        BindEvent(go, OnButtonClicked, Define.UIEvent.Click);
    }

    public void OnButtonClicked(PointerEventData data)
    {
        String text = GetText((int)Texts.InputText).text;
        
        if (text.Length > 1)
        {
            C_ENTER_GAME enterGame = new C_ENTER_GAME();
            enterGame.Name = text;
            enterGame.RoomId = "AAAA";
            Managers.Network.Send(enterGame, INGAME.EnterGame);
        }
    }
}

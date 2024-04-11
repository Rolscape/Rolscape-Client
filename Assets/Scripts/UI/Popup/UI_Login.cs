using Protocol;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

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
        
        Bind();
        SetUpInputField();
        
        GameObject go = GetButton((int)Buttons.NicknameButton).gameObject;
        BindEvent(go, OnButtonClicked, Define.UIEvent.Click);
    }
    
    void Bind()
    {
        Bind<Button>(typeof(Buttons));
        Bind<TextMeshProUGUI>(typeof(Texts));
        Bind<TMP_InputField>(typeof(InputFields));
    }

    void SetUpInputField()
    {
        GetText((int)Texts.PointText).text = "Setting User Nickname";
        GetText((int)Texts.SettingText).text = "Join Game";
        GetText((int)Texts.InputPointText).text = "Input User Nickname";

        TMP_InputField inputField = Get<TMP_InputField>((int)InputFields.InputField);
        inputField.characterLimit = 9;
        inputField.onEndEdit.AddListener(OnEndEdit);
    }
    
    public void OnButtonClicked(PointerEventData data)
    {
        // String text = GetText((int)Texts.InputText).text;
        //
        // if (text.Length > 1)
        // {
        //     Managers.Scene.LoadScene(Define.Scene.Game);
        //     UI_Nickname.NickName = text;
        // }
    }

    void OnEndEdit(string text)
    {
        // TODO End setting nickname 
        if (text.Length > 1)
        {
            gameObject.SetActive(false);
            UI_Nickname.NickName = text;

            C_ENTER_GAME enterGame = new C_ENTER_GAME();
            enterGame.Name = text;
            enterGame.RoomId = "AAAA";
            Managers.Network.Send(enterGame, INGAME.EnterGame);
            Managers.UI.ShowPopupUI<UI_Start>();
        }
    }

    public void SuccessLoginGame()
    {
        Managers.UI.ShowPopupUI<UI_Start>();
    }

    public void FailedLoginGame()
    {
        gameObject.SetActive(true);
    }
}

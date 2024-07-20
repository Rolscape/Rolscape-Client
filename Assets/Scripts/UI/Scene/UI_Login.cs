using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class UI_Login : UI_Scene
{
    enum Buttons
    {
        NicknameButton,
        StudentButton,
        TeacherButton,
        PoliceButton
    }

    enum Texts
    {
        PointText,
        InputText,
        SettingText,
        InputPointText
    }

    enum InputFields
    {
        InputField
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
        
        GameObject studentButton = GetButton((int)Buttons.StudentButton).gameObject;
        GameObject teacherButton = GetButton((int)Buttons.TeacherButton).gameObject;
        GameObject policeButton = GetButton((int)Buttons.PoliceButton).gameObject;
        BindEvent(studentButton, OnStudentButtonClicked, Define.UIEvent.Click);
        BindEvent(teacherButton, OnTeacherButtonClicked, Define.UIEvent.Click);
        BindEvent(policeButton, OnPoliceButtonClicked, Define.UIEvent.Click);
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
        //GetText((int)Texts.SettingText).text = "Setting";
        GetText((int)Texts.InputPointText).text = "Input User Nickname";

        TMP_InputField inputField = Get<TMP_InputField>((int)InputFields.InputField);
        inputField.characterLimit = 9;
        inputField.onEndEdit.AddListener(OnEndEdit);
    }

    public void OnStudentButtonClicked(PointerEventData data)
    {
        GameScene.job = GameScene.Jobs.Student;
        Managers.Scene.LoadScene(Define.Scene.Game);
    }

    public void OnTeacherButtonClicked(PointerEventData data)
    {
        GameScene.job = GameScene.Jobs.Teacher;
        Managers.Scene.LoadScene(Define.Scene.Game);
    }

    public void OnPoliceButtonClicked(PointerEventData data)
    {
        GameScene.job = GameScene.Jobs.Police;
        Managers.Scene.LoadScene(Define.Scene.Game);
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
            //Managers.Scene.LoadScene(Define.Scene.Game);
            UI_Nickname.NickName = text;
        }
    }
    
}

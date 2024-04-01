using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UI_Question : UI_Popup
{
    enum Panel
    {
        Panel,
    }

    enum Images
    {
        Question,
    }

    enum InputFields
    {
        InputField,
    }

    enum Texts
    {
        PointText,
        Answer,
    }
    
    
    public override void Init()
    {
        base.Init();
        
        BindUI();
        SetInputField();
        SetImage();
    }

    void Start()
    {
        Init();
    }

    void BindUI()
    {
        Bind<Image>(typeof(Images));
        Bind<TextMeshProUGUI>(typeof(Texts));
        Bind<TMP_InputField>(typeof(InputFields));
    }

    void SetInputField()
    {
        GetText((int)Texts.PointText).text = "A";
        TMP_InputField inputField = Get<TMP_InputField>((int)InputFields.InputField);
        inputField.transform.localPosition = new Vector3(490.0f, 30.0f, 0.0f);
        inputField.pointSize = 100;
        inputField.characterLimit = 3;
        inputField.contentType = TMP_InputField.ContentType.DecimalNumber;
        
        inputField.onEndEdit.AddListener(OnEndEdit);
    }

    void SetImage(string path = null)
    {
        Image image = GetImage((int)Images.Question);
        image.rectTransform.sizeDelta = new Vector2(1500.0f, 800.0f);
        if (string.IsNullOrEmpty(path))
            path = "Question1";
        Texture2D texture2D = Managers.Resource.Load<Texture2D>($"Arts/Question/{path}");
        Sprite sprite = Sprite.Create(texture2D, new Rect(0, 0, texture2D.width, texture2D.height), Vector2.one * 0.5f);
        image.sprite = sprite;
    }

    void OnEndEdit(string text)
    {
        // TODO Answer Check
        Debug.Log($"사용자가 입력한 정담은: {text}");
    }
    
}

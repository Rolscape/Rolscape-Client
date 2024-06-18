using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_SMMusicOffice : UI_SM
{
    private Dictionary<int, string> answer = new Dictionary<int, string>();
    enum Texts
    {
        Timer
    }

    enum Images
    {
        BackGround,
        Quiz
    }

    enum InputFields
    {
        Answer
    }

    void BindUI()
    {
        Bind<TextMeshProUGUI>(typeof(Texts));
        Bind<Image>(typeof(Images));
        Bind<TMP_InputField>(typeof(InputFields));
        
        TMP_InputField inputField = Get<TMP_InputField>((int)InputFields.Answer);
        inputField.onEndEdit.AddListener(OnEndEdit);
    }
    
    public override void Init()
    {
        base.Init();
    }

    void Start()
    {
        Init();
    }

    void CheckAnswer()
    {
        
    }

    void OnEndEdit(string text)
    {
        
    }
    
}
